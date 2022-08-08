using Flow_Control.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AATUV3.Scripts;
using UXTU.Scripts.Intel;
using RyzenSMUBackend;
using System.Windows;

namespace Flow_Control.Scripts
{
    internal class ApplySettings
    {
        public static async void AppleACSettings(int ACProfile)
        {
            string fileToLoad = "";
            string acMode = "";

            if (ACProfile == 0) fileToLoad = "Silent.txt";
            else if (ACProfile == 1) fileToLoad = "Perf.txt";
            else if (ACProfile == 2) fileToLoad = "Turbo.txt";
            else if (ACProfile == 3) fileToLoad = "Manual.txt";

            if (ACProfile == 0) acMode = "silent";
            else if (ACProfile == 1) acMode = "performance";
            else if (ACProfile == 2 || ACProfile == 3) acMode = "turbo";

            string filePath = Settings.Default.Path + "\\presets\\" + fileToLoad;

            var lines = File.ReadAllLines(filePath);

            string atrofacArgs = $"fan --plan {acMode} --cpu 30c:{lines[1]}%,40c:{lines[2]}%,50c:{lines[3]}%,60c:{lines[4]}%,70c:{lines[5]}%,80c:{lines[6]}%,90c:{lines[7]}%,100c:{lines[8]}% --gpu 30c:{lines[11]}%,40c:{lines[12]}%,50c:{lines[13]}%,60c:{lines[14]}%,70c:{lines[15]}%,80c:{lines[16]}%,90c:{lines[17]}%,100c:{lines[18]}%";

            string atrofacPath = "\\bin\\atrofac\\atrofac-cli.exe";
            BasicExeBackend.ApplySettings(atrofacPath, atrofacArgs, true);


            System.Threading.Thread.Sleep(2000);


            if (GetSystemInfo.GetCPUName().Contains("AMD"))
            {
                SendCommand.set_tctl_temp(Convert.ToUInt32(lines[41]));
                SendCommand.set_apu_skin_temp_limit(Convert.ToUInt32(lines[42]));
                SendCommand.set_stapm_limit(Convert.ToUInt32(lines[32]) * 1000);
                SendCommand.set_slow_limit(Convert.ToUInt32(lines[35]) * 1000);
                SendCommand.set_fast_limit(Convert.ToUInt32(lines[38]) * 1000);

                int iGPUClock = Convert.ToInt32(lines[21]);

                if(iGPUClock > 200) SendCommand.set_gfx_clk(Convert.ToUInt32(iGPUClock));

                int CPUCO = Convert.ToInt32(lines[28]);
                int iGPUCO = Convert.ToInt32(lines[29]);

                SendCommand.set_coall(Convert.ToUInt32(0x100000 - (uint)((int)CPUCO)));
                SendCommand.set_cogfx(Convert.ToUInt32(0x100000 - (uint)((int)iGPUCO)));

            }
            else
            {
                int pl1 = Convert.ToInt32(lines[35]);
                int pl2 = Convert.ToInt32(lines[38]);
                await Task.Run(() => ChangeTDP.changeTDP(pl1, pl2));
            }

            System.Threading.Thread.Sleep(2000);

            string path = "\\bin\\oc.exe";
            //Pass settings on to be applied
            BasicExeBackend.ApplySettings(path, "0 " + lines[24] + " " + lines[25], true);
            BasicExeBackend.ApplySettings(path, "1 " + lines[24] + " " + lines[25], true);
            BasicExeBackend.ApplySettings(path, "2 " + lines[24] + " " + lines[25], true);
        }
    }
}
