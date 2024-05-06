// ********************************************************************************************************************
//
//  Zip to SD Card Image by Mike Dailly, (c) Copyright Ogre Games Ltd. 2024, All rights reserved.
//
//  Released under GPL 3.0
//
// ********************************************************************************************************************
using System.Diagnostics;
using System.IO.Compression;

namespace Zip2SD
{
    internal static class Program
    {
        /// <summary>Path+name of hdf monkey exe</summary>
        public const string HDFMONEY_PATH = "hdfmonkey.exe";
        /// <summary>Primary form</summary>
        public static Form1? MainForm;

        // ***************************************************************************************************
        /// <summary>
        ///     Spawn HDF Money with specific args
        /// </summary>
        /// <param name="args">Arguments for HDF Monkey</param>
        // ***************************************************************************************************
        public static void SpawnHDFMonkey(params string[] _args)
        {
            string arguments = "";
            for (int i = 0; i < _args.Length; i++)
            {
                arguments += _args[i];
                if (i != (_args.Length - 1)) arguments += " ";

            }

            Process hdfmonkey = new Process();
            hdfmonkey.StartInfo.FileName = HDFMONEY_PATH;
            hdfmonkey.StartInfo.Arguments = arguments;
            hdfmonkey.StartInfo.CreateNoWindow = true;
            hdfmonkey.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            hdfmonkey.StartInfo.UseShellExecute = false;
            hdfmonkey.Start();
            hdfmonkey.WaitForExit();
        }


        // ***************************************************************************************************
        /// <summary>
        ///     Copy a ZIP file to an SD Card Image
        /// </summary>
        /// <param name="_zipPath"></param>
        // ***************************************************************************************************
        static void CopyZip(string _zipPath, string _imgPath)
        {
            if (MainForm != null)
            {
                try
                {
                    string temp_file = Path.GetTempFileName();
                    string DestFilename = "";

                    // Open the ZIP file
                    using (ZipArchive archive = ZipFile.OpenRead(_zipPath))
                    {
                        MainForm.progressBar.Maximum = archive.Entries.Count;
                        MainForm.progressBar.Value = 0;
                        MainForm.FilelistBox.Items.Clear();

                        int count = 1;
                        int max_count = 5;
                        // and loop through all files and folders in the file.
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            MainForm.progressBar.Value++;
                            DestFilename = entry.FullName;

                            // Delete the old file
                            if (File.Exists(temp_file)) File.Delete(temp_file);

                            // Do we have a directory entry?
                            if (entry.Length > 0)
                            {
                                // extract
                                entry.ExtractToFile(temp_file);
                                // and copy to the SD card image
                                SpawnHDFMonkey("put", _imgPath, temp_file, DestFilename);
                            }
                            else
                            {
                                // If we have a directory, then remove the end / if we have one
                                if (DestFilename.EndsWith('/') || DestFilename.EndsWith("\\"))
                                {
                                    DestFilename = DestFilename.Substring(0, DestFilename.Length - 1);
                                }
                                // then make the new directory
                                SpawnHDFMonkey("mkdir", _imgPath, DestFilename);
                            }

                            // Add extracted files to view
                            MainForm.FilelistBox.Items.Add(DestFilename);
                            MainForm.FilelistBox.SelectedIndex = MainForm.FilelistBox.Items.Count - 1;

                            count--;
                            if (count <= 0)
                            {
                                Application.DoEvents();
                                count = max_count;
                            }
                        }
                        MainForm.progressBar.Value = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error building SD Card image." + Environment.NewLine + ex.Message, "ERROR");
                    return;
                }
            }
        }

        // **************************************************************************************************
        /// <summary>
        ///     Create a new SD card image using user preferences
        /// </summary>
        /// <param name="_imagePath"></param>
        // **************************************************************************************************
        static void CreateSDImage(string _imagePath, string SDSize, string format, string LabelText)
        {
            SpawnHDFMonkey("create", format, _imagePath, SDSize, LabelText);
        }

        // **************************************************************************************************
        /// <summary>
        ///     Create an SD card image from a ZIP file
        /// </summary>
        /// <param name="args"></param>
        // **************************************************************************************************
        public static void BuildSDCard(string ZipPath, string TargetSDImage, string SDSize, string format, string LabelText)
        {
            CreateSDImage(TargetSDImage, SDSize, format, LabelText);

            CopyZip(ZipPath, TargetSDImage);
        }


        // **************************************************************************************************
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // **************************************************************************************************
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MainForm = new Form1();
            Application.Run(MainForm);
        }
    }
}