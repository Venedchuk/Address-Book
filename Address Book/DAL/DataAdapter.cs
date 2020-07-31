using Address_Book.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Address_Book.DAL
{
    public class DataAdapter
    {
        public DataAdapter()
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"] ?? throw new ConfigurationErrorsException();

        }
        public DataAdapter(string customConnectionString)
        {
            ConnectionString = customConnectionString;

        }
        string ConnectionString;
        public IEnumerable<User> GetUsers(string env)
        {
            List<User> resultList = new List<User>();
            using (SqlConnection dbConnection = new SqlConnection(ConnectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    using (SqlCommand dbCommand = new SqlCommand())
                    {
                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "GetUserWithPhones";
                        dbCommand.Parameters.Add("@env", SqlDbType.NVarChar).Value = env;
                        dbConnection.Open();
                        reader = dbCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            if (resultList.Any(u => u.Id == (int)reader["Id"]))
                            {
                                AddPhones(resultList, reader);
                            }
                            else
                            {
                                User user = new User
                                {
                                    Id = (int)reader["Id"],
                                    Name = (string)reader["Name"],
                                    Phones = new List<Phone>()
                                };
                                resultList.Add(user);
                                AddPhones(resultList, reader);

                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            };
            return resultList;
        }
        private void AddPhones(List<User> resultList, SqlDataReader reader)
        {



            if (!string.IsNullOrWhiteSpace(reader.GetSafeString("PhoneNumber")))
            {
                var phone = new Phone()
                {
                    Id = reader.GetSafeInt("Id"),
                    IsActive = reader.GetSafeBool("IsActive"),

                    OwnerId = reader.GetSafeInt("OwnerId"),
                    PhoneNumber = reader.GetSafeString("PhoneNumber")
                };
                 resultList.Single(u => u.Id == (int)reader["id"]).Phones.Add(phone);
            }

           
        }

    }
}