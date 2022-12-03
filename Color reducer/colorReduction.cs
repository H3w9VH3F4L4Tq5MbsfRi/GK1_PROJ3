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
        private int maxAmmountOfColors = 3;
        private string path = string.Empty;
        private int epsilon = 24;
        public form()
        {
            InitializeComponent();
            loadDefault("lena.jpg");
            colorTrackBar_ValueChanged(new object(), new EventArgs());
            form_Resize(new object(), new EventArgs());
        }
        //EVENT HANDLERS
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
        private void colorTrackBar_ValueChanged(object sender, EventArgs e)
        {
            maxAmmountOfColors = colorTrackBar.Value;
            colorTextBox.Text = "Color palette limited to " + Math.Pow(maxAmmountOfColors + 1, 3).ToString() + " colors.";
            colorTextBox.Refresh();
            calcAndLoadReduced();
        }
        private void form_Resize(object sender, EventArgs e)
        {
            // TRY-CATCH BECAUSE MINIMISING COUNTS AS RESIZING FOR SOME REASON
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
        private void lenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDefault("lena.jpg");
        }
        private void lenagrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDefault("lena_grayscale.jpg");
        }
        private void beachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDefault("beach.jpg");
        }
        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDefault("colors.jpg");
        }
        private void lasVegasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDefault("lasvegas.jpg");
        }
        private void lewandowskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDefault("lewandowski.jpg");
        }
        private void floydSteinbergsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (floydSteinbergsToolStripMenuItem.Checked)
                return;
            floydSteinbergsToolStripMenuItem.Checked = true;
            burkessToolStripMenuItem.Checked = false;
            stuckysToolStripMenuItem.Checked = false;
            this.Cursor = Cursors.WaitCursor;
            calcAndLoadUncertainty();
            this.Cursor = Cursors.Default;
        }
        private void burkessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (burkessToolStripMenuItem.Checked)
                return;
            burkessToolStripMenuItem.Checked = true;
            floydSteinbergsToolStripMenuItem.Checked = false;
            stuckysToolStripMenuItem.Checked = false;
            this.Cursor = Cursors.WaitCursor;
            calcAndLoadUncertainty();
            this.Cursor = Cursors.Default;
        }
        private void stuckysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stuckysToolStripMenuItem.Checked)
                return;
            stuckysToolStripMenuItem.Checked = true;
            floydSteinbergsToolStripMenuItem.Checked = false;
            burkessToolStripMenuItem.Checked = false;
            this.Cursor = Cursors.WaitCursor;
            calcAndLoadUncertainty();
            this.Cursor = Cursors.Default;
        }
        private void changeΕValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string capture = Microsoft.VisualBasic.Interaction.InputBox("Enter desired ε value: ", "Change K-mean ε value", epsilon.ToString());
            int newEpsilon = -1;
            try
            {
                newEpsilon = int.Parse(capture);
            }
            catch
            {
                return;
            }
            if (newEpsilon >= 0)
            {
                epsilon = newEpsilon;
                this.Cursor = Cursors.WaitCursor;
                calcAndLoadKmeans();
                this.Cursor = Cursors.Default;
            }
        }
        //OWN FUNCTIONS
        private void loadImage()
        {
            originalPbox.Image = new Bitmap(Image.FromFile(path), originalPbox.Width, originalPbox.Height);
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
            Bitmap uncertainty = new Bitmap(Image.FromFile(path), uncertaintyPbox.Width, uncertaintyPbox.Height);
            uncertaintyPbox.Image = uncertainty;

            using (FastBitmap f = uncertainty.FastLock())
                for (int i = 0; i < f.Width; i++)
                    for (int j = 0; j < f.Height; j++)
                    {
                        Color originalColor = f.GetPixel(i, j);
                        Color approxedColor = approximateColor(originalColor);
                        f.SetPixel(i, j, approxedColor);
                        Vector4 errorColor = calcColorError(originalColor, approxedColor);

                        if (floydSteinbergsToolStripMenuItem.Checked)
                            floydSteinbergsDithering(f, i, j, errorColor);
                        else if (burkessToolStripMenuItem.Checked)
                            burkessDithering(f, i, j, errorColor);
                        else
                            stuckysDithering(f, i, j, errorColor);
                    }

            uncertaintyGbox.Text = "Propagation of uncertainty";
            uncertaintyGbox.Refresh();
        }
        private void calcAndLoadPopularity()
        {
            popularityGbox.Text = "Popularity algorithm (CALCULATING)";
            popularityGbox.Refresh();
            Dictionary<Color, int> colorDictionary = new Dictionary<Color, int>();
            Bitmap popularity = new Bitmap(Image.FromFile(path), popularityPbox.Width, popularityPbox.Height);
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
            popularityGbox.Refresh();
        }
        private void calcAndLoadKmeans()
        {
            kmeansGbox.Text = "K-means algorithm (CALCULATING)";
            kmeansGbox.Refresh();
            Bitmap kmeans = new Bitmap(Image.FromFile(path), kmeansPbox.Width, kmeansPbox.Height);
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
                    if (maxDiff <= epsilon)
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

            kmeansGbox.Text = "K-means algorithm";
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
        private Vector4 calcColorError(Color originalColor, Color approxedColor)
        {
            return new Vector4(originalColor.A - approxedColor.A, originalColor.R - approxedColor.R, originalColor.G - approxedColor.G, originalColor.B - approxedColor.B);
        }
        private Color calcErroredColor(Color originalColor, Vector4 errorColor, double filter)
        {
            return Color.FromArgb(originalColor.A + (int)(errorColor.X * filter), originalColor.R + (int)(errorColor.Y * filter), originalColor.G + (int)(errorColor.Z * filter), originalColor.B + (int)(errorColor.W * filter));
        }
        private static int calcColorOffset(Color originalColor, Color currentColor)
        {
            return Math.Abs(originalColor.A - currentColor.A) +
                   Math.Abs(originalColor.R - currentColor.R) +
                   Math.Abs(originalColor.G - currentColor.G) +
                   Math.Abs(originalColor.B - currentColor.B);
        }
        private void loadDefault(string a)
        {
            path = System.IO.Path.GetFullPath(@"..\..\..\") + "sample pictures\\" + a;
            form_Resize(new object(), new EventArgs());
        }
        private void floydSteinbergsDithering(FastBitmap f, int i, int j, Vector4 errorColor)
        {
            if (i + 1 < f.Width && j + 1 < f.Height)
                f.SetPixel(i + 1, j + 1, calcErroredColor(f.GetPixel(i + 1, j + 1), errorColor, 1 / 16));
            if (i + 1 < f.Width)
                f.SetPixel(i + 1, j, calcErroredColor(f.GetPixel(i + 1, j), errorColor, 7 / 16));
            if (j + 1 < f.Height)
                f.SetPixel(i, j + 1, calcErroredColor(f.GetPixel(i, j + 1), errorColor, 5 / 16));
            if (i - 1 >= 0 && j + 1 < f.Height)
                f.SetPixel(i - 1, j + 1, calcErroredColor(f.GetPixel(i - 1, j + 1), errorColor, 3 / 16));
        }
        private void burkessDithering(FastBitmap f, int i, int j, Vector4 errorColor)
        {
            if (i + 1 < f.Width && j + 1 < f.Height)
                f.SetPixel(i + 1, j + 1, calcErroredColor(f.GetPixel(i + 1, j + 1), errorColor, 4 / 32));
            if (i + 2 < f.Width && j + 1 < f.Height)
                f.SetPixel(i + 2, j + 1, calcErroredColor(f.GetPixel(i + 2, j + 1), errorColor, 2 / 32));
            if (i + 1 < f.Width)
                f.SetPixel(i + 1, j, calcErroredColor(f.GetPixel(i + 1, j), errorColor, 8 / 32));
            if (i + 2 < f.Width)
                f.SetPixel(i + 2, j, calcErroredColor(f.GetPixel(i + 2, j), errorColor, 4 / 32));
            if (j + 1 < f.Height)
                f.SetPixel(i, j + 1, calcErroredColor(f.GetPixel(i, j + 1), errorColor, 8 / 32));
            if (i - 1 >= 0 && j + 1 < f.Height)
                f.SetPixel(i - 1, j + 1, calcErroredColor(f.GetPixel(i - 1, j + 1), errorColor, 4 / 32));
            if (i - 2 >= 0 && j + 1 < f.Height)
                f.SetPixel(i - 2, j + 1, calcErroredColor(f.GetPixel(i - 2, j + 1), errorColor, 2 / 32));
        }
        private void stuckysDithering(FastBitmap f, int i, int j, Vector4 errorColor)
        {
            if (i + 1 < f.Width && j + 1 < f.Height)
                f.SetPixel(i + 1, j + 1, calcErroredColor(f.GetPixel(i + 1, j + 1), errorColor, 4 / 42));
            if (i + 2 < f.Width && j + 1 < f.Height)
                f.SetPixel(i + 2, j + 1, calcErroredColor(f.GetPixel(i + 2, j + 1), errorColor, 2 / 42));
            if (i + 1 < f.Width)
                f.SetPixel(i + 1, j, calcErroredColor(f.GetPixel(i + 1, j), errorColor, 8 / 42));
            if (i + 2 < f.Width)
                f.SetPixel(i + 2, j, calcErroredColor(f.GetPixel(i + 2, j), errorColor, 4 / 42));
            if (j + 1 < f.Height)
                f.SetPixel(i, j + 1, calcErroredColor(f.GetPixel(i, j + 1), errorColor, 8 / 42));
            if (i - 1 >= 0 && j + 1 < f.Height)
                f.SetPixel(i - 1, j + 1, calcErroredColor(f.GetPixel(i - 1, j + 1), errorColor, 4 / 42));
            if (i - 2 >= 0 && j + 1 < f.Height)
                f.SetPixel(i - 2, j + 1, calcErroredColor(f.GetPixel(i - 2, j + 1), errorColor, 2 / 42));
            if (i - 2 >= 0 && j + 2 < f.Height)
                f.SetPixel(i - 2, j + 2, calcErroredColor(f.GetPixel(i - 2, j + 2), errorColor, 1 / 42));
            if (i - 1 >= 0 && j + 2 < f.Height)
                f.SetPixel(i - 1, j + 2, calcErroredColor(f.GetPixel(i - 1, j + 2), errorColor, 2 / 42));
            if (j + 2 < f.Height)
                f.SetPixel(i, j + 2, calcErroredColor(f.GetPixel(i, j + 2), errorColor, 4 / 42));
            if (i + 1 < f.Width && j + 2 < f.Height)
                f.SetPixel(i + 1, j + 2, calcErroredColor(f.GetPixel(i + 1, j + 2), errorColor, 2 / 42));
            if (i + 2 < f.Width && j + 2 < f.Height)
                f.SetPixel(i + 2, j + 2, calcErroredColor(f.GetPixel(i + 2, j + 2), errorColor, 1 / 42));
        }
    }
}