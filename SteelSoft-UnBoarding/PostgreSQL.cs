using Npgsql;

namespace SteelSoft_UnBoarding
{
    public class PostgreSQL
    {
        private static string GetConString() => $"host={Config.HOST};port={Config.PORT};username={Config.USER};password={Config.PASS};Database={Config.DATABASE}";

        public static int QueryNotExicute(string query)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(GetConString());
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            return cmd.ExecuteNonQuery();
        }

        public static List<Dictionary<string,string>> Query(string query)
        {
            List<Dictionary<string, string>> result = new();
            using NpgsqlConnection conn = new NpgsqlConnection(GetConString());
            conn.Open();
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var row = new Dictionary<string, string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.GetValue(i).ToString() ?? "";
                }
                result.Add(row);
            }
            return result;
        }
    }
}
