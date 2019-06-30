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
    public partial class formCity : Form
    {
        public formCity()
        {
            InitializeComponent();
        }
        private void formCity_Load(object sender, EventArgs e)
        {
            DAL.Country aCountry = new DAL.Country();
            countryNameComboBox.DataSource = aCountry.Select().Tables[0];
            countryNameComboBox.DisplayMember = "Name";
            countryNameComboBox.ValueMember = "id";
            countryNameComboBox.SelectedValue = -1;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            formNewCity newCity = new formNewCity();
            newCity.ShowDialog();
            searchButton.PerformClick();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DAL.City aCity = new DAL.City();
            aCity.Search = searchTextBox.Text;
            try
            {
                aCity.CountryId = Convert.ToInt32(countryNameComboBox.SelectedValue);
            }
            catch
            {
                
            }
            
            searchDataGridView.DataSource = aCity.Select().Tables[0];
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(searchDataGridView.SelectedRows.Count<=0)
                return;
            DialogResult aDialogResult = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if(aDialogResult!=DialogResult.Yes)
                return;


            System.Data.SqlClient.SqlConnection aConnection = new SqlConnection();
            aConnection.ConnectionString = @"Data Source=DESKTOP-NIK1ATE\sqlexpress;Initial Catalog=DemoProjectDB;
                                                Integrated Security=True";
            aConnection.Open();



            SqlCommand command = new SqlCommand();
            command.Connection = aConnection;
            command.CommandText = @"delete from City where id=@id";
           
            command.Parameters.AddWithValue("@id",searchDataGridView.SelectedRows[0].Cells["columnId"].Value);


            try
            {
                command.ExecuteNonQuery();

                MessageBox.Show("Data Deleted");
                searchButton.PerformClick();
                
            }
            catch (Exception aException)
            {
                MessageBox.Show(aException.Message);
            }
            aConnection.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
           
        }

       
    }
}
