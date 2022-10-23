using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control.Scripts
{
    internal class GlobalVariables
    {
        public static string txtFilePath = "";

        public static bool IsConnectedToInternet()
        {
            string host = "1.1.1.1";
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }
            return result;
        }
    }
}
