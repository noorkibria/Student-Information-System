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
using DemoProject.DAL;

namespace DemoProject
{
    public partial class formCountry : Form
    {
        
        public formCountry()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            formNewCountry newCountry = new formNewCountry();
            newCountry.ShowDialog();
            searchButton.PerformClick();


        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DAL.Country aCountry = new DAL.Country();
            aCountry.Search = searchTextBox.Text;
            searchDataGridView.DataSource = aCountry.Select().Tables[0];

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (searchDataGridView.SelectedRows.Count <= 0)
                return;
            DialogResult aDialogResult = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (aDialogResult != DialogResult.Yes)
                return;

            DAL.Country aCountry = new DAL.Country();
            //aCountry.Id = Convert.ToInt32(searchDataGridView.SelectedRows[0].Cells["columnId"].Value);

            string ids = "";
            for (int i = 0; i < searchDataGridView.SelectedRows.Count; i++)
            {
                ids += searchDataGridView.SelectedRows[0].Cells["columnId"].Value.ToString() + ", ";
            }
            ids = ids.Substring(0, ids.Length - 2);

            if (aCountry.Delete(ids))
            {
                MessageBox.Show("Data Deleted");
                searchButton.PerformClick();
            }
            else
            {
                MessageBox.Show(aCountry.Error);
            }


        }

        

        private void editButton_Click(object sender, EventArgs e)
        {
           
            
        }

       

    }
}

