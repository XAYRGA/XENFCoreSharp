using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql;
using MySql.Data.MySqlClient;


namespace XENFCoreSharp
{
    public static class SQL2
    {

        static string lastError;
        static public MySqlConnection sqlConnection;
        static string us;
        static string pa;
        static string ho;
        static string da;

        public static bool Init(string host, string user, string password, string db)
        {
            ho = host;
            us = user;
            pa = password;
            da = db;
            return Reconnect();
        }

        public static bool DEBUGKill()
        {
            sqlConnection.Close();
            return true;
        }
        public static bool Reconnect()
        {
            string conStr = string.Format("server={0};user={1};database={2};port=3306;password={3}", ho, us, da, pa);
            sqlConnection = new MySqlConnection(conStr);
            try
            {
                Helpers.warn("SQL2 is reconnecting.");
                sqlConnection.Open();
                Helpers.warn("SQL2 Connected.");
                return true;
            }
            catch (MySqlException E) {
                lastError = E.Message;
                Helpers.warn("SQL2 couldn't connect: " + lastError);
                return false;
            }
        }

        public static bool CheckConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Broken | sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                Reconnect();
                return false;
            }
            return sqlConnection.State == System.Data.ConnectionState.Open;
        }

        public static string escape(string esc)
        {
            return MySqlHelper.EscapeString(esc);
        }

        public static bool Query(string query, out MySqlDataReader rdr)
        {
            rdr = null;
            
            if (!CheckConnection())
            {
                return false;
            }
            MySqlCommand comm = new MySqlCommand(query, sqlConnection);
            try
            {
                rdr = comm.ExecuteReader();
                return true;
            }
            catch (MySqlException E)
            {
                lastError = E.Message;
                return false;
            }
        }

        public static bool NonQuery(string data, out int rowsAffected)
        {
            rowsAffected = 0;
            if (!CheckConnection())
            {
                return false;
            }
            MySqlCommand comm = new MySqlCommand(data, sqlConnection);
            try
            {
                rowsAffected = comm.ExecuteNonQuery();
                return true;
            } catch (MySqlException E)
            {
                lastError = E.Message;
                return false;
            }
        }

        public static string getLastError()
        {
            return lastError;
        }
    }
}
