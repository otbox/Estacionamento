using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class Connection
    {
        public static MySqlConnection conn;
        
        public void conectar()
        {
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=;database=estacionamento";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                
            }
        }
    }
}
