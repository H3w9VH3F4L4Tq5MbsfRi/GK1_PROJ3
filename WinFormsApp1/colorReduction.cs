using FastBitmapLib;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WinFormsApp1
{
    public partial class form : Form
    {
        private Bitmap original;
        private Bitmap uncertainty;
        private Bitmap popularity;
        private Bitmap kmeans;
        private int maxAmmountOfColors = 3;
        private string path = string.Empty;
        public form()
        {
            InitializeComponent();
            original = new Bitmap(originalPbox.Width, originalPbox.Height);
            originalPbox.Image = original;
            using (Graphics g = Graphics.FromImage(original))
                g.Clear(Color.HotPink);
            uncertainty = new Bitmap(uncertaintyPbox.Width, uncertaintyPbox.Height);
            uncertaintyPbox.Image = uncertainty;
            using (Graphics g = Graphics.FromImage(uncertainty))
                g.Clear(Color.Pink);
            popularity = new Bitmap(popularityPbox.Width, popularityPbox.Height);
            popularityPbox.Image = popularity;
            using (Graphics g = Graphics.FromImage(popularity))
                g.Clear(Color.DeepPink);
            kmeans = new Bitmap(kmeansPbox.Width, kmeansPbox.Height);
            kmeansPbox.Image = kmeans;
            using (Graphics g = Graphics.FromImage(kmeans))
                g.Clear(Color.MediumVioletRed);
            kValueToolStripMenuItem.Text = "Pallet limited to " + Math.Pow(maxAmmountOfColors, 3).ToString() + " colors.";
            path = System.IO.Path.GetFullPath(@"..\..\..\..\") + "lena.jpg";
            form_Resize(new object(), new EventArgs());
        }
        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Load image";
                dialog.Filter = "All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string oldPath = path;
                    try
                    {
                        path = dialog.FileName;
                        loadImage();
                    }
                    catch
                    {
                        MessageBox.Show("Unable to load selected image file.", "Exeption while loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        path = oldPath;
                        return;
                    }
                    calcAndLoadReduced();
                }
            }
        }
        private void loadImage()
        {
            original = new Bitmap(Image.FromFile(path), originalPbox.Width, originalPbox.Height);
            originalPbox.Image = original;
            originalPbox.Refresh();
        }
        private void calcAndLoadReduced()
        {
            calcAndLoadUncertainty();
            calcAndLoadPopularity();
            calcAndLoadKmeans();
        }
        private void calcAndLoadUncertainty()
        {
            uncertainty = new Bitmap(original);
            uncertaintyPbox.Image = uncertainty;

            using(FastBitmap f = uncertainty.FastLock())
                for (int i = 0; i < f.Width;i++)
                    for (int j = 0; j < f.Height; j++)
                    {
                        Color originalColor = f.GetPixel(i, j);
                        Color approxedColor = approximateColor(originalColor);
                        f.SetPixel(i, j, approxedColor);
                        (int,int,int,int) errorColor = calcColorError(originalColor, approxedColor);

                        // Floyd–Steinberg dithering
                        if (i + 1 < f.Width && j + 1 < f.Height)
                            f.SetPixel(i + 1, j + 1, calcErroredColor(f.GetPixel(i + 1, j + 1), errorColor, 1 / 16));
                        if (i + 1 < f.Width)
                            f.SetPixel(i + 1, j, calcErroredColor(f.GetPixel(i + 1, j), errorColor, 7 / 16));
                        if (j + 1 < f.Height)
                            f.SetPixel(i, j + 1, calcErroredColor(f.GetPixel(i, j + 1), errorColor, 5 / 16));
                        if (i - 1 >= 0 && j + 1 < f.Height)
                            f.SetPixel(i - 1, j + 1, calcErroredColor(f.GetPixel(i - 1, j + 1), errorColor, 3 / 16));
                    }

            uncertaintyPbox.Refresh();
        }
        private void calcAndLoadPopularity()
        {
            Dictionary<Color,int> colorDictionary = new Dictionary<Color, int>();
            popularity = new Bitmap(original);
            popularityPbox.Image = popularity;

            using (FastBitmap f = popularity.FastLock())
                for (int i = 0; i < f.Width; i++)
                    for (int j = 0; j < f.Height; j++)
                    {
                        Color c = f.GetPixel(i, j);
                        if (colorDictionary.ContainsKey(c))
                            colorDictionary[c] += 1;
                        else
                            colorDictionary.Add(c, 1);
                    }
            colorDictionary = colorDictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Take((int)Math.Pow(maxAmmountOfColors, 3)).ToDictionary(x => x.Key, x => x.Value);
            Color[] bestColors = (new List<Color>(colorDictionary.Keys)).ToArray();

            using (FastBitmap f = popularity.FastLock())
                for (int i = 0; i < f.Width; i++)
                    for (int j = 0; j < f.Height; j++)
                    {
                        Color originalColor = f.GetPixel(i, j);
                        Color bestColor = Color.HotPink;
                        int lowestOffset = int.MaxValue;

                        for (int k = 0; k < bestColors.Length; k++)
                        {
                            int currOffset = calcColorOffset(originalColor, bestColors[k]);
                            if (currOffset < lowestOffset)
                            {
                                lowestOffset = currOffset;
                                bestColor = bestColors[k];
                            }
                        }

                        f.SetPixel(i, j, bestColor);
                    }

            popularityPbox.Refresh();
        }
        private void calcAndLoadKmeans()
        {
            kmeans = new Bitmap(kmeansPbox.Width, kmeansPbox.Height);
            kmeansPbox.Image = kmeans;
            using (Graphics g = Graphics.FromImage(kmeans))
                g.Clear(Color.MediumVioletRed);
        }
        private Color approximateColor(Color color)
        {
            int step = (int)(255 / maxAmmountOfColors);

            int minRchannelError = int.MaxValue;
            int minGchannelError = int.MaxValue;
            int minBchannelError = int.MaxValue;
            int bestRchannelValue = -1;
            int bestGchannelValue = -1;
            int bestBchannelValue = -1;


            for (int i = 0; i < 256; i+=step)
            {
                if (minRchannelError > Math.Abs(color.R - i))
                {
                    minRchannelError = Math.Abs(color.R - i);
                    bestRchannelValue = i;
                }
                if (minGchannelError > Math.Abs(color.G - i))
                {
                    minGchannelError = Math.Abs(color.G - i);
                    bestGchannelValue = i;
                }
                if (minBchannelError > Math.Abs(color.B - i))
                {
                    minBchannelError = Math.Abs(color.B - i);
                    bestBchannelValue = i;
                }
            }

            return Color.FromArgb(color.A, bestRchannelValue, bestGchannelValue, bestBchannelValue);
        }
        private (int,int,int,int) calcColorError(Color originalColor, Color approxedColor)
        {
            return (originalColor.A - approxedColor.A, originalColor.R - approxedColor.R, originalColor.G - approxedColor.G, originalColor.B - approxedColor.B);
        }
        private Color calcErroredColor(Color originalColor, (int,int,int,int) errorColor, double filter)
        {
            return Color.FromArgb(originalColor.A + (int)(errorColor.Item1 * filter), originalColor.R + (int)(errorColor.Item2 * filter), originalColor.G + (int)(errorColor.Item3 * filter), originalColor.B + (int)(errorColor.Item4 * filter));
        }
        private void form_Resize(object sender, EventArgs e)
        {
            try
            {
                loadImage();
            }
            catch
            {
                return;
            }
            calcAndLoadReduced();
        }
        private int calcColorOffset(Color originalColor, Color currentColor)
        {
            return Math.Abs(originalColor.R - currentColor.R) + Math.Abs(originalColor.G - currentColor.G) + Math.Abs(originalColor.B - currentColor.B);
        }
        private void kValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string output = Microsoft.VisualBasic.Interaction.InputBox("Choose k value.", string.Empty, maxAmmountOfColors.ToString());
            int newK = -1;
            try
            {
                newK = int.Parse(output);
            }
            catch
            {
                MessageBox.Show("Unable to parse entered value to integer.", "Wrong input value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (newK > 0 && newK < 256)
            {
                maxAmmountOfColors = newK;
                kValueToolStripMenuItem.Text = "Pallet limited to " + Math.Pow(maxAmmountOfColors, 3).ToString() + " colors.";
                loadImage();
                calcAndLoadReduced();
            }
            else
                MessageBox.Show("The k value must be an integer between 0 and 256.", "Wrong input value", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}