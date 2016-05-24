using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Easy.Infrastructure.Repository
{
    static class DataBase
    {
        private static readonly string ConnectString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        public static IDbConnection Open()
        {
            var db = new MySqlConnection(ConnectString);
            db.Open();
            return db;
        }
    }
}
