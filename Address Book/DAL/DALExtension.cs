using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Address_Book.DAL
{
    public static class DALExtension
    {
        public static string GetSafeString(this SqlDataReader reader, string column)
        {
            var value = reader[column];
            if (value == DBNull.Value || value == null)
                return string.Empty;
            return (string)reader[column];
        }
        public static int GetSafeInt(this SqlDataReader reader, string column)
        {
            var value = reader[column];
            if (value == DBNull.Value || value == null)
                return 0;
            return (int)reader[column];
        }
        public static bool GetSafeBool(this SqlDataReader reader, string column)
        {
            var value = reader[column];
            if (value == DBNull.Value || value == null)
                return false;
            return (bool)value;
        }
    }
}