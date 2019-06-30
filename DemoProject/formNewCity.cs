using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{

    public partial class formNewCity : Form
    {
        private ErrorProvider aErrorProvider = new ErrorProvider();

        public formNewCity()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void formNewCity_Load(object sender, EventArgs e)
        {
            DAL.Country aCountry = new DAL.Country();
            countryNameComboBox.DataSource = aCountry.Select().Tables[0];
            countryNameComboBox.DisplayMember = "Name";
            countryNameComboBox.ValueMember = "id";
            countryNameComboBox.SelectedValue = -1;



        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int error = 0;
            aErrorProvider.Clear();
            if (cityNameTextBox.Text == "")
            {
                error++;
                aErrorProvider.SetError(cityNameTextBox, "Requred");
            }
            if (countryNameComboBox.SelectedValue == null || countryNameComboBox.SelectedValue.ToString() == "")
            {
                error++;
                aErrorProvider.SetError(countryNameComboBox, "Requred");
            }
            if (error > 0)
                return;


            DAL.City aCity = new DAL.City();
            aCity.Name = cityNameTextBox.Text;
            aCity.CountryId = Convert.ToInt32(countryNameComboBox.SelectedValue);

            if (aCity.Insert())
            {

                MessageBox.Show("Data Saved");
                cityNameTextBox.Text = "";
                countryNameComboBox.SelectedValue = -1;

                cityNameTextBox.Focus();

            }
            else
            {
                MessageBox.Show(aCity.Error);
            }

        }

        private void countryNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
