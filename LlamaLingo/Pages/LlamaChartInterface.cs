using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LlamaLingo.Pages
{
    public class LlamaChartInterface
    {
		public static bool IsInitialized = false;

		public static List<bool> includeColumn = new List<bool>
		{
			false,
			false,
			true,
			true,
			false,
			false
		};

		public static string databaseName = "ColorTest";

		public static string getDatabaseName()
		{
			return databaseName;
		}

		public static void setDatabaseName(string newVal) {
		    ColorManage.resetInitializationState();
			databaseName = newVal;
			IsInitialized = false;
		}

		public static void Initialize() {

			if (!IsInitialized)
			{
				IsInitialized = true;

				List<bool> output = new List<bool>();
				String sql = "SELECT colNum, includeCol from dbo.ColorChartInfo\n" +
					"WHERE tableName='" + databaseName + "'\n" +
					"ORDER BY colNum;";
				using (ServerInterface reader = new())
				{
					reader.PerformQuery(sql);
					for (int i = 0; reader.Read(); i++)
					{
						output.Add(reader.GetBoolean(1));
					}
				}
				includeColumn = output;
			}
		}

		public static List<bool> getIncludeColumn()
		{
			Initialize();
			return includeColumn;
		}

		public static void setIncludeColumn(List<bool> includeColumn) {
			Initialize();
			LlamaChartInterface.includeColumn = includeColumn;
		}
	}
}
