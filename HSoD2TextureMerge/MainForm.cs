using System;
using System.Collections.Generic;
using System.Drawing;
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
        }   //getFile

        private Bitmap mergeImage(Bitmap rgbTexture,Bitmap alphaTexture)
        {
            textureWithAlpha = new Bitmap(rgbTexture.Width, rgbTexture.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            try
            {
                for (int i = 0; i < rgbTexture.Width; i++)
                {
                    for (int j = 0; j < rgbTexture.Height; j++)
                    {
                        Color withAlpha = Color.FromArgb(alphaTexture.GetPixel(i, j).R, rgbTexture.GetPixel(i, j));
                        textureWithAlpha.SetPixel(i, j, withAlpha);
                    }
                }   //for end

                return textureWithAlpha;

            }
            catch
            {
                return textureWithAlpha;
            }
        }   //mergeImage

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
        }   //FolderSelect_Click

        

        private void btn_Process_Click(object sender, EventArgs e)
        {
            

            if (folderPath != "")
            {
                string saveFolderPath = "";
                folderBrowserDialog_Save.ShowDialog();
                saveFolderPath = folderBrowserDialog_Save.SelectedPath;

                if(saveFolderPath != "")
                {
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
                                    textureWithAlpha.Save(saveFolderPath + saveName, System.Drawing.Imaging.ImageFormat.Png);

                                    count++;

                                    Console.WriteLine(kvp.Key + " proceed  Remain file(s): " + (fileMap.Keys.Count - count - errorList.Count));
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
                                Console.WriteLine(kvp.Key + " : Can not find Alpha texture for it. Pleas make sure name the Alpha file as Example_Alpha.png");
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
                    }
                }   //if end

                
            }
            else
            {
                MessageBox.Show("令人窒息的操作顺序 我不会怪你的.....");
            }   //if end
        }   //Process_Click

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            PreviewForm preView = new PreviewForm();
            preView.ShowDialog();
            this.Enabled = true;
        }

        private void richTextBox_Console_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
