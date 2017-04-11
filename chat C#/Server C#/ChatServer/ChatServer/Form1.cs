using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

//this name space let u can use all net variable
using System.Net;

//this name space will provide socket lib
using System.Net.Sockets;

namespace ChatServer
{
    public partial class frmServerMain : Form
    {
        //port variable
        private int m_iPort = 1900;

        //int variable let u control stop or start thread
        private int m_iThreadState = 1;

        //this hash table let u save all session whn they connect to server
        private Hashtable m_hSession = null;

        //this is tcp server let open port listener
        private TcpListener m_tcpServerListener = null;

        public frmServerMain()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                //u can check if stop server or start server
                if (!this.btnStartServer.Text.Equals("Stop Server"))
                {
                    //start server, check port number is integer or not
                    this.m_iPort = Convert.ToInt32(txtPortListener.Text);

                    //open port by this command, create new server
                    this.m_tcpServerListener = new TcpListener(this.m_iPort);

                    //start tcp server listen on port
                    this.m_tcpServerListener.Start();

                    //appent to log
                    this.txtServerLog.AppendText("Server is listening on " + this.txtPortListener.Text + " port...\r\n");
                    this.btnStartServer.Text = "Stop Server";

                    //start thread let accept connection from client
                    startThread(acceptSocket);

                    //start thread let receiving all data from client
                    startThread(recvData);
                }
                else 
                {
                    //if server stop, checking let stop server
                    if (this.m_tcpServerListener != null)
                    {
                        //stopping server
                        this.m_tcpServerListener.Stop();
                    }

                    //stop thread by state variable
                    this.m_iThreadState = 0;

                    //init start server state
                    this.btnStartServer.Text = "Start Server";
                    this.txtServerLog.AppendText("Server stopped listening on " + this.txtPortListener.Text + " port...\r\n");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        //this function let u can start thread
        private void startThread(Action voidTarget)
        {
            this.m_iThreadState = 1;
            ThreadStart threadStart = new ThreadStart(voidTarget);
            Thread thread = new Thread(threadStart);

            //let background using set thread will dead when u stop form, if not when u stop form this thread will still running in back ground
            thread.IsBackground = true;

            //starting thread
            thread.Start();
        }

        //this function let u append text into text box component in thread
        private void invokeAppendTextBox(TextBox t, String s)
        {
            if (t.InvokeRequired)
            {
                t.Invoke(new Action<TextBox,string>(invokeAppendTextBox),new Object[]{t,s});
            }
            else
            {
                t.AppendText(s);
            }
        }

        //this is thread running in back ground let accept all connection from client
        private void acceptSocket()
        {
            int iSessionID = 0;
            //set log let we know state of thread
            invokeAppendTextBox(this.txtServerLog, "Thread - 1: Accept thread is running.\r\n");

            //check thread is running with some condition
            while (this.m_iThreadState != 0 
                && this.m_tcpServerListener != null)
            {
                try
                {
                    //get socket from client when client connect to server
                    Socket sckClient = this.m_tcpServerListener.AcceptSocket();

                    if (sckClient != null)
                    {
                        //if having client connected successed, u can confirm and append to log text box
                        invokeAppendTextBox(this.txtServerLog, "Client " + ((IPEndPoint)sckClient.RemoteEndPoint).Address.ToString() 
                            + " has just connected\r\n");

                        //add session into hash table let manager
                        this.m_hSession.Add(iSessionID, sckClient);
                        iSessionID++;
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
                Thread.Sleep(500);
            }

            //confirm when thread stopped
            invokeAppendTextBox(this.txtServerLog, "Thread - 1: Accept thread stopped.\r\n");
        }


        //this thread let receiving all data fom all client
        private void recvData()
        {
            //set log let confirm thread started
            invokeAppendTextBox(this.txtServerLog, "Thread - 2: recv data thread is running.\r\n");

            //check thread state alive
            while (this.m_iThreadState != 0)
            {
                try
                {
                    //check session manager
                    if (this.m_hSession != null)
                    {
                        //if having session is connected, load and check data to be send from clienr
                        foreach (Object o in this.m_hSession.Keys)
                        {

                            int iByte = 0;
                            Socket s = (Socket)this.m_hSession[o];

                            //check session is connected or not
                            if (!s.Connected)
                            {
                                //if client is disconnected, remove from hash table session
                                this.m_hSession.Remove(o);
                                continue;
                            }

                            //check data from client have or not
                            iByte = s.Available;
                            while(iByte > 0)
                            {
                                //if having data from client reading byte and show
                                byte[] btBuffer = new byte[iByte];
                                int iRead = s.Receive(btBuffer);
                                String strData = System.Text.Encoding.ASCII.GetString(btBuffer);

                                //show data in text box
                                invokeAppendTextBox(this.txtServerLog, "Client " + o + ":" 
                                    + strData);

                                //set auto response to client
                                if (strData.Equals("hello"))
                                {
                                    s.Send(System.Text.Encoding.ASCII.GetBytes("server: hello Client " + o + ", nice to meet u"));
                                }
                                else
                                {
                                    s.Send(System.Text.Encoding.ASCII.GetBytes("server: yes"));
                                }
                                iByte = iByte - iRead;
                            }
                            
                        }
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
                Thread.Sleep(200);
            }
            //confirm when this thread stopped
            invokeAppendTextBox(this.txtServerLog, "Thread - 2: recv data thread stopped.\r\n");
        }

        private void frmServerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //when form closing, u should free all memory
            if (this.m_tcpServerListener != null)
            {
                this.m_tcpServerListener.Stop();
            }

            if (this.m_hSession != null)
            {
                this.m_hSession.Clear();
            }
        }

        private void frmServerMain_Load(object sender, EventArgs e)
        {
            this.m_hSession = new Hashtable();
        }
    }
}
