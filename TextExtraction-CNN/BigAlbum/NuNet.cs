using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigAlbum
{
    public partial class NuNet : Form
    {
        //******************************************************************
        public IndusSeal album;
        string path = @"D:\_March2018\HsmImgs";
        NnBP nnbp;
        string nnFileName = "NnBp.net";
        Random rand = new Random(DateTime.Now.Millisecond);
        int count = 0;
        double minErr;
        Bitmap bmpTng;
        Bitmap bmpTst;
        public PictureBox pbOut;
        float threshold;
        //******************************************************************
        public NuNet()
        {
            InitializeComponent();
            threshold = 0.6f;
            labelThVal.Text = threshold.ToString();
        }
        //******************************************************************
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //******************************************************************
        private void btnNnTrain_Click(object sender, EventArgs e)
        {
            if (btnNnTrain.Text == "NN=>>")
            {
                minErr = double.MaxValue;
                btnNnTrain.Text = "NN=||";
                timer1.Interval = 1;
                timer1.Start();
            }
            else
            {
                btnNnTrain.Text = "NN=>>";
                timer1.Stop();
            }
        }
        //******************************************************************
        private void btnNnReset_Click(object sender, EventArgs e)
        {
            nnbp = new NnBP();
            nnbp.ii = 75;
            nnbp.jj = 50;
            nnbp.kk = 1;
            nnbp.SetParameters();
            count = 0;
        }
        //******************************************************************
        private void btnSaveNn_Click(object sender, EventArgs e)
        {
            if (nnbp == null)
                return;
            saveFileDialog1.Title = "Select Neural Net File (*.net)";
            saveFileDialog1.InitialDirectory = path;
            saveFileDialog1.Filter = "Net (*.net)|*.net|" + "All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
            nnFileName = saveFileDialog1.FileName;
            nnbp.SaveNet(nnFileName);
        }
        //******************************************************************
        private void btnLoadNn_Click(object sender, EventArgs e)
        {
            if (nnbp == null)
                return;
            openFileDialog1.Title = "Load Neural Net File (*.net)";
            openFileDialog1.InitialDirectory = path;
            openFileDialog1.Filter = "Net (*.net)|*.net|" + "All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
            nnFileName = openFileDialog1.FileName;
            nnbp.LoadNet(nnFileName);
        }
        //******************************************************************
        private void btnNnData_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (nnbp == null)
                return;
            //int sz = 100000;//In-Out Training Data Size
            CreateNewNnData();
            Cursor.Current = Cursors.Default;
        }
        //******************************************************************
        private void CreateNewNnData()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < album.jpgFlnms.Length; i++)
            {
                Bitmap bmJpg = new Bitmap(album.jpgFlnms[i]);
                Bitmap bmBmp = new Bitmap(album.bmpFlnms[i]);
                for (int yc = 2; yc < bmJpg.Height-2; yc++)
                {
                    for (int xc = 2; xc < bmJpg.Width - 2; xc++)
                    {
                        NnBP.NNDATA dt = new NnBP.NNDATA();
                        dt.inp = new float[nnbp.yi.Length];
                        dt.outp = new float[nnbp.outk.Length];
                        int n = 0;
                        int m = 0;
                        for (int y = -2; y <= 2; y++)
                        {
                            for (int x = -2; x <= 2; x++)
                            {
                                Color colJpg = bmJpg.GetPixel(xc + x, yc + y);
                                Color colBmp = bmBmp.GetPixel(xc + x, yc + y);
                                dt.inp[n++] = colJpg.R / 256.0f;
                                dt.inp[n++] = colJpg.G / 256.0f;
                                dt.inp[n++] = colJpg.B / 256.0f;
                                if((x==0)&(y==0))
                                dt.outp[m++] = colBmp.G / 256.0f;
                            }
                        }
                        al.Add(dt);
                    }
                }
                bmBmp.Dispose();
            }
            nnbp.nnData = new NnBP.NNDATA[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                nnbp.nnData[i] = (NnBP.NNDATA)al[i];
            }
            al.Clear();
        }
        //******************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            int maxSmpls = 2500; //1000 
            double error = 0;
            double interror = 0;
            for (int sn = 0; sn < maxSmpls; sn++)
            {
                int nr = rand.Next(nnbp.nnData.Length);
                nnbp.LoadInOut(nr);
                double er = nnbp.UpdateNet();

                error += er;
                interror += nnbp.interr;
                nnbp.update_and_correct_error();
            }
            double err2 = Math.Round(error, 3);
            if (minErr > err2)
                minErr = err2;
            count++;
            lblIntErr.Text = interror.ToString();
            lblErr.Text = err2.ToString();
            lblMinErr.Text = minErr.ToString();
            lblCount.Text = count.ToString();
        }
        //******************************************************************
        private void CreateTestNnData(int imgno)
        {
            int i = imgno;
            {
                Bitmap bmJpg = new Bitmap(album.jpgFlnms[i]);
                Bitmap bmBmp = new Bitmap(album.bmpFlnms[i]);
                Bitmap bmOut = new Bitmap(bmBmp.Width, bmBmp.Height);
                for (int yc = 2; yc < bmJpg.Height - 2; yc++)
                {
                    for (int xc = 2; xc < bmJpg.Width - 2; xc++)
                    {
                        int n = 0;
                        int m = 0;
                        for (int y = -2; y <= 2; y++)
                        {
                            for (int x = -2; x <= 2; x++)
                            {
                                Color colJpg = bmJpg.GetPixel(xc + x, yc + y);
                            ///    Color colBmp = bmBmp.GetPixel(xc + x, yc + y);
                                nnbp.yi[n++] = colJpg.R / 256.0f;
                                nnbp.yi[n++] = colJpg.G / 256.0f;
                                nnbp.yi[n++] = colJpg.B / 256.0f;
                               // if ((x == 0) & (y == 0))
                                  //  nnbp.outk[m++] = colBmp.G / 256.0f;
                            }
                        }
                        nnbp.UpdateNet();
                        if (nnbp.yk[0] < threshold)
                            bmOut.SetPixel(xc, yc, Color.Black);
                        else bmOut.SetPixel(xc, yc, Color.White);
                    }
                }
                pbOut.Image = bmOut;
                bmBmp.Dispose();
            }
        }
        //******************************************************************
        private void btnTest_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CreateTestNnData(album.imgPtr);
            Image img1 = album.pictureBox2.Image;
            Bitmap pic2 = new Bitmap(img1);
            int ht1 = img1.Height;
            int wt1 = img1.Width;
            int blackcount1 = 0;

            for (int y = 0; y < ht1; y++)
            {
                for (int x = 0; x < wt1; x++)
                {
                    Color colbmp = pic2.GetPixel(x, y);
                    float pt = colbmp.G / 256.0f;
                    if (pt > threshold)
                        blackcount1++;
                }
            }

            Image img2 = album.pictureBox3.Image;
            Bitmap pic3 = new Bitmap(img2);
            int ht2 = img2.Height;
            int wt2 = img2.Width;
            int blackcount2 = 0;

            for (int y = 0; y < ht2; y++)
            {
                for (int x = 0; x < wt2; x++)
                {
                    Color colbmp = pic3.GetPixel(x, y);
                    float pt = colbmp.G / 256.0f;
                    if (pt > threshold)
                        blackcount2++;
                }
            }
            float picture = (float)ht1 * wt1;
            float ratio1 = blackcount1 / picture;
            float ratio2 = blackcount2 / picture;

            if (ratio1 > ratio2 && threshold >= 0.35f && threshold <= 1.1f)
            {
                float t1 = (float)Math.Round(threshold, 2) - 0.1f;
                if (t1 >= 0.35f && t1 <= 1.0f)
                {
                    threshold = (float)Math.Round(threshold, 2) - 0.1f;
                }
            }
            else if (ratio1 < ratio2 && threshold >= 0.35f && threshold <= 1.1f)
            {
                float t2 = (float)Math.Round(threshold, 2) + 0.1f;
                if (t2 >= 0.35f && t2 <= 1.0f)
                {
                    threshold = (float)Math.Round(threshold, 2) + 0.1f;
                }
            }
            Cursor.Current = Cursors.Default;
        }
        //******************************************************************
        private void buttonoR_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
           Bitmap pic2 = new Bitmap(album.pictureBox2.Image);
           Bitmap pic3 = new Bitmap(album.pictureBox3.Image);
           Bitmap pic4 = new Bitmap(pic2.Width, pic2.Height);
                    for (int x = 0; x < pic2.Height; x++)
                    {
                        for (int y = 0; y < pic2.Width; y++)
                        {
                            Color x1 = pic2.GetPixel(y, x);
                            Color x2 = pic3.GetPixel(y, x);
                            if ((x1.G < 100) || (x2.G < 100))
                            {
                                Color col = pic4.GetPixel(y, x);
                                if (col != Color.Black)
                                    pic4.SetPixel(y, x, Color.Black);
                            }
                            else
                            {
                                pic4.SetPixel(y, x, Color.White);
                            }
                        }
                    }
                    pic2.Dispose();
                    pic3.Dispose();
                   //string tempfn = album.bmpFlnms[album.imgPtr];
                    string savefilename = album.bmpFlnms[album.imgPtr];
                  // tempfn = tempfn.Replace("bmp", "");
                   //string savefilename = tempfn + "jpg";
                    //album.pictureBox2.Image.Dispose();
                    album.pictureBox2.Image.Dispose();  
                    album.pictureBox4.Image = pic4;
                    album.pictureBox2.Image = pic4;
                   // album.pictureBox2.Image = pic4;
 
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    using (var stream = File.Open(savefilename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {                   }
                    pic4.Save(savefilename);
                    Cursor.Current = Cursors.Default;
        }
        //******************************************************************
        private void trackBarThreshould_Scroll(object sender, EventArgs e)
        {
            int tv = trackBarThreshould.Value;
            float thr = (float)tv / 10;
            threshold = thr;
            labelThVal.Text = threshold.ToString();
        }
        //******************************************************************
        //******************************************************************
    }
}
