using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject.DAL
{
    class City:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
       

        public bool Insert()
        {


            MyCommand = commandBuilder(@"INSERT INTO City (Name,CountryId) VALUES 
                                (@Name,@CountryId)");
            MyCommand.Parameters.AddWithValue("@Name", Name);
            MyCommand.Parameters.AddWithValue("@CountryId", CountryId);


            return ExecuteNQ(MyCommand);

        }
        public bool Update()
        {
            MyCommand = commandBuilder(@"update City set Name= @Name,CountryId=@CountryId where id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@Name", Name);
            MyCommand.Parameters.AddWithValue("@CountryId", CountryId);

            return ExecuteNQ(MyCommand);
        }
         public bool Delete()
        {
            MyCommand = commandBuilder(@"delete from City where id=@id");

            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }
         public bool SelectById()
        {
            MyCommand = commandBuilder(@"select id,Name,CountryId from City where id=@id)");

            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }
          public DataSet Select()
          {
              MyCommand =
                  commandBuilder(@"Select City.id,City.Name,Country.Name as Country from City left join Country on City.CountryId=Country.id where City.id>0");
              if (!string.IsNullOrEmpty(Search))
              {
                  MyCommand.CommandText += " and city.Name like @Search";
                  MyCommand.Parameters.AddWithValue("@Search", "%" + Search + "%");
              }
              if (CountryId > 0)
              {
                  MyCommand.CommandText += " and Country.id=@CountryId";
                  MyCommand.Parameters.AddWithValue("@CountryId", CountryId);
              }
            return ExecuteDataSet(MyCommand);
           
        }
    }
}
