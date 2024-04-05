using Microsoft.Data.SqlClient;
using System;

namespace LlamaLingo.Pages
{
    public class ServerInterface : IDisposable
    {

        public static SqlConnection conn;
        public static bool isConnected;

        public SqlDataReader reader;

        public int length = 0;

        public void PerformQuery(string sql)
        {
            Connect();
            if (conn == null)
            {
                length = 0;
                reader = null;
            } else
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (sql.StartsWith("SELECT")) {
                        try
                        {
                            reader = cmd.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            conn = null;
                            length = 0;
                            reader = null;

                            var qepithim = sql;
                            
                            length = 1 / length; // intentional crash
                        }
                    }
                    else
                    {
                        reader = null;
                        length = 0;

                        string what = sql;

                        int result = cmd.ExecuteNonQuery();

                        if (result <= 0) {
                            length = 1 / length; // intentional crash
                        }
                    }
                }
            }
        }

        public bool Read()
        {
            if (reader == null)
            {
                length++;
                return (length <= 20);
            } else
            {
                return reader.Read();
            }
        }

        public string GetString(int a)
        {
            if (reader == null)
            {
                return "EXAMPLE " + length + ":" + a;
            } else
            {
                return reader.GetString(a);
            }
        }

		public bool GetBoolean(int a)
		{
			if (reader == null)
			{
				return (a % 2 == 0);
			}
			else
			{
				return reader.GetBoolean(a);
			}
		}

		public int GetInt32(int a)
        {
            if (reader == null)
            {
                return 2*length;
            } else
            {
                return reader.GetInt32(a);
            }
        }

        public static string Connect()
        {
            if (isConnected)
            {
                return "alreadyConnected";
            }

            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "llamalingo.database.windows.net";
            stringBuilder.UserID = "LlamaLingoLogin";
            stringBuilder.Password = "UMDLlamaLingo4444";
            stringBuilder.InitialCatalog = "LlamaLingoDB";

            conn = new SqlConnection(stringBuilder.ConnectionString);
            try
            {
                conn.Open();
            } catch (Exception e)
            {
                conn = null;

            }
            isConnected = true;
            return "qepithim";


        }

        public void Dispose()
        {
            if (reader == null) return;
            reader.DisposeAsync();
        }
    }
}
