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

namespace Contour
{
    public partial class Form1 : Form
    {
        //***************************************************************
        int[][] centroid;
        int[][] histogram;
        int[][] hlfpyramid;
        string input = @"A:\Indus\Contour\IndusFont1840Out5";
       // string input = @"A:\Indus\HSM\IndusFont1840Out3";
        string outputloc = @"A:\Indus\Contour\outputorder.csv";
        string histogramcontour1840 = @"A:\Indus\Contour\histogramcontour1840.csv";
        string[] flnmsall;
        public int[] sortSeq;
        //***************************************************************
        public Form1()
        {
            InitializeComponent();
        }
        //***************************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int x,y;
            int count = 0;
            flnmsall = Directory.GetFiles(input, "*.bmp");
            centroid = new int[flnmsall.Length][];
            histogram = new int[flnmsall.Length][]; 
                for (int i = 0; i < flnmsall.Length;i++ )
                {
                    centroid[i] = new int[2];
                    histogram[i] = new int[8];
                }
                for (int i = 0; i < flnmsall.Length; i++)
                {
                    x = 0;
                    y = 0;
                    count = 0;              
                    Bitmap bt = new Bitmap(flnmsall[i]);
                    for (int p = 0; p < bt.Height; p++)
                    {
                        for (int q = 0; q < bt.Width; q++)
                        {
                           Color x1 = bt.GetPixel(q,p);
                           if ((x1.A==255) && (x1.R==0) && (x1.G==0) && (x1.B==0))
                            {
                                x += q;
                                y += p;
                                count++;
                            }
                        }
                    }
                    if (count != 0)
                    {
                        x = x / count;
                        y = y / count;
                        centroid[i][0] = x;
                        centroid[i][1] = y;
                    }
                }
                Cursor.Current = Cursors.Default;
        }
        //***************************************************************
        public static string lookupInTable(int x,int y,int dir)
        {
            int p=0;
            int q=0;
            if(dir==0)
            {
                p = x + 1;
                q = y;
            }
            else if(dir==1)
            {
                p = x + 1;
                q = y - 1;
            }
            else if(dir==2)
            {
                p = x;
                q = y - 1;
            }
            else if(dir==3)
            {
                p = x - 1;
                q = y - 1;
            }
            else if(dir==4)
            {
                p = x - 1;
                q = y;
            }
            else if(dir==5)
            {
                p = x - 1;
                q = y + 1;
            }
            else if(dir==6)
            {
                p = x;
                q = y + 1;
            }
            else if (dir==7)
            {
                p = x + 1;
                q = y + 1;
            }
            string lookedvalues=p.ToString()+","+q.ToString();
            return lookedvalues;
        }
        //***************************************************************
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int x0 = 0;
            int y0 = 0;
            int locx = 0;
            int locy = 0;
            for(int i=0;i<flnmsall.Length;i++)
            {
                Bitmap bt = new Bitmap(flnmsall[i]);
                for(int x=0;x<8;x++)
                {
                    x0=centroid[i][0];
                    y0=centroid[i][1];
                    locx = 0;
                    locy = 0;
                    while (true)
                    {
                        string result = lookupInTable(x0, y0, x);
                        string[] wrds = result.Split(',');
                        x0 = int.Parse(wrds[0]);
                        y0 = int.Parse(wrds[1]);
                        if ((x0 >= 0) && (x0 < bt.Width) && (y0 >= 0) && (y0 < bt.Height))
                        {
                            Color x1 = bt.GetPixel(x0, y0);
                            if ((x1.A == 255) && (x1.R == 0) && (x1.G == 0) && (x1.B == 0))
                            {
                                locx = x0;
                                locy = y0;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    x0 = centroid[i][0];
                    y0 = centroid[i][1];
                    int dist = getdistance(x0, y0, locx, locy);
                    histogram[i][x] = dist;
                }
            }
            StreamWriter sw = new StreamWriter(histogramcontour1840);
            for (int n = 0; n < flnmsall.Length; n++)
            {
                string line = flnmsall[n]+",";
                for(int i=0;i<8;i++)
                {
                    line += histogram[n][i].ToString() + ",";
                }
                sw.WriteLine(line);
            }
            sw.Close();
            Cursor.Current = Cursors.Default;
        }
        //***************************************************************
        private int getdistance(int x0, int y0, int locx, int locy)
        {
            int di;
            di = Math.Abs(locx - x0) + Math.Abs(locy - y0);
            return di;
        }
        //***************************************************************
        public void MakeHlfPyramid()//made for Traingular Matrix
        {
            hlfpyramid = new int[flnmsall.Length][];
            for (int i = 0; i < hlfpyramid.Length; i++)
            {
                hlfpyramid[i] = new int[i];
            }
            for (int i = 0; i < histogram.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < histogram[i].Length; k++)
                    {
                        sum += Math.Abs(histogram[i][k] - histogram[j][k]);
                    }
                    hlfpyramid[i][j] = sum;
                }
            }
        }
        //****************************************************************
        public void DataTreeSort(int choice)
        {
            //hlfpyramid
            string[] r2 = new string[hlfpyramid.Length];
            for (int i = 0; i < hlfpyramid.Length; i++)
            {
                r2[i] = i.ToString() + ",";
            }
            for (int n = hlfpyramid.Length - 1; n > 0; n--)
            {
                int mMn = 0;
                float valMn = hlfpyramid[n][0];
                for (int m = 1; m < hlfpyramid[n].Length; m++)
                {
                    if (valMn > hlfpyramid[n][m])
                    {
                        valMn = hlfpyramid[n][m];
                        mMn = m;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (i < mMn)
                    {
                        if (choice == 2)
                        {
                            hlfpyramid[mMn][i] = (hlfpyramid[mMn][i] + hlfpyramid[n][i]) / 2;
                        }
                        else if (choice == 3)
                        {
                            hlfpyramid[mMn][i] = distmax(hlfpyramid[mMn][i], hlfpyramid[n][i]);
                        }
                        else if (choice == 1)
                        {
                            hlfpyramid[mMn][i] = distmin(hlfpyramid[mMn][i], hlfpyramid[n][i]);
                        }
                    }
                    if (i > mMn)
                    {
                        if (choice == 2)
                        {
                            hlfpyramid[i][mMn] = (hlfpyramid[i][mMn] + hlfpyramid[n][i]) / 2;
                        }
                        else if (choice == 3)
                        {
                            hlfpyramid[i][mMn] = distmax(hlfpyramid[i][mMn], hlfpyramid[n][i]);
                        }
                        else if (choice == 1)
                        {
                            hlfpyramid[i][mMn] = distmin(hlfpyramid[i][mMn], hlfpyramid[n][i]);
                        }
                    }
                }
                r2[mMn] += r2[n];
            }
            string line = r2[0].TrimEnd(',');
            StreamWriter sw = new StreamWriter(outputloc);
            sw.WriteLine(line);
            sw.Close();
            string[] wrds = line.Split(',');
            sortSeq = new int[wrds.Length];              //removed int[] 
            for (int i = 0; i < wrds.Length; i++)
            {
                sortSeq[i] = int.Parse(wrds[i]);
            }
        }
        //****************************************************************        
        public static int distmin(int a, int b)
        {
            if (a > b)
                return b;
            else
                return a;
        }
        //****************************************************************
        public static int distmax(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }
        //****************************************************************
        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MakeHlfPyramid();
            DataTreeSort(1);
            Cursor.Current = Cursors.Default;
        }
        //****************************************************************
        private void button4_Click(object sender, EventArgs e)
        {
            output out1=new output();
            out1.Show();
        }
        //****************************************************************
    }
}
