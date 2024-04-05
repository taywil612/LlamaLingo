using System.Collections.Generic;
using System;

namespace LlamaLingo.Pages
{
    public class NextItem
    {
        static int Elements(int min)
        {
            String sql = "SELECT TOP 1 id from dbo." + LlamaChartInterface.getDatabaseName() + "\n"
                + "WHERE id>" + min + "\n"
                + "ORDER BY id";
            using (ServerInterface reader = new ServerInterface())
            {
                reader.PerformQuery(sql);
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
            }

            if (min == int.MinValue)
            {
                return min;
            }
            else
            {
                return Elements(int.MinValue);
            }
        }

        public static int GetNextID(int currentID)
        {
            int ints = Elements(currentID);
            return ints;
        }
    }


}
