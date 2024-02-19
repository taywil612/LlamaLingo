using Microsoft.Data.SqlClient;
using System.Data;

namespace LlamaLingo.Pages
{
    public class ServerIntermediary : System.IDisposable
    {
        public static bool isConnected = false;
        public static SqlConnection conn = null;

        public SqlCommand sqlCommand = null;
        public SqlDataReader reader = null;

        public bool Read()
        {
            return reader.Read();
        }

        public string GetString(int i)
        {
            return reader.GetString(i);
        }

        public int GetInt32(int i)
        {
            return reader.GetInt32(i);
        }

        public void submitQuery(string query)
        {
            connect();
            sqlCommand = new SqlCommand(query, conn);
            reader = sqlCommand.ExecuteReader();
        }

        public ServerIntermediary(string query)
        {
            connect();
            submitQuery(query);
        }
        public static void connect()
        {
            if (isConnected)
            {
                return;
            }

            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "llamalingo.database.windows.net";
            stringBuilder.UserID = "LlamaLingoLogin";
            stringBuilder.Password = "UMDLlamaLingo4444";
            stringBuilder.InitialCatalog = "LlamaLingoDB";

            conn = new SqlConnection(stringBuilder.ConnectionString);
            conn.Open();
            isConnected = true;
        }

        public void Dispose()
        {
            reader.DisposeAsync();
        }
    }
}
