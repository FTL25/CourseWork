using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AnswerForm : Form
    {
        public AnswerForm(double accuracy, int[] data)
        {
            InitializeComponent();

            AccuracyLabel.Text += accuracy.ToString();
            label1.Text += " - " + Convert.ToString(data[0]);
            label2.Text += " - " + Convert.ToString(data[1]);
            label3.Text += " - " + Convert.ToString(data[2]);
            label4.Text += " - " + Convert.ToString(data[3]);
            label5.Text += " - " + Convert.ToString(data[4]);
            label6.Text += " - " + Convert.ToString(data[5]);
            label7.Text += " - " + Convert.ToString(data[6]);
            label8.Text += " - " + Convert.ToString(data[7]);
            label9.Text += " - " + Convert.ToString(data[8]);
            label10.Text += " - " + Convert.ToString(data[9]);
            label11.Text += " - " + Convert.ToString(data[10]);
            label12.Text += " - " + Convert.ToString(data[11]);
            label13.Text += " - " + Convert.ToString(data[12]);
            label14.Text += " - " + Convert.ToString(data[13]);
            label15.Text += " - " + Convert.ToString(data[14]);
            label16.Text += " - " + Convert.ToString(data[15]);
            label17.Text += " - " + Convert.ToString(data[16]);

            progressBar1.Value = data[0];
            progressBar2.Value = data[1];
            progressBar3.Value = data[2];
            progressBar4.Value = data[3];
            progressBar5.Value = data[4];
            progressBar6.Value = data[5];
            progressBar7.Value = data[6];
            progressBar8.Value = data[7];
            progressBar9.Value = data[8];
            progressBar10.Value = data[9];
            progressBar11.Value = data[10];
            progressBar12.Value = data[11];
            progressBar13.Value = data[12];
            progressBar14.Value = data[13];
            progressBar15.Value = data[14];
            progressBar16.Value = data[15];
            progressBar17.Value = data[16];
            this.MouseDown += AnswerForm_MouseDown;
        }
        public AnswerForm(double[] data)
        {
            InitializeComponent();
            progressBar1.Value = Percent(data[0]);
            progressBar2.Value = Percent(data[1]);
            progressBar3.Value = Percent(data[2]);
            //progressBar4.Value = Percent(data[3]);
            //progressBar5.Value = Percent(data[4]);
            //progressBar6.Value = Percent(data[5]);
            //progressBar7.Value = Percent(data[6]);
            //progressBar8.Value = Percent(data[7]);
            //progressBar9.Value = Percent(data[8]);
            //progressBar10.Value = Percent(data[9]);
            //progressBar11.Value = Percent(data[10]);
            //progressBar12.Value = Percent(data[11]);
            //progressBar13.Value = Percent(data[12]);
            //progressBar14.Value = Percent(data[13]);
            //progressBar16.Value = Percent(data[15]);
            //progressBar17.Value = Percent(data[16]);
            this.MouseDown += AnswerForm_MouseDown;
        }

        private void AnswerForm_MouseDown(object? sender, MouseEventArgs e)
        {
            Close();
        }

        private int Percent(double x)
        {
            return (int)(x * 100);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AnswerForm_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void progressBar12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
