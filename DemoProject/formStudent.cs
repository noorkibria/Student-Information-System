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
using DemoProject.DAL;

namespace DemoProject
{
    public partial class formStudent : Form
    {
        formNewStudent newStudent = new formNewStudent();
        public formStudent()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            
            //newStudent.MdiParent = this.MdiParent;

            newStudent.ShowDialog();
            searchButton.PerformClick();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DAL.Student aStudent=new Student();
            aStudent.Search = searchTextBox.Text;
            int countryId = 0;

            try
            {
                countryId = Convert.ToInt32(countryComboBox.SelectedValue);
                aStudent.CityId = Convert.ToInt32(cityComboBox.SelectedValue);
            }
            catch
            {
                
            }
            searchDataGridView.DataSource = aStudent.Select(countryId).Tables[0];

        }

        private void formStudent_Load(object sender, EventArgs e)
        {
            DAL.Country aCountry = new DAL.Country();

            countryComboBox.DataSource = aCountry.Select().Tables[0];
            countryComboBox.DisplayMember = "Name";
            countryComboBox.ValueMember = "id";
            countryComboBox.SelectedValue = -1;
        }

        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                System.Data.SqlClient.SqlConnection aConnection = new SqlConnection();
                aConnection.ConnectionString = @"Data Source=DESKTOP-NIK1ATE\sqlexpress;Initial Catalog=DemoProjectDB;
                                                Integrated Security=True";
                aConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = aConnection;
                command.CommandText = "SELECT id,Name FROM City WHERE CountryId=@CountryId";
                command.Parameters.AddWithValue("@countryId", countryComboBox.SelectedValue);

                SqlDataAdapter aDataAdapter = new SqlDataAdapter(command);
                DataSet aDataSet = new DataSet();
                aDataAdapter.Fill(aDataSet);
                aConnection.Close();
                cityComboBox.DataSource = aDataSet.Tables[0];
                cityComboBox.DisplayMember = "Name";
                cityComboBox.ValueMember = "id";
                cityComboBox.SelectedValue = -1;

            }
            catch
            {

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (searchDataGridView.SelectedRows.Count <= 0)
                return;
            DialogResult aDialogResult = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (aDialogResult != DialogResult.Yes)
                return;
            DAL.Student aStudent = new DAL.Student();

            aStudent.Id = Convert.ToInt32(searchDataGridView.SelectedRows[0].Cells["columnId"].Value);
            if (aStudent.Delete())
            {
                MessageBox.Show("Data Deleted");
                searchButton.PerformClick();
            }
            else
            {
                MessageBox.Show(aStudent.Error);
            }


        }

        private void editButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
