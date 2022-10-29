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
using System.Collections;
using System.Diagnostics;

namespace Flow_Control.Pages
{
    /// <summary>
    /// Interaction logic for DXVKInstall.xaml
    /// </summary>
    public partial class Magpie : Page
    {
        public Magpie()
        {
            InitializeComponent();

            int i = 0;

            foreach (var process in Process.GetProcessesByName("magpie")) i++;
            foreach (var process in Process.GetProcessesByName("Magpie")) i++;

            if ( i <= 0)
            {
                MessageBox.Show("Magpie service is not open, restart program to use this feature.", "Magpie service is not open!");
            }

            if (File.Exists(Settings.Default.Path + "\\bin\\magpie\\config.mp"))
            {

                var lines = File.ReadAllLines(Settings.Default.Path + "\\bin\\magpie\\config.mp");

                int captureMode = Convert.ToInt32(lines[1]);
                rdVsyncEn.IsChecked = Convert.ToBoolean(lines[4]);
                rd3DEn.IsChecked = Convert.ToBoolean(lines[7]);
                int interpolationMode = Convert.ToInt32(lines[10]);
                double sharpness = Convert.ToDouble(lines[13]);

                sldSharp.Value = Convert.ToInt32(sharpness * 100);
                tbxSharp.Text = sharpness * 100 + "%";

                if (captureMode == 1) rdDesktop.IsChecked = true;

                if (interpolationMode == 1) rdbilinear.IsChecked = true;
            }

        }

        private async void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Settings.Default.Path + "\\bin\\magpie\\config.mp";
            int captureMode = 0;
            int interpolationMode = 0;

            if (rdGraphics.IsChecked == true) captureMode = 0;
            else captureMode = 1;

            if (rdNearest.IsChecked == true) interpolationMode = 0;
            else interpolationMode = 1;

            int sharp = (int)sldSharp.Value;
            double sharpness = (double)sharp / 100;

            bool VSync, dmode;

            if (rdVsyncEn.IsChecked == true) VSync = true; else VSync = false;
            if (rd3DEn.IsChecked == true) dmode = true; else dmode = false;

            string finalOutput = $"[Capture Mode]\n{captureMode.ToString()}\n\n[VSync]\n{VSync.ToString()}\n\n[Is3DMode]\n{dmode.ToString()}\n\n[Interpolation]\n{interpolationMode.ToString()}\n\n[FSR Sharpness]\n{sharpness.ToString()}";
            File.WriteAllText(path, finalOutput);
        }

        private void sldSharp_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbxSharp.Text = (int)sldSharp.Value + "%";
        }
    }
}
