using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server; 
namespace Client
{
    enum ClientState { Connected, Disconnected };
    public partial class ClientForm : Form
    {
        ClientState CurrentState;
        IPAddress ServerAddress;
        int ServerPort;
        TcpClient MyClient;
        NetworkStream NStream;
        StreamReader SR;
        StreamWriter SW;
        public ClientForm()
        {
            InitializeComponent();
            CurrentState = ClientState.Disconnected;
            ServerAddress = IPAddress.Parse("127.0.0.1");
            ServerPort = 6666;
            MyClient = null;
            NStream = null; 
            SR = null;
            SW = null;
        }

        
        private void Disconnect()
        {
            if (SR != null) { SR.Close(); }
            if (NStream != null) { NStream.Close(); }
            if (MyClient != null)
            {
                MyClient.Close();
            }
        }

        private void SetClientState(ClientState currentState)
        {
            if(currentState == ClientState.Disconnected)
            {
                ConnectBtn.Enabled = true;
                DisconnectBtn.Enabled = false;
            }
            else if(currentState == ClientState.Connected)
            {
                ConnectBtn.Enabled = false;
                DisconnectBtn.Enabled = true;
            }
        }

        async private void ConnectBtn_Click(object sender, EventArgs e)
        {
            MyClient = new TcpClient();
            await MyClient.ConnectAsync(ServerAddress, ServerPort);
            NStream = MyClient.GetStream();
            SR = new StreamReader(NStream);
            SetClientState(ClientState.Connected);
        }
        private void Signin()
        {
           
        }
        private void ClientForm_Paint(object sender, PaintEventArgs e)
        {
            SetClientState(ClientState.Disconnected);
        }


        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
