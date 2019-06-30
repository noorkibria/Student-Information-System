using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class StudentManagementSystem : Form
    {
        
        formCountry country = new formCountry();
        formCity city = new formCity();
        formStudent student=new formStudent();

        public StudentManagementSystem()
        {
            InitializeComponent();
        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(country.IsDisposed)
                country=new formCountry();
            country.MdiParent = this;
            country.Show();
            country.BringToFront();



        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(city.IsDisposed)
                city=new formCity();
            city.MdiParent = this;
            city.Show();
            city.BringToFront();

        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (student.IsDisposed)
                student = new formStudent();
            student.MdiParent = this;
            student.Show();
            student.BringToFront();
        }
    }
}
