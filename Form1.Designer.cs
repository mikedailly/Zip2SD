namespace Zip2SD
{
    partial class Form1
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
            this.ZipPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TargetSDImage = new System.Windows.Forms.TextBox();
            this.FilelistBox = new System.Windows.Forms.ListBox();
            this.BuildButton = new System.Windows.Forms.Button();
            this.LabelText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SizeCombo = new System.Windows.Forms.ComboBox();
            this.FormatCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ZipPath
            // 
            this.ZipPath.Location = new System.Drawing.Point(159, 45);
            this.ZipPath.Name = "ZipPath";
            this.ZipPath.Size = new System.Drawing.Size(532, 23);
            this.ZipPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source ZIP file";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(296, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "ZIP to SD Card Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(10, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Target IMG file";
            // 
            // TargetSDImage
            // 
            this.TargetSDImage.Location = new System.Drawing.Point(159, 100);
            this.TargetSDImage.Name = "TargetSDImage";
            this.TargetSDImage.Size = new System.Drawing.Size(532, 23);
            this.TargetSDImage.TabIndex = 4;
            this.TargetSDImage.Text = "ZXNext.img";
            // 
            // FilelistBox
            // 
            this.FilelistBox.FormattingEnabled = true;
            this.FilelistBox.ItemHeight = 15;
            this.FilelistBox.Location = new System.Drawing.Point(12, 192);
            this.FilelistBox.Name = "FilelistBox";
            this.FilelistBox.Size = new System.Drawing.Size(732, 199);
            this.FilelistBox.TabIndex = 6;
            // 
            // BuildButton
            // 
            this.BuildButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BuildButton.Location = new System.Drawing.Point(586, 409);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(158, 54);
            this.BuildButton.TabIndex = 7;
            this.BuildButton.Text = "BUILD";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // LabelText
            // 
            this.LabelText.Location = new System.Drawing.Point(627, 163);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(117, 23);
            this.LabelText.TabIndex = 9;
            this.LabelText.Text = "ZXNEXT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(568, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Label";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(301, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Size";
            // 
            // SizeCombo
            // 
            this.SizeCombo.FormattingEnabled = true;
            this.SizeCombo.Items.AddRange(new object[] {
            "128MB",
            "256MB",
            "512MB",
            "1GB",
            "4GB",
            "8GB",
            "16GB",
            "32GB",
            "64GB",
            "128GB",
            "256GB",
            "512GB"});
            this.SizeCombo.Location = new System.Drawing.Point(347, 161);
            this.SizeCombo.Name = "SizeCombo";
            this.SizeCombo.Size = new System.Drawing.Size(121, 23);
            this.SizeCombo.TabIndex = 12;
            // 
            // FormatCombo
            // 
            this.FormatCombo.FormattingEnabled = true;
            this.FormatCombo.Items.AddRange(new object[] {
            "Fat12",
            "Fat16",
            "Fat32"});
            this.FormatCombo.Location = new System.Drawing.Point(89, 164);
            this.FormatCombo.Name = "FormatCombo";
            this.FormatCombo.Size = new System.Drawing.Size(121, 23);
            this.FormatCombo.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(15, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Format";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 440);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(556, 23);
            this.progressBar.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(240, 409);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Build Process";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(697, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 25);
            this.button3.TabIndex = 17;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 475);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.FormatCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SizeCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LabelText);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.FilelistBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TargetSDImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ZipPath);
            this.Name = "Form1";
            this.Text = "Zip2SD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        public TextBox LabelText;
        public ComboBox SizeCombo;
        public ComboBox FormatCombo;
        public TextBox TargetSDImage;
        public TextBox ZipPath;
        private Label label7;
        public ProgressBar progressBar;
        private Button button3;
        public Button BuildButton;
        public ListBox FilelistBox;
    }
}