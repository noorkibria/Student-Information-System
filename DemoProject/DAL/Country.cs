using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject.DAL
{
    class Country:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public bool Insert()
        {

           
           MyCommand= commandBuilder(@"INSERT INTO Country (Name) VALUES 
                                (@Name)");
           MyCommand.Parameters.AddWithValue("@Name", Name);

           return ExecuteNQ(MyCommand);

        }
        public bool Update()
        {
            MyCommand = commandBuilder(@"update Country set Name=@Name where id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@Name", Name);
           

            return ExecuteNQ(MyCommand);
        }



         public bool Delete(string ids="")
        {
             if (ids == "")
             {
                 MyCommand = commandBuilder(@"delete from Country where id=@id");

                 MyCommand.Parameters.AddWithValue("@id", Id);
             }
             else
             {
                 MyCommand = commandBuilder(@"delete from Country where id in ("+ids+")");
             }
           

            return ExecuteNQ(MyCommand);
        }
         public bool SelectById()
        {
            MyCommand = commandBuilder(@"select id,Name from Country where id=@id)");

            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }
          public DataSet Select()
          {
              MyCommand = commandBuilder(@"Select id,Name from Country");
              if (!string.IsNullOrEmpty(Search))
              {
                  MyCommand.CommandText += " where Name like @Search";
                  MyCommand.Parameters.AddWithValue("@Search", "%" + Search + "%");
              }
              return ExecuteDataSet(MyCommand);
            
        }
    }
}
