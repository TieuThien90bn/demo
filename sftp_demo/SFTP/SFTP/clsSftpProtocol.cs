using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Renci.SshNet;

namespace SFTP
{
    public class SftpProtocol
    {
        private String m_strErrorDes = "";

        //this is sftp client variable
        private SftpClient m_sftpClient = null;

        public SftpProtocol()
        { 
        
        }


        //this is function using let connect to sftp server
        public bool connectSftpServer(String strHost, int iPort, String strUserName,
            String strPassword, int iTimeout)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";

                //create a new instance for sftp client variable
                this.m_sftpClient = new SftpClient(strHost, iPort, strUserName, strPassword);
                this.m_sftpClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(iTimeout);
                this.m_sftpClient.KeepAliveInterval = TimeSpan.FromSeconds(10);

                //connect to server
                this.m_sftpClient.Connect();
                blResult = true;
            }
            catch (Exception exp)
            {
                //return error let show for user
                this.m_strErrorDes = "SFTP_0000: ERROR - " + exp.Message;
            }
            return blResult;
        }

        //function using upload file to sftp server
        public bool uploadFile(String strSource, String strDesPath, bool blOverride)
        { 
            bool blResult = false;
            System.IO.FileStream fileStream = null;

            try
            {
                this.m_strErrorDes = "";

                //in here we will get stream of file from local dir
                fileStream = new System.IO.FileStream(strSource, 
                    System.IO.FileMode.Open,System.IO.FileAccess.Read);

                this.m_sftpClient.UploadFile(fileStream, strDesPath, blOverride, null);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0001: ERROR - " + exp.Message;
            }
            finally
            {
                //after open file stream please close file stream let handle of file to be free
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return blResult;
        }

        //this function use to download file
        public bool downloadFile(String strSftpPath, String strLocalPath)
        {
            bool blResult = false;
            System.IO.FileStream fileStream = null;

            try
            {
                this.m_strErrorDes = "";
                //open new file in local dir
                fileStream = new System.IO.FileStream(strLocalPath, System.IO.FileMode.OpenOrCreate);

                //download file from sftp server
                this.m_sftpClient.DownloadFile(strSftpPath, fileStream, null);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0002: ERROR - " + exp.Message;
            }
            finally
            {
                //closing stream
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return blResult;
        }

        //function use to delete file
        public bool deleteFile(String strFilePath)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";
                this.m_sftpClient.DeleteFile(strFilePath);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0004: ERROR - " + exp.Message;
            }
            return blResult;
        }

        //rename file
        public bool renameFile(String strOldPathName,String strNewPathName)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";
                this.m_sftpClient.RenameFile(strOldPathName, strNewPathName);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0005: ERROR - " + exp.Message;
            }
            return blResult;
        }

        //delete folder
        public bool deleteDirectory(String strFolderPath)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";
                this.m_sftpClient.DeleteDirectory(strFolderPath);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0006: ERROR - " + exp.Message;
            }
            return blResult;
        }

        //creating a new folder
        public bool creatingDirectory(String strFolderPath)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";
                this.m_sftpClient.CreateDirectory(strFolderPath);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0007: ERROR - " + exp.Message;
            }
            return blResult;
        }

        //creating text file
        public bool creatingText(String strFilePath)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";
                this.m_sftpClient.CreateText(strFilePath);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0008: ERROR - " + exp.Message;
            }
            return blResult;
        }

        //list file from sftp server
        public IEnumerable<Renci.SshNet.Sftp.SftpFile> listFile(String strSftpPath)
        {
            IEnumerable<Renci.SshNet.Sftp.SftpFile> ienFileList = null;

            try
            {
                this.m_strErrorDes = "";
                ienFileList = this.m_sftpClient.ListDirectory(strSftpPath, null);
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0003: ERROR - " + exp.Message;
            }
            return ienFileList;
        }

        //closing sftp client
        public void close()
        {
            try
            {
                if (this.m_sftpClient != null)
                {
                    this.m_sftpClient.Disconnect();
                }
            }
            catch (Exception exp)
            { 
            
            }
            this.m_sftpClient = null;
        }

        //get error when using function of sftp client
        public String getErrorDes()
        {
            return this.m_strErrorDes;
        }
    }
}
