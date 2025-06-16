using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CourseWork
{
    public partial class MainForm : Form
    {
        NeuralNetwork NN = new NeuralNetwork(2025, 35, 17, 0.07);
        List<List<PictureBox>> pictureBoxes;
        List<List<Bitmap>> Bitmaps;
        List<List<PictureBox>> RootPictures;
        List<List<Bitmap>> RootBitmaps;
        List<List<PictureBox>> FractionPictures;
        List<List<Bitmap>> FractionBitmaps;
        List<List<PictureBox>> DotPictures;
        List<List<Bitmap>> DotBitmaps;
        Dictionary<string, Bitmap> TrainingPictures = new Dictionary<string, Bitmap>();
        int side = 45, step = 20, Xstart = 20, Ystart = 30, lowerBorder = 150;
        Size Root = new Size(18, 45);
        Size Fraction = new Size(45, 18);
        Size Dot = new Size(18, 18);
        Pen BorderPen = new Pen(Color.Gray, 1);
        Pen pen = new Pen(Color.Black, 1);

        Point Prev;
        bool drawing;
        Stack<Point> Avalanche = new Stack<Point>();

        string TrainPath = "Îáó÷åíèå";
        string TestPath = "Òåñò";
        public MainForm()
        {
            InitializeComponent();
            Launch();
            LaunchRoot();
            LaunchFraction();
            LaunchDot();
            Start();
            StartRoot();
            StartFraction();
            StartDot();
            foreach (List<PictureBox> list in pictureBoxes)
            {
                foreach (PictureBox box in list)
                {
                    box.MouseMove += Box_MouseMove;
                    box.MouseUp += Box_MouseUp;
                    box.MouseDown += Box_MouseDown;
                }
            }
            foreach (List<PictureBox> list in RootPictures)
            {
                foreach (PictureBox box in list)
                {
                    box.MouseDown += Box_MouseDownRoot;
                }
            }
            foreach (List<PictureBox> list in FractionPictures)
            {
                foreach (PictureBox box in list)
                {
                    box.MouseDown += Box_MouseDownFraction;
                }
            }
            foreach (List<PictureBox> list in DotPictures)
            {
                foreach (PictureBox box in list)
                {
                    box.MouseDown += Box_MouseDownDot;
                }
            }
        }

        private void Box_MouseDownRoot(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Bitmap bitmap = (Bitmap)pictureBox.Image;
                int row = 0, column = 0;
                for (int i = 0; i < RootBitmaps.Count; i++)
                {
                    if (RootBitmaps[i].Contains(bitmap))
                    {
                        row = i;
                        column = RootBitmaps[i].IndexOf(bitmap);
                        break;
                    }
                }
                for (int i = column - 1; i >= 0; i--)
                {
                    if (RootBitmaps[row][i].GetPixel(RootBitmaps[row][i].Width / 2, RootBitmaps[row][i].Height / 2).Name == "ff000000")
                    {
                        RootEnd(pictureBox, bitmap);
                        return;
                    }
                    else if (RootBitmaps[row][i].GetPixel(RootBitmaps[row][i].Width / 2, 3).Name == "ff000000")
                    {
                        SquareRoot(pictureBox, bitmap);
                        return;
                    }
                }
                SquareRoot(pictureBox, bitmap);
            }
            else if (e.Button == MouseButtons.Right)
                Rubber(sender);
        }
        private void SquareRoot(PictureBox pictureBox, Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(pen, 6, bitmap.Height - 4, bitmap.Width - 6, 3);
                g.DrawLine(pen, bitmap.Width - 5, 3, bitmap.Width - 1, 3);
                g.DrawLine(pen, 0, (bitmap.Height * 2) / 3, 6, bitmap.Height - 4);
            }
            pictureBox.Invalidate();
        }
        private void RootEnd(PictureBox pictureBox, Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(pen, 0, 3, bitmap.Width - 1, 3);
                g.DrawLine(pen, bitmap.Width - 1, 3, bitmap.Width - 1, 9);
            }
            pictureBox.Invalidate();
        }
        private void Box_MouseDownFraction(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Bitmap bitmap = (Bitmap)pictureBox.Image;
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawLine(pen, 2, pictureBox.Height / 2, pictureBox.Width - 2, pictureBox.Height / 2);
                }
                pictureBox.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
                Rubber(sender);
        }
        private void Box_MouseDownDot(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Bitmap bitmap = (Bitmap)pictureBox.Image;
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawEllipse(pen, 7, 7, 4, 4);
                }
                pictureBox.Invalidate();
                Avalanche.Push(new Point(bitmap.Width / 2, bitmap.Height / 2));
                Filling(pictureBox, bitmap);
            }
            else if (e.Button == MouseButtons.Right)
                Rubber(sender);
        }

        private void Box_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawing = true;
                Prev = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
                Rubber(sender);
        }

        private void Box_MouseUp(object? sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void Box_MouseMove(object? sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Bitmap bitmap = (Bitmap)pictureBox.Image;
            if (drawing)
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawLine(pen, Prev, e.Location);
                    pictureBox.Invalidate();
                }
                Prev = e.Location;
            }
        }
        private void Rubber(object? sender)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Bitmap bitmap = (Bitmap)pictureBox.Image;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(this.BackColor);
                g.DrawRectangle(BorderPen, 0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
            }
            pictureBox.Invalidate();
        }
        private void Launch()
        {
            pictureBoxes = new List<List<PictureBox>>();
            Bitmaps = new List<List<Bitmap>>();
            for (int y = Ystart; y < lowerBorder; y += side + step)
            {
                List<PictureBox> pictures = new List<PictureBox>();
                List<Bitmap> maps = new List<Bitmap>();
                for (int x = Xstart; x < this.Width - side; x += side + step)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(x, y);
                    pictureBox.Size = new Size(side, side);
                    Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                    this.Controls.Add(pictureBox);
                    pictures.Add(pictureBox);
                    maps.Add(bitmap);
                }
                pictureBoxes.Add(pictures);
                Bitmaps.Add(maps);
            }
        }
        private void LaunchRoot()
        {
            RootPictures = new List<List<PictureBox>>();
            RootBitmaps = new List<List<Bitmap>>();
            for (int y = Ystart; y < lowerBorder; y += side + step)
            {
                List<PictureBox> pictures = new List<PictureBox>();
                List<Bitmap> maps = new List<Bitmap>();
                for (int x = 1; x < this.Width; x += side + step)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(x, y);
                    pictureBox.Size = Root;
                    Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                    this.Controls.Add(pictureBox);
                    pictures.Add(pictureBox);
                    maps.Add(bitmap);
                }
                RootPictures.Add(pictures);
                RootBitmaps.Add(maps);
            }
        }
        private void LaunchFraction()
        {
            FractionPictures = new List<List<PictureBox>>();
            FractionBitmaps = new List<List<Bitmap>>();
            for (int y = 11 + side + step; y < lowerBorder + step; y += side + step)
            {
                List<PictureBox> pictures = new List<PictureBox>();
                List<Bitmap> maps = new List<Bitmap>();
                for (int x = step; x < this.Width - side; x += side + step)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(x, y);
                    pictureBox.Size = Fraction;
                    Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                    this.Controls.Add(pictureBox);
                    pictures.Add(pictureBox);
                    maps.Add(bitmap);
                }
                FractionPictures.Add(pictures);
                FractionBitmaps.Add(maps);
            }
        }
        private void LaunchDot()
        {
            DotPictures = new List<List<PictureBox>>();
            DotBitmaps = new List<List<Bitmap>>();
            for (int y = Ystart + side + 1; y < lowerBorder + step; y += side + step)
            {
                List<PictureBox> pictures = new List<PictureBox>();
                List<Bitmap> maps = new List<Bitmap>();
                for (int x = Xstart + 1 - step; x < this.Width; x += side + step)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(x, y);
                    pictureBox.Size = Dot;
                    Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                    this.Controls.Add(pictureBox);
                    pictures.Add(pictureBox);
                    maps.Add(bitmap);
                }
                DotPictures.Add(pictures);
                DotBitmaps.Add(maps);
            }
        }
        private void Start()
        {
            for (int y = 0; y < pictureBoxes.Count; y++)
            {
                for (int x = 0; x < pictureBoxes[0].Count; x++)
                {
                    pictureBoxes[y][x].SizeMode = PictureBoxSizeMode.CenterImage;
                    Bitmaps[y][x] = new Bitmap(pictureBoxes[y][x].Width, pictureBoxes[y][x].Height);
                    pictureBoxes[y][x].Image = (Image)Bitmaps[y][x];
                    using (Graphics g = Graphics.FromImage(Bitmaps[y][x]))
                    {
                        g.DrawRectangle(BorderPen, 0, 0,
                            pictureBoxes[y][x].Width - 1, pictureBoxes[y][x].Height - 1);
                        pictureBoxes[y][x].Invalidate();
                    }
                }
            }
        }
        private void StartRoot()
        {
            for (int y = 0; y < RootPictures.Count; y++)
            {
                for (int x = 0; x < RootPictures[0].Count; x++)
                {
                    RootBitmaps[y][x] = new Bitmap(RootPictures[y][x].Width, RootPictures[y][x].Height);
                    RootPictures[y][x].Image = (Image)RootBitmaps[y][x];
                    using (Graphics g = Graphics.FromImage(RootBitmaps[y][x]))
                    {
                        g.DrawRectangle(BorderPen, 0, 0,
                            RootPictures[y][x].Width - 1, RootPictures[y][x].Height - 1);
                        RootPictures[y][x].Invalidate();
                    }
                }
            }
        }
        private void StartFraction()
        {
            for (int y = 0; y < FractionPictures.Count; y++)
            {
                for (int x = 0; x < FractionPictures[0].Count; x++)
                {
                    FractionBitmaps[y][x] = new Bitmap(FractionPictures[y][x].Width, FractionPictures[y][x].Height);
                    FractionPictures[y][x].Image = (Image)FractionBitmaps[y][x];
                    using (Graphics g = Graphics.FromImage(FractionBitmaps[y][x]))
                    {
                        g.DrawRectangle(BorderPen, 0, 0,
                            FractionPictures[y][x].Width - 1, FractionPictures[y][x].Height - 1);
                        FractionPictures[y][x].Invalidate();
                    }
                }
            }
        }
        private void StartDot()
        {
            for (int y = 0; y < DotPictures.Count; y++)
            {
                for (int x = 0; x < DotPictures[0].Count; x++)
                {
                    DotBitmaps[y][x] = new Bitmap(DotPictures[y][x].Width, DotPictures[y][x].Height);
                    DotPictures[y][x].Image = (Image)DotBitmaps[y][x];
                    using (Graphics g = Graphics.FromImage(DotBitmaps[y][x]))
                    {
                        g.DrawRectangle(BorderPen, 0, 0,
                            DotPictures[y][x].Width - 1, DotPictures[y][x].Height - 1);
                        DotPictures[y][x].Invalidate();
                    }
                }
            }
        }
        private void ïîèñêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (double lr = 0.05; lr < 0.12; lr += 0.01)
            {
                NN = null;
                NN = new NeuralNetwork(2025, 57, 17, 0.07);

                DirectoryInfo catalog = new DirectoryInfo(TrainPath);
                var examples = from NNexample in catalog.EnumerateFiles()
                               select new { NNexample };
                string[] photos = new string[examples.Count()];
                int k = 0;
                foreach (var photo in examples)
                {
                    photos[k] = photo.NNexample.FullName;
                    k++;
                }

                int R = 0, N = 1;
                int[] data;

                Random.Shared.Shuffle(photos);
                for (int j = 0; j < photos.Length; j++)
                {
                    Image image = Image.FromFile(photos[j]);
                    Bitmap bitmap = (Bitmap)image;
                    NN.FirstLayer.Clear();
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            int color;
                            if (bitmap.GetPixel(x, y).Name == "ff000000")
                                color = 1;
                            else
                                color = 0;
                            NN.FirstLayer.Add(color);
                        }
                    }

                    Regex regex = new Regex(@"\\. \(");
                    NN.Activation();
                    string pattern = Convert.ToString(regex.Match(photos[j]));
                    double[] dE = NN.dError(Convert.ToString(pattern[1]));

                    double[][] dError = new double[1][];
                    dError[0] = dE;
                    NN.GradientDescent(dError);

                }
                Check(out R, out N, out data, TestPath);

                int T = 0, M = N;
                int[] ints = new int[data.Length];
                Check(out T, out M, out ints, TrainPath);

                FileStream file = new FileStream("Æóðíàë.txt", FileMode.Append);
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine($"Ðàçíèöà: {(double)R / (double)N - (double)T / (double)M}; " +
                        $"Òî÷íîñòè: {R} / {N} = {(double)R / (double)N} è {T} / {M} = {(double)T / (double)M}; ");
                }
            }
        }
        private void ñïðàâêàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm form = new InfoForm();
            form.ShowDialog();
        }
        private void ñîõðàíèòüÂåñàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NN.SaveWeights();
        }
        private void çàãðóçêàÂåñîâToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NN.LoadWeights();
        }
        private void âûõîäToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void î÷èñòèòüÝêðàíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < pictureBoxes.Count; y++)
            {
                for (int x = 0; x < pictureBoxes[0].Count; x++)
                {
                    pictureBoxes[y][x].Image = null;
                    Bitmaps[y][x] = null;
                    pictureBoxes[y][x].Invalidate();
                }
            }
            for (int y = 0; y < RootPictures.Count; y++)
            {
                for (int x = 0; x < RootPictures[0].Count; x++)
                {
                    RootPictures[y][x].Image = null;
                    RootBitmaps[y][x] = null;
                    RootPictures[y][x].Invalidate();
                }
            }
            for (int y = 0; y < FractionPictures.Count; y++)
            {
                for (int x = 0; x < FractionPictures[0].Count; x++)
                {
                    FractionPictures[y][x].Image = null;
                    FractionBitmaps[y][x] = null;
                    FractionPictures[y][x].Invalidate();
                }
            }
            for (int y = 0; y < DotPictures.Count; y++)
            {
                for (int x = 0; x < DotPictures[0].Count; x++)
                {
                    DotPictures[y][x].Image = null;
                    DotBitmaps[y][x] = null;
                    DotPictures[y][x].Invalidate();
                }
            }
            Start();
            StartRoot();
            StartFraction();
            StartDot();
        }

        private void ðàñïîçíàâàíèåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool empty = true;
            string[][] Answers = new string[Bitmaps.Count][];
            for (int i = 0; i < Answers.Length; i++)
            {
                Answers[i] = new string[Bitmaps[0].Count];
            }

            for (int y = 0; y < Bitmaps.Count; y++)
            {
                for (int x = 0; x < Bitmaps[0].Count; x++)
                {
                    NN.FirstLayer.Clear();
                    empty = true;
                    for (int yy = 0; yy < Bitmaps[y][x].Height; yy++)
                    {
                        for (int xx = 0; xx < Bitmaps[y][x].Height; xx++)
                        {
                            int color;
                            if (Bitmaps[y][x].GetPixel(xx, yy).Name == "ff000000")
                                color = 1;
                            else
                                color = 0;
                            if (color == 1)
                                empty = false;
                            NN.FirstLayer.Add(color);
                        }
                    }
                    if (!empty)
                    {
                        NN.Activation();
                        Answers[y][x] = NN.Answer();
                    }
                    ÑreatingExpression(Answers);


                }
            }
        }
        private void ÑreatingExpression(string[][] Answers)
        {
            string Expression = "";
            string[][] temp = new string[Answers.Length][];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new string[Answers[0].Length];
            }
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp[0].Length; j++)
                {
                    temp[i][j] = "";
                }
            }
            int RootNum = 0;

            for (int y = 0; y < Answers.Length; y++)
            {
                for (int x = 0; x < Answers[0].Length; x++)
                {
                    if (RootBitmaps[y][x].GetPixel(RootBitmaps[y][x].Width / 2, RootBitmaps[y][x].Height / 2).Name == "ff000000")
                    {
                        temp[y][x] += "R(";
                        RootNum++;
                    }

                    temp[y][x] += Answers[y][x];

                    if (DotBitmaps[y][x + 1].GetPixel(DotBitmaps[y][x].Width / 2, DotBitmaps[y][x].Height / 2).Name == "ff000000")
                    {
                        temp[y][x] += ",";
                    }


                    if (RootNum > 0 && x == Answers[0].Length - 1)
                    {
                        temp[y][x] += ")";
                        RootNum--;
                    }
                    else if (RootNum > 0 && RootBitmaps[y][x + 1].GetPixel(RootBitmaps[y][x + 1].Width / 2, 3).Name == "ff000000")
                    {
                        temp[y][x] += ")";
                        RootNum--;
                    }
                }
            }
            int start = 0, end = 0;
            string numerator = "", denominator = "";
            for (int x = 0; x < Answers[0].Length; x++)
            {
                if (FractionBitmaps[0][x].GetPixel(FractionBitmaps[0][x].Width / 2, FractionBitmaps[0][x].Height / 2).Name == "ff000000")
                {
                    start = x;
                    while (FractionBitmaps[0][x].GetPixel(FractionBitmaps[0][x].Width / 2,
                        FractionBitmaps[0][x].Height / 2).Name == "ff000000")
                    {
                        if (x == Answers[0].Length - 1)
                            break;
                        x++;
                    }
                    for (int i = start; i < x; i++)
                    {
                        numerator += temp[0][i];
                        denominator += temp[1][i];
                    }
                    Expression += $"(({numerator})/({denominator}))";
                    x--;
                    numerator = ""; denominator = "";
                }
                else
                {
                    Expression += temp[0][x];
                    Expression += temp[1][x];
                }
            }
            ExampleBox.Text = Expression;
        }
        private void WaitingStart()
        {
            new Thread(() => form.ShowDialog()).Start();
        }
        private void WaitingStop()
        {
            form.Close();
        }
        delegate void Waiting();

        WaitForm form;
        CancellationTokenSource CancelTokenSource;
        CancellationToken token;
        private void Form_FormClosed(object? sender, FormClosedEventArgs e)
        {
            CancelTokenSource.Cancel();
            CancelTokenSource.Dispose();
        }
        private void îáó÷åíèåToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CancelTokenSource = new CancellationTokenSource();
            token = CancelTokenSource.Token;
            form = new WaitForm();
            form.FormClosed += Form_FormClosed;
            Invoke(new Waiting(WaitingStart));

            DirectoryInfo catalog = new DirectoryInfo(TrainPath);
            var examples = from NNexample in catalog.EnumerateFiles()
                           select new { NNexample };
            string[] photos = new string[examples.Count()];
            int i = 0;
            foreach (var photo in examples)
            {
                photos[i] = photo.NNexample.FullName;
                i++;
            }

            i = 0;
            int R = 0, N = 1;
            int[] data;

            //int batch_size = 5;
            //int batch_count = photos.Length / batch_size;
            //int b = 0;
            //double[][] dErrors = new double[batch_size][];
            //for (int f = 0; f < dErrors.Length; f++)
            //{
            //    dErrors[f] = new double[NN.OutSize];
            //}

            for (i = 0; i < 1000; i++)
            {
                if ((double)R / (double)N > 0.9)
                {
                    return;
                }
                Random.Shared.Shuffle(photos);
                for (int j = 0; j < photos.Length; j++)
                {
                    Image image = Image.FromFile(photos[j]);
                    Bitmap bitmap = (Bitmap)image;
                    NN.FirstLayer.Clear();
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            int color;
                            if (bitmap.GetPixel(x, y).Name == "ff000000")
                                color = 1;
                            else
                                color = 0;
                            NN.FirstLayer.Add(color);
                        }
                    }
                    if (token.IsCancellationRequested)
                        return;

                    Regex regex = new Regex(@"\\. \(");
                    NN.Activation();
                    string pattern = Convert.ToString(regex.Match(photos[j]));
                    double[] dE = NN.dError(Convert.ToString(pattern[1]));

                    double[][] dError = new double[1][];
                    dError[0] = dE;
                    NN.GradientDescent(dError);

                    //dErrors[b] = dE;
                    //if (b == batch_size - 1)
                    //{
                    //    b = 0;
                    //    dErrors = Matrix.Transpose(dErrors);
                    //    double[][] dError = new double[1][];
                    //    dError[0] = new double[NN.OutSize];

                    //    for (int k = 0; k < dError[0].Length; k++)
                    //    {
                    //        dError[0][k] = dErrors[k].Average();
                    //    }
                    //    NN.GradientDescent(dError);

                    //    dErrors = Matrix.Transpose(dErrors);
                    //}
                    //else
                    //    b++;

                }

                if (i % 1 == 0)
                {
                    Check(out R, out N, out data, TestPath);

                    int T = 0, M = N;
                    int[] ints = new int[data.Length];
                    Check(out T, out M, out ints, TrainPath);

                    FileStream file = new FileStream("Æóðíàë.txt", FileMode.Append);
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        writer.WriteLine($"Ýïîõà {i}. Òî÷íîñòü äëÿ òåñòîâîé: {R} / {N} = {(double)R / (double)N} è" +
                            $" äëÿ îáó÷àþùåé: {T} / {M} = {(double)T / (double)M}");
                    }
                }


            }


            NN.SaveWeights();
            Invoke(new Waiting(WaitingStop));
        }
        private void Check(out int R, out int N, out int[] data, string path)
        {
            R = 0;
            N = 0;
            string[] classes = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "-", "x", "d", "^", "(", ")" };
            data = new int[classes.Length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
            }
            int[] limits = new int[classes.Length];
            for (int i = 0; i < limits.Length; i++)
            {
                limits[i] = 0;
            }
            DirectoryInfo catalog = new DirectoryInfo(path);
            var examples = from NNexample in catalog.EnumerateFiles()
                           select new { NNexample };
            bool limit = false;
            foreach (var photo in examples)
            {
                for (int i = 0; i < classes.Length; i++)
                {
                    if (classes[i] == Convert.ToString(photo.NNexample.Name[0]))
                    {
                        if (limits[i] == 100)
                        {
                            limit = true;
                            break;
                        }
                        else
                        {
                            limits[i]++;
                            N++;
                            break;
                        }
                    }
                }
                if (limit)
                {
                    limit = false;
                    continue;
                }
                Image image = Image.FromFile(photo.NNexample.FullName);
                Bitmap bitmap = (Bitmap)image;
                NN.FirstLayer.Clear();
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        int color;
                        if (bitmap.GetPixel(x, y).Name == "ff000000")
                            color = 1;
                        else
                            color = 0;
                        NN.FirstLayer.Add(color);
                    }
                }
                NN.Activation();
                double[] answer = NN.Probabilities();
                for (int i = 0; i < answer.Length; i++)
                {
                    if (answer[i] == answer.Max())
                    {
                        if (classes[i] == Convert.ToString(photo.NNexample.Name[0]))
                        {
                            R++;
                            data[i]++;
                        }
                    }
                }
            }
        }
        private void Filling(PictureBox pictureBox, Bitmap bitmap)
        {
            while (Avalanche.Count != 0)
            {
                Point Current = Avalanche.Pop();
                bitmap.SetPixel(Current.X, Current.Y, pen.Color);
                pictureBox.Invalidate();

                Point Next = new Point(Current.X + 1, Current.Y); // Òî÷êà ñïðàâà
                if (bitmap.GetPixel(Next.X, Next.Y).ToArgb() != pen.Color.ToArgb())
                {
                    Avalanche.Push(Next);
                }

                Next.X = Current.X - 1; Next.Y = Current.Y; // Òî÷êà ñëåâà
                if (bitmap.GetPixel(Next.X, Next.Y).ToArgb() != pen.Color.ToArgb())
                {
                    Avalanche.Push(Next);
                }

                Next.X = Current.X; Next.Y = Current.Y + 1; // Òî÷êà ñíèçó
                if (bitmap.GetPixel(Next.X, Next.Y).ToArgb() != pen.Color.ToArgb())
                {
                    Avalanche.Push(Next);
                }

                Next.X = Current.X; Next.Y = Current.Y - 1; // Òî÷êà ñâåðõó
                if (bitmap.GetPixel(Next.X, Next.Y).ToArgb() != pen.Color.ToArgb())
                {
                    Avalanche.Push(Next);
                }
            }
        }
        private void òåñòToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int R, N;
            int[] data;
            Check(out R, out N, out data, TestPath);

            AnswerForm form = new AnswerForm((double)R / (double)N, data);
            form.ShowDialog();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            string answer = Calculator.Analyze(ExampleBox.Text);
            if (answer == "---")
            {
                MessageBox.Show("Îøèáêà! Óðàâíåíèå çàïèñàíî íåïðàâèëüíî!");
            }
            else
                AnswerBox.Text = answer;
        }

        private void AnswerLabel_Click(object sender, EventArgs e)
        {

        }
        private void íàñòðîéêèToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Form_FormClosed1(object? sender, FormClosedEventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void îáó÷åíèåToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void òåñòToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çàãðóçêàÂåñîâToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
