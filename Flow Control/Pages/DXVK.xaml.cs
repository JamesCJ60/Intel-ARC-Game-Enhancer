using Flow_Control.Properties;
using Flow_Control.Scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
using MessageBox = System.Windows.MessageBox;

namespace Flow_Control.Pages
{
    /// <summary>
    /// Interaction logic for ComingSoon.xaml
    /// </summary>
    /// 

    class Game
    {
        public int ID { get; set; }
        public string gameName { get; set; }
        public string imagePath { get; set; }
        public string filePath { get; set; }
    }


    public partial class DXVK : Page
    {

        public static FileInfo[] Files;

        public DXVK()
        {
            InitializeComponent();

            Scripts.GlobalVariables.txtFilePath = null;

            List<Game> games = new List<Game>();
            try
            {


                string image = "";
                string path = Settings.Default.Path + "\\Lists\\DXVK";
                string root = Settings.Default.Path + "\\Lists\\DXVK";

                bool internet = Scripts.GlobalVariables.IsConnectedToInternet();

                DirectoryInfo dinfo = new DirectoryInfo(path);
                Files = dinfo.GetFiles("*.txt");
                int i = 0;

                foreach (FileInfo file in Files)
                {
                    string txtPath = path + $"\\{file.Name}";
                    var lines = File.ReadAllLines(txtPath);

                    if (lines[10] == "" || !lines[10].Contains("https")) image = "pack://application:,,,/Assetsb/Icons/gamepad-line.png";
                    else
                    {
                        if (internet == true) image = lines[10];
                        else image = "pack://application:,,,/Assetsb/Icons/gamepad-line.png";
                    }

                    games.Add(new Game()
                    {
                        ID = i,
                        gameName = lines[1],
                        imagePath = image,
                        filePath = txtPath,
                    });

                    i++;
                }

                lbGames.ItemsSource = games;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            lbGames.SelectedIndex = 0;

            Game model = lbGames.SelectedItem as Game;
            Scripts.GlobalVariables.txtFilePath = Convert.ToString(model.filePath);
            PagesNavigation.Navigate(new System.Uri("Pages/DXVKInstall.xaml", UriKind.RelativeOrAbsolute));
        }

        private void lbGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game model = lbGames.SelectedItem as Game;
            Scripts.GlobalVariables.txtFilePath = Convert.ToString(model.filePath);
            PagesNavigation.NavigationService.Refresh();
        }


    }
}
