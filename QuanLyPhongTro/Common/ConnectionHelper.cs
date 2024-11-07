using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.IO;
using System.Configuration;

namespace MyWork.Common
{
    public class ConnectionHelper
    {
        public static string cachedConnectionString;
        public static string GetConnectionString()
        {
            // Kiểm tra xem chuỗi kết nối đã được lưu trong bộ nhớ cache chưa
            if (!string.IsNullOrEmpty(cachedConnectionString) && TryOpenConnection(cachedConnectionString))
            {
                return cachedConnectionString;
            }

            // Kiểm tra xem có chuỗi kết nối trong App.config không
            string appConfigConnectionString = ConfigurationManager.ConnectionStrings["MyWorkEntities"]?.ConnectionString;

            if (!string.IsNullOrEmpty(appConfigConnectionString) && TryOpenConnection(appConfigConnectionString))
            {
                // Lưu giữ chuỗi kết nối vào bộ nhớ cache
                cachedConnectionString = appConfigConnectionString;
                return appConfigConnectionString;
            }

            // Nếu không có trong App.config hoặc kết nối không hợp lệ, thì đọc từ file config.xml
            string defaultConnectionString = GetDefaultConnectionString();

            // Lưu giữ chuỗi kết nối vào bộ nhớ cache
            cachedConnectionString = defaultConnectionString;

            return defaultConnectionString;
        }


        public static bool TryOpenConnection(string connectionString)
        {
            try
            {
                var entityBuilder = new EntityConnectionStringBuilder(connectionString);
                using (var connection = new SqlConnection(entityBuilder.ProviderConnectionString))
                {
                    connection.Open();
                    return connection.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsConnectionStringValid(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string GetDefaultConnectionString()
        {
            // Đọc chuỗi kết nối từ file config.xml
            const string ConfigFileName = "config.xml";
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);

            if (File.Exists(configPath))
            {
                var doc = new XmlDocument();
                doc.Load(configPath);

                var connectionStringNode = doc.SelectSingleNode("/configuration/connectionStrings/add[@name='MyWorkEntities']");
                if (connectionStringNode != null)
                {
                    string defaultConnectionString = connectionStringNode.Attributes["connectionString"].Value;

                    if (IsConnectionStringValid(defaultConnectionString))
                    {
                        return defaultConnectionString;
                    }
                }
            }

            // Nếu không tìm thấy chuỗi kết nối trong file hoặc kết nối không hợp lệ, trả về chuỗi mặc định hoặc có thể throw exception tùy vào logic của bạn.
            return "default_connection_string";
        }
    }
}
