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
    public partial class SelectInput : Form
    {
        //****************************************************************
        public Grouper grouper;
        public static bool shown;
        Random rnd = new Random(DateTime.Now.Millisecond);
        public int[] rndseq;//display random sequence
        public int dispWidth;
        public PictureBox pb;

        //string tngAllCsv = @"X:\_February2018\tngIndo1840_4.csv";
        //string fileFontCsv = @"X:\_February2018\IndusFont1840.csv";
        //string fileTrngCsv = @"X:\_February2018\tngIndo1840.csv";
        //****************************************************************
        public SelectInput()
        {
            InitializeComponent();
            string str = Directory.GetCurrentDirectory();
            System.IO.DriveInfo di = new System.IO.DriveInfo(str);
            string drv = di.Name;
            //tngAllCsv = tngAllCsv.Replace(@"X:\", drv);
           // fileFontCsv = fileFontCsv.Replace(@"X:\", drv);
            //fileTrngCsv = fileTrngCsv.Replace(@"X:\", drv);
        }
        //****************************************************************
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        //****************************************************************
        private int[] RandomSequence(int pmx, int snmx)
        {
            int[] pn = new int[pmx];
            int[] rn = new int[snmx];
            for (int i = 0; i < pn.Length; i++)
            {
                pn[i] = i;
            }
            for (int n = 0; n < pn.Length * pn.Length; n++)
            {
                int n1 = rnd.Next(pn.Length);
                int n2 = rnd.Next(pn.Length);
                int n3 = pn[n1];
                pn[n1] = pn[n2];
                pn[n2] = n3;
            }
            int m = 0;
            for (int i = 0; i < rn.Length; i++)
            {
                rn[i] = pn[m];
                m++;
                //if (m > 40)
                //     m = 0;
            }
            return rn;
        }
        //****************************************************************
        private void SelectInput_Shown(object sender, EventArgs e)
        {
            shown = true;
            txbxSymLine.Text = dispWidth.ToString();
        }
        //****************************************************************
        private void SelectInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            shown = false;
        }
        //****************************************************************
        private void lblExit_Click(object sender, EventArgs e)
        {
            shown = false;
            this.Hide();
        }
        //****************************************************************
        private void lblSetDisplayWidth_Click(object sender, EventArgs e)
        {
            grouper.dispWidth = int.Parse(txbxSymLine.Text);
        }
        //****************************************************************
        private void CreateTrainingCsvFile(int[] rndseq)
        {
            grouper.tngFln = grouper.tngFln.Replace("1840", txbxSmplMx.Text);
            string[] allLines = File.ReadAllLines(grouper.tngFln);
            StreamWriter sw = new StreamWriter(grouper.tngFln);
            for (int n = 0; n < rndseq.Length; n++)
            {
                string line = allLines[rndseq[n]];
                sw.WriteLine(line);
            }
            sw.Close();
        }
        //****************************************************************
        private void lblInputRandSamples_Click(object sender, EventArgs e)
        {
            int snmx = int.Parse(txbxSmplMx.Text);//C:\_February2018\IndusScriptCode\IndusFont1840Out3
            string[] flnmsall = Directory.GetFiles(grouper.pathOut3, "*.bmp");
            if (snmx > flnmsall.Length)
            {
                snmx = flnmsall.Length;
                txbxSmplMx.Text = snmx.ToString();
            }
            rndseq = RandomSequence(flnmsall.Length, snmx);
            grouper.DisplayselectedSymbols(rndseq);
           // CreateTrainingCsvFile(rndseq); 
        }
        //****************************************************************
        private void lblInputSerialSamples_Click(object sender, EventArgs e)
        {
            string[] flnmsall = Directory.GetFiles(grouper.pathOut3, "*.bmp");
            int snmx = flnmsall.Length;
            rndseq = new int[snmx];       //removed int[]     
            for (int i = 0; i < snmx; i++)
            {
                rndseq[i] = i;
            }
            grouper.DisplayselectedSymbols(rndseq);
           // CreateTrainingCsvFile(rndseq);
        }
        //****************************************************************
        private void lbl4HistoCsvConvert_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GetHystograms();
            DoNormalize();
            Cursor.Current = Cursors.Default;
        }
        //****************************************************************
        private void GetHystograms()
        {
            //This method creates IndusFont1840_4.csv data file 
            //from Bmp(70X54) folder IndusFont1840Out3
            //by combining 4 hystograms- 
            //Vertical(54), Horizental(70), digonal135(124), digonal45(124)
            //Total 372 columns
            string[] flnms = Directory.GetFiles(grouper.pathOut3, "*.bmp");
            string[] flnmsSel = new string[rndseq.Length];
            for (int i = 0; i < rndseq.Length; i++)
            {
                flnmsSel[i] = flnms[rndseq[i]];
            }
            StreamWriter sw = new StreamWriter(grouper.pathFontsv.Replace("1840", rndseq.Length.ToString().PadLeft(4, '0')));
            for (int n = 0; n < rndseq.Length; n++)
            {
                string line = GetThisHystogram(n, flnmsSel);
                sw.WriteLine(line);
            }
            //for (int n = 0; n < flnms.Length; n++)
            //{
            //    string line = GetThisHystogram(n, flnms);
            //    sw.WriteLine(line);
            //}
            sw.Close();
        }
        //****************************************************************
        private string GetThisHystogram(int n, string[] flnms)
        {
            FileInfo fi = new FileInfo(flnms[n]);
            Bitmap bm = new Bitmap(flnms[n]);
            Rectangle rect = new Rectangle(0, 0, bm.Width - 1, bm.Height - 1);
            string line = fi.Name + ",";
            for (int y = 0; y < bm.Height; y++)
            {
                int xsum = 0;
                for (int x = 0; x < bm.Width; x++)
                {
                    xsum += bm.GetPixel(x, y).G;
                }
                line += xsum.ToString() + ",";
            }
            for (int x = 0; x < bm.Width; x++)
            {
                int ysum = 0;
                for (int y = 0; y < bm.Height; y++)
                {
                    ysum += bm.GetPixel(x, y).G;
                }
                line += ysum.ToString() + ",";
            }
            int m1 = 0;
            for (int c = 0; c < bm.Width + bm.Height; c++)
            {
                int xysum = 0;
                for (int x = 0; x < c; x++)
                {
                    int y = -x + c;
                    if (rect.Contains(x, y))
                    {
                        xysum += bm.GetPixel(x, y).G;
                    }
                }
                line += xysum.ToString() + ",";
                m1++;
            }
            int m2 = 0;
            for (int c = -bm.Width; c < bm.Height; c++)
            {
                int yxsum = 0;
                for (int x = bm.Width - 1; x >= -bm.Height; x--)
                {
                    int y = x + c;
                    if (rect.Contains(x, y))
                    {
                        yxsum += bm.GetPixel(x, y).G;
                    }
                }
                line += yxsum.ToString() + ",";
                m2++;
            }
            line = line.TrimEnd(',');
            return line;
        }
        //****************************************************************
        private void DoNormalize()
        {
            StreamWriter sw = new StreamWriter(grouper.pathTngCsv.Replace("1840", rndseq.Length.ToString().PadLeft(4, '0')));//124 columns normalized training CSV
            string[] lns = File.ReadAllLines(grouper.pathFontsv.Replace("1840", rndseq.Length.ToString().PadLeft(4, '0')));
            for (int n = 0; n < lns.Length; n++)
            {
                string[] wrds = lns[n].Split(',');
                int sum = 0;
                for (int i = 1; i < wrds.Length; i++)
                {
                    sum = (int)Math.Max(sum, int.Parse(wrds[i]));
                }
                string line = wrds[0] + ",";
                if (sum == 0)
                    sum = 1;
                for (int i = 1; i < wrds.Length; i++)
                {
                    float v1 = float.Parse(wrds[i]) / sum;
                    v1 = (float)Math.Round(v1, 3);
                    string vs = v1.ToString();
                    if (vs == "1")
                        vs = "1.0";
                    line += vs.PadRight(5, '0') + ",";
                }
                line = line.TrimEnd(',');
                sw.WriteLine(line);
            }
            sw.Close();
        }
        //****************************************************************
    }
}
