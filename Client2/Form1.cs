using System;
using SimpleTCP;
using System.Text;
using System.Windows.Forms;

namespace Client2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;
        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }
        private void TxtHost_TextChanged(object sender, EventArgs e)
        {

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


    }
}

