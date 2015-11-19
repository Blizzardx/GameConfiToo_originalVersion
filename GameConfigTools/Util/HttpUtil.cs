using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Web;

namespace GameConfigTools.Util
{
    public class HttpUtil
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HttpUtil));

        private static readonly Encoding encoding = Encoding.UTF8;

        public static string HttpGet(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Timeout = 10000;
                request.ReadWriteTimeout = 10000;
                WebResponse response = request.GetResponse();
                
                string html = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                return html;
            }
            catch (System.UriFormatException ex)
            {
                logger.Error(string.Format("get request {0} fail.", url), ex);
            }
            catch (System.Net.WebException ex)
            {
                logger.Error(string.Format("get request {0} fail.", url), ex);
            }
            return null;
        }

        public static int HttpDownloadFile(string url, string savePath)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Timeout = 10000;
                request.ReadWriteTimeout = 10000;
                WebResponse response = request.GetResponse();

                HttpWebResponse resp = response as HttpWebResponse;
                if ((int)resp.StatusCode != 200)
                {
                    return (int)resp.StatusCode;
                }

                Stream stream = response.GetResponseStream();
                byte[] buff = new byte[256];
                byte[] bytes = new byte[resp.ContentLength];
                int len = 0;
                int lenTotal = 0;
                do{
                    lenTotal += len;
                    len = stream.Read(buff, 0, buff.Length);
                    if (len == 0)
                    {
                        break;
                    }
                    Array.Copy(buff, lenTotal, bytes, lenTotal, len);

                }while(len != 0);

                using(FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Flush();
                }

                return 200;
            }
            catch (System.UriFormatException ex)
            {
                logger.Error(string.Format("get request {0} fail.", url), ex);
            }
            catch (System.Net.WebException ex)
            {
                logger.Error(string.Format("get request {0} fail.", url), ex);
            }
            return 200;
        }

        public static int HttpHead(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "HEAD";
                request.Timeout = 10000;
                request.ReadWriteTimeout = 10000;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                return (int)response.StatusCode;
            }
            catch (System.UriFormatException ex)
            {
                logger.Error(string.Format("get request {0} fail.", url), ex);
            }
            catch (System.Net.WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    return (int)((HttpWebResponse)e.Response).StatusCode;
                }
            }
            return -1;
        }

        public static string HttpPost(string url, string data)
        {
            HttpWebRequest request = null;
            StreamReader streamReader = null;
            Stream responseStream = null;
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 2000;
                request.ReadWriteTimeout = 2000;
                request.Accept = "application/json, text/javascript, */* q=0.01";
                //request.Headers["Accept-Charset"] = "GBK,utf-8;q=0.7,*;q=0.3";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                //request.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Method = "POST";
                byte[] postData = Encoding.UTF8.GetBytes(data);
                request.ContentLength = postData.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postData, 0, postData.Length);
                //获取响应
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                responseStream = response.GetResponseStream();
                //如果http头中接受gzip的话，这里就要判断是否为有压缩，有的话，直接解压缩即可  
                if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                }
                streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string retString = streamReader.ReadToEnd();
                return retString;
            }
            catch (Exception e)
            {
                logger.Error(string.Format("post request {0} fail.", url), e);
                return null;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                }       
            }
        }

        public static string UrlEncode(string temp, Encoding encoding)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                string t = temp[i].ToString();
                string k = HttpUtility.UrlEncode(t, encoding);
                if (t == k)
                {
                    stringBuilder.Append(t);
                }
                else
                {
                    stringBuilder.Append(k.ToUpper());
                }
            }
            return stringBuilder.ToString();
        }

        public static int UploadFile(string url, string filePath)
        {
            if (!File.Exists(filePath))
            {
                logger.Error(string.Format("file {0} is not exist.", filePath));
                return -1;
            }
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                fs.Close();

                int index = filePath.LastIndexOf("\\");

                string fileName = filePath.Substring(index + 1, filePath.Length - index - 1);

                // Generate post objects
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("filename", fileName);
                postParameters.Add("fileformat", "bytes");
                postParameters.Add("path", "config");
                postParameters.Add("file", new HttpUtil.FileParameter(data, fileName, "application/msword"));

                // Create request and receive response
                HttpWebResponse webResponse = HttpUtil.MultipartFormDataPost(url, postParameters);
                if (webResponse.StatusCode != HttpStatusCode.OK)
                {
                    logger.Error(string.Format("upload error. statusCode:{0}", webResponse.StatusCode));
                }

                return (int)webResponse.StatusCode;
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    return (int)((HttpWebResponse)e.Response).StatusCode;
                }
                logger.Error("upload error.", e);
                return -1;
            }
        }

        private static HttpWebResponse MultipartFormDataPost(string postUrl, Dictionary<string, object> postParameters)
        {
            string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
            string contentType = "multipart/form-data; boundary=" + formDataBoundary;

            byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);

            return PostForm(postUrl, contentType, formData);
        }
        private static HttpWebResponse PostForm(string postUrl, string contentType, byte[] formData)
        {
            HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;
            request.Timeout = 60000;
            if (request == null)
            {
                throw new NullReferenceException("request is not a http request");
            }

            // Set up the request properties.
            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = formData.Length;

            // You could add authentication here as well if needed:
            // request.PreAuthenticate = true;
            // request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
            // request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes("username" + ":" + "password")));

            // Send the form data to the request.
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(formData, 0, formData.Length);
                requestStream.Close();
            }

            return request.GetResponse() as HttpWebResponse;
        }

        private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            Stream formDataStream = new System.IO.MemoryStream();
            bool needsCLRF = false;

            foreach (var param in postParameters)
            {
                // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                // Skip it on the first parameter, add it to subsequent parameters.
                if (needsCLRF)
                    formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                needsCLRF = true;

                if (param.Value is FileParameter)
                {
                    FileParameter fileToUpload = (FileParameter)param.Value;

                    // Add just the first part of this param, since we will write the file data directly to the Stream
                    string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                        boundary,
                        param.Key,
                        fileToUpload.FileName ?? param.Key,
                        fileToUpload.ContentType ?? "application/octet-stream");

                    formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                    // Write the file data directly to the Stream, rather than serializing it to a string.
                    formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                }
                else
                {
                    string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                        boundary,
                        param.Key,
                        param.Value);
                    formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
                }
            }

            // Add the end of the request.  Start with a newline
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }

        public class FileParameter
        {
            public byte[] File { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public FileParameter(byte[] file) : this(file, null) { }
            public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
            public FileParameter(byte[] file, string filename, string contenttype)
            {
                File = file;
                FileName = filename;
                ContentType = contenttype;
            }
        }
    }
}
