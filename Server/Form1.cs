using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connect4;

namespace Server
{
    
    public partial class Form1 : Form
    {
        private Server server;
        List<Client> Players;   
        public Form1()
        {
            InitializeComponent();
            EndBtn.Enabled= false;
            server=new Server();                //give me IP,port
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            EndBtn.Enabled = true;
            server.Start();
            Connect4.Connect4Game connect4Game = new Connect4.Connect4Game();
            connect4Game.Show();

        }

        private void EndBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = true;
            EndBtn.Enabled = false;
            server.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.Broadcast("welcome");
        }
    }
}
