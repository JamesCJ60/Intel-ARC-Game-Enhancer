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
using Interop;
using MessageBox = System.Windows.MessageBox;

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

            var startColour = (SolidColorBrush)new BrushConverter().ConvertFrom("#1e90ff");
            var endColour = (SolidColorBrush)new BrushConverter().ConvertFrom("#1ec8ff");

            System.Windows.Application.Current.Resources["PrimaryBlueColor"] = new LinearGradientBrush(startColour.Color, endColour.Color, new Point(0, 1), new Point(1, 0));

            startColour = (SolidColorBrush)new BrushConverter().ConvertFrom("#5160ff");
            endColour = (SolidColorBrush)new BrushConverter().ConvertFrom("#51a9ff");

            System.Windows.Application.Current.Resources["PrimaryBlueColorHover"] = new LinearGradientBrush(startColour.Color, endColour.Color, new Point(0, 0), new Point(1, 1));

            startColour = (SolidColorBrush)new BrushConverter().ConvertFrom("#0059d1");
            endColour = (SolidColorBrush)new BrushConverter().ConvertFrom("#008dd1");
            System.Windows.Application.Current.Resources["PrimaryBlueColorDown"] = new LinearGradientBrush(startColour.Color, endColour.Color, new Point(0, 0), new Point(1, 1));

            //Get current directory
            if (Settings.Default["Path"].ToString() == "" || Settings.Default["Path"].ToString() == null || Settings.Default["Path"].ToString().Contains("System32"))
            {
                //Get current path
                var path = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;

                //Save path
                Settings.Default["Path"] = path;
                Settings.Default.Save();
            }

            InitializeComponent();

            Title.Text = rdDXVK.Content.ToString();
            PagesNavigation.Navigate(new System.Uri("Pages/DXVK.xaml", UriKind.RelativeOrAbsolute));
            string pathToMagpie = Settings.Default.Path + "\\bin\\magpie\\Magpie.exe";
            System.Diagnostics.Process.Start(pathToMagpie);
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

        private void rdDXVK_Click(object sender, RoutedEventArgs e)
        {
            Title.Text = rdDXVK.Content.ToString();
            PagesNavigation.Navigate(new System.Uri("Pages/DXVK.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdGamePatch_Click(object sender, RoutedEventArgs e)
        {
            Title.Text = rdGamePatch.Content.ToString();
            PagesNavigation.Navigate(new System.Uri("Pages/ComingSoon.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdMagpie_Click(object sender, RoutedEventArgs e)
        {
            Title.Text = rdMagpie.Content.ToString();
            PagesNavigation.Navigate(new System.Uri("Pages/Magpie.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdDLSS2FSR_Click(object sender, RoutedEventArgs e)
        {
            Title.Text = rdDLSS2FSR.Content.ToString();
            PagesNavigation.Navigate(new System.Uri("Pages/ComingSoon.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
