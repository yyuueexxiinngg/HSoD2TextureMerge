using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HSoD2TextureMerge
{
    public partial class MainForm : Form
    {
        String folderPath = "";

        // Store files unable to merge
        Dictionary<string, string> errorListMap;

        List<FileInfo> copyList;

        // Use these two sample file to extract pattern
        private String sampleRGBFilePath;
        private String sampleAlphaFilePath;

        // File map, <RGBFilePath, alphaFilePath>
        Dictionary<string, string> fileMap;

        public MainForm()
        {
            InitializeComponent();
            richTextBox_Console.AppendText(
                "Created By yyuueexxiinngg  : https://github.com/yyuueexxiinngg/HSoD2TextureMerge    / By 西城飘雪 : https://www.mihoyo.tech  " +
                "\nPlease select the folder contains all textures and make sure the alpha file name with suffix is in the same name and same folder as RGB image. " +
                "\n\n请选择包含所有贴图的父级文件夹 注意Alpha贴图后要与RGB贴图同名 + 自定义后缀(默认'_Alpha'), 且在同级文件夹下");
        }

        private void getFile(string path, Dictionary<string, string> fileMap)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles();
                DirectoryInfo[] dirChild = dir.GetDirectories();

                foreach (FileInfo file in files)
                {
                    if (file.FullName.IndexOf(textBox_Suffix.Text) == -1)
                    {
                        string fileExtension = file.Extension;
                        if (String.Equals(fileExtension, ".png", StringComparison.CurrentCultureIgnoreCase) ||
                            String.Equals(fileExtension, ".jpg", StringComparison.CurrentCultureIgnoreCase) ||
                            String.Equals(fileExtension, ".bmp", StringComparison.CurrentCultureIgnoreCase))
                        {
                            string alphaPath = file.FullName.Replace(fileExtension, "") + textBox_Suffix.Text +
                                               fileExtension;

                            if (File.Exists(alphaPath))
                            {
                                fileMap.Add(file.FullName, alphaPath);
                            }
                            else
                            {
                                copyList.Add(file);
                            } //if end
                        } //if end
                    } //if end
                } //foreach end

                //Recursion for the subfolder
                foreach (DirectoryInfo dirSub in dirChild)
                {
                    getFile(dirSub.FullName, fileMap);
                } //foreach end
            }
            catch
            {
            } //try catch end
        } //getFile()

        public unsafe Bitmap mergeImage(Bitmap rgbTexture, Bitmap alphaTexture)
        {
            int width = rgbTexture.Width;
            int height = rgbTexture.Height;

            try
            {
                BitmapData textureWithAlphaData = rgbTexture.LockBits(new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                BitmapData alphaTextureData = alphaTexture.LockBits(new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                byte* resultP = (byte*) textureWithAlphaData.Scan0;
                byte* alphaP = (byte*) alphaTextureData.Scan0;

                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        resultP[3] = alphaP[2];
                        resultP += 4;
                        alphaP += 4;
                    }
                }

                rgbTexture.UnlockBits(textureWithAlphaData);
                alphaTexture.UnlockBits(alphaTextureData);

                return rgbTexture;
            }
            catch
            {
                return rgbTexture;
            }
        } //mergeImage()

        private void copyFiles(FileInfo sourceFile, string destFolder, string destFileName)
        {
            if (File.Exists(destFolder + destFileName))
            {
                copyFiles(sourceFile, destFolder,
                    destFileName.Replace(sourceFile.Extension, "R") + sourceFile.Extension);
            }
            else
            {
                File.Copy(sourceFile.FullName, destFolder + destFileName);
            }
        }

        private void errorFileProcessing()
        {
            DialogResult dr =
                MessageBox.Show(
                    "There were also images that unable to proceed (might because reslution mismatch), do you want to copy them to a new folder?",
                    "Copy Files?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                folderBrowserDialog2_unmatched.ShowDialog();
                if (folderBrowserDialog2_unmatched.SelectedPath != "")
                {
                    foreach (KeyValuePair<string, string> kvp in errorListMap)
                    {
                        try
                        {
                            string[] split = kvp.Key.Split('\\');
                            string[] alphaSplit = kvp.Value.Split('\\');
                            File.Copy(kvp.Key,
                                folderBrowserDialog2_unmatched.SelectedPath + "\\" + split[split.Length - 1]);
                            File.Copy(kvp.Value,
                                folderBrowserDialog2_unmatched.SelectedPath + "\\" + alphaSplit[split.Length - 1]);
                            richTextBox_Console.AppendText("\n" + kvp.Key + "  Copied");
                            richTextBox_Console_Foucus();
                        }
                        catch (Exception ex)
                        {
                            richTextBox_Console.AppendText("\n" + kvp.Key + "  copying failed. " + ex.Message);
                            richTextBox_Console_Foucus();
                        }
                    }
                }
            }
        }

        private void unmatchedFileProcessing()
        {
            DialogResult dr =
                MessageBox.Show(
                    "There were images that did not find matched Alpha textures, do you want to copy them to a new folder?",
                    "Copy Files?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                folderBrowserDialog2_unmatched.ShowDialog();
                if (folderBrowserDialog2_unmatched.SelectedPath != "")
                {
                    foreach (FileInfo file in copyList)
                    {
                        if (file.Exists)
                        {
                            copyFiles(file, folderBrowserDialog2_unmatched.SelectedPath + "\\", file.Name);
                            richTextBox_Console.AppendText("\n" + file.FullName + "  Copied");
                            richTextBox_Console_Foucus();
                        }
                    }

                    folderBrowserDialog2_unmatched.SelectedPath = "";
                } //if end
            } //if end
        } //unmatchedFileProcessing()

        private void richTextBox_Console_Foucus()
        {
            richTextBox_Console.SelectionStart = richTextBox_Console.TextLength;
            richTextBox_Console.SelectionLength = 0;
            richTextBox_Console.Focus();
        } //richTextBox_Console_Foucus()

        private void btn_FolderSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            try
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                btn_Process.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Unable to open the folder");
            }
        } //FolderSelect_Click()


        private void btn_Process_Click(object sender, EventArgs e)
        {
            if (folderPath != "")
            {
                string saveFolderPath = "";
                folderBrowserDialog_Save.ShowDialog();
                saveFolderPath = folderBrowserDialog_Save.SelectedPath;

                if (saveFolderPath != "")
                {
                    DateTime beforeDT = DateTime.Now;
                    fileMap = new Dictionary<string, string>();
                    copyList = new List<FileInfo>();
                    errorListMap = new Dictionary<string, string>();

                    getFile(folderPath, fileMap);

                    int count = 0;


                    try
                    {
                        foreach (KeyValuePair<string, string> kvp in fileMap)
                        {
                            if (File.Exists(kvp.Value))
                            {
                                try
                                {
                                    Bitmap rgbTexture = new Bitmap(kvp.Key);
                                    Bitmap alphaTexture = new Bitmap(kvp.Value);
                                    
                                    if (rgbTexture.Width != alphaTexture.Width ||
                                        rgbTexture.Height != alphaTexture.Height)
                                    {
                                        // Try scaling the alpha image to fit rgb image
                                        alphaTexture = new Bitmap(alphaTexture,
                                            new Size(rgbTexture.Width, rgbTexture.Height));
                                    }

                                    string saveName =
                                        kvp.Key.Replace(folderPath, ""); //To get the path with subfolder for each image

                                    string pattern = @"\\\S*\\";

                                    if (!Directory.Exists(saveFolderPath + Regex.Match(saveName, pattern)))
                                    {
                                        Directory.CreateDirectory(saveFolderPath + Regex.Match(saveName, pattern));
                                    }

                                    // Only start to merge if the two files have same resolution 
                                    if (rgbTexture.Width == alphaTexture.Width &&
                                        rgbTexture.Height == alphaTexture.Height)
                                    {
                                        Bitmap textureWithAlpha = new Bitmap(mergeImage(rgbTexture, alphaTexture));
                                        textureWithAlpha.Save(saveFolderPath + saveName, ImageFormat.Png);

                                        count++;

                                        richTextBox_Console.AppendText(
                                            "\n" + kvp.Key + " proceeded  Remain file(s): " +
                                            (fileMap.Keys.Count - count - errorListMap.Count));
                                        richTextBox_Console_Foucus();

                                        textureWithAlpha.Dispose();
                                    }
                                    else
                                    {
                                        errorListMap.Add(kvp.Key, kvp.Value);
                                        richTextBox_Console.AppendText(
                                            "\n" + kvp.Key + " :" +
                                            " Resolution check failed please make sure Alpha texture sharing the same resolution as RGB one");
                                        richTextBox_Console_Foucus();
                                    }

                                    rgbTexture.Dispose();
                                    alphaTexture.Dispose();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(kvp.Key + ":" + ex.Message +
                                                      " Please make sure Alpha texture sharing the same resolution as RGB one");
                                    errorListMap.Add(kvp.Key, kvp.Value);
                                    richTextBox_Console.AppendText("\n" + kvp.Key + " :" + ex.Message);
                                    richTextBox_Console_Foucus();
                                }
                            }
                            else
                            {
                                errorListMap.Add(kvp.Key, kvp.Value);
                                richTextBox_Console.AppendText(
                                    "\n" + kvp.Value + " Skipped : Can not find Alpha texture for it.");
                                richTextBox_Console_Foucus();
                            } //if end
                        } //foreach end
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("flag1: " + ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Total files : " + fileMap.Keys.Count + "    " + count +
                                          " file(s) are proceed , " + errorListMap.Count + " file(s) are skiped.");
                        richTextBox_Console.AppendText("\nTotal files : " + fileMap.Keys.Count + "    " + count +
                                                       " file(s) were proceeded , " + errorListMap.Count +
                                                       " file(s) are skipped.  ");
                        richTextBox_Console_Foucus();
                    }

                    DateTime afterDT = System.DateTime.Now;
                    TimeSpan ts = afterDT.Subtract(beforeDT);
                    richTextBox_Console.AppendText("Time:" + ts.TotalSeconds + " s\n");
                    richTextBox_Console_Foucus();

                    if (copyList.Count > 0)
                    {
                        unmatchedFileProcessing();
                    }

                    if (errorListMap.Count > 0)
                    {
                        errorFileProcessing();
                    }
                } //internal if end
            }
            else
            {
                MessageBox.Show("Please select resources folder first....");
            } //if end
        } //Process_Click()

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            PreviewForm preView = new PreviewForm();
            preView.ShowDialog();
            this.Enabled = true;
        } //btn_Preview_Click()

        private void richTextBox_Console_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        } //richTextBox_Console_LinkClicked()

        private void btn_SelectSample_Click(object sender, EventArgs e)
        {
            try
            {
                openSampleFileDialog.Title = "Open Sample RGB File";
                openSampleFileDialog.ShowDialog();
                sampleRGBFilePath = openSampleFileDialog.FileName;

                openSampleFileDialog.Title = "Open Sample Alpha File";
                openSampleFileDialog.ShowDialog();
                sampleAlphaFilePath = openSampleFileDialog.FileName;

                String rgbFileName = Path.GetFileName(sampleRGBFilePath);
                String alphaFileName = Path.GetFileName(sampleAlphaFilePath);
                MessageBox.Show(sampleAlphaFilePath);
            }
            catch
            {
                MessageBox.Show("Unable to open the folder");
            }
        }
    } //Class MainForm
} //Namespace