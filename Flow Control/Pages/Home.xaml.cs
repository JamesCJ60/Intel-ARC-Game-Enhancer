using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Flow_Control.Scripts;
using Flow_Control.Properties;
using AATUV3.Scripts;

namespace Flow_Control.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            string deviceName = MotherboardInfo.Product;
            deviceName = deviceName.Substring(0, deviceName.LastIndexOf('_'));
            deviceName = deviceName.Replace("ROG ", null);
            lblDeviceName.Text = deviceName;


            lblCPUName.Text = GetSystemInfo.GetCPUName().Replace("with Radeon Graphics", null); ;
            lbliGPUName.Text = GetSystemInfo.GetiGPUName().Replace("(R)", null); ;
            lbldGPUName.Text = GetSystemInfo.GetdGPUName().Replace("Laptop GPU", null); ;

            if(GetSystemInfo.GetdGPUName() == null || GetSystemInfo.GetdGPUName() == "")
            {
                dGPUName.Visibility = Visibility.Collapsed;
            }

            switchProfile(Settings.Default.ACProfile);

            if (Settings.Default.ACProfile == 0) rdSilent.IsChecked = true;
            else if (Settings.Default.ACProfile == 1) rdPerf.IsChecked = true;
            else if (Settings.Default.ACProfile == 2) rdTurbo.IsChecked = true;
            else if (Settings.Default.ACProfile == 3) rdMan.IsChecked = true;
        }

        public async void switchProfile(int ACProfile)
        {
            if (ACProfile == 0)
            {
                imgACProfile.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/ACProfiles/Silent.png"));
            }
            if (ACProfile == 1)
            {
                imgACProfile.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/ACProfiles/Bal.png"));
            }
            if (ACProfile == 2)
            {
                imgACProfile.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/ACProfiles/Turbo.png"));
            }
            if (ACProfile == 3)
            {
                imgACProfile.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/ACProfiles/Windows.png"));
            }

            Settings.Default.ACProfile = ACProfile;
            Settings.Default.Save();

            await Task.Run(() => ApplySettings.AppleACSettings(ACProfile));
        }

        private void rdSilent_Click(object sender, RoutedEventArgs e)
        {
            switchProfile(0);
        }

        private void rdPerf_Click(object sender, RoutedEventArgs e)
        {
            switchProfile(1);
        }

        private void rdTurbo_Click(object sender, RoutedEventArgs e)
        {
            switchProfile(2);
        }

        private void rdMan_Click(object sender, RoutedEventArgs e)
        {
            switchProfile(3);
        }
    }
}
