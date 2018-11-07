using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesktopServer
{
    public class RegularMessages
    {
        public static void HaventTypedPort()
        {
            MessageBox.Show("You haven't typed port");
        }

        public static void WrongPortFormat()
        {
            MessageBox.Show("Wrong port format");
        }

        public static void HaventTypedIpAddress()
        {
            MessageBox.Show("You haven't typed ip address");
        }

        public static void WrongIpAddressFormat()
        {
            MessageBox.Show("Wrong ip format");
        }

        public static void Connected()
        {
            MessageBox.Show("Connected!");
        }

        public static void FailedToConnect()
        {
            MessageBox.Show("Failed to connect...");
        }

    }
}
