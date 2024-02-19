namespace LlamaLingo.Pages
{
	public class StoredChartType
	{
		public static string currentType = "color-chart";

		public static void setType(string type)
		{
			currentType = type;
		}

		public static string getType() { return currentType; }
	}
}
