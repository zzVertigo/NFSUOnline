using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace NFSUOnline.Core.Database
{
    public class MySQL
    {
        public static string connString = "server=localhost;user=root;database=nfsuonline;";

        public static int getSeed(string index, string tableName)
        {
            string sql = "SELECT coalesce(MAX(" + index + "), 0) FROM " + tableName;
            int seed = -1;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Prepare();
                        seed = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch
                {
                    Console.WriteLine("MySQL db exception!!");
                }
            }

            return seed;
        }

        public static long getIDByUsername(string username)
        {
            string sql = "SELECT * FROM players WHERE Username = '" + username + "'";
            long userid = -1;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Prepare();

                        using MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            userid = rdr.GetInt64(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to get the user: " + ex);
                }
            }

            return userid;
        }
    }
}
