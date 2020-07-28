using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndusScriptGrouper
{
    public partial class Grouper : Form
    {
        //****************************************************************
        public struct TRNGDATA
        {
            public string bmpName;
            public float[] data;
        };
        //****************************************************************
        public SelectInput selectinput;
        public DoOrdering doordering;
        //public string pathOut3 =   @"X:\_February2018\IndusScriptCode\IndusFont1840Out3";
        //public string pathTngCsv = @"X:\_February2018\IndusScriptCode\tngIndo1840_4.csv";
        //public string pathFontsv = @"X:\_February2018\IndusScriptCode\IndusFont1840_4.csv";
        //public string tngFln =     @"X:\_February2018\IndusScriptCode\IndusFont1840_4.csv";
        public string pathOut3= @"X:\Indus\HSM\IndusFont1840Out3";
        public string pathTngCsv = @"X:\Indus\HSM\tngIndo1840_4.csv";
        public string pathFontsv = @"X:\Indus\HSM\IndusFont1840_4.csv";
        public string tngFln = @"X:\Indus\HSM\IndusFont1840_4.csv";
        Random rnd = new Random(DateTime.Now.Millisecond);
        public int dispWidth = 16;
        public int[] selSymsNm;
        public TRNGDATA[] trngdata;
        public int[] seqn;
        public float[][] hlfpyramid;//half pyramid
        //****************************************************************
        public Grouper()
        {
            InitializeComponent();
            selectinput = new SelectInput();
            doordering = new DoOrdering();
            selectinput.grouper = this;
            doordering.grouper = this;
            selectinput.pb = pictureBox2;
            selectinput.dispWidth = this.dispWidth;
            string str = Directory.GetCurrentDirectory();
            System.IO.DriveInfo di = new System.IO.DriveInfo(str);
            string drv = di.Name;
            pathOut3 = pathOut3.Replace(@"X:\", drv);
            pathTngCsv = pathTngCsv.Replace(@"X:\", drv);
            pathFontsv = pathFontsv.Replace(@"X:\", drv);
            tngFln = tngFln.Replace(@"X:\", drv);
        }
        //****************************************************************
        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //****************************************************************
        private void Grouper_Shown(object sender, EventArgs e)
        {
            int w = SystemInformation.VirtualScreen.Width;
            int h = SystemInformation.VirtualScreen.Height;
            this.Width = w;
            this.Height = h / 2;
            this.Location = new Point(0, 0);
            pictureBox1.Size = panel1.Size;
            pictureBox1.Location = new Point(0, 0);
            richTextBox1.Size = panel1.Size;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Visible = false;
            pictureBox1.Visible = true;
        }
        //****************************************************************
        private void Grouper_SizeChanged(object sender, EventArgs e)
        {
        }
        //****************************************************************
        public void DisplayselectedSymbols(int[] rn)
        {
            selSymsNm = new int[rn.Length];
            for (int i = 0; i < rn.Length; i++)
            {
                selSymsNm[i] = rn[i];
            }
            int wn = dispWidth;
            string[] flnmsall = Directory.GetFiles(pathOut3, "*.bmp");
            Bitmap b0=new Bitmap(flnmsall[0]);
            int hn = (rn.Length + wn - 1) / wn;
            int wk = (int)(b0.Width * 1.1);
            int hk = (int)(b0.Height * 1.5);
            Bitmap bm = new Bitmap(wk * wn, hk * hn);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.LightBlue);
            for (int n = 0; n < rn.Length; n++)
            {
                Bitmap bn=new Bitmap(flnmsall[rn[n]]);
                FileInfo fi = new FileInfo(flnmsall[rn[n]]);
                string nm = fi.Name.Replace(".bmp", "");
                int x = (n % wn) * wk;
                int y = (n / wn) * hk;
                g.DrawImage(bn, new Point(x, y));
                Font drawFont = new Font("Arial", 8);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                PointF drawPoint = new PointF(x + 10, y + b0.Height);
                g.DrawString(nm, drawFont, drawBrush, drawPoint );
            }
            g.Dispose();
            pictureBox1.Image = bm;
            pictureBox1.Size = bm.Size;
        }
        //****************************************************************
        private void lblInputImages_Click(object sender, EventArgs e)
        {
            if (SelectInput.shown == false)
            {
                SelectInput.shown = true;
                selectinput.Show();
                selectinput.BringToFront();
                richTextBox1.Visible = false;
                pictureBox1.Visible = true;
            }
            else
            {
                SelectInput.shown = false;
                selectinput.Hide();
            }
        }
        //****************************************************************
        private void SaveOrderedResult(int[] rn)
        {

        }
        //****************************************************************
        private void lblInputData_Click(object sender, EventArgs e)
        {
            string lines = File.ReadAllText(pathTngCsv);
            richTextBox1.Text = lines;
            richTextBox1.Visible = true;
            pictureBox1.Visible = false;
        }
        //****************************************************************
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (selSymsNm == null)
                return;
            int wn = dispWidth;
            string[] flnmsall = Directory.GetFiles(pathOut3, "*.bmp");
            Bitmap b0 = new Bitmap(flnmsall[0]);
            int hn = (selSymsNm.Length + wn - 1) / wn;
            int wk = (int)(b0.Width * 1.1);
            int hk = (int)(b0.Height * 1.5);
            int n1 = e.Y / hk;
            int n2 = e.X / wk;
            int n = n1 * wn + n2;
            Bitmap bn = new Bitmap(flnmsall[selSymsNm[n]]);
            pictureBox2.Image = bn;//here
            //************added code for neighbours
            if ((n - 2) >= 0)
            {
                Bitmap bn1 = new Bitmap(flnmsall[selSymsNm[n - 2]]);
                pictureBox3.Image = bn1;
                Bitmap bn2 = new Bitmap(flnmsall[selSymsNm[n - 1]]);
                pictureBox4.Image = bn2;
            }
            else if((n-1) >=0)
            {
                Bitmap bn2 = new Bitmap(flnmsall[selSymsNm[n - 1]]);
                pictureBox4.Image = bn2;
                pictureBox3.Visible = false;
            }
            else
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
            }
            if ((n + 2) <= (selSymsNm.Length-1))
            {
                Bitmap bn3 = new Bitmap(flnmsall[selSymsNm[n + 1]]);
                pictureBox5.Image = bn3;
                Bitmap bn4 = new Bitmap(flnmsall[selSymsNm[n + 2]]);
                pictureBox6.Image = bn4;
            }
            else if((n+1) <= (selSymsNm.Length-1))
            {
                Bitmap bn3 = new Bitmap(flnmsall[selSymsNm[n + 1]]);
                pictureBox5.Image = bn3;
                pictureBox6.Visible = false;
            }
            else
            {
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
            }
        }
        //****************************************************************
        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);
            string currentlinetext = richTextBox1.Lines[currentline];
            string pathBmp=pathOut3+@"\"+currentlinetext.Split(',')[0];
            Bitmap bm = new Bitmap(pathBmp);
            pictureBox2.Image = bm;//here
            richTextBox1.Select(firstcharindex, currentlinetext.Length);
            //MessageBox.Show(pathBmp);
        }
        //****************************************************************
        private void lblDoOrdering_Click(object sender, EventArgs e)
        {
            if (DoOrdering.shown == false)
            {
                DoOrdering.shown = true;
                doordering.Show();
                doordering.BringToFront();
                richTextBox1.Visible = false;
                pictureBox1.Visible = true;
            }
            else
            {
                DoOrdering.shown = false;
                doordering.Hide();
            }
            //Cursor.Current = Cursors.WaitCursor;
            //MakeHlfPyramid();
            //DataTreeSort(choice);
            //Cursor.Current = Cursors.Default;
        }
        //****************************************************************
        private float[] String2Data(string lines)
        {
            string[] wrds = lines.Split(',');
            float[] dt = new float[wrds.Length - 1];
            for (int n = 1; n < wrds.Length; n++)
            {
                dt[n-1] = float.Parse(wrds[n]);
            }
            return dt;
        }
        //****************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        //****************************************************************
        private float CalculateDistance()
        {
            float dist = 0;
            for (int i = 0; i < trngdata.Length; i++)
            {
                int k = i - 1;
                if (k < 0)
                    k += trngdata.Length;
                float sum = 0;
                for (int j = 0; j < trngdata[i].data.Length; j++)
                {
                    sum += Math.Abs(trngdata[seqn[i]].data[j] - trngdata[seqn[k]].data[j]);
                }
                dist += sum;
            }
            return dist;
        }
        //****************************************************************
        public void MakeHlfPyramid()//made for Traingular Matrix
        {
            string[] dtLines = File.ReadAllLines(pathTngCsv.Replace("1840", selectinput.rndseq.Length.ToString().PadLeft(4, '0')));
            string[] wds = dtLines[0].Split(',');
            float[][] dtreal = new float[dtLines.Length][];
            for (int i = 0; i < dtreal.Length; i++)
            {
                dtreal[i] = new float[wds.Length - 2];
                string[] wrds = dtLines[i].Split(',');
                for (int j = 0; j < dtreal[i].Length; j++)
                {
                    dtreal[i][j] = float.Parse(wrds[j + 2]);
                }
            }
            hlfpyramid = new float[dtLines.Length][];
            for (int i = 0; i < hlfpyramid.Length; i++)
            {
                hlfpyramid[i] = new float[i];
            }
            for (int i = 0; i < dtreal.Length; i++)
            {
                for (int j = 0; j < i; j++) 
                {
                    float sum = 0;
                    for (int k = 0; k < dtreal[i].Length; k++)
                    {
                        sum += Math.Abs(dtreal[i][k] - dtreal[j][k]);
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
                        else if(choice ==1)
                        {
                            hlfpyramid[i][mMn] = distmin(hlfpyramid[i][mMn], hlfpyramid[n][i]);      
                        }                
                    }
                }
                r2[mMn] += r2[n];
            }
            string line = r2[0].TrimEnd(',');
            string[] wrds = line.Split(',');
            int[] sortSeq = new int[wrds.Length];
            for (int i = 0; i < wrds.Length; i++)
            {
                sortSeq[i] = int.Parse(wrds[i]);              
            }
            int[] rndseq1 = new int[wrds.Length];
            for (int i = 0; i < wrds.Length; i++)
            {
                rndseq1[i] = selectinput.rndseq[sortSeq[i]];
            }
            DisplayselectedSymbols(rndseq1);
        }
        //****************************************************************
        private float distmin(float a,float b)
        {
            if (a > b)
                return b;
            else
                return a;
        }
        //****************************************************************
        private float distmax(float a, float b)
        {
            if (a > b)
                return a;
            else
                return b;
        }
        //****************************************************************
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
        }
        //****************************************************************
        //****************************************************************
    }
}
