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
        Bitmap rgbTexture;
        Bitmap alphaTexture;
        Bitmap textureWithAlpha;
        List<string> errorList;
        Dictionary<string, string> fileMap;

        public MainForm()
        {
            InitializeComponent();
            richTextBox_Console.AppendText("Created By yyuueexxiinngg  : https://github.com/yyuueexxiinngg/HSoD2TextureMerge    / By 西城飘雪 : https://www.mihoyo.tech  " +
                "\nPlease select the folder contains all textures and make sure ***_Alpha.*** is in the same name and same folder as RGB image. " +
                "\nPlease notice that the program currently using single thread to proceed images, witch means process would be slow." +
                "\nMuiltiple threads processing might be available for later version~" +
                "\n\n请选择包含所有贴图的父级文件夹 注意 ***_Alpha.*** 要与RGB贴图同名且在同级文件夹下" +
                "\n软件现在仅单线程运行和处理图片 所以有点慢 卡住是正常现象~" +
                "\n也许应该大概可能会在后续版本支持多线程处理  (如果我没偷懒 QAQ");
        }

        private void getFile(string path, Dictionary<string, string> fileMap)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles();
                DirectoryInfo[] dir_child = dir.GetDirectories();

                foreach (FileInfo file in files)
                {
                    if (file.FullName.IndexOf("Alpha") == -1)
                    {
                        string[] split = file.FullName.Split('.');
                        fileMap.Add(file.FullName, split[split.Length - 2] + "_Alpha.png");
                    }   //if end
                }   //foreach end

                //Recursion for the subfolder
                foreach (DirectoryInfo dir_sub in dir_child)
                {
                    getFile(dir_sub.FullName, fileMap);
                }   //foreach end
            }
            catch
            {

            }   //try catch end
        }   //getFile()

        public unsafe Bitmap mergeImage(Bitmap rgbTexture,Bitmap alphaTexture)
        {
            int width = rgbTexture.Width;
            int height = rgbTexture.Height;
            textureWithAlpha = rgbTexture;

            try
            {
                BitmapData textureWithAlphaData = textureWithAlpha.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                BitmapData alphaTextureData = alphaTexture.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                byte* resultP = (byte*)textureWithAlphaData.Scan0;
                byte* alphaP = (byte*)alphaTextureData.Scan0;

                int resultOffset = textureWithAlphaData.Stride - width * 4;
                int alphaOffset = textureWithAlphaData.Stride - width * 4;

                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        resultP[3] = alphaP[2];
                        resultP += 4;
                        alphaP += 4;
                    }
                    resultP += resultOffset;
                    alphaP += alphaOffset;
                }

                textureWithAlpha.UnlockBits(textureWithAlphaData);
                alphaTexture.UnlockBits(alphaTextureData);

                return textureWithAlpha;
            }
            catch
            {
                return textureWithAlpha;
            }
        }   //mergeImage()

        private void richTextBox_Console_Foucus()
        {
            richTextBox_Console.SelectionStart = richTextBox_Console.TextLength;
            richTextBox_Console.SelectionLength = 0;
            richTextBox_Console.Focus();
        }   //richTextBox_Console_Foucus()

        private void btn_FolderSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            try
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }
            catch
            {
                MessageBox.Show("Unable to open the folder");
            }
        }   //FolderSelect_Click()

        

        private void btn_Process_Click(object sender, EventArgs e)
        {
            if (folderPath != "")
            {
                string saveFolderPath = "";
                folderBrowserDialog_Save.ShowDialog();
                saveFolderPath = folderBrowserDialog_Save.SelectedPath;

                if(saveFolderPath != "")
                {
                    DateTime beforDT = DateTime.Now;
                    fileMap = new Dictionary<string, string>();
                    getFile(folderPath, fileMap);

                    int count = 0;
                    errorList = new List<string>();

                    try
                    {
                        foreach (KeyValuePair<string, string> kvp in fileMap)
                        {
                            if (File.Exists(kvp.Value))
                            {
                                try
                                {
                                    rgbTexture = new Bitmap(kvp.Key);
                                    alphaTexture = new Bitmap(kvp.Value);

                                    string saveName = kvp.Key.Replace(folderPath, "");   //To get the path with subfolder for each image

                                    string pattern = @"\\\S*\\";

                                    if (!Directory.Exists(saveFolderPath + Regex.Match(saveName, pattern)))
                                    {
                                        Directory.CreateDirectory(saveFolderPath + Regex.Match(saveName, pattern));
                                    }


                                    textureWithAlpha = new Bitmap(mergeImage(rgbTexture, alphaTexture));
                                    textureWithAlpha.Save(saveFolderPath + saveName, ImageFormat.Png);

                                    count++;

                                    richTextBox_Console.AppendText("\n" + kvp.Key + " proceeded  Remain file(s): " + (fileMap.Keys.Count - count - errorList.Count));
                                    richTextBox_Console_Foucus();

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(kvp.Key + " :" + ex.Message);
                                    errorList.Add(kvp.Key);
                                }
                            }
                            else
                            {
                                errorList.Add(kvp.Key);
                                richTextBox_Console.AppendText("\n" + kvp.Key + " Skipped : Can not find Alpha texture for it.");
                                richTextBox_Console_Foucus();
                            }//if end
                        }   //foreach end
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("flag1: " + ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Total files : " + fileMap.Keys.Count + "    " + count + " file(s) are proceed , " + errorList.Count + " file(s) are skiped.");
                        richTextBox_Console.AppendText("\nTotal files : " + fileMap.Keys.Count + "    " + count + " file(s) were proceeded , " + errorList.Count + " file(s) are skipped.  ");
                        richTextBox_Console_Foucus();
                    }

                    DateTime afterDT = System.DateTime.Now;
                    TimeSpan ts = afterDT.Subtract(beforDT);
                    richTextBox_Console.AppendText("Time:" + ts.TotalSeconds + " s\n");
                    richTextBox_Console_Foucus();
                }   //internal if end
            }
            else
            {
                MessageBox.Show("令人窒息的操作顺序 我不会怪你的.....");
            }   //if end
        }   //Process_Click()

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            PreviewForm preView = new PreviewForm();
            preView.ShowDialog();
            this.Enabled = true;
        }   //btn_Preview_Click()

        private void richTextBox_Console_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }   //richTextBox_Console_LinkClicked()
    }   //Class MainForm
}   //Namespace
