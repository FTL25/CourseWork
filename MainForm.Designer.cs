namespace CourseWork
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            очиститьЭкранToolStripMenuItem = new ToolStripMenuItem();
            распознаваниеToolStripMenuItem = new ToolStripMenuItem();
            авпToolStripMenuItem = new ToolStripMenuItem();
            поискToolStripMenuItem = new ToolStripMenuItem();
            обучениеToolStripMenuItem1 = new ToolStripMenuItem();
            тестToolStripMenuItem1 = new ToolStripMenuItem();
            сохранитьВесаToolStripMenuItem = new ToolStripMenuItem();
            загрузкаВесовToolStripMenuItem1 = new ToolStripMenuItem();
            выходToolStripMenuItem1 = new ToolStripMenuItem();
            ExampleBox = new TextBox();
            InfoLabel = new Label();
            EnterButton = new Button();
            AnswerLabel = new Label();
            AnswerBox = new TextBox();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { справкаToolStripMenuItem, очиститьЭкранToolStripMenuItem, распознаваниеToolStripMenuItem, авпToolStripMenuItem, выходToolStripMenuItem1 });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(802, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(81, 24);
            справкаToolStripMenuItem.Text = "Справка";
            справкаToolStripMenuItem.Click += справкаToolStripMenuItem_Click;
            // 
            // очиститьЭкранToolStripMenuItem
            // 
            очиститьЭкранToolStripMenuItem.Name = "очиститьЭкранToolStripMenuItem";
            очиститьЭкранToolStripMenuItem.Size = new Size(131, 24);
            очиститьЭкранToolStripMenuItem.Text = "Очистить экран";
            очиститьЭкранToolStripMenuItem.Click += очиститьЭкранToolStripMenuItem_Click;
            // 
            // распознаваниеToolStripMenuItem
            // 
            распознаваниеToolStripMenuItem.Name = "распознаваниеToolStripMenuItem";
            распознаваниеToolStripMenuItem.Size = new Size(130, 24);
            распознаваниеToolStripMenuItem.Text = "Распознавание";
            распознаваниеToolStripMenuItem.Click += распознаваниеToolStripMenuItem_Click;
            // 
            // авпToolStripMenuItem
            // 
            авпToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { поискToolStripMenuItem, обучениеToolStripMenuItem1, тестToolStripMenuItem1, сохранитьВесаToolStripMenuItem, загрузкаВесовToolStripMenuItem1 });
            авпToolStripMenuItem.Name = "авпToolStripMenuItem";
            авпToolStripMenuItem.Size = new Size(98, 24);
            авпToolStripMenuItem.Text = "Настройки";
            // 
            // поискToolStripMenuItem
            // 
            поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            поискToolStripMenuItem.Size = new Size(224, 26);
            поискToolStripMenuItem.Text = "Поиск";
            поискToolStripMenuItem.Click += поискToolStripMenuItem_Click;
            // 
            // обучениеToolStripMenuItem1
            // 
            обучениеToolStripMenuItem1.Name = "обучениеToolStripMenuItem1";
            обучениеToolStripMenuItem1.Size = new Size(224, 26);
            обучениеToolStripMenuItem1.Text = "Обучение";
            обучениеToolStripMenuItem1.Click += обучениеToolStripMenuItem1_Click;
            // 
            // тестToolStripMenuItem1
            // 
            тестToolStripMenuItem1.Name = "тестToolStripMenuItem1";
            тестToolStripMenuItem1.Size = new Size(224, 26);
            тестToolStripMenuItem1.Text = "Тест";
            тестToolStripMenuItem1.Click += тестToolStripMenuItem1_Click;
            // 
            // сохранитьВесаToolStripMenuItem
            // 
            сохранитьВесаToolStripMenuItem.Name = "сохранитьВесаToolStripMenuItem";
            сохранитьВесаToolStripMenuItem.Size = new Size(224, 26);
            сохранитьВесаToolStripMenuItem.Text = "Сохранить веса";
            сохранитьВесаToolStripMenuItem.Click += сохранитьВесаToolStripMenuItem_Click;
            // 
            // загрузкаВесовToolStripMenuItem1
            // 
            загрузкаВесовToolStripMenuItem1.Name = "загрузкаВесовToolStripMenuItem1";
            загрузкаВесовToolStripMenuItem1.Size = new Size(224, 26);
            загрузкаВесовToolStripMenuItem1.Text = "Загрузка весов";
            загрузкаВесовToolStripMenuItem1.Click += загрузкаВесовToolStripMenuItem1_Click;
            // 
            // выходToolStripMenuItem1
            // 
            выходToolStripMenuItem1.Name = "выходToolStripMenuItem1";
            выходToolStripMenuItem1.Size = new Size(67, 24);
            выходToolStripMenuItem1.Text = "Выход";
            выходToolStripMenuItem1.Click += выходToolStripMenuItem1_Click;
            // 
            // ExampleBox
            // 
            ExampleBox.BackColor = SystemColors.Info;
            ExampleBox.Font = new Font("Segoe UI", 10F);
            ExampleBox.Location = new Point(20, 190);
            ExampleBox.Multiline = true;
            ExampleBox.Name = "ExampleBox";
            ExampleBox.Size = new Size(395, 91);
            ExampleBox.TabIndex = 1;
            // 
            // InfoLabel
            // 
            InfoLabel.AutoSize = true;
            InfoLabel.Font = new Font("Segoe UI", 10F);
            InfoLabel.Location = new Point(20, 305);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(240, 92);
            InfoLabel.TabIndex = 3;
            InfoLabel.Text = "Если калькулятор распознал \r\nваш пример неправильно,\r\nперепишите рукописные \r\nсимволы";
            InfoLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // EnterButton
            // 
            EnterButton.BackColor = SystemColors.ActiveCaption;
            EnterButton.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            EnterButton.FlatStyle = FlatStyle.Flat;
            EnterButton.Font = new Font("Segoe UI", 10F);
            EnterButton.Location = new Point(274, 305);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(141, 56);
            EnterButton.TabIndex = 4;
            EnterButton.Text = "Рассчитать";
            EnterButton.UseVisualStyleBackColor = false;
            EnterButton.Click += EnterButton_Click;
            // 
            // AnswerLabel
            // 
            AnswerLabel.AutoSize = true;
            AnswerLabel.Font = new Font("Segoe UI", 10F);
            AnswerLabel.Location = new Point(437, 322);
            AnswerLabel.Name = "AnswerLabel";
            AnswerLabel.Size = new Size(59, 23);
            AnswerLabel.TabIndex = 5;
            AnswerLabel.Text = "Ответ:";
            AnswerLabel.Click += AnswerLabel_Click;
            // 
            // AnswerBox
            // 
            AnswerBox.BackColor = SystemColors.Info;
            AnswerBox.Font = new Font("Segoe UI", 10F);
            AnswerBox.Location = new Point(502, 322);
            AnswerBox.Name = "AnswerBox";
            AnswerBox.Size = new Size(288, 30);
            AnswerBox.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(802, 415);
            Controls.Add(AnswerBox);
            Controls.Add(AnswerLabel);
            Controls.Add(EnterButton);
            Controls.Add(InfoLabel);
            Controls.Add(ExampleBox);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "Калькулятор с рукописным вводом";
            Load += MainForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem выходToolStripMenuItem1;
        private ToolStripMenuItem очиститьЭкранToolStripMenuItem;
        private ToolStripMenuItem распознаваниеToolStripMenuItem;
        private TextBox ExampleBox;
        private Label InfoLabel;
        private Button EnterButton;
        private Label AnswerLabel;
        private TextBox AnswerBox;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem авпToolStripMenuItem;
        private ToolStripMenuItem обучениеToolStripMenuItem1;
        private ToolStripMenuItem тестToolStripMenuItem1;
        private ToolStripMenuItem загрузкаВесовToolStripMenuItem1;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem поискToolStripMenuItem;
        private ToolStripMenuItem сохранитьВесаToolStripMenuItem;
    }
}
