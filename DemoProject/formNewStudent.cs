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
    public partial class formNewStudent : Form
    {
        ErrorProvider aErrorProvider=new ErrorProvider();
        public formNewStudent()
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
            if (nameTextBox.Text == "")
            {
                error ++;
                aErrorProvider.SetError(nameTextBox,"Requred");
            }
            if (contactTextBox.Text == "")
            {
                error ++;
                aErrorProvider.SetError(contactTextBox, "Required");
            }
            if (emailTextBox.Text == "")
            {
                error++;
                aErrorProvider.SetError(emailTextBox, "Required");
            }
            if (addressTextBox.Text == "")
            {
               
            }
            else if (addressTextBox.Text.Length < 10)
            {
                error ++;
                aErrorProvider.SetError(addressTextBox,"addres must be contained 10 character or more");
            }
            if (error > 0)
                 return;


            System.Data.SqlClient.SqlConnection aConnection=new SqlConnection();
            aConnection.ConnectionString = @"Data Source=DESKTOP-NIK1ATE\sqlexpress;Initial Catalog=DemoProjectDB;
                                                Integrated Security=True";
            aConnection.Open();



            SqlCommand command=new SqlCommand();
            command.Connection = aConnection;
            command.CommandText =@"INSERT INTO Student (Name,Contact,Email,Address,CityId) VALUES 
                                (@Name,@Contact,@Email,@Address,@CityId)";

            command.Parameters.AddWithValue("@Name", nameTextBox.Text);
            command.Parameters.AddWithValue("@Contact", contactTextBox.Text);
            command.Parameters.AddWithValue("@Email", emailTextBox.Text);
            command.Parameters.AddWithValue("@Address", addressTextBox.Text);
            command.Parameters.AddWithValue("@CityId", cityComboBox.SelectedValue);
            


            try
            {
                command.ExecuteNonQuery();

                //database related code will be done here
                MessageBox.Show("Data Saved");
                nameTextBox.Text = "";
                contactTextBox.Text = "";
                emailTextBox.Text = "";
                addressTextBox.Text = "";
                cityComboBox.Text = "";
                countryComboBox.Text = "";
                nameTextBox.Focus();
            }
            catch(Exception aException)
            {
                MessageBox.Show(aException.Message);
            }
            aConnection.Close();


        }

        private void formNewStudent_Load(object sender, EventArgs e)
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

        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
