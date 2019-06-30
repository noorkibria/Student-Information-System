using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.DAL
{
    internal class Department : MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Insert()
        {
            MyCommand = commandBuilder(@"INSERT INTO Department (Name,Description) VALUES 
                                (@Name,@Descrition)");
            MyCommand.Parameters.AddWithValue("@Name", Name);
            MyCommand.Parameters.AddWithValue("@Descrition", Description);
            return ExecuteNQ(MyCommand);
        }

        public bool Update()
        {
            MyCommand = commandBuilder(@"update Department set Name=@Name,Description=@Description where id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@Name", Name);
            MyCommand.Parameters.AddWithValue("@Descrition", Description);
            return ExecuteNQ(MyCommand);
        }

        public bool Delete()
        {
            MyCommand = commandBuilder(@"delete from Department where id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }

        public bool SelectById()
        {
            MyCommand = commandBuilder(@"select id,Name,Description from Department where id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }
        public DataSet Select()
        {
            return ExecuteDataSet(@"select id,Name,Description from Department");
           

        }
    }
}
