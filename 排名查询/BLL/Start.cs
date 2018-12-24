using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 排名查询.BLL
{
    /// <summary>
    /// 初始化赋值等操作
    /// </summary>
    public class Start
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>返回处理结果</returns>
        public bool ChuShiHua()
        {
            try
            {
                //先声明
                XMLS xml = new XMLS();

                //初始化值
                DAL.GlobalValue.Url_Kyewords = new Dictionary<string, string>();

                foreach (string urs in xml.GetUrls())
                {
                    //写入全局变量中
                    DAL.GlobalValue.Url_Kyewords.Add(urs, xml.GetKyewordStr(urs));

                }
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// 反序列化取到关键词
        /// </summary>
        /// <param name="url">查询的URL</param>
        /// <returns>返回查询到的值</returns>
        public List<string> GetKeywords(string url)
        {
            List<string> keywords = new List<string>();
            //字符串分割
            string[] Keywords = DAL.GlobalValue.Url_Kyewords[url].Split(new string[] { "^-@" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < Keywords.Length; i++)
            {
                keywords.Add(Keywords[i]);
            }
            return keywords;
        }

        /// <summary>
        /// 获取链接表
        /// </summary>
        /// <returns>返回处理结果</returns>
        public List<string> GetUrls()
        {
            List<string> urls = new List<string>();
            foreach (var item in DAL.GlobalValue.Url_Kyewords)
            {
                urls.Add(item.Key);
            }
            return urls;
        }
    }
}
