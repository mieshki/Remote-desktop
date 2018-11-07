using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace RemoteDesktopServer
{
    public partial class RemoteDesktopServer : Form
    {
        private int portNumber;
        private IPAddress ipAddress;

        private readonly TcpClient client = new TcpClient();
        private UdpClient udpServer;

        private NetworkStream mainStream;

        private Image GrabDesktopImage()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics graphic = Graphics.FromImage(screenshot);
            graphic.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            return screenshot;
        }

        private void SendDesktopImage()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            mainStream = client.GetStream();
            binFormatter.Serialize(mainStream, GrabDesktopImage());
        }

        private void ReceiveMousePos()
        {
            var groupEP = new IPEndPoint(IPAddress.Any, portNumber);
            var data = udpServer.Receive(ref groupEP);
            //MessageBox.Show(data.ToString());
            var received = Encoding.UTF8.GetString(data);

            //MessageBox.Show(received);

            string[] mousePos = received.Split('-');
            try
            {
                float xPos = float.Parse(mousePos[0]);
                float yPos = float.Parse(mousePos[1]);
                //MessageBox.Show("xPos = " + xPos);
                //MessageBox.Show("yPos = " + yPos);

                int screenX = Screen.PrimaryScreen.Bounds.Width;
                int screenY = Screen.PrimaryScreen.Bounds.Height;

                float boundsX = xPos * (int)screenX;
                float boundsY = yPos * (int)screenY;

                Cursor.Position = new Point((int)boundsX, (int)boundsY);
            }
            catch(Exception)
            {
                // wywala wyjątek jak np. ma się 2 monitory i wyjedzie się poza któryś
                // można dać wart absolutną w kliencie ale bezpieczniej łapać wyjątek i nawet
                // go ignorować
            }        

        }

        public RemoteDesktopServer()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                portNumber = int.Parse(txtPort.Text);
            }
            catch(Exception)
            {
                if (txtPort.Text.Length < 1) RegularMessages.HaventTypedPort();
                else RegularMessages.WrongPortFormat();
                return;
            }

            try
            {
                ipAddress = IPAddress.Parse(txtIpAddr.Text);
            }
            catch (Exception)
            {
                if (txtIpAddr.Text.Length < 1) RegularMessages.HaventTypedIpAddress();
                else RegularMessages.WrongIpAddressFormat();
                return;
            }

            try
            {
                client.Connect(ipAddress, portNumber);
                udpServer = new UdpClient(portNumber);
                RegularMessages.Connected();
            }
            catch(Exception)
            {
                RegularMessages.FailedToConnect();
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (btnShare.Text.StartsWith("Share"))
            {
                timer1.Start();
                btnShare.Text = "Stop sharing";
            }
            else
            {
                timer1.Stop();
                btnShare.Text = "Share my screen";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendDesktopImage();
            ReceiveMousePos();
        }
    }
}
