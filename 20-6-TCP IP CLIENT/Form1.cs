﻿using SimpleTCP;
using System;
using System.Text;
using System.Windows.Forms;
namespace _20_6_TCP_IP_CLIENT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                server = new SimpleTcpServer();
                server.Delimiter = 0x13; //enter
                server.StringEncoder = Encoding.UTF8; 
                server.DataReceived += Server_DataReceived;
            }
            
        }
        private void Server_DataReceived(object Sender, SimpleTCP.Message e)

        {
            //Update mesage to txtStatus
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += e.MessageString;
                e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            });
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            //Start server host
            txtStatus.Text += "Server starting...";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(txtHost.Text);
            server.Start(ip, Convert.ToInt32(txtPort.Text));
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
        }
    }



}
