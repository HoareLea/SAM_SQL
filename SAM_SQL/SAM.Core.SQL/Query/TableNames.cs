using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SAM.Core.SQL
{
    public static partial class Query
    {
        public static List<string> TableNames(this string path)
        {
            SqlConnection sQLiteConnection = new SqlConnection(string.Format(@"Data Source= {0}", path));

            return sQLiteConnection.TableNames();
        }

        public static List<string> TableNames(this SqlConnection sQLConnection)
        {
            if (sQLConnection == null)
                return null;

            if(sQLConnection.State != ConnectionState.Open)
            {
                sQLConnection.Open();
            }

            List<string> result = new List<string>();
            DataTable dataTable = sQLConnection.GetSchema("Tables");
            foreach (DataRow row in dataTable.Rows)
            {
                string tablename = (string)row[2];
                result.Add(tablename);
            }

            return result;
        }
    }
}