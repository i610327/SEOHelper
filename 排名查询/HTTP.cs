using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace 排名查询
{
    class HTTP
    {
        public static string contentType = "application/x-www-form-urlencoded";
        public static string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
        public static string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; Zune 4.7; BOIE9;ZHCN)";
        public static string referer = "https://www.hao123.com";
       
        
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="method">GET or POST</param>
        /// <param name="postData">like "username=admin&password=123"</param>
        /// <returns></returns>
        public static string HTTPGain(string url, CookieContainer cookieContainer = null, string method = "GET", string postData = "")
        {

            cookieContainer = cookieContainer ?? new CookieContainer();

            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
           
            try
            {
                if (!url.StartsWith("http"))//判断是否带有http
                {
                    url = "http://" + url;

                }
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Referer = referer;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = method;
                httpWebRequest.ServicePoint.ConnectionLimit = int.MaxValue;

                if (method.ToUpper() == "POST")
                {
                    byte[] byteRequest = Encoding.Default.GetBytes(postData);
                    Stream stream = httpWebRequest.GetRequestStream();
                    stream.Write(byteRequest, 0, byteRequest.Length);
                    stream.Close();
                }

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string cookie_string = httpWebResponse.Headers.Get("Set-Cookie");
                cookie_string += "0";
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string html = streamReader.ReadToEnd();

                streamReader.Close();
                responseStream.Close();

                httpWebRequest.Abort();
                httpWebResponse.Close();
                if (!html.Contains("charset=gb2312\""))
                {
                    return html;
                }
                else
                {
                    return HTTPGains(url, "gb2312");
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url">链接</param>
        /// <param name="getEncoding">编码</param>
        /// <returns>返回代码</returns>
        public static string HTTPGains(string url, string getEncoding="utf-8", CookieContainer cookieContainer = null, string method = "GET", string postData = "")
        {

            cookieContainer = cookieContainer ?? new CookieContainer();

            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            if (!url.StartsWith("http"))//判断是否带有http
            {
                url = "http://" + url;

            }
            try
            {
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Referer = referer;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = method;
                httpWebRequest.ServicePoint.ConnectionLimit = int.MaxValue;

                if (method.ToUpper() == "POST")
                {
                    byte[] byteRequest = Encoding.Default.GetBytes(postData);
                    Stream stream = httpWebRequest.GetRequestStream();
                    stream.Write(byteRequest, 0, byteRequest.Length);
                    stream.Close();
                }

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string cookie_string = httpWebResponse.Headers.Get("Set-Cookie");
                cookie_string += "0";
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding(getEncoding));
                string html = streamReader.ReadToEnd();

                streamReader.Close();
                responseStream.Close();

                httpWebRequest.Abort();
                httpWebResponse.Close();

                return html;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// 抓取HTTP代码（不乱码）
        /// </summary>
        /// <param name="url">链接</param>
        /// <returns>返回代码</returns>
        public static string GetHtml(string url)
        {
            string htmlCode;
            HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            webRequest.Timeout = 30000;
            webRequest.Method = "GET";
            webRequest.UserAgent = "Mozilla/4.0";
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");


            HttpWebResponse webResponse = (System.Net.HttpWebResponse)webRequest.GetResponse();

            //获取目标网站的编码格式
            string contentype = webResponse.Headers["Content-Type"];
            Regex regex = new Regex("charset\\s*=\\s*[\\W]?\\s*([\\w-]+)", RegexOptions.IgnoreCase);
            if (webResponse.ContentEncoding.ToLower() == "gzip")//如果使用了GZip则先解压
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (var zipStream = new System.IO.Compression.GZipStream(streamReceive, System.IO.Compression.CompressionMode.Decompress))
                    {

                        //匹配编码格式
                        if (regex.IsMatch(contentype))
                        {
                            Encoding ending = Encoding.GetEncoding(regex.Match(contentype).Groups[1].Value.Trim());
                            using (StreamReader sr = new System.IO.StreamReader(zipStream, ending))
                            {
                                htmlCode = sr.ReadToEnd();
                            }
                        }
                        else
                        {
                            using (StreamReader sr = new System.IO.StreamReader(zipStream, Encoding.UTF8))
                            {
                                htmlCode = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            else
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(streamReceive, Encoding.GetEncoding("gb2312")))
                    {
                        htmlCode = sr.ReadToEnd();
                    }
                }
            }
            return htmlCode;
        }


        /// <summary>
        /// GB2312转换成UTF8
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public  static string gb2312_utf8(string text)
        {
            //声明字符集   
            System.Text.Encoding utf8, gb2312;
            //gb2312   
            gb2312 = System.Text.Encoding.GetEncoding("gb2312");
            //utf8   
            utf8 = System.Text.Encoding.GetEncoding("utf-8");
            byte[] gb;
            gb = gb2312.GetBytes(text);
            gb = System.Text.Encoding.Convert(gb2312, utf8, gb);
            //返回转换后的字符   
            return utf8.GetString(gb);
        }



        //查询状态码，如果是301，那么就获取301后的真实地址，如果是404，那么返回页面不存在

        //
    }
}
