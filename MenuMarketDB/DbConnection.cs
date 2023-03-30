﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MenuMarketDB
{
    
    class DbConnection
    {

        static private string Connections = @"Data Source=DESKTOP-CO22LR3;Initial Catalog=marketIN;Integrated Security=True";
        public SqlConnection connection = new SqlConnection(Connections);

        public void ConOpen() 
        {

            if (connection.State == System.Data.ConnectionState.Closed)
            {

                connection.Open();

            }
        
        }

        public void ConClosed() 
        {

            if (connection.State == System.Data.ConnectionState.Open)
            {

                connection.Close();

            }
        
        }

        public SqlConnection GetConnection() 
        {

            return connection;
        
        }
    }
}
