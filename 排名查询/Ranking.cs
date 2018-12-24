using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace 排名查询
{
    class Ranking
    {
      
        /// <summary>
        /// 判断对应的搜索引擎下是否被收录
        /// </summary>
        /// <param name="genre">搜索引擎类型</param>
        /// <param name="ur">查询的链接</param>
        /// <returns>返回结果</returns>
        public static bool Included(string genre , string ur)
        {
            //去除http和https
            ur = ur.Replace("http://", "");
            ur = ur.Replace("https://", "");
            //如果类型是百度
            if (genre == "BaiDu")
            {
                return  BaiDu_Included(ur);
            
            }
                //如果搜索引擎是好搜
                 if (genre == "HaoSo")
               {

                }
                 //如果搜索引擎是搜狗
                 if (genre == "SoGou")
                 {

                 }
                 return false;
        
        }

        /// <summary>
        /// 收录、快照日期、标题查询
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="ur"></param>
        /// <returns></returns>
        public static string[] GetSite(string genre, string ur)
        {
            string[] sites = new string[3];
            //如果类型是百度
            if (genre == "BaiDu")
            {
                //是否收录
                if (BaiDu_Included(ur))
                {
                    sites[0] = "已收录";
                    sites[1] = GetUrlTitle(true, ur);
                    sites[2] = SiteUrlDate(genre,ur);
                }
                else
                {
                    sites[0] = "未收录";
                    sites[1] = GetUrlTitle(false, ur);
                    sites[2] = "无快照";
                
                }
            }
            return sites;
        
        }


        /// <summary>
        /// 查询百度收录收录
        /// </summary>
        /// <param name="url">查询URL</param>
        /// <returns>返回结果</returns>
        private static bool BaiDu_Included(string url)
        {

            //如果类型是百度
            string str = HTTP.HTTPGain("https://www.baidu.com/s?wd=" + url);
            if (str.Contains("很抱歉，没有找到与") && str.Contains("如有任何意见或建议") || str.Contains("没有找到该URL。您可以直接访问"))
            {
                return false;//证明没有收录
            }
            else
            {
                return true;//已经收录
            }
        
        }


        /// <summary>
        /// 查询快照日期
        /// </summary>
        /// <param name="genre">类型</param>
        /// <param name="url">链接</param>
        /// <returns>返回快照日期</returns>
        public static string SiteUrlDate(string genre, string url)
        {
            //如果类型是百度
            if (genre == "BaiDu")
            {
                string html = HTTP.HTTPGain("https://www.baidu.com/s?wd=" + url);
                //正则过滤内容&拼凑链接
                string temp_url = "http://cache.baiducontent.com/c" + GetRegexStr(html, "http://cache.baiducontent.com/c([\\s\\S]*?)=1\"")+"=1";
                //抓取代码
                string temp_str = HTTP.HTTPGains(temp_url, "gb2312");
                //获取快照日期
                string date = GetRegexStr(temp_str, "北京时间 ([\\s\\S]*?)日");
                //统一化日期格式
                date = date.Replace("月", "-");
                date = date.Replace("年", "-");
                if (date.Length > 1)
                {
                    return date;
                }
                else
                {
                    return "获取失败";
                }
            }

            return "无快照";
        }

        /// <summary>
        /// 获取标题
        /// </summary>
        /// <param name="site">是否收录</param>
        /// <param name="url">链接</param>
        /// <returns>返回标题</returns>
        public static string GetUrlTitle(bool site, string url)
        {
            if (url.Length < 1)
            {
                return null;
            }

            //如果类型是百度
            if (site)
            {
                //如果类型是百度
                string html = HTTP.HTTPGain("https://www.baidu.com/s?wd=" + url);
                string titlestr = GetRegexStr(html, "<div class=\"result c-container \" id=\"1\"([\\s\\S]*?)class=\"m\">百度快照</a></div></div>").Trim();
                string title = GetRegexStr(titlestr, "data-tools=\'{\"title\":\"([\\s\\S]*?)\"");
                if (title.Length > 3)
                {
                    return title;
                }
                else 
                {
                    title = GetRegexStr(html, "data-tools=\'{\"title\":\"([\\s\\S]*?)\"").Trim();
                }
                
                return title;
            }
            else
            {
                //url = Jump302(url);
                string html = HTTP.HTTPGain(url).Replace("TITLE", "title"); ;
                string title = GetRegexStr(html, "<title>([\\s\\S]*?)</title>").Trim();
                if (title.Length < 1)
                {
                    return "页面不存在";
                }
                return title.Trim();
            }

        }


        /// <summary>
        /// 正则查找
        /// </summary>
        /// <param name="reString">正文</param>
        /// <param name="regexCode">正则表达式</param>
        /// <returns>返回结果(单条数据)</returns>
        public static string GetRegexStr(string reString, string regexCode)
        {
            System.Text.RegularExpressions.Regex reg;//正则表达式变量
            reg = new System.Text.RegularExpressions.Regex(regexCode);//初始化正则对象

            System.Text.RegularExpressions.MatchCollection mc = reg.Matches(reString);//匹配;
            string temp = string.Empty;//声明一个临时变量
            for (int ic = 0; ic < mc.Count; ic++)
            {
                System.Text.RegularExpressions.GroupCollection gc = mc[ic].Groups;//获取所有分组
                System.Collections.Specialized.NameValueCollection nc = new System.Collections.Specialized.NameValueCollection();
                for (int i = 0; i < gc.Count; i++)
                {
                    temp = gc[i].Value;  //得到组对应数据

                }

            }
            return temp;

        }


        /// <summary>
        /// 查看在指定搜索引擎下的关键词排名
        /// </summary>
        /// <param name="genre">搜索引擎类型</param>
        /// <param name="keyword">关键词</param>
        /// <param name="ur">链接</param>
        /// <returns>如果未收录则返回-1，如果前三十页找不到则返回0，其余正常返回排名</returns>
        public static int ranking(string genre, string keyword, string ur)
        {
            //去除http和https
            ur = ur.Replace("http://", "");
            ur = ur.Replace("https://", "");

            //如果在此链接并没有被收录
            if (Included(genre, ur)==false)
            {
                //未收录则返回负数
                return -1;
            
            }
            
            //如果搜索引擎是百度
            if (genre == "BaiDu")
            {
                //此次就利用正则吧
            }
           
            return 0;
        }

        /// <summary>
        /// 将网站进行302跳转，并得出真实网址
        /// </summary>
        /// <param name="ur">需要被跳转的UR</param>
        /// <returns>返回处理结果</returns>
        public static string Jump302(string ur)
        {
            try
            {
                //获取302真实地址

                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(ur);
                myHttpWebRequest.AllowAutoRedirect = false;
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                return myHttpWebResponse.Headers.Get("Location");
            }
            catch
            {
                //如果异常就证明无法302，获取已经得到了该网站！ 
                return ur;
            }
        }


    }
}
