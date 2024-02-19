using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LlamaLingo.Pages
{
    public class ColorManage
    {
        private static int currentID = 2;

        private static bool isConnected = false;
        private static SqlConnection conn = null;

        private static List<string> componentNames = new List<string>() { "Red Strength", "Green Strength", "Blue Strength" };
        public static List<int> getComponents()
        {
            //        connect();

            //        List<int> output;
            //        String sql = "SELECT redStr, grnStr, bluStr from dbo.ColorTest\n" +
            //            "WHERE id=" + currentID + ";";
            //        using (SqlCommand cmd = new SqlCommand(sql, conn))
            //        {
            //            using (SqlDataReader reader = cmd.ExecuteReader())
            //            {
            //                if (reader.Read()) {
            //                    output = new List<int>
            //                    {
            //                        reader.GetInt32(0),
            //                        reader.GetInt32(1),
            //                        reader.GetInt32(2),
            //                    };
            //                } else
            //                {
            //                    output = new List<int>
            //                    {
            //                        0, 0, 0
            //                    };
            //                }
            //}
            //        }
            //        return output;

            
            List<int> output;
            String sql = "SELECT redStr, grnStr, bluStr from dbo.ColorTest\n" +
                "WHERE id=" + currentID + ";";
            using (ServerIntermediary reader = new ServerIntermediary(sql))
            {
                if (reader.Read()) {
                    output = new List<int>
                    {
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2),
                    };
                } else
                {
                    output = new List<int>
                    {
                        0, 0, 0
                    };
                }
            }
            return output;
        }

        public static bool setCurrentId(int id)
        {
			String sql = "SELECT * from dbo.ColorTest\n" +
				"WHERE id=" + id + ";";
            using (ServerIntermediary reader = new ServerIntermediary(sql))
            {
                if (reader.Read())
				{
                    currentID = id;
                    return true;
				}
				else
				{
                    return false;
				}
			}
        }

        public static bool incrementId()
        {
            String sql = "Select id from dbo.ColorTest\n" +
                "WHERE id > " + currentID + "\n" +
                "ORDER BY id;";
            using (ServerIntermediary reader = new ServerIntermediary(sql))
            {
                if (reader.Read())
                {
                    currentID = reader.GetInt32(0);
                    return true;
                }
            }
            sql = "Select id from dbo.ColorTest\n" +
                "ORDER BY id;";
            using (ServerIntermediary reader = new ServerIntermediary(sql))
            {
                if (reader.Read())
                {
                    currentID = reader.GetInt32(0);
                    return true;
                } else
                {
                    return false;
                }
            }
        }
        public static int getCurrentId()
		{
			return currentID;
        }

        public static List<int> getIDs()
        {
			List<int> output = new List<int>();
            String sql = "SELECT id from dbo.ColorTest";
            using (ServerIntermediary reader = new ServerIntermediary(sql))
            {
				while (reader.Read())
                {
                    output.Add(reader.GetInt32(0));
                }
			}
            return output;
		}



        public static List<string> getColors()
        {
            List<string> output = new List<string>();
			String sql = "SELECT color from dbo.ColorTest";
            using (ServerIntermediary reader = new ServerIntermediary(sql))
            {
                while (reader.Read())
				{
					output.Add(reader.GetString(0));
				}
			}
			return output;
		}

        public static string getThisColor()
        {
            String sql = "SELECT color from dbo.ColorTest\n"
                + "WHERE id=" + currentID + ";";
            using (ServerIntermediary reader = new ServerIntermediary(sql))
            {
                while (reader.Read())
				{
					return reader.GetString(0);
				}
			}
            return "";
		}

        public static List<string> getComponentNames()
        {
            return componentNames;
        }

        public static string connect()
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
			conn.Open();
            isConnected = true;
            return "qepithim";


		}
    }
}
