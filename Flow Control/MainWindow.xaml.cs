using System;
using System.Collections.Generic;
using System.Linq;
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
using Flow_Control.Scripts;
using Interop;

namespace Flow_Control
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            compatCheck();
            

            PagesNavigation.Navigate(new System.Uri("Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

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
    }
}
