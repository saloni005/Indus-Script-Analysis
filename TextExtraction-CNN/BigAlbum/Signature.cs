using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigAlbum
{
    class Signature
    {
        Random rand = new Random(DateTime.Now.Millisecond);
        //******************************************************************
        public string path = @"H:\Download\test2018\test2018";
        public string pathOut = @"H:\Download\test2018\out2018";
        string flnmIn;
        string flnmOut;
        float[][] smpls;
        int smgd = 2; 
        Point[] grid;
        int xsz = 10;
        int ysz = 10;
        Bitmap bmp;
        //******************************************************************
        public Signature()
        {
            //GetRandomSamples(flnmIn);
        }
        //******************************************************************
        public void GetRandomSamples(string flnmIn)
        {
            this.flnmIn = flnmIn;
            bmp = new Bitmap(flnmIn);
            CreateGrid();
            CreateSamples();
            SaveSamples();
            bmp.Dispose();
        }
        //******************************************************************
        private void SaveSamples()
        {
            FileInfo fi = new FileInfo(flnmIn);
            string flnm = pathOut+@"\"+fi.Name.Replace(".jpg", ".dat");
            StreamWriter sw = new StreamWriter(flnm);
            string line = "";
            for (int i = 0; i < smpls.Length; i++)
            {
                for (int j = 0; j < smpls[i].Length; j++)
                {
                    float d = smpls[i][j]/360.0f;
                    d = (float)Math.Round(d, 3);
                    line += d.ToString()+",";
                }
            }
            line = line.TrimEnd(',');
            sw.Write(line);
            sw.Close();
        }
        //******************************************************************
        private void CreateSamples()
        {
            int kx = bmp.Width / xsz;
            int ky = bmp.Height / ysz;
            smpls = new float[grid.Length][];
            for (int i = 0; i < smpls.Length; i++)
            {
                smpls[i] = new float[smgd];
                for (int j = 0; j < smgd; j++)
                {
                    int xr = rand.Next(kx);
                    int yr = rand.Next(ky);
                    Color col = bmp.GetPixel(grid[i].X + xr, grid[i].Y + yr);
                    smpls[i][j] = col.GetHue();
                }
            }
        }
        //******************************************************************
        private void CreateGrid()
        {
            float kx = (float)bmp.Width / xsz;
            float ky = (float)bmp.Height / ysz;
            grid = new Point[xsz * ysz];
            int n = 0;
            for (int y = 0; y < ysz; y++)
            {
                for (int x = 0; x < xsz; x++)
                {
                    grid[n] = new Point((int)(kx * x), (int)(ky * y));
                    n++;
                }
            }
        }
        //******************************************************************
        //******************************************************************
    }
    //******************************************************************
}
