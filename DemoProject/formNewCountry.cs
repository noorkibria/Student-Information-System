using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoProject
{
    public partial class formNewCountry : Form
    {
        ErrorProvider aErrorProvider=new ErrorProvider();
        public formNewCountry()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int error = 0;
            aErrorProvider.Clear();
            if (countryNameTextBox.Text == "")
            {
                error++;
                aErrorProvider.SetError(countryNameTextBox, "Requred");
            }
            if(error>0)
                return;

            DAL.Country aCountry = new DAL.Country();
            aCountry.Name = countryNameTextBox.Text;
            if(aCountry.Insert())
            {
               
                MessageBox.Show("Data Saved");
                countryNameTextBox.Text = "";
                countryNameTextBox.Focus();

            }
            else 
            {
                MessageBox.Show(aCountry.Error);
            }
           
        }

        private void countryNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
           
        }
    }
}
