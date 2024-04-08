using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LlamaLingo.Pages
{
    public class ColorManage
    {
        private static int currentID = 2;

        private static bool idInitialized = false;
        private static SqlConnection conn = null;

        private static List<string> componentNames = new List<string>() { "Red Strength", "Green Strength", "Blue Strength" };
        public static List<int> getComponents()
        {
			//List<int> output;
			//string sql = "SELECT redStr, grnStr, bluStr from dbo.ColorTest\n" +
			//    "WHERE id=" + currentID + ";";
			//using (ServerInterface reader = new())
			//{
			//    reader.PerformQuery(sql);
			//    if (reader.Read())
			//    {
			//        output = new List<int>
			//    {
			//        reader.GetInt32(0),
			//        reader.GetInt32(1),
			//        reader.GetInt32(2),
			//    };
			//    }
			//    else
			//    {
			//        output = new List<int>
			//    {
			//        0, 0, 0
			//    };
			//    }
			//}
			//return output;

			initializeId();
			return getComponents(LlamaChartInterface.getIncludeColumn());
        }

		public static List<int> getComponents(List<bool> includeElement)
		{
			initializeId();
			List<int> output = new List<int>();
			string sql = "SELECT * from dbo." + LlamaChartInterface.getDatabaseName() + "\n" +
				"WHERE id=" + currentID + ";";
			using (ServerInterface reader = new())
			{
				reader.PerformQuery(sql);
                reader.Read();
				for (int i = 0; ; i++)
                {
                    if (i >= includeElement.Count) break;
                    if (includeElement[i])
                    {
                        output.Add(reader.GetInt32(i));
                    }
                }
			}
			return output;
		}

		public static List<string> getComponentNames(List<bool> includeElement)
		{
			initializeId();
			List<string> output = new List<string>();
			string sql = "SELECT COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS\n"
					+ "WHERE TABLE_NAME='" + LlamaChartInterface.getDatabaseName() + "';";
			using (ServerInterface reader = new())
			{
				reader.PerformQuery(sql);
				for (int i = 0; reader.Read(); i++)
				{
					if (i >= includeElement.Count)
                    {
                        includeElement.Add(false);
                    }
					if (includeElement[i])
					{
						output.Add(reader.GetString(0));
					}
				}
			}
			return output;
		}

		public static List<string> getDatabaseComponentNames()
		{
			initializeId();
			List<string> output = new List<string>();
			string sql = "SELECT COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS\n"
					+ "WHERE TABLE_NAME='" + LlamaChartInterface.getDatabaseName() + "';";
			using (ServerInterface reader = new())
			{
				reader.PerformQuery(sql);
				for (int i = 0; reader.Read(); i++)
				{
				    output.Add(reader.GetString(0));
				}
			}
			return output;
		}

		public static bool setCurrentId(int id)
		{
			initializeId();
			string sql = "SELECT * from dbo." + LlamaChartInterface.getDatabaseName() + "\n" +
				"WHERE id=" + id + ";";
            using (ServerInterface reader = new ServerInterface())
            {
                reader.PerformQuery(sql);
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

        public static int getCurrentId()
		{
			initializeId();
			return currentID;
        }

        public static List<int> getIDs()
		{
			initializeId();
			List<int> output = new List<int>();
            string sql = "SELECT id from dbo." + LlamaChartInterface.getDatabaseName() + "";
            using (ServerInterface reader = new ServerInterface())
            {
                reader.PerformQuery(sql);
                while (reader.Read())
                {
                    output.Add(reader.GetInt32(0));
                }
            }
            return output;
		}



        public static List<string> getColors()
		{
			initializeId();
			string titleCol = "color";
			string sql = "SELECT titleCol from dbo.ColorChartTitles\n" +
				"WHERE tableName='" + LlamaChartInterface.getDatabaseName() + "';";
			using (ServerInterface reader = new ServerInterface())
			{
				reader.PerformQuery(sql);
				if (reader.Read())
				{
					titleCol = reader.GetString(0);
				}
			}

			List<string> output = new List<string>();
			sql = "SELECT " + titleCol + " from dbo." + LlamaChartInterface.getDatabaseName() + "";
            using (ServerInterface reader = new ServerInterface())
            {
                reader.PerformQuery(sql);
                while (reader.Read())
                {
                    output.Add(reader.GetString(0));
                }
            }
			return output;
		}

        public static string getThisColor()
        {
            initializeId();

            string titleCol = "color";
            string sql = "SELECT titleCol from dbo.ColorChartTitles\n" +
                "WHERE tableName='" + LlamaChartInterface.getDatabaseName() + "';";
            using (ServerInterface reader = new ServerInterface())
            {
                reader.PerformQuery(sql);
                if (reader.Read())
                {
                    titleCol = reader.GetString(0);
                }
            }

            sql = "SELECT " + titleCol + " from dbo." + LlamaChartInterface.getDatabaseName() + "\n"
                + "WHERE id=" + currentID + ";";
            using (ServerInterface reader = new ServerInterface())
            {
                reader.PerformQuery(sql);
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

        public static string initializeId()
        {
			if (idInitialized)
			{
				return "alreadyConnected";
			}

			idInitialized = true;

			string sql = "SELECT MIN(id) from dbo." + LlamaChartInterface.getDatabaseName();
			using (ServerInterface reader = new ServerInterface())
			{
				reader.PerformQuery(sql);
				if (reader.Read())
				{
					currentID = reader.GetInt32(0);
				}
			}

			return "qepithim";


		}

		public static void resetInitializationState()
		{
			idInitialized = false;
		}
    }
}
