// ********************************************************************************************************************
//
//  Zip to SD Card Image by Mike Dailly, (c) Copyright Ogre Games Ltd. 2024, All rights reserved.
//
//  Released under GPL 3.0
//
// ********************************************************************************************************************
namespace Zip2SD
{
    public partial class Form1 : Form
    {
        /// <summary>Sizes we allow (2G doesn't work)</summary>
        public static string[] Sizes = new string[] { "128M", "256M", "512M", "1G", "4G","8G","16G", "32G", "64G", "128G", "256G", "512G" };
        /// <summary>Formats we allow</summary>
        public static string[] Formats = new string[] { "--fat12", "--fat16", "--fat32" };
        public Form1()
        {
            InitializeComponent();

            SizeCombo.SelectedIndex = 4;
            FormatCombo.SelectedIndex = 2;
        }

        // ************************************************************************************
        /// <summary>
        ///     Select ZIP file to open
        /// </summary>
        // ************************************************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Zip Files (*.zip)|*.zip|All Files (*.*)|*.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() != DialogResult.OK) return;
            ZipPath.Text = dlg.FileName;
            
        }

        // ************************************************************************************
        /// <summary>
        ///     SD Card Image File+Path selection
        /// </summary>
        // ************************************************************************************
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = TargetSDImage.Text;
            dlg.Filter = "Image File (*.img)|*.img|All Files (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            TargetSDImage.Text = dlg.FileName;
        }

        // ************************************************************************************
        /// <summary>
        ///     Validate the file selected is there, and a ZIP file - as much as we can....
        /// </summary>
        /// <param name="_filename">ZIP filename</param>
        /// <returns>
        ///     true for found
        ///     false for error
        /// </returns>
        // ************************************************************************************
        private bool ValidateZip(string _filename)
        {
            // Does the ZIP exist?
            if (!File.Exists(_filename))
            {
                MessageBox.Show("Error, can't find requested ZIP file.", "Error");
                return false;
            }

            FileStream file = File.Open(_filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.Read);
            long len = file.Length;
            byte[] buff = new byte[4];
            file.Read(buff, 0, 2);
            file.Close();
            file.Dispose();

            // Found a ZIP file - starts with PK
            if (buff[0] == 0x50 && buff[1] == 0x4B)
            {
                return true;
            }

            return false;
        }

        // ************************************************************************************
        /// <summary>
        ///     BUILD button pressed
        /// </summary>
        // ************************************************************************************
        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidateZip(ZipPath.Text)) return;

            BuildButton.Enabled= false;
            Program.BuildSDCard(ZipPath.Text, TargetSDImage.Text, Sizes[SizeCombo.SelectedIndex], Formats[FormatCombo.SelectedIndex], LabelText.Text);
            BuildButton.Enabled = true;
        }
    }
}