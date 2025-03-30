using System;
using System.Windows;
using Microsoft.Win32;
using Software.Data;
using System.Net.Http;

namespace Software
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Ensure compatibility with .NET 6.0 or later
            // DatabaseHelper dbHelper = new DatabaseHelper();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string storedLicenseKey = (string)Registry.GetValue(
                @"HKEY_CURRENT_USER\Software\SoftwareName", "StoredLicenseKey", null);

            if (!string.IsNullOrEmpty(storedLicenseKey))
            {
                // Open MainWindow directly if a valid key exists
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.MainWindow = mainWindow;
            }
            else
            {
                // Open LoginWindow if no valid key exists
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.MainWindow = loginWindow;
            }
        }

    }
}
