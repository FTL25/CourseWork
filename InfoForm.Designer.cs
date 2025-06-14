namespace CourseWork
{
    partial class InfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            Title1 = new Label();
            Text1 = new Label();
            Text2 = new Label();
            Title2 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // Title1
            // 
            Title1.AutoSize = true;
            Title1.Font = new Font("Segoe UI", 14F);
            Title1.Location = new Point(725, 9);
            Title1.Name = "Title1";
            Title1.Size = new Size(188, 32);
            Title1.TabIndex = 0;
            Title1.Text = "Ввод примеров";
            // 
            // Text1
            // 
            Text1.AutoSize = true;
            Text1.Font = new Font("Segoe UI", 10F);
            Text1.Location = new Point(468, 63);
            Text1.Name = "Text1";
            Text1.Size = new Size(737, 161);
            Text1.TabIndex = 1;
            Text1.Text = resources.GetString("Text1.Text");
            // 
            // Text2
            // 
            Text2.AutoSize = true;
            Text2.Font = new Font("Segoe UI", 10F);
            Text2.Location = new Point(625, 297);
            Text2.Name = "Text2";
            Text2.Size = new Size(432, 253);
            Text2.TabIndex = 2;
            Text2.Text = resources.GetString("Text2.Text");
            // 
            // Title2
            // 
            Title2.AutoSize = true;
            Title2.Font = new Font("Segoe UI", 14F);
            Title2.Location = new Point(745, 247);
            Title2.Name = "Title2";
            Title2.Size = new Size(152, 32);
            Title2.TabIndex = 3;
            Title2.Text = "Калькулятор";
            Title2.Click += Title2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 297);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(536, 234);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(413, 219);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // InfoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 567);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Title2);
            Controls.Add(Text2);
            Controls.Add(Text1);
            Controls.Add(Title1);
            Name = "InfoForm";
            Text = "Информация о программе";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title1;
        private Label Text1;
        private Label label1;
        private Label Text2;
        private Label Title2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}