using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        formCountry aCountry = new formCountry();
        formCity aCity = new formCity();
        formStudent aStudent = new formStudent();

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(aCountry.IsDisposed)
                aCountry=new formCountry();

                aCountry.MdiParent = this;
                aCountry.Show();
                aCountry.BringToFront();
            
        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aCity.IsDisposed)
                aCity = new formCity();
            
                
                aCity.Show();
                aCity.MdiParent = this;
                aCity.BringToFront();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aStudent.IsDisposed)
                aStudent = new formStudent();
            aStudent.MdiParent = this;
            aStudent.Show();
            aStudent.BringToFront();
        }
    }
}
