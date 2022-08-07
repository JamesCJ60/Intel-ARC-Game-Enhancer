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

            if (Settings.Default.PowerFix == true)
            {
                rdEnableFix.IsChecked = true;
                rdEnableFix.Tag = FindResource("enable");
                rdDisableFix.Tag = FindResource("disable");
            }
            else 
            {
                rdEnableFix.Tag = FindResource("disable");
                rdDisableFix.Tag = FindResource("enable");
                rdDisableFix.IsChecked = true; 
            }

            lblCPUName.Text = GetSystemInfo.GetCPUName().Replace("with Radeon Graphics", null);
            lbliGPUName.Text = GetSystemInfo.GetiGPUName().Replace("(R)", null);
            lbldGPUName.Text = GetSystemInfo.GetdGPUName().Replace("Laptop GPU", null);

            if(GetSystemInfo.GetdGPUName() == null || GetSystemInfo.GetdGPUName() == "")
            {
                dGPUName.Visibility = Visibility.Collapsed;
            }

            if (deviceName.Contains("Flow Z13")) PowerFix.Visibility = Visibility.Visible;
            else PowerFix.Visibility = Visibility.Collapsed;

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

        public static Guid DLAHI_GUID = new Guid("{5c4c3332-344d-483c-8739-259e934c9cc8}");
        public static string DLAHI_Instance = @"SWD\DRIVERENUM\OEM_DAL_COMPONENT&4&293F28F0&0";

        public static Guid DTTDE_GUID = new Guid("{5c4c3332-344d-483c-8739-259e934c9cc8}");
        public static string DTTDE_Instance = @"SWD\DRIVERENUM\{BC7814A1-A80E-44B3-87C6-652EAC676387}#DTTEXTCOMPONENT&4&DE2304&0";

        private void rdDisableFix_Click(object sender, RoutedEventArgs e)
        {
            rdEnableFix.Tag = FindResource("disable");
            rdDisableFix.Tag = FindResource("enable");
            Settings.Default.PowerFix = false;
            Settings.Default.Save();
            DeviceHelper.SetDeviceEnabled(DLAHI_GUID, DLAHI_Instance, false);
            DeviceHelper.SetDeviceEnabled(DTTDE_GUID, DTTDE_Instance, false);
        }

        private void rdEnableFix_Click(object sender, RoutedEventArgs e)
        {
            rdEnableFix.Tag = FindResource("enable");
            rdDisableFix.Tag = FindResource("disable");
            Settings.Default.PowerFix = true;
            Settings.Default.Save();
            DeviceHelper.SetDeviceEnabled(DLAHI_GUID, DLAHI_Instance, true);
            DeviceHelper.SetDeviceEnabled(DTTDE_GUID, DTTDE_Instance, true);
        }
    }
}
