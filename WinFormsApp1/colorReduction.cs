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
        private static int precision = 12;
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
            colorTextBox.Text = "Pallet limited to " + Math.Pow(maxAmmountOfColors + 1, 3).ToString() + " colors.";
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
            this.Cursor = Cursors.WaitCursor;
            calcAndLoadUncertainty();
            calcAndLoadPopularity();
            calcAndLoadKmeans();
            this.Cursor = Cursors.Default;
        }
        private void calcAndLoadUncertainty()
        {
            uncertaintyGbox.Text = "Propagation of uncertainty (CALCULATING)";
            uncertaintyGbox.Refresh();
            uncertainty = new Bitmap(original);
            uncertaintyPbox.Image = uncertainty;

            using (FastBitmap f = uncertainty.FastLock())
                for (int i = 0; i < f.Width; i++)
                    for (int j = 0; j < f.Height; j++)
                    {
                        Color originalColor = f.GetPixel(i, j);
                        Color approxedColor = approximateColor(originalColor);
                        f.SetPixel(i, j, approxedColor);
                        (int, int, int, int) errorColor = calcColorError(originalColor, approxedColor);

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

            uncertaintyGbox.Text = "Propagation of uncertainty";
            uncertaintyPbox.Refresh();
            uncertaintyGbox.Refresh();
        }
        private void calcAndLoadPopularity()
        {
            popularityGbox.Text = "Popularity algorithm (CALCULATING)";
            popularityGbox.Refresh();
            Dictionary<Color, int> colorDictionary = new Dictionary<Color, int>();
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
            colorDictionary = colorDictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Take((int)Math.Pow(maxAmmountOfColors + 1, 3)).ToDictionary(x => x.Key, x => x.Value);
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

            popularityGbox.Text = "Popularity algorithm";
            popularityPbox.Refresh();
            popularityGbox.Refresh();
        }
        private void calcAndLoadKmeans()
        {
            kmeansGbox.Text = "K-means algorithm (CALCULATING)";
            kmeansGbox.Refresh();
            kmeans = new Bitmap(original);
            kmeansPbox.Image = kmeans;

            int k = (int)Math.Pow(maxAmmountOfColors + 1, 3);
            Random r = new Random();
            int x = kmeans.Width;
            int y = kmeans.Height;

            using (FastBitmap f = kmeans.FastLock())
            {

                List<Color> temp = new List<Color>();
                for (int i = 0; i < k; i++)
                    temp.Add(f.GetPixel(r.Next(0, x), r.Next(0, y)));
                Color[] means = temp.ToArray();
                bool run = true;

                while (run)
                {
                    int[] counter = new int[means.Length];
                    (long, long, long, long)[] sum = new (long, long, long, long)[means.Length];

                    for (int i = 0; i < x; i++)
                        for (int j = 0; j < y; j++)
                        {
                            Color originalColor = f.GetPixel(i, j);
                            int bestMeanIndx = -1;
                            int lowestOffset = int.MaxValue;

                            for (int l = 0; l < means.Length; l++)
                            {
                                int currOffset = calcColorOffset(originalColor, means[l]);
                                if (currOffset < lowestOffset)
                                {
                                    lowestOffset = currOffset;
                                    bestMeanIndx = l;
                                }
                            }

                            counter[bestMeanIndx]++;
                            sum[bestMeanIndx].Item1 += originalColor.A;
                            sum[bestMeanIndx].Item2 += originalColor.R;
                            sum[bestMeanIndx].Item3 += originalColor.G;
                            sum[bestMeanIndx].Item4 += originalColor.B;
                        }

                    Color[] newMeans = new Color[means.Length];
                    for (int i = 0; i < means.Length; i++)
                    {
                        if (counter[i] == 0)
                        {
                            newMeans[i] = means[i];
                            break;
                        }
                        int A = (int)(sum[i].Item1 / counter[i]);
                        int R = (int)(sum[i].Item2 / counter[i]);
                        int G = (int)(sum[i].Item3 / counter[i]);
                        int B = (int)(sum[i].Item4 / counter[i]);
                        newMeans[i] = Color.FromArgb(A, R, G, B);
                    }

                    int maxDiff = int.MinValue;
                    for (int i = 0; i < means.Length; i++)
                    {
                        int currDiff = calcColorOffset(means[i], newMeans[i]);
                        if (currDiff > maxDiff)
                            maxDiff = currDiff;
                    }
                    means = newMeans;
                    //Debug.WriteLine(maxDiff);
                    if (maxDiff <= precision)
                        run = false;
                }

                for (int i = 0; i < x; i++)
                    for (int j = 0; j < y; j++)
                    {
                        Color originalColor = f.GetPixel(i, j);
                        int bestMeanIndx = -1;
                        int lowestOffset = int.MaxValue;

                        for (int l = 0; l < means.Length; l++)
                        {
                            int currOffset = calcColorOffset(originalColor, means[l]);
                            if (currOffset < lowestOffset)
                            {
                                lowestOffset = currOffset;
                                bestMeanIndx = l;
                            }
                        }

                        f.SetPixel(i, j, means[bestMeanIndx]);
                    }
            }

            kmeansGbox.Text = "K - means algorithm";
            kmeansPbox.Refresh();
            kmeansGbox.Refresh();
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


            for (int i = 0; i < 256; i += step)
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
        private (int, int, int, int) calcColorError(Color originalColor, Color approxedColor)
        {
            return (originalColor.A - approxedColor.A, originalColor.R - approxedColor.R, originalColor.G - approxedColor.G, originalColor.B - approxedColor.B);
        }
        private Color calcErroredColor(Color originalColor, (int, int, int, int) errorColor, double filter)
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
            return ownAbs(originalColor.R - currentColor.R) + ownAbs(originalColor.G - currentColor.G) + ownAbs(originalColor.B - currentColor.B);
        }
        private void colorTrackBar_ValueChanged(object sender, EventArgs e)
        {
            maxAmmountOfColors = colorTrackBar.Value;
            colorTextBox.Text = "Pallet limited to " + Math.Pow(maxAmmountOfColors + 1, 3).ToString() + " colors.";
            calcAndLoadReduced();
        }
        private int ownAbs(int x)
        {
            if (x < 0)
                return -x;
            else
                return x;
        }
    }
}