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
    }


    public partial class DXVK : Page
    {
        public DXVK()
        {
            InitializeComponent();

            PagesNavigation.Navigate(new System.Uri("Pages/DXVKInstall.xaml", UriKind.RelativeOrAbsolute));

            List<Game> games = new List<Game>();

            games.Add(new Game()
            {
                ID = 0,
                gameName = "Fallout 3: GOTY",
                //imagePath = "pack://application:,,,/Assets/Icons/gamepad-line.png"
                imagePath = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/b1f444f5-ca6c-4df3-8c44-ec6e0276f5ac/d76r2tw-95d002f4-3377-4f06-a64e-0e39e585656b.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2IxZjQ0NGY1LWNhNmMtNGRmMy04YzQ0LWVjNmUwMjc2ZjVhY1wvZDc2cjJ0dy05NWQwMDJmNC0zMzc3LTRmMDYtYTY0ZS0wZTM5ZTU4NTY1NmIucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.Mz-tqNl93hbJMPoRQ_0sHkvSMU02vr51-6n1wPbXt1s"
            });
            games.Add(new Game()
            {
                ID = 1,
                gameName = "Fallout New Vegas",
                //imagePath = "pack://application:,,,/Assets/Icons/gamepad-line.png"
                imagePath = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/657be565-f4b2-4e47-841f-1b0711b0205b/d73ol0y-032c2a80-faa8-4554-b190-35a0c68456d6.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzY1N2JlNTY1LWY0YjItNGU0Ny04NDFmLTFiMDcxMWIwMjA1YlwvZDczb2wweS0wMzJjMmE4MC1mYWE4LTQ1NTQtYjE5MC0zNWEwYzY4NDU2ZDYucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.R9nCDPQWgEsirghMh-iL95WedHfVdouEkSeCeId7PQs",
            });
            games.Add(new Game()
            {
                ID = 2,
                gameName = "Fallout 4",
                //imagePath = "pack://application:,,,/Assets/Icons/gamepad-line.png"
                imagePath = "https://staticdelivery.nexusmods.com/mods/1151/images/10080-0-1455866940.png"
            });

            games.Add(new Game()
            {
                ID = 3,
                gameName = "Fallout 76",
                //imagePath = "pack://application:,,,/Assets/Icons/gamepad-line.png"
                imagePath = "https://cdn2.steamgriddb.com/file/sgdb-cdn/icon/b7196f5fd0fce35ccadc7001fd067588/32/1024x1024.png"
            });

            lbGames.ItemsSource = games;

            lbGames.SelectedIndex = 0;
        }

        private void lbGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
