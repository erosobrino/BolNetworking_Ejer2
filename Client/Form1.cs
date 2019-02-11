using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        string IP_SERVER;
        int port;
        string msg;
        IPEndPoint ie;
        Socket server;
        NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;
        bool nameIntroduced = false;
        public delegate void delegateTextBox(TextBox textBox, string message);
        private static readonly object l = new object();
        Thread threadMessage;
        int contMessages = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            txtServerMessage.Clear();
            try
            {
                IP_SERVER = txtIp.Text;
                IPAddress.Parse(IP_SERVER);
                port = Convert.ToInt32(txtPort.Text);
                ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), Convert.ToInt32(port));
                server = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ie);
                    ns = new NetworkStream(server);
                    sr = new StreamReader(ns);
                    sw = new StreamWriter(ns);
                    try
                    {
                        txtServerMessage.AppendText(sr.ReadLine());
                        btSend.Enabled = true;
                    }
                    catch (IOException)
                    {
                        txtServerMessage.AppendText("There is no conection with server");
                    }
                }
                catch (SocketException ee)
                {
                    txtServerMessage.AppendText(String.Format("Error connection: {0}\nError code: {1}({2})", ee.Message, (SocketError)ee.ErrorCode, ee.ErrorCode));
                }
            }
            catch
            {
                IP_SERVER = "127.0.0.1";
                port = 31416;
                txtIp.Text = IP_SERVER;
                txtPort.Text = port + "";
                txtServerMessage.AppendText("Error in IP or Port, will use default");
            }
        }

        private void receiveMessage()
        {
            delegateTextBox delegateText = new delegateTextBox(addTextServer);
            try
            {
                while (true)
                {
                    string msg = sr.ReadLine();
                    //Console.WriteLine(msg);
                    if (msg != null)
                    {
                        lock (l)
                            Invoke(delegateText, txtServerMessage, msg);
                    }
                }
            }
            catch (IOException) { }
        }

        private void addTextServer(TextBox textBox, string message)
        {
            textBox.AppendText(message);
            textBox.AppendText(Environment.NewLine);
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserMessage.Text.Length > 0)
                {
                    contMessages++;
                    sw.WriteLine(txtUserMessage.Text);
                    sw.Flush();
                    if (!nameIntroduced)
                    {
                        txtServerMessage.Clear();
                        txtServerMessage.AppendText(sr.ReadLine());
                        btList.Enabled = true;
                        btExit.Enabled = true;
                        nameIntroduced = true;
                        lblMessage.Text = "Your message here";
                        threadMessage = new Thread(() => receiveMessage());
                        threadMessage.Start();
                        threadMessage.IsBackground = true;
                    }
                    if (nameIntroduced)
                    {
                        if (contMessages != 1)
                            txtServerMessage.AppendText(txtUserMessage.Text);
                        txtServerMessage.AppendText(Environment.NewLine);
                        txtUserMessage.Text = "";
                    }
                }
            }
            catch (IOException) { txtServerMessage.AppendText("Sin Conexion"); }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            try
            {
                sw.WriteLine("#exit");
                sw.Flush();
                sr.Close();
                sw.Close();
                ns.Close();
                server.Close();
                txtServerMessage.AppendText("Conection closed");
            }
            catch { txtServerMessage.AppendText("Error Conection"); }
            btSend.Enabled = false;
            btExit.Enabled = false;
            btList.Enabled = false;
            nameIntroduced = false;
            contMessages = 0;
        }

        private void btList_Click(object sender, EventArgs e)
        {
            try
            {
                sw.WriteLine("#list");
                sw.Flush();
            }
            catch { txtServerMessage.AppendText("Error Conection"); }
        }
    }
}
