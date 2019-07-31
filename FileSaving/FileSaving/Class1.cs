using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FileSaving
{
    public class Class1
    {
        public void DownloadFile(string filePath, String URI, String headerkey, String headerValue, String methodType, String body)
        {
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");



            if (headerkey != null && headerkey != "" && headerValue != null)
            {
                client.Headers.Add(headerkey, headerValue);
            }

            if(methodType == "POST")
            {
              
                String response = client.UploadString(URI, body);
                byte[] bytes = Encoding.Default.GetBytes(response);
                File.WriteAllBytes(filePath, bytes);
            }
            else if (methodType == "GET")
            {
                client.DownloadFile(URI, filePath);
            }
            
        }


      /*  public void DownloadDataAndSave(string filePath, string URI)
        {
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            byte[] arrBytes = client.DownloadData(URI);
            Console.WriteLine(arrBytes);
            File.WriteAllBytes(filePath + ".txt", arrBytes);
            File.WriteAllBytes(filePath, arrBytes);
        }*/

    }
}
