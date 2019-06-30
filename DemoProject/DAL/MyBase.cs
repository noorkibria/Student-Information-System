using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DemoProject.DAL
{
    class MyBase
    {
        protected string _error;

        public string Error
        {
            get { return _error; }
        }

        public string Search { get; set; }
        protected SqlConnection aConnection = new SqlConnection(@"Data Source=DESKTOP-NIK1ATE\sqlexpress;Initial Catalog=DemoProjectDB;
                                                Integrated Security=True");

        protected bool Connection()
        {
            try
            {
                aConnection.Open();
                return true;
            }
            catch (Exception aException)
            {
                _error = aException.Message;
            }
            return false;

        }

        protected bool ExecuteNQ(SqlCommand command)
        {
            if (!Connection())
                return false;
            try
            {
                command.ExecuteNonQuery();
                return true;

            }
            catch (Exception aException)
            {
                _error = aException.Message;

            }

            return false;
        }
        protected SqlCommand MyCommand { get; set; }
        protected SqlCommand commandBuilder(string sql)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = aConnection;
            command.CommandText = sql;
            return command;
        }

        protected DataSet ExecuteDataSet(string sql)
        {
            if (!Connection())
                return null;


            SqlCommand command = new SqlCommand();
            command.Connection = aConnection;
            command.CommandText =sql;
            SqlDataAdapter aDataAdapter = new SqlDataAdapter(command);
            DataSet aDataSet = new DataSet();
            aDataAdapter.Fill(aDataSet);

            return aDataSet;
        }
        protected DataSet ExecuteDataSet(SqlCommand command)
        {
            if (!Connection())
                return null;

            SqlDataAdapter aDataAdapter = new SqlDataAdapter(command);
            DataSet aDataSet = new DataSet();
            aDataAdapter.Fill(aDataSet);

            return aDataSet;
        }
    }
}
