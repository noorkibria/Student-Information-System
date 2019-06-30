using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.DAL
{
    class Student:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }

        public DataSet Select(int countryId=0)
        {
            MyCommand = commandBuilder(@"select Student.id,Student.Name,Student.Contact,Student.Email,Student.Address,City.Name as City,Country.Name as Country
                                    from Student 
                                    join City on Student.CityId=City.id
                                    join Country on City.CountryId=Country.id where Student.id>0");
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " and (Student.Name like @Search or Student.Contact like @search or Student.Email like @search or Student.Address like @Search)";
                MyCommand.Parameters.AddWithValue("@Search", "%" + Search + "%");
            }
            if (CityId > 0)
            {
                MyCommand.CommandText += " and City.id=@CityId";
                MyCommand.Parameters.AddWithValue("@CityId", CityId);
            }
            if (countryId > 0)
            {
                MyCommand.CommandText += " and Country.id=@CountryId";
                MyCommand.Parameters.AddWithValue("@CountryId", countryId);
            }
            return ExecuteDataSet(MyCommand);
       

        }
        public bool Delete()
        {
            MyCommand = commandBuilder(@"delete from Student where id=@id");

            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }
        public bool Update()
        {
            MyCommand = commandBuilder(@"update Student set Name=@Name,Contact=@Contact,Email=@Email,Address=@Address where id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@Name", Name);
            MyCommand.Parameters.AddWithValue("@Contact", Contact);
            MyCommand.Parameters.AddWithValue("@Email", Email);
            MyCommand.Parameters.AddWithValue("@Address", Address);

            return ExecuteNQ(MyCommand);
        }

    }
    
}
