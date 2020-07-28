using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigAlbum
{
    public partial class IndusSeal : Form
    {
        //******************************************************************
        public Config cnfg;
        public NuNet nunet;
        string path = @"H:\Download\test2018\test2018";
        string pathOut = @"H:\Download\test2018\out2018";
        public string[] jpgFlnms;
        public string[] bmpFlnms;
        public int imgPtr;
        string currFileName;
        Random rand = new Random(DateTime.Now.Millisecond);
        Point ptDn;
        int rtst;
        int rten;
        //******************************************************************
        public IndusSeal()
        {
            InitializeComponent();
            cnfg = new Config();
            //nunet = new NuNet();
            pictureBox1.MouseWheel += new MouseEventHandler(this.PictureBox_MouseWheel);  
        }
        //******************************************************************
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //******************************************************************
        private void btnLoad_Click(object sender, EventArgs e)
        {
            GetSeals();
            if (jpgFlnms == null)
                return;
            if (jpgFlnms.Length == 0)
                return;
            //imgPtr = 0;
         //   pb.Image = bmpStack[imgPtr];
        }
        //******************************************************************
        private void GetSeals()
        {
            folderBrowserDialog1.SelectedPath = cnfg.tngPath;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            path = folderBrowserDialog1.SelectedPath;
            cnfg.tngPath = path;
            jpgFlnms = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
            bmpFlnms = Directory.GetFiles(path, "*.bmp", SearchOption.AllDirectories);

            imgPtr = 0;
            Bitmap img1 = new Bitmap(jpgFlnms[0]);
            pictureBox1.Image = img1;
            if (bmpFlnms.Length != 0)
            {
                Bitmap img2 = new Bitmap(bmpFlnms[0]);
                pictureBox2.Image = img2;
            }
            //img1.Dispose();
            //img2.Dispose();
            label1.Text = imgPtr.ToString();
        }
        //******************************************************************
        private string MakeImageList(int ptr)
        {
            rtst = ptr - 100;
            if (rtst < 0)
                rtst = 0;
            rten = rtst + 200;
            if (rten >= jpgFlnms.Length)
                rten = jpgFlnms.Length;
            string list = "";
            for (int i = rtst; i < rten; i++)
            {
                FileInfo fi = new FileInfo(jpgFlnms[i]);
                list += i.ToString().PadLeft(7, '0') + ": " + fi.Name + "\n";
            }
            return list;
        }
        //******************************************************************
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ptDn = new Point(e.X, e.Y);
        }
        //******************************************************************
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point ptMov = new Point(e.X, e.Y);
                int dx = e.X - ptDn.X;
                int dy = e.Y - ptDn.Y;
                if (Math.Abs(dx) > Math.Abs(dy))
                    imgPtr += dx;
                else
                    imgPtr += dy*100;
                if (imgPtr < 0)
                    imgPtr = 0;
                if (imgPtr >= jpgFlnms.Length)
                    imgPtr = jpgFlnms.Length;
                label1.Text = imgPtr.ToString();
                timer1.Interval = 100;
                timer1.Start();
                ptDn = ptMov;
            }
        }
        //******************************************************************
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                imgPtr++;
            else
                imgPtr--;
            if (imgPtr < 0)
                imgPtr = 0;
            if (imgPtr >= jpgFlnms.Length)
                imgPtr = jpgFlnms.Length;
            label1.Text = imgPtr.ToString();
            timer1.Interval = 100;
            timer1.Start();
        }
        //******************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = new Bitmap(jpgFlnms[imgPtr]);
            timer1.Stop();
            if ((imgPtr < rtst) | (imgPtr > rten))
            {
             //   richTextBox1.Text = MakeImageList(imgPtr);
            }
        }
        //******************************************************************
        private void btnSignature_Click(object sender, EventArgs e)
        {
            return;//temp
            Directory.CreateDirectory(pathOut);
            Signature signature = new Signature();
            for (int i = 0; i < jpgFlnms.Length; i++)
			{
                FileInfo fi = new FileInfo(jpgFlnms[i]);
                string flnm = pathOut + @"\" + fi.Name.Replace(".jpg", ".dat");
                if(!File.Exists(flnm))
                signature.GetRandomSamples(jpgFlnms[i]);
			}
        }
        //******************************************************************
        private void btnNuNet_Click(object sender, EventArgs e)
        {
            NuNet nunet = new NuNet();
            nunet.album = this;
            nunet.pbOut=pictureBox3;
            nunet.Show();
        }
        //******************************************************************
        private void Album_Shown(object sender, EventArgs e)
        {
            bool r = cnfg.LoadCfg(cnfg.exePath + @"\BigAlbum.cfg");
            if (r == false)
            {
                MessageBox.Show("CAUSION: No config file was found");
                //return;
            }
            if (Directory.Exists(cnfg.sigPath))
            {
            }
        }
        //******************************************************************
        private void Album_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateCnfg();
        }
        //*******************************************************************************
        private void UpdateCnfg()
        {
            //cnfg.imgPtr1 = imgPtr1;
            //cnfg.imgPtr2 = imgPtr2;
            //cnfg.imgPtr3 = imgPtr3;
            cnfg.SaveCfg(cnfg.exePath + @"\BigAlbum.cfg");
        }
        //******************************************************************
        private void btnPrevbtnPrev_Click(object sender, EventArgs e)
        {
            imgPtr--;
            if (imgPtr < 0)
                imgPtr = 0;
            pictureBox1.Image = new Bitmap(jpgFlnms[imgPtr]);
            Bitmap img2 = new Bitmap(bmpFlnms[imgPtr]);
            pictureBox2.Image = img2;
            label1.Text = imgPtr.ToString();
           // img2.Dispose();
        }
        //******************************************************************
        private void btnNext_Click(object sender, EventArgs e)
        {
            imgPtr++;
            if (imgPtr >= jpgFlnms.Length)
                imgPtr = jpgFlnms.Length-1;
            pictureBox1.Image = new Bitmap(jpgFlnms[imgPtr]);
            Bitmap img2 = new Bitmap(bmpFlnms[imgPtr]);
            pictureBox2.Image = img2;
            label1.Text = imgPtr.ToString();
          //  img2.Dispose();
        }
        //******************************************************************
        //******************************************************************
    }
}
