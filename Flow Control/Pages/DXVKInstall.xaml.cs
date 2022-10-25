using Flow_Control.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Reflection;
using Path = System.IO.Path;

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

                string image = "";

                if (lines[10] == "" || !lines[10].Contains("https")) image = "pack://application:,,,/Assetsb/Icons/gamepad-line.png";
                else
                {
                    if (Scripts.GlobalVariables.IsConnectedToInternet() == true) image = lines[10];
                    else image = "pack://application:,,,/Assetsb/Icons/gamepad-line.png";
                }

                GameImage.Source = new BitmapImage(new Uri(image));
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

        private async void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var lines = File.ReadAllLines(Scripts.GlobalVariables.txtFilePath);

            string[] file = null;
            string fileToFind = lines[4];
            string drive = "F:\\SteamLibrary\\";

            MessageBox.Show("Select any base directory that contains the game you are looking for within a storage device in the next menu, e.g. Steam library folder. \n\nThe process for handling this function will be improved in the future.", "Game Installation Selection");

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                drive = dialog.FileName;
                MessageBox.Show("Starting game location process. This may take sometime.", "Starting DXVK Installation");
                file = await Task.Run(() => RecursiveSearch(drive, fileToFind));

                if (file != null)
                {
                    int bit = 32;
                    if (lines[28].Contains("32")) bit = 32; else bit = 64;

                    string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                    path = path + $"//x{bit}";

                    if (lines[31] != "false")
                    {
                        file[0] = file[0].Replace(fileToFind, null);
                        file[0] = file[0] + $"\\{lines[32]}";
                    }

                    Copy(path, file[0].Replace(fileToFind, null));

                    MessageBox.Show("DXVK has been installed without issue.", "DXVK Installation Finished");
                }
                else MessageBox.Show($"Could not find {lines[4]} in install location provided.", "DXVK Installation Finished");
            }
        }

        void Copy(string sourceDir, string targetDir)
        {
            foreach (var file in Directory.GetFiles(sourceDir))
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)), true);
        }

        private static string[] RecursiveSearch(string path, string file)
        {
            string[] files = null;

            try
            {
                files = Directory.GetFiles(path, file, SearchOption.AllDirectories);
                return files;
            }
            catch (Exception ex)
            {
                return files;
            }

            if (files == null)
            {
                return files;
            }
        }
    }
}
