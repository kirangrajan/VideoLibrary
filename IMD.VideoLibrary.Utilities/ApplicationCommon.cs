using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using System.Configuration;

namespace IMD.VideoLibrary.Utilities
{
    /// <summary>
    /// Application Common
    /// </summary>
    public class ApplicationCommon
    {
        /// <summary>
        /// Default Database
        /// </summary>
        public static string DefaultDatabase
        {
            get
            {
                try
                {
                    return ((DatabaseSettings)ConfigurationManager.GetSection("dataConfiguration")).DefaultDatabase;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Connection Strings
        /// </summary>
        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                try
                {
                    return (ConnectionStringSettingsCollection)ConfigurationManager.ConnectionStrings;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static string DefaultSQLConnectionString
        {
            get
            {
                try
                {
                    return Constants.DefaultSQLConnectionString;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
