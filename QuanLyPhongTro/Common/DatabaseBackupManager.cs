using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Data;

namespace MyWork.Common
{
    public static class DatabaseBackupManager
    {
        public static void BackupDatabase(string backupPath)
        {
            string connectionString = GetConnectionStringWithoutMetadata();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(GetSqlConnectionString(connectionString)))
                {
                    ServerConnection connection = new ServerConnection(sqlConnection);
                    Server sqlServer = new Server(connection);
                    Backup backup = new Backup();
                    backup.Action = BackupActionType.Database;
                    string databaseName = "MyWork";
                    if (sqlServer.Databases.Contains(databaseName))
                    {
                        Database database = sqlServer.Databases[databaseName];
                        backup.Database = database.Name;
                        BackupDeviceItem backupDevice = new BackupDeviceItem(backupPath, DeviceType.File);
                        backup.Devices.Add(backupDevice);
                        backup.Initialize = true;
                        backup.Checksum = true;
                        backup.ContinueAfterError = true;
                        backup.SqlBackup(sqlServer);

                        MessageBox.Show($"Sao lưu thành công. File đã được lưu ở {backupPath}", "Sao lưu hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Cơ sở dữ liệu '{databaseName}' không được tìm thấy trên server.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GetConnectionStringWithoutMetadata()
        {
            // Kiểm tra xem chuỗi kết nối đã được lưu trong bộ nhớ cache chưa
            if (!string.IsNullOrEmpty(ConnectionHelper.cachedConnectionString) && TryOpenConnection(ConnectionHelper.cachedConnectionString))
            {
                return ConnectionHelper.cachedConnectionString;
            }
            // Kiểm tra xem có chuỗi kết nối trong App.config không
            string appConfigConnectionString = ConfigurationManager.ConnectionStrings["MyWorkEntities"]?.ConnectionString;
            if (!string.IsNullOrEmpty(appConfigConnectionString) && TryOpenConnection(appConfigConnectionString))
            {
                // Lưu giữ chuỗi kết nối vào bộ nhớ cache
                ConnectionHelper.cachedConnectionString = appConfigConnectionString;
                return appConfigConnectionString;
            }
            // Nếu không có trong App.config hoặc kết nối không hợp lệ, thì đọc từ file config.xml
            string defaultConnectionString = GetDefaultConnectionString();
            ConnectionHelper.cachedConnectionString = defaultConnectionString;
            return defaultConnectionString;
        }

        private static string GetDefaultConnectionString()
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
            return GetDefaultSqlConnectionString();
        }

        private static bool IsConnectionStringValid(string connectionString)
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

        private static bool TryOpenConnection(string connectionString)
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

        private static string GetSqlConnectionString(string entityConnectionString)
        {
            var entityBuilder = new EntityConnectionStringBuilder(entityConnectionString);
            return entityBuilder.ProviderConnectionString;
        }

        private static string GetDefaultSqlConnectionString()
        {
            // Cấu hình chuỗi kết nối SQL mặc định với ServerName là "."
            var sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = ".",  // Server mặc định là "."
                InitialCatalog = "MyWork",
                IntegratedSecurity = true,  // Sử dụng xác thực Windows, bạn có thể thay đổi nếu cần
                MultipleActiveResultSets = true
            };

            return sqlBuilder.ToString();
        }
    }
}
