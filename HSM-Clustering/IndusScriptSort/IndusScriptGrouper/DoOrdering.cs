using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndusScriptGrouper
{
    public partial class DoOrdering : Form
    {
        public static int choice;
        public static bool shown;
        public Grouper grouper;
        //**********************************************************
        public DoOrdering()
        {
            InitializeComponent();
        }
        //**********************************************************
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) 
                choice = 1;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                choice = 2;
        }
        //**********************************************************
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                choice = 3;
        }
        //**********************************************************  
        private void DoGrouping_Shown(object sender, EventArgs e)
        {
            shown = true;
        }
        //**********************************************************
        private void DoGrouping_FormClosing(object sender, FormClosingEventArgs e)
        {
            shown = false;
        }
        //********************************************************** 
        private void labelexit_Click(object sender, EventArgs e)
        {
            shown = false;
            this.Hide();
        }
        //**********************************************************
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cursor.Current = Cursors.WaitCursor;
            grouper.MakeHlfPyramid();
            grouper.DataTreeSort(choice);
            Cursor.Current = Cursors.Default;
        }
        //**********************************************************
        //********************************************************** 
    }
}
