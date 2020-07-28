using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;

namespace BigAlbum
{
    class NnBP
    {
        //..............................................................
        public struct NNDATA
        {
            public float[] inp;
            public float[] outp;
        }
        //..............................................................
        public double eta = 0.01;
        public int ii = 0;
        public int jj = 0;
        public int kk = 0;
        public double[] yi;
        double[] xj;
        double[] yj;
        double[] xk;
        public double[] yk;
        public double[] outk;
        double[,] wij;
        double[,] wjk;
        public int interr;
        public NNDATA[] nnData;
        //..............................................................
        public NnBP()
        {
        }
        //..............................................................
        public void SetParameters()
        {
            yi = new double[ii + 1];
            xj = new double[jj + 1];
            yj = new double[jj + 1];
            xk = new double[kk];
            yk = new double[kk];
            outk = new double[kk];
            wij = new double[ii + 1, jj];
            wjk = new double[jj + 1, kk];
            load_random_weight();
        }
        //..............................................................
        public void LoadInOut(int no)
        {
            
            for (int n = 0; n < nnData[no].inp.Length; n++)
            {
                yi[n] = nnData[no].inp[n];
            }
            for (int n = 0; n < nnData[no].outp.Length; n++)
            {
                outk[n] = nnData[no].outp[n];
            }
        }
        //..............................................................
        public double UpdateNet()
        {
            yi[ii] = 1.0;
            yj[jj] = 1.0;

            for (int j = 0; j < jj; j++)
            {
                xj[j] = 0;
                for (int i = 0; i < ii + 1; i++)
                {
                    xj[j] += yi[i] * wij[i, j];
                }
                if (xj[j] > 10) xj[j] = 10;
                if (xj[j] < -10) xj[j] = -10;
                yj[j] = 1.0 / (1.0 + Math.Exp(-xj[j]));
            }
            for (int k = 0; k < kk; k++)
            {
                xk[k] = 0;
                for (int j = 0; j < jj + 1; j++)
                {
                    xk[k] += yj[j] * wjk[j, k];
                }
                if (xk[k] > 10) xk[k] = 10;
                if (xk[k] < -10) xk[k] = -10;
                yk[k] = 1.0 / (1.0 + Math.Exp(-xk[k]));
            }
            double err = 0;
            interr = 0;
            for (int k = 0; k < kk; k++)
            {
                err += Math.Abs(yk[k] - outk[k]);
                interr += (int)Math.Round(Math.Abs(yk[k] - outk[k]));
            }
            return err;
        }
        //..............................................................
        public void update_and_correct_error()
        {
            int i, j, k;
            double r;
            for (k = 0; k < kk; k++)
                for (j = 0; j < jj + 1; j++)
                    wjk[j, k] -= eta * (yk[k] - outk[k]) * yk[k] * (1 - yk[k]) * yj[j];

            for (j = 0; j < jj; j++)
            {
                r = 0;
                for (k = 0; k < kk; k++)
                    r += (yk[k] - outk[k]) * yk[k] * (1 - yk[k]) * wjk[j, k];
                r = r * eta * yj[j] * (1 - yj[j]);
                for (i = 0; i < ii + 1; i++)
                    wij[i, j] -= r * yi[i];
            }
        }
        //..............................................................
        public void load_random_weight()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            int i, j, k;
            for (k = 0; k < kk; k++) for (j = 0; j < jj + 1; j++)
                    wjk[j, k] = 0.5 - rand.NextDouble();

            for (j = 0; j < jj; j++) for (i = 0; i < ii + 1; i++)
                    wij[i, j] = 0.5 - rand.NextDouble();
            yi[ii] = 1.0;
            yj[jj] = 1.0;
        }
        //..............................................................
        string Net2String()
        {
            string netstr = "";
            netstr += ii.ToString() + "\r\n";
            netstr += jj.ToString() + "\r\n";
            netstr += kk.ToString() + "\r\n";
            int i, j, k;
            for (k = 0; k < kk; k++) for (j = 0; j < jj + 1; j++)
                    netstr += wjk[j, k].ToString() + ",";
            netstr += "\r\n";

            for (j = 0; j < jj; j++) for (i = 0; i < ii + 1; i++)
                    netstr += wij[i, j].ToString() + ",";
            netstr += "\r\n";
            return netstr;
        }
        //..............................................................
        public bool SaveNet(string fileName)
        {
            FileStream strm;
            string content;
            content = Net2String();

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            try
            {
                strm = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            }
            catch
            {
                //("Cannot open " + path + " for writing");
                return false;
            }

            strm.Write(encoding.GetBytes(content), 0, (int)content.Length);
            strm.Close();
            return true;
        }
        //..............................................................
        public bool LoadNet(string flnm)
        {
            FileStream strm;
            byte[] byt;
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            try
            {
                strm = new FileStream(flnm, FileMode.Open, FileAccess.Read);
            }
            catch
            {
                //("Cannot open " + flnm + " for reading");
                return false;
            }
            byt = new byte[strm.Length];
            strm.Read(byt, 0, (int)strm.Length);
            strm.Close();
            string buf = System.Text.ASCIIEncoding.ASCII.GetString(byt);
            bool r = String2Net(buf);
            yi[ii] = 1.0;
            yj[jj] = 1.0;
            return r;
        }
        //..............................................................
        bool String2Net(string netstr)
        {
            netstr = netstr.Replace("\r\n", ",");
            netstr = netstr.Replace(",,", ",");
            string[] words = netstr.Split(new Char[] { ',' });
            int nn = 0;
            ii = System.Convert.ToInt32(words[nn]);
            nn++;
            jj = System.Convert.ToInt32(words[nn]);
            nn++;
            kk = System.Convert.ToInt32(words[nn]);
            nn++;

            yi = new double[ii + 1];
            xj = new double[jj + 1];
            yj = new double[jj + 1];
            xk = new double[kk];
            yk = new double[kk];
            outk = new double[kk];
            wij = new double[ii + 1, jj];
            wjk = new double[jj + 1, kk];

            int i, j, k;
            for (k = 0; k < kk; k++) for (j = 0; j < jj + 1; j++)
                {
                    wjk[j, k] = System.Convert.ToDouble(words[nn]);
                    nn++;
                }

            for (j = 0; j < jj; j++) for (i = 0; i < ii + 1; i++)
                {
                    wij[i, j] = System.Convert.ToDouble(words[nn]);
                    nn++;
                }

            return true;
        }
        //..............................................................
    }
}
