using IMD.VideoLibrary.Repository.Enum;
using IMD.VideoLibrary.Utilities;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace IMD.VideoLibrary.Repository.Common
{
    public class ApplicationDatabase
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="ApplicationDatabase"/> class from being created. 
        /// Private constructor
        /// </summary>
        private ApplicationDatabase()
        {
        }

        public static Database Create(string connectionString = "", DatabaseType databaseType = DatabaseType.SqlServer)
        {
            Database database;

            switch (databaseType)
            {
                case DatabaseType.SqlServer:
                    database = connectionString.Trim().Length > 0 ? new SqlDatabase(connectionString) :
                new SqlDatabase(ApplicationCommon.ConnectionStrings[ApplicationCommon.DefaultSQLConnectionString].ConnectionString);
                    break;
                default:
                    database = connectionString.Trim().Length > 0 ? new SqlDatabase(connectionString) :
               new SqlDatabase(ApplicationCommon.ConnectionStrings[ApplicationCommon.DefaultSQLConnectionString].ConnectionString);
                    break;
            }

            return database;
        }
    }
}
