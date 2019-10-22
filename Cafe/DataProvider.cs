using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Cafe
{
    public class DataProvider
    {
        #region Singleton DataProvider
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get 
            {
                if (instance == null)
                    instance = new DataProvider();
                return DataProvider.instance;
            }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }
        #endregion

        // Connection String
        private string connectSTR = @"Data Source=...\...\...\QuanLyCaPhe.db; Version=3";

        #region Methods
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
 
            using (SQLiteConnection connection = new SQLiteConnection(connectSTR))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command); 
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query)
        {
            int data = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectSTR))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query)
        {
            object data = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectSTR))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
        #endregion
    }
}
