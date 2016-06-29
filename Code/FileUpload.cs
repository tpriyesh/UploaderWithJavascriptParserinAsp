using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace CmsApplication.Code
{
    public class FileUpload
    {

        string ftpUrl = System.Configuration.ConfigurationManager.AppSettings["FtpUrl"].ToString();
        string ftpUserId = System.Configuration.ConfigurationManager.AppSettings["FtpUserId"].ToString();
        string ftpPassword = System.Configuration.ConfigurationManager.AppSettings["FtpPassword"].ToString();
        string ftpDirectory = System.Configuration.ConfigurationManager.AppSettings["FtpDirectory"].ToString();

        private FtpWebRequest GetRequest(string uriString)
        {
            var request = (FtpWebRequest)WebRequest.Create(new Uri(uriString));
            request.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            return request;
        }


        private bool checkFileExists(WebRequest request)
        {
            try
            {
                request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public string UploadToFTP(string ftpfullpath,string file)
        {
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
            ftp.Credentials = new NetworkCredential(ftpUserId, ftpPassword);

            ftp.KeepAlive = true;
            ftp.UseBinary = true;
            ftp.Method = WebRequestMethods.Ftp.UploadFile;
            // Copy the entire contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader(file);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            ftp.ContentLength = fileContents.Length;

            // Upload the file stream to the server.
            Stream requestStream = ftp.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();






            // Get the response from the FTP server.
            FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();

            // Close the connection = Happy a FTP server.
            response.Close();

            // Return the status of the upload.
            return response.StatusDescription;

        }

        public string FileUploader(string file,string clientName)
        {
            try
            {
              
               string mainDirectory = clientName + "-scoreboard.sportsflash.com.au/"+"web/content/scoreboard/js";

               string fileName = Path.GetFileName(file);
               // string filename = "C://ab.js";
             //   string ftpfullpath = ftpUrl+"httpdocs/uploads/"+fileName;


                string ftpfullpath = ftpUrl +"/"+mainDirectory+"/" + fileName;

                //FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                //ftp.Credentials = new NetworkCredential(ftpUserId, ftpPassword);

                //ftp.KeepAlive = true;
                //ftp.UseBinary = true;
                //ftp.Method = WebRequestMethods.Ftp.UploadFile;

                //check If file exist on server or not

                bool checkStatus = checkFileExists(GetRequest(ftpfullpath));
                string getServerResponse = "";
                if (checkStatus == true)
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftpfullpath));
                    request.Method = WebRequestMethods.Ftp.Rename;
                    request.RenameTo = "clientconfig" + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss") + ".js";
                    //If you want to access Resourse Protected,give UserName and PWD
                    request.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
                    request.UseBinary = true;
                    request.UsePassive = true;
                    request.KeepAlive = true;
                    request.Timeout = -1;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    string status = response.StatusDescription;
                    if (response.StatusCode.ToString() == "FileActionOK")
                    {
                      getServerResponse=  UploadToFTP(ftpfullpath, file);
                    }

                    response.Close();



                }
                else
                {
                    FtpWebRequest reqObj = (FtpWebRequest)WebRequest.Create(new Uri(ftpfullpath));
                    reqObj.Method = WebRequestMethods.Ftp.UploadFile;
                    //If you want to access Resourse Protected,give UserName and PWD
                    reqObj.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
                    reqObj.UseBinary = true;
                    reqObj.UsePassive = true;
                    reqObj.KeepAlive = true;
                    reqObj.Timeout = -1;
                    // Copy the contents of the file to the byte array.
                    byte[] fileContents = File.ReadAllBytes(file);
                    reqObj.ContentLength = fileContents.Length;
                    //Upload File to FTPServer
                    Stream requestStream = reqObj.GetRequestStream();
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();
                    FtpWebResponse response = (FtpWebResponse)reqObj.GetResponse();
                    response.Close();
                    string status = response.StatusDescription;
                    getServerResponse = status;


                }


                return getServerResponse;

               
            }
            catch (Exception ex)
            {
                return null;
               // throw ex;
            }
        }
    }
}