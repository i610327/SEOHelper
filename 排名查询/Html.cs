using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace 排名查询
{
    class Html
    {

        /// <summary>
        /// 过滤html标签
        /// </summary>
        /// <param name="strHtml">html的内容</param>
        /// <returns></returns>
        public static string StripHTML(string stringToStrip)
        {
            // paring using RegEx           //
            stringToStrip = Regex.Replace(stringToStrip, "</p(?:\\s*)>(?:\\s*)<p(?:\\s*)>", "\n\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = Regex.Replace(stringToStrip, "", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = Regex.Replace(stringToStrip, "\"", "''", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = StripHtmlXmlTags(stringToStrip);
            return stringToStrip;
        }
        private static string StripHtmlXmlTags(string content)
        {
            return Regex.Replace(content, "<[^>]+>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }


        public string GetGeneralContent(string strUrl)
        {

            string strMsg = string.Empty;

            try
            {

                WebRequest request = WebRequest.Create(strUrl);

                WebResponse response = request.GetResponse();

                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));



                strMsg = reader.ReadToEnd();



                reader.Close();

                reader.Dispose();

                response.Close();

            }

            catch

            { }

            return StripHTML(strMsg);

        }
    }
}
