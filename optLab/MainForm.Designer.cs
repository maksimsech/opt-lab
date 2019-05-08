namespace optLab
{
    partial class MainForm
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
            this.funcLabel = new System.Windows.Forms.Label();
            this.limitLabel = new System.Windows.Forms.Label();
            this.funcTextBox = new System.Windows.Forms.TextBox();
            this.limitGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftTextBox = new System.Windows.Forms.TextBox();
            this.rightTextBox = new System.Windows.Forms.TextBox();
            this.leftLabel = new System.Windows.Forms.Label();
            this.signLabel = new System.Windows.Forms.Label();
            this.rightLabel = new System.Windows.Forms.Label();
            this.signComboBox = new System.Windows.Forms.ComboBox();
            this.methodLabel = new System.Windows.Forms.Label();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.MakeButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.addInfoLabel = new System.Windows.Forms.Label();
            this.addInfoTextBox = new System.Windows.Forms.TextBox();
            this.upBorderLabel = new System.Windows.Forms.Label();
            this.botBorderLabel = new System.Windows.Forms.Label();
            this.botBorderTextBox = new System.Windows.Forms.TextBox();
            this.upBorderTextBox = new System.Windows.Forms.TextBox();
            this.x1TextBox = new System.Windows.Forms.TextBox();
            this.x2TextBox = new System.Windows.Forms.TextBox();
            this.x2Label = new System.Windows.Forms.Label();
            this.x1Label = new System.Windows.Forms.Label();
            this.fxLabel = new System.Windows.Forms.Label();
            this.fxTextBox = new System.Windows.Forms.TextBox();
            this.resultGridView = new System.Windows.Forms.DataGridView();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addResultTextBox = new System.Windows.Forms.TextBox();
            this.addResultLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.hjX1TextBox = new System.Windows.Forms.TextBox();
            this.hjX2TextBox = new System.Windows.Forms.TextBox();
            this.hjX1Label = new System.Windows.Forms.Label();
            this.hjX2Label = new System.Windows.Forms.Label();
            this.rLabel = new System.Windows.Forms.Label();
            this.rTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.limitGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // funcLabel
            // 
            this.funcLabel.AutoSize = true;
            this.funcLabel.Location = new System.Drawing.Point(4, 12);
            this.funcLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.funcLabel.Name = "funcLabel";
            this.funcLabel.Size = new System.Drawing.Size(41, 13);
            this.funcLabel.TabIndex = 0;
            this.funcLabel.Text = "f(x1,x2)";
            // 
            // limitLabel
            // 
            this.limitLabel.AutoSize = true;
            this.limitLabel.Location = new System.Drawing.Point(7, 39);
            this.limitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(73, 13);
            this.limitLabel.TabIndex = 1;
            this.limitLabel.Text = "Ограничения";
            // 
            // funcTextBox
            // 
            this.funcTextBox.Location = new System.Drawing.Point(52, 10);
            this.funcTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.funcTextBox.Name = "funcTextBox";
            this.funcTextBox.Size = new System.Drawing.Size(263, 20);
            this.funcTextBox.TabIndex = 1;
            // 
            // limitGridView
            // 
            this.limitGridView.AllowUserToAddRows = false;
            this.limitGridView.AllowUserToDeleteRows = false;
            this.limitGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.limitGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.limitGridView.Location = new System.Drawing.Point(7, 55);
            this.limitGridView.Margin = new System.Windows.Forms.Padding(2);
            this.limitGridView.Name = "limitGridView";
            this.limitGridView.ReadOnly = true;
            this.limitGridView.RowHeadersVisible = false;
            this.limitGridView.RowTemplate.Height = 24;
            this.limitGridView.Size = new System.Drawing.Size(307, 201);
            this.limitGridView.TabIndex = 2;
            this.limitGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.limitGridView_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Условие";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Знак";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Значение";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // leftTextBox
            // 
            this.leftTextBox.Location = new System.Drawing.Point(46, 261);
            this.leftTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.leftTextBox.Name = "leftTextBox";
            this.leftTextBox.Size = new System.Drawing.Size(54, 20);
            this.leftTextBox.TabIndex = 3;
            // 
            // rightTextBox
            // 
            this.rightTextBox.Location = new System.Drawing.Point(232, 262);
            this.rightTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.rightTextBox.Name = "rightTextBox";
            this.rightTextBox.Size = new System.Drawing.Size(36, 20);
            this.rightTextBox.TabIndex = 5;
            // 
            // leftLabel
            // 
            this.leftLabel.AutoSize = true;
            this.leftLabel.Location = new System.Drawing.Point(4, 263);
            this.leftLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.Size = new System.Drawing.Size(39, 13);
            this.leftLabel.TabIndex = 6;
            this.leftLabel.Text = "Левая";
            // 
            // signLabel
            // 
            this.signLabel.AutoSize = true;
            this.signLabel.Location = new System.Drawing.Point(103, 263);
            this.signLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.signLabel.Name = "signLabel";
            this.signLabel.Size = new System.Drawing.Size(32, 13);
            this.signLabel.TabIndex = 7;
            this.signLabel.Text = "Знак";
            // 
            // rightLabel
            // 
            this.rightLabel.AutoSize = true;
            this.rightLabel.Location = new System.Drawing.Point(184, 263);
            this.rightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rightLabel.Name = "rightLabel";
            this.rightLabel.Size = new System.Drawing.Size(45, 13);
            this.rightLabel.TabIndex = 8;
            this.rightLabel.Text = "Правая";
            // 
            // signComboBox
            // 
            this.signComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.signComboBox.FormattingEnabled = true;
            this.signComboBox.Items.AddRange(new object[] {
            ">=",
            ">",
            "<=",
            "<"});
            this.signComboBox.Location = new System.Drawing.Point(137, 261);
            this.signComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.signComboBox.Name = "signComboBox";
            this.signComboBox.Size = new System.Drawing.Size(44, 21);
            this.signComboBox.TabIndex = 4;
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.Location = new System.Drawing.Point(4, 294);
            this.methodLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(39, 13);
            this.methodLabel.TabIndex = 10;
            this.methodLabel.Text = "Метод";
            // 
            // methodComboBox
            // 
            this.methodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Items.AddRange(new object[] {
            "Метод прямого перебора по сетке",
            "Метод Монте-Карло",
            "Метод Хука-Дживса",
            "Метод штрафных функций"});
            this.methodComboBox.Location = new System.Drawing.Point(56, 292);
            this.methodComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(259, 21);
            this.methodComboBox.TabIndex = 7;
            this.methodComboBox.SelectedIndexChanged += new System.EventHandler(this.methodComboBox_SelectedIndexChanged);
            // 
            // MakeButton
            // 
            this.MakeButton.Location = new System.Drawing.Point(162, 316);
            this.MakeButton.Margin = new System.Windows.Forms.Padding(2);
            this.MakeButton.Name = "MakeButton";
            this.MakeButton.Size = new System.Drawing.Size(74, 27);
            this.MakeButton.TabIndex = 11;
            this.MakeButton.Text = "Вычислить";
            this.MakeButton.UseVisualStyleBackColor = true;
            this.MakeButton.Click += new System.EventHandler(this.MakeButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(272, 261);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(42, 20);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Доб.";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // addInfoLabel
            // 
            this.addInfoLabel.AutoSize = true;
            this.addInfoLabel.Location = new System.Drawing.Point(9, 364);
            this.addInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addInfoLabel.Name = "addInfoLabel";
            this.addInfoLabel.Size = new System.Drawing.Size(0, 13);
            this.addInfoLabel.TabIndex = 14;
            this.addInfoLabel.Visible = false;
            // 
            // addInfoTextBox
            // 
            this.addInfoTextBox.Location = new System.Drawing.Point(56, 362);
            this.addInfoTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.addInfoTextBox.Name = "addInfoTextBox";
            this.addInfoTextBox.Size = new System.Drawing.Size(48, 20);
            this.addInfoTextBox.TabIndex = 10;
            this.addInfoTextBox.Visible = false;
            // 
            // upBorderLabel
            // 
            this.upBorderLabel.AutoSize = true;
            this.upBorderLabel.Location = new System.Drawing.Point(4, 341);
            this.upBorderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.upBorderLabel.Name = "upBorderLabel";
            this.upBorderLabel.Size = new System.Drawing.Size(49, 13);
            this.upBorderLabel.TabIndex = 16;
            this.upBorderLabel.Text = "Верхняя";
            this.upBorderLabel.Visible = false;
            // 
            // botBorderLabel
            // 
            this.botBorderLabel.AutoSize = true;
            this.botBorderLabel.Location = new System.Drawing.Point(4, 318);
            this.botBorderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.botBorderLabel.Name = "botBorderLabel";
            this.botBorderLabel.Size = new System.Drawing.Size(47, 13);
            this.botBorderLabel.TabIndex = 17;
            this.botBorderLabel.Text = "Нижняя";
            this.botBorderLabel.Visible = false;
            // 
            // botBorderTextBox
            // 
            this.botBorderTextBox.Location = new System.Drawing.Point(56, 316);
            this.botBorderTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.botBorderTextBox.Name = "botBorderTextBox";
            this.botBorderTextBox.Size = new System.Drawing.Size(48, 20);
            this.botBorderTextBox.TabIndex = 8;
            this.botBorderTextBox.Visible = false;
            // 
            // upBorderTextBox
            // 
            this.upBorderTextBox.Location = new System.Drawing.Point(56, 339);
            this.upBorderTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.upBorderTextBox.Name = "upBorderTextBox";
            this.upBorderTextBox.Size = new System.Drawing.Size(48, 20);
            this.upBorderTextBox.TabIndex = 9;
            this.upBorderTextBox.Visible = false;
            // 
            // x1TextBox
            // 
            this.x1TextBox.Location = new System.Drawing.Point(436, 16);
            this.x1TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.x1TextBox.Name = "x1TextBox";
            this.x1TextBox.Size = new System.Drawing.Size(76, 20);
            this.x1TextBox.TabIndex = 26;
            // 
            // x2TextBox
            // 
            this.x2TextBox.Location = new System.Drawing.Point(535, 16);
            this.x2TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.x2TextBox.Name = "x2TextBox";
            this.x2TextBox.Size = new System.Drawing.Size(76, 20);
            this.x2TextBox.TabIndex = 25;
            // 
            // x2Label
            // 
            this.x2Label.AutoSize = true;
            this.x2Label.Location = new System.Drawing.Point(516, 19);
            this.x2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.x2Label.Name = "x2Label";
            this.x2Label.Size = new System.Drawing.Size(18, 13);
            this.x2Label.TabIndex = 24;
            this.x2Label.Text = "x2";
            // 
            // x1Label
            // 
            this.x1Label.AutoSize = true;
            this.x1Label.Location = new System.Drawing.Point(416, 19);
            this.x1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.x1Label.Name = "x1Label";
            this.x1Label.Size = new System.Drawing.Size(18, 13);
            this.x1Label.TabIndex = 23;
            this.x1Label.Text = "x1";
            // 
            // fxLabel
            // 
            this.fxLabel.AutoSize = true;
            this.fxLabel.Location = new System.Drawing.Point(318, 19);
            this.fxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fxLabel.Name = "fxLabel";
            this.fxLabel.Size = new System.Drawing.Size(15, 13);
            this.fxLabel.TabIndex = 22;
            this.fxLabel.Text = "fx";
            // 
            // fxTextBox
            // 
            this.fxTextBox.Location = new System.Drawing.Point(336, 16);
            this.fxTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.fxTextBox.Name = "fxTextBox";
            this.fxTextBox.Size = new System.Drawing.Size(76, 20);
            this.fxTextBox.TabIndex = 21;
            // 
            // resultGridView
            // 
            this.resultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGridView.ColumnHeadersVisible = false;
            this.resultGridView.Location = new System.Drawing.Point(318, 39);
            this.resultGridView.Margin = new System.Windows.Forms.Padding(2);
            this.resultGridView.Name = "resultGridView";
            this.resultGridView.RowHeadersVisible = false;
            this.resultGridView.RowTemplate.Height = 24;
            this.resultGridView.Size = new System.Drawing.Size(292, 256);
            this.resultGridView.TabIndex = 27;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(616, 10);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 500);
            this.pictureBox.TabIndex = 28;
            this.pictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 431);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 19);
            this.button1.TabIndex = 29;
            this.button1.Text = "Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addResultTextBox
            // 
            this.addResultTextBox.Location = new System.Drawing.Point(394, 300);
            this.addResultTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.addResultTextBox.Name = "addResultTextBox";
            this.addResultTextBox.Size = new System.Drawing.Size(76, 20);
            this.addResultTextBox.TabIndex = 30;
            // 
            // addResultLabel
            // 
            this.addResultLabel.AutoSize = true;
            this.addResultLabel.Location = new System.Drawing.Point(318, 302);
            this.addResultLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addResultLabel.Name = "addResultLabel";
            this.addResultLabel.Size = new System.Drawing.Size(72, 13);
            this.addResultLabel.TabIndex = 31;
            this.addResultLabel.Text = "Кол-во точек";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(499, 455);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 19);
            this.button2.TabIndex = 32;
            this.button2.Text = "levels";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // hjX1TextBox
            // 
            this.hjX1TextBox.Location = new System.Drawing.Point(56, 387);
            this.hjX1TextBox.Name = "hjX1TextBox";
            this.hjX1TextBox.Size = new System.Drawing.Size(48, 20);
            this.hjX1TextBox.TabIndex = 33;
            // 
            // hjX2TextBox
            // 
            this.hjX2TextBox.Location = new System.Drawing.Point(56, 413);
            this.hjX2TextBox.Name = "hjX2TextBox";
            this.hjX2TextBox.Size = new System.Drawing.Size(48, 20);
            this.hjX2TextBox.TabIndex = 34;
            // 
            // hjX1Label
            // 
            this.hjX1Label.AutoSize = true;
            this.hjX1Label.Location = new System.Drawing.Point(4, 390);
            this.hjX1Label.Name = "hjX1Label";
            this.hjX1Label.Size = new System.Drawing.Size(18, 13);
            this.hjX1Label.TabIndex = 35;
            this.hjX1Label.Text = "x1";
            // 
            // hjX2Label
            // 
            this.hjX2Label.AutoSize = true;
            this.hjX2Label.Location = new System.Drawing.Point(4, 416);
            this.hjX2Label.Name = "hjX2Label";
            this.hjX2Label.Size = new System.Drawing.Size(18, 13);
            this.hjX2Label.TabIndex = 36;
            this.hjX2Label.Text = "x2";
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Location = new System.Drawing.Point(4, 442);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(10, 13);
            this.rLabel.TabIndex = 37;
            this.rLabel.Text = "r";
            // 
            // rTextBox
            // 
            this.rTextBox.Location = new System.Drawing.Point(56, 439);
            this.rTextBox.Name = "rTextBox";
            this.rTextBox.Size = new System.Drawing.Size(48, 20);
            this.rTextBox.TabIndex = 38;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 518);
            this.Controls.Add(this.rTextBox);
            this.Controls.Add(this.rLabel);
            this.Controls.Add(this.hjX2Label);
            this.Controls.Add(this.hjX1Label);
            this.Controls.Add(this.hjX2TextBox);
            this.Controls.Add(this.hjX1TextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.addResultLabel);
            this.Controls.Add(this.addResultTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.resultGridView);
            this.Controls.Add(this.x1TextBox);
            this.Controls.Add(this.x2TextBox);
            this.Controls.Add(this.x2Label);
            this.Controls.Add(this.x1Label);
            this.Controls.Add(this.fxLabel);
            this.Controls.Add(this.fxTextBox);
            this.Controls.Add(this.upBorderTextBox);
            this.Controls.Add(this.botBorderTextBox);
            this.Controls.Add(this.botBorderLabel);
            this.Controls.Add(this.upBorderLabel);
            this.Controls.Add(this.addInfoTextBox);
            this.Controls.Add(this.addInfoLabel);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.MakeButton);
            this.Controls.Add(this.methodComboBox);
            this.Controls.Add(this.methodLabel);
            this.Controls.Add(this.signComboBox);
            this.Controls.Add(this.rightLabel);
            this.Controls.Add(this.signLabel);
            this.Controls.Add(this.leftLabel);
            this.Controls.Add(this.rightTextBox);
            this.Controls.Add(this.leftTextBox);
            this.Controls.Add(this.limitGridView);
            this.Controls.Add(this.funcTextBox);
            this.Controls.Add(this.limitLabel);
            this.Controls.Add(this.funcLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.limitGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label funcLabel;
        private System.Windows.Forms.Label limitLabel;
        private System.Windows.Forms.TextBox funcTextBox;
        private System.Windows.Forms.DataGridView limitGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox leftTextBox;
        private System.Windows.Forms.TextBox rightTextBox;
        private System.Windows.Forms.Label leftLabel;
        private System.Windows.Forms.Label signLabel;
        private System.Windows.Forms.Label rightLabel;
        private System.Windows.Forms.ComboBox signComboBox;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Button MakeButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label addInfoLabel;
        private System.Windows.Forms.TextBox addInfoTextBox;
        private System.Windows.Forms.Label upBorderLabel;
        private System.Windows.Forms.Label botBorderLabel;
        private System.Windows.Forms.TextBox botBorderTextBox;
        private System.Windows.Forms.TextBox upBorderTextBox;
        private System.Windows.Forms.TextBox x1TextBox;
        private System.Windows.Forms.TextBox x2TextBox;
        private System.Windows.Forms.Label x2Label;
        private System.Windows.Forms.Label x1Label;
        private System.Windows.Forms.Label fxLabel;
        private System.Windows.Forms.TextBox fxTextBox;
        private System.Windows.Forms.DataGridView resultGridView;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox addResultTextBox;
        private System.Windows.Forms.Label addResultLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox hjX1TextBox;
        private System.Windows.Forms.TextBox hjX2TextBox;
        private System.Windows.Forms.Label hjX1Label;
        private System.Windows.Forms.Label hjX2Label;
        private System.Windows.Forms.Label rLabel;
        private System.Windows.Forms.TextBox rTextBox;
    }
}

