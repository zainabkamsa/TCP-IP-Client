using System;
using SimpleTCP;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace _20_6_TCP_IP_CLIENT__CLIENT_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;

        private List<string> cipherSuites = new List<string>()
            { "RSA", "AES", "DH" };


        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            //Connect to server
            client.Connect(txtHost.Text, Convert.ToInt32(txtPort.Text));
        }


        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            //Update message to txtStatus
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += e.MessageString;
            });
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));
        }

        private void TxtHost_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void startNegotiationButton_Click(object sender, EventArgs e)
        {
            var guid = Guid.NewGuid().ToString();
            var next = new Random().Next(224);
            var byteValue = Convert.ToByte(next);
            var clientRandom = Encoding.ASCII.GetString(new byte[] { byteValue });
            txtStatus.Text = clientRandom + guid;
        }
    }
}
