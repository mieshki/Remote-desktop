using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesktopViewer
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
    }
}
