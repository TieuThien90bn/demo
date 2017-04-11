using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

//using socket name space
using System.Net.Sockets;

namespace ChatClient
{
    public partial class frmChatClient : Form
    {
        //using int variable let set thread state (stop or start)
        private int m_iThreadState = 1;

        //create socket variable
        private Socket m_sckClient = null;

        //set string let send data variable
        private String m_strData = "";

        public frmChatClient()
        {
            InitializeComponent();
        }

        //load form event
        private void frmChatClient_Load(object sender, EventArgs e)
        {
            try
            {
                //creating new socket variable
                this.m_sckClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //connect to server via port and ip
                this.m_sckClient.Connect("127.0.0.1", 1900);

                //start thread receiving data and sending data
                startThread(recvData);
                startThread(sendData);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        //this is short function let start thread
        private void startThread(Action voidTarget)
        {
            this.m_iThreadState = 1;
            ThreadStart threadStart = new ThreadStart(voidTarget);
            Thread thread = new Thread(threadStart);

            thread.IsBackground = true;
            thread.Start();
        }

        //thread use to send data
        private void sendData()
        {
            //check thread state
            while (this.m_iThreadState != 0 && this.m_sckClient != null)
            {
                try
                {
                    //check client is connected or not
                    if (this.m_sckClient.Connected)
                    {
                        //if client connected, checking data if data have u can send to server
                        if(!this.m_strData.Equals(""))
                        {
                            //send data to server
                            this.m_sckClient.Send(System.Text.Encoding.ASCII.GetBytes(this.m_strData));
                            this.m_strData = "";
                        }
                    }
                    else
                    {
                        //if client is not connected break thread
                        break;
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
                Thread.Sleep(200);
            }
        }

        //this function let append text into textbox in thread
        private void invokeAppendTextBox(TextBox t, String s)
        {
            if (t.InvokeRequired)
            {
                t.Invoke(new Action<TextBox, string>(invokeAppendTextBox), new Object[] { t, s });
            }
            else
            {
                t.AppendText(s);
            }
        }

        //this thread let receiver data from server
        private void recvData()
        {
            //checking thread state
            while (this.m_iThreadState != 0 && this.m_sckClient != null)
            {
                try
                {
                    //check client connected or not
                    if (this.m_sckClient.Connected)
                    {
                        //if client connected , reading data from server
                        //checking data available from client in out stream
                        int iByte = this.m_sckClient.Available;
                        while (iByte > 0)
                        {
                            //reading all byte and show to chat box
                            byte[] btBuffer = new byte[iByte];
                            int iRead = this.m_sckClient.Receive(btBuffer);
                            invokeAppendTextBox(this.txtChatContent, "Client :"
                                + System.Text.Encoding.ASCII.GetString(btBuffer));
                            iByte = iByte - iRead;
                        }
                    }
                    else
                    {
                        //if client is disconnected, bfreak thread
                        break;
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
                Thread.Sleep(200);
            }
        }

        //this is click event of send button let send data
        private void btnSend_Click(object sender, EventArgs e)
        {
            this.m_strData = txtChatText.Text;
        }

        private void frmChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            //when closing form, remember close connection
            try
            {
                if (this.m_sckClient != null)
                {
                    this.m_sckClient.Close();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
