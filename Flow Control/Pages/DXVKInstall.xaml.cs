using Flow_Control.Properties;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Flow_Control.Pages
{
    /// <summary>
    /// Interaction logic for DXVKInstall.xaml
    /// </summary>
    public partial class DXVKInstall : Page
    {
        public DXVKInstall()
        {
            InitializeComponent();

            try
            {
                var lines = File.ReadAllLines(Scripts.GlobalVariables.txtFilePath);

                GameName.Text = lines[1];
                GameImage.Source = new BitmapImage(new Uri(lines[10]));
                Description.Text = lines[7];
                Developer.Text = lines[16];
                API.Text = lines[13];
                Release.Text = lines[19];
                Genre.Text = lines[22];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
