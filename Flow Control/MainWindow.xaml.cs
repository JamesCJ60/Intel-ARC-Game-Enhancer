using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Flow_Control.Properties;
using Flow_Control.Scripts;
using Interop;
using RyzenSMUBackend;

namespace Flow_Control
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public MainWindow()
        {
            if (!MainWindow.IsAdministrator())
            {
                // Restart and run as admin
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                startInfo.Arguments = "restart";
                Process.Start(startInfo);
                this.Close();
            }

            //Get current directory
            if (Settings.Default["Path"].ToString() == "" || Settings.Default["Path"].ToString() == null || Settings.Default["Path"].ToString().Contains("System32"))
            {
                //Get current path
                var path = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;

                //Save APU Name
                Settings.Default["CPUName"] = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");

                //Save CPUID
                ManagementClass managClass = new ManagementClass("win32_processor");
                ManagementObjectCollection managCollec = managClass.GetInstances();

                foreach (ManagementObject managObj in managCollec)
                {
                    Settings.Default["CPUID"] = managObj.Properties["processorID"].Value.ToString();
                    break;
                }

                //Save path
                Settings.Default["Path"] = path;
                Settings.Default.Save();
            }

            if (Settings.Default.CPUName.Contains("AMD") || Settings.Default.CPUName.Contains("Ryzen"))
            {
                Families.SetFam();
            }

            InitializeComponent();

            compatCheck();
            

            PagesNavigation.Navigate(new System.Uri("Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        [DllImport("inpoutx64.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPhysLong(UIntPtr memAddress, ref uint DData);

        [DllImport("inpoutx64.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsInpOutDriverOpen();

        [DllImport("inpoutx64.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetPhysLong(UIntPtr memAddress, uint DData);

        public void compatCheck()
        {
            string deviceName = MotherboardInfo.Product;

            if (!deviceName.Contains("Flow"))
            {
                System.Windows.Forms.DialogResult dialog = System.Windows.Forms.MessageBox.Show("Unsupported device detected! This program only works on ROG Flow devices", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialog == System.Windows.Forms.DialogResult.OK)
                {
                    Environment.Exit(0);

                }
                else if (dialog == System.Windows.Forms.DialogResult.None)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void Close_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Minimise_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
