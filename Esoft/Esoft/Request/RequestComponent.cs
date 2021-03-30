using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Esoft
{
    class RequestComponent<T>
    {
        WebRequest req;
        WebResponse response;
        public void Request(string url, string con, string method, string login = "", string password = "")
        {
            try
            {
                req = WebRequest.Create(url);
                req.ContentType = con;
                req.Method = method;
                if(login != "" && password != "")
                {
                    req.Headers.Add("Authorization", "Basic " + login + ":" + password );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public T GetResponse(string url, string method = "GET", string data = null, string contentType = "application/json")
        {
            try
            {
                if (data != null) contentType = "application/json";
                Request(url, contentType, method);
                T dataTemp;
                if(data != null)
                {
                    req.ContentType = contentType;
                    using (StreamWriter requestWriter = new StreamWriter(req.GetRequestStream()))
                    {
                        requestWriter.Write(data);
                        requestWriter.Close();
                    }
                }
                response = req.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string read = reader.ReadToEnd();
                    if (!typeof(T).IsArray)
                    {
                        read = read.Replace("[", "");
                        read = read.Replace("]", "");
                    }
                    dataTemp = JsonSerializer.Deserialize<T>(read);
                }
                
                return dataTemp;
            }
            catch (Exception ex)
            {
            }
            return default;
        }

        
    }
}
