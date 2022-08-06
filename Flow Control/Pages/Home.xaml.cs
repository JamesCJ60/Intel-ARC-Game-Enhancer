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
        }
    }
}
