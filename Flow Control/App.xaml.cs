using Flow_Control.Properties;
using Flow_Control.Scripts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Flow_Control
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static Guid DLAHI_GUID = new Guid("{5c4c3332-344d-483c-8739-259e934c9cc8}");
        public static string DLAHI_Instance = @"SWD\DRIVERENUM\OEM_DAL_COMPONENT&4&293F28F0&0";

        public static Guid DTTDE_GUID = new Guid("{5c4c3332-344d-483c-8739-259e934c9cc8}");
        public static string DTTDE_Instance = @"SWD\DRIVERENUM\{BC7814A1-A80E-44B3-87C6-652EAC676387}#DTTEXTCOMPONENT&4&DE2304&0";

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            if (Settings.Default.PowerFix == true)
            {
                DeviceHelper.SetDeviceEnabled(DLAHI_GUID, DLAHI_Instance, false);
                DeviceHelper.SetDeviceEnabled(DTTDE_GUID, DTTDE_Instance, false);
            }
        }
    }
}
