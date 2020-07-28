using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contour
{
    public partial class output : Form
    {
        string input1 = @"A:\Indus\HSM\IndusFont1840Out3";
        string outputloc = @"A:\Indus\Contour\outputorder.csv";
        public int[] sortSeq;
        public string order;
        //************************************************************
        public output()
        {
            InitializeComponent();
        }
        //************************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(outputloc);
            order = sr.ReadLine();
            sr.Close();
            string[] wrd = order.Split(',');
            sortSeq = new int[wrd.Length];
            for (int i = 0; i < wrd.Length; i++)
            {
                 sortSeq[i] = int.Parse(wrd[i]);
            }
            string[] filename = Directory.GetFiles(input1, "*.bmp");
            string[] filename1 = new string[wrd.Length];
            for(int i=0;i<1840;i++)
            {
                filename1[i] = filename[sortSeq[i]];
            }
            Bitmap final = Combine(filename1);
            final.Save(@"A:\Indus\Contour\finalindus.jpg", ImageFormat.Jpeg);
            pictureBox1.Image = final;
            flowLayoutPanel1.Controls.Add(pictureBox1);
        }
        //************************************************************
        public static Bitmap Combine(string[] files)
        {
            List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
            Bitmap finalImage = null;
            int width = 0;
            int height = 0;
            foreach (string image in files)
            {
                Bitmap bitmap = new Bitmap(image);
                width = bitmap.Width * 10;
                height = bitmap.Height * 187;
                images.Add(bitmap);
            }
            finalImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.White);
                int offset = 0;
                int count = 0;
                int y = 0;
                foreach (Bitmap image in images)
                {
                    g.DrawImage(image, new Rectangle(offset, y, image.Width, image.Height));
                    count++;
                    if ((count % 10 == 0) && (count != 0))
                    {
                        y += image.Height;
                        offset = 0;
                    }
                    else
                    {
                        offset += image.Width;
                    }
                }
            }
            return finalImage;
        }
        //*******************************************************************
    }
}
