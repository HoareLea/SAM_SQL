using System.Data.SqlClient;

namespace SAM.Core.SQL
{
    public static partial class Create
    {
        public static SqlConnection SQLConnection(this string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !System.IO.File.Exists(path))
            {
                return null;
            }

            SqlConnection result = new SqlConnection(string.Format(@"Data Source= {0}", path));

            return result;
        }
    }
}