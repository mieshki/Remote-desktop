using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesktopViewer
{
    public partial class ReceivedDesktopImagesForm : Form
    {
        private int portNumber;
        private IPAddress serverIpAddress;

        private TcpClient tcpClient;
        private TcpListener tcpServerListener;
        private NetworkStream mainStream;

        private readonly Thread Listening;
        private readonly Thread DataTransfer;

        public ReceivedDesktopImagesForm(int port)
        {
            portNumber = port;

            tcpClient = new TcpClient();
            Listening = new Thread(StartListening);
            DataTransfer = new Thread(DataOperations);

            InitializeComponent();
        }

        private void SendCursorPosition()
        {
            var udpClient = new UdpClient();
            IPEndPoint ep = new IPEndPoint(serverIpAddress, portNumber);
            udpClient.Connect(ep);

            byte[] mousePositionXandYpercentage = Encoding.UTF8.GetBytes(MouseController.mouseWidthPositionInPercentage + "-" + MouseController.mouseHeightPositionInPercentage);
            udpClient.Send(mousePositionXandYpercentage, mousePositionXandYpercentage.Length);
        }

        private void ReceiveDesktopImage()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            mainStream = tcpClient.GetStream();
            pictureBox1.Image = (Image)binFormatter.Deserialize(mainStream);
        }

        private void StartListening()
        {
            while (!tcpClient.Connected)
            {
                tcpServerListener.Start();
                tcpClient = tcpServerListener.AcceptTcpClient();
            }
            serverIpAddress = GetServerIpAddres(); 
            DataTransfer.Start();
        }
        
        private void StopListening()
        {
            tcpServerListener.Stop();
            tcpClient = null;

            if (Listening.IsAlive) Listening.Abort();
            if (DataTransfer.IsAlive) DataTransfer.Abort();
        }

        private void DataOperations()
        { 
            while (tcpClient.Connected)
            {
                ReceiveDesktopImage();
                SendCursorPosition();
            }
        }

        private IPAddress GetServerIpAddres()
        {
           return ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            tcpServerListener = new TcpListener(IPAddress.Any, portNumber);
            Listening.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            StopListening();
        }

    }
}
