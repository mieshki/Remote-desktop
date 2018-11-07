using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesktopViewer
{
    public partial class RemoteDesktopViewerForm : Form
    {
        public RemoteDesktopViewerForm()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                int port = int.Parse(txtPort.Text);
                ReceivedDesktopImagesForm receivedDesktopImagesForm = new ReceivedDesktopImagesForm(port);
                double screenMultiplier = 0.75;
                receivedDesktopImagesForm.Size = new Size((int)(screenMultiplier * Screen.PrimaryScreen.Bounds.Width), (int)(screenMultiplier * Screen.PrimaryScreen.Bounds.Height));
                receivedDesktopImagesForm.StartPosition = FormStartPosition.CenterScreen;
                receivedDesktopImagesForm.WindowState = FormWindowState.Maximized;
                receivedDesktopImagesForm.Show();
            }
            catch (Exception)
            {
                if (txtPort.Text.Length < 1) RegularMessages.HaventTypedPort();
                else RegularMessages.WrongPortFormat();
            }
        }

    }
}
