using System.Data;
using System.Data.SqlClient;

namespace SAM.Core.SQL
{
    public static partial class Query
    {
        public static DataTable DataTable(this SqlConnection sQLConnection, string tableName, params string[] columnNames)
        {
            if(sQLConnection == null || string.IsNullOrEmpty(tableName))
            {
                return null;
            }

            if(sQLConnection.State != ConnectionState.Open)
            {
                sQLConnection.Open();
            }

            string names = null;
            if(columnNames == null || columnNames.Length == 0)
            {
                names = "*";
            }
            else
            {
                names = string.Join(", ", columnNames);
            }

            DataTable result = null;
            using (SqlCommand sQLiteCommand = sQLConnection.CreateCommand())
            {
                sQLiteCommand.CommandText = string.Format("SELECT {0} FROM {1}", names, tableName);
                using (SqlDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader(CommandBehavior.SingleResult))
                {
                    result = new DataTable();
                    result.Load(sQLiteDataReader);
                }
            }

            return result;
        }
    }
}