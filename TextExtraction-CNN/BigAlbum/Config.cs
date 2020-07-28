using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
//H.S.Mazumdar March 19, 2018 
namespace BigAlbum
{
    //******************************************************
    public class Config
    {
        //******************************************************
        public string exePath;
        public string tngPath;
        public string tstPath;
        public string sigPath;
        public string netPath;
        public string projFolder;
        int count = 6;
        //******************************************************
        public Config()
        {
            exePath = Application.StartupPath;
        }
        //*******************************************************
        public bool LoadCfg(string flnm)
        {
            if (!File.Exists(flnm))
                return false;
            string[] lines = File.ReadAllLines(flnm);
            if (lines.Length < count)
            {
                MessageBox.Show("Old version of *.cfg File");
                return false;
            }
            if (lines[0] != exePath)
            {
                MessageBox.Show("CAUSION: Code is relocated");
                return false;
            }
            tngPath = lines[1];
            tstPath = lines[2];
            sigPath = lines[3];
            netPath = lines[4];
            projFolder = lines[5];
            
            return true;
        }
        //*******************************************************
        public void SaveCfg(string flnm)
        {
            string[] lines = new string[count];
            lines[0] = exePath;
            lines[1] = tngPath;
            lines[2] = tstPath;
            lines[3] = sigPath;
            lines[4] = netPath;
            lines[5] = projFolder;
            File.WriteAllLines(flnm, lines);
        }
        //*********************************************
    }
    //******************************************************
}
