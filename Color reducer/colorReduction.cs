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
        private int epsilon = 1000;
        private static int border = 10;
        private static int miniBorder = 2;
        private bool hsv = false;
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
                    hsv = false;
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
                if (hsv)
                    generateHSV();
                else
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
            hsv = false;
            loadDefault("lena.jpg");
        }
        private void lenagrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hsv = false;
            loadDefault("lena_grayscale.jpg");
        }
        private void beachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hsv = false;
            loadDefault("beach.jpg");
        }
        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hsv = false;
            loadDefault("colors.jpg");
        }
        private void lasVegasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hsv = false;
            loadDefault("lasvegas.jpg");
        }
        private void lewandowskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hsv = false;
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
        private void generateButton_Click(object sender, EventArgs e)
        {
            hsv = true;
            generateHSV();
        }
        private void vTrackBar_ValueChanged(object sender, EventArgs e)
        {
            generateHSV();
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
            Bitmap uncertainty = new Bitmap(originalPbox.Image);
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
            Bitmap popularity = new Bitmap(originalPbox.Image);
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
            Bitmap kmeans = new Bitmap(originalPbox.Image);
            kmeansPbox.Image = kmeans;

            int k = (int)Math.Pow(maxAmmountOfColors + 1, 3);
            Random r = new Random();
            int x = kmeans.Width;
            int y = kmeans.Height;

            using (FastBitmap f = kmeans.FastLock())
            {
                List<Color> temp = new List<Color>();
                List<(int x, int y)> temp2 = new List<(int x, int y)>();
                for (int i = 0; i < k; i++)
                {
                    int x1 = r.Next(0, x);
                    int y1 = r.Next(0, y);
                    temp.Add(f.GetPixel(x1, y1));
                    temp2.Add((x1,y1));
                }
                Color[] means = temp.ToArray();
                (int x, int y)[] meansCoords = temp2.ToArray();
                bool run = true;

                while (run)
                {
                    (double x, double y)[] coorsd = new (double, double)[means.Length];
                    double[] weights = new double[means.Length];

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

                            double w = calcDistance(i, j, meansCoords[bestMeanIndx].x, meansCoords[bestMeanIndx].y);
                            weights[bestMeanIndx] += w;
                            coorsd[bestMeanIndx].x += i * w;
                            coorsd[bestMeanIndx].y += j * w;
                        }

                    Color[] newMeans = new Color[means.Length];
                    for (int i = 0; i < means.Length; i++)
                    {
                        if (weights[i] == 0)
                        {
                            newMeans[i] = means[i];
                            break;
                        }
                        coorsd[i].x /= weights[i];
                        coorsd[i].y /= weights[i];
                        newMeans[i] = f.GetPixel((int)coorsd[i].x, (int)coorsd[i].y);
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
        private double calcDistance(int x1, int y1, int x2, int y2)
        {
            return (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
        }
        private void generateHSV()
        {
            Bitmap b = new Bitmap(originalPbox.Width, originalPbox.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.FillRectangle(Brushes.Black, 0, 0, originalPbox.Width, originalPbox.Height);
                g.FillRectangle(Brushes.White, border, border, originalPbox.Width - 2 * border, originalPbox.Height - 2 * border);
            }

            int start = border + miniBorder;
            int width = (int)((double)(originalPbox.Width - 2 * border - 11 * miniBorder) / 10);
            int height = originalPbox.Height - 2 * border - 2 * miniBorder;

            for (int i = 0; i < 10; i++)
            {
                using (FastBitmap f = b.FastLock())
                    generateHSVrectangle(f, start, border + miniBorder, width, height, i * 36);
                //g.FillRectangle(Brushes.HotPink, start, border + miniBorder, width, height);
                start += width;
                start += miniBorder;
            }

            originalPbox.Image = b;
            originalPbox.Refresh();
            calcAndLoadReduced();
        }
        private void generateHSVrectangle(FastBitmap f, int startX, int startY, int width, int height, double hue)
        {
            for (int i = 0; i < height; i++)
            {
                double s = (double)(height - i) / height;
                double v = (double)vTrackBar.Value / 1000;
                Color c = ColorFromHSV(hue, s, v);

                for (int j = 0; j < width; j++)
                {
                    f.SetPixel(j+startX,i+startY,c);
                }
            }
        }
        private static Color ColorFromHSV(double hue, double saturation, double value)
        {
            double f = hue / 60 - Math.Floor(hue / 60);
            int swtch = (int)(Math.Floor(hue / 60)) % 6;
            int a = (int)(value * 255);
            int b = (int)(value * 255 * (1 - saturation));
            int c = (int)(value * 255 * (1 - f * saturation));
            int d = (int)(value * 255 * (1 - (1 - f) * saturation));

            if (swtch == 0)
                return Color.FromArgb(255, a, d, b);
            else if (swtch == 1)
                return Color.FromArgb(255, c, a, b);
            else if (swtch == 2)
                return Color.FromArgb(255, b, a, d);
            else if (swtch == 3)
                return Color.FromArgb(255, b, c, a);
            else if (swtch == 4)
                return Color.FromArgb(255, d, b, a);
            else
                return Color.FromArgb(255, a, b, c);
        }
    }
}