// ********************************************************************************************************************
//
//  Zip to SD Card Image by Mike Dailly, (c) Copyright Ogre Games Ltd. 2024, All rights reserved.
//
//  Released under GPL 3.0
//
//  hdfmonkey released under GPL 3.0, and source fork available at
//  https://github.com/mikedailly/hdfmonkey
//
// ********************************************************************************************************************
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using static System.Windows.Forms.DataFormats;

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
            //if (MainForm != null)
            {
                try
                {
                    string temp_file = Path.GetTempFileName();
                    string DestFilename = "";

                    // Open the ZIP file
                    using (ZipArchive archive = ZipFile.OpenRead(_zipPath))
                    {
                        if (MainForm != null)
                        {
                            MainForm.progressBar.Maximum = archive.Entries.Count;
                            MainForm.progressBar.Value = 0;
                            MainForm.FilelistBox.Items.Clear();
                        }
                        int count = 1;
                        int max_count = 5;
                        // and loop through all files and folders in the file.
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (MainForm != null) MainForm.progressBar.Value++;
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
                            if (MainForm != null)
                            {
                                MainForm.FilelistBox.Items.Add(DestFilename);
                                MainForm.FilelistBox.SelectedIndex = MainForm.FilelistBox.Items.Count - 1;
                            }

                            count--;
                            if (count <= 0)
                            {
                                Application.DoEvents();
                                count = max_count;
                            }
                        }
                        if (MainForm != null) MainForm.progressBar.Value = 0;
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

            Console.WriteLine("Building SD Card Image");
            CopyZip(ZipPath, TargetSDImage);
            Console.WriteLine("Building SD Card Image - Done");
        }


        // **************************************************************************************************
        /// <summary>
        ///     Automate the building of the SD Card Image
        /// </summary>
        /// <param name="_args">Commandline arguments</param>
        // **************************************************************************************************
        public static void ParseCommandLine(string[] _args)
        {
            //-src="C:\source\ZXSpectrum\_Demos\_NEXTROM\sn-complete-24.11.zip" -dest="C:\source\ZXSpectrum\_Demos\_NEXTROM\ZXIMAGE.IMG" -fat32 -4gb
            //if ()

            string ZipPath = "";
            string TargetSDImage = "";
            string size = Form1.Sizes[4];
            string fat = Form1.Formats[2];
            int index = 0;
            while (index < _args.Length)
            {
                string a = _args[index++];
                if (a.StartsWith("-src=")) 
                {
                    ZipPath = a.Substring(5);
                }
                else if (a.StartsWith("-dest="))
                {
                    TargetSDImage = a.Substring(6);
                }
                else if (a=="-fat12") fat = Form1.Formats[0];
                else if (a=="-fat16") fat = Form1.Formats[1];
                else if (a=="-fat32") fat = Form1.Formats[2];
                else if (a=="-1gb") size = Form1.Sizes[3];
                else if (a=="-2gb") size = Form1.Sizes[4];
                else if (a=="-4gb") size = Form1.Sizes[4];
                else if (a == "-8gb") size = Form1.Sizes[5];
                else if (a == "-16gb") size = Form1.Sizes[6];
                else if (a == "-32gb") size = Form1.Sizes[7];
            }


            Program.BuildSDCard(ZipPath, TargetSDImage, size, fat, "ZXNext");
        }

        // **************************************************************************************************
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // **************************************************************************************************
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                ParseCommandLine(args);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MainForm = new Form1();
            Application.Run(MainForm);
        }
    }
}