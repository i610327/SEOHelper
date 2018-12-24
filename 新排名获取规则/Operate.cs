using CsharpHttpHelper;
using CsharpHttpHelper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace 新排名获取规则
{
    /// <summary>
    /// 实际操作类
    /// </summary>
    public class Operate:Ranking
    {

        /// <summary>
        /// 初始化时赋予选择的搜索引擎
        /// </summary>
        /// <param name="Facilitator">搜索引擎</param>
        public Operate(string Facilitator)
        {
            this.facilitator = Facilitator;
        }

        /// <summary>
        /// 判断是否被收录
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public override bool Included(string url)
        {
            if (this.facilitator == "baidu")
            {
                //如果类型是百度
                string httpstr = FeaturesBLL.HTTP.Read.HTTPGain(GetFacilitatorUrl() + url);
                if (httpstr.Contains("很抱歉，没有找到与") && httpstr.Contains("如有任何意见或建议") || httpstr.Contains("没有找到该URL。您可以直接访问"))
                {
                    return false;//证明没有收录
                }
                else
                {
                    return true;//已经收录
                }
            
            }

            if (this.facilitator == "so")
            {
                //如果类型是好搜
                string httpstr = FeaturesBLL.HTTP.Read.HTTPGain(GetFacilitatorUrl() + url);
                if (httpstr.Contains("找不到该URL，可以直接访问"))
                {
                    return false;//证明没有收录
                }
                else
                {
                    return true;//已经收录
                }

            }

            if (this.facilitator == "sogou")
            {
                //如果类型是搜狗
                string httpstr = FeaturesBLL.HTTP.Read.HTTPGain(GetFacilitatorUrl() + url);
                if (httpstr.Contains("搜狗已为您找到约0条相关结果") && httpstr.Contains("您是不是想直接访问") || httpstr.Contains("未收录？<a id=\"bbx_url_suburl"))
                {
                    return false;//证明没有收录
                }
                else
                {
                    return true;//已经收录
                }

            }


            return true;

        }

        /// <summary>
        /// 实例化类
        /// </summary>
        FeaturesBLL.Find.Regularly rl = new FeaturesBLL.Find.Regularly();
        FeaturesBLL.HTTP.Filter ff = new FeaturesBLL.HTTP.Filter();


        /// <summary>
        /// 第一页的源代码
        /// </summary>
        /// <param name="httpStr">源代码</param>
        /// <returns>返回每页地址（第二页开始）</returns>
        public override void PageUrl(string httpStr)
        {
            //划分数组空间
            pageUrl = new string[9];

            //如果类型是百度
            if (this.facilitator == "baidu")
            {
                //页数范围
                string pagestr = rl.GetRegexStr(httpStr, "<strong><span class=\"fk fk_cur\"><i class=\"c-icon c-icon-bear-p\"></i></span><span class=\"pc\">1</span></strong>([\\s\\S]*?)<span class=\"fk fkd\"><i class=\"c-icon c-icon-bear-pn\"></i></span><span class=\"pc\">10</span></a>");

                //未处理的翻页地址
                string[] temp_pageUrl = pagestr.Split(new string[] { "<a" }, StringSplitOptions.RemoveEmptyEntries);

                //储存到数组
                for (int i = 0; i < temp_pageUrl.Length; i++)
                {
                    pageUrl[i] = "https://www.baidu.com" + rl.GetRegexStr(temp_pageUrl[i], "href=\"([\\s\\S]*?)\">").Trim();
                }

            }


            //如果类型是好搜
            if (this.facilitator == "so")
            {
                //页数范围
                string pagestr = rl.GetRegexStr(httpStr, "<div id=\"page\">([\\s\\S]*?)下一页</a><span class=\"nums\" style=\"margin-left:20px\">找到相关结果约");

                //未处理的翻页地址
                string[] temp_pageUrl = pagestr.Split(new string[] { "<a" }, StringSplitOptions.RemoveEmptyEntries);

                //储存到数组
                for (int i = 1; i < temp_pageUrl.Length-1; i++)
                {
                    pageUrl[i - 1] = "https://www.so.com" + rl.GetRegexStr(temp_pageUrl[i], "href=\"([\\s\\S]*?)\">").Trim();
                }

            }

            //如果类型是搜狗
            if (this.facilitator == "sogou")
            {

            }

           
        }


        /// <summary>
        /// 排名查询
        /// </summary>
        /// <param name="keyword">查询的关键词</param>
        /// <param name="url">相应关键词的地址</param>
        /// <param name="number">查询的排名设置</param>
        /// <returns>返回排名结果</returns>
        public override int GetRanking(string keyword, string url, int number)
        {
            //先检测是否收录
            if (!Included(url))
            {
                return -1;
            }
            
            //获取源文本
            string httpstr = FeaturesBLL.HTTP.Read.HTTPGain(GetFacilitatorUrl() + keyword);
            //获取翻页地址
            PageUrl(httpstr);

            if (number <= 10)
            {
                int ranking=ComputingRanking(0, httpstr, url);
                if (ranking != 0)
                {
                    return ranking;
                }
            }
            else if (number > 10 && number <= 20)
            {
                //第一页查看排名
                int ranking = ComputingRanking(0, httpstr, url);
                if (ranking != 0)
                {
                    return ranking;
                }
                //第二页查看排名
                ranking = ComputingRanking(1, FeaturesBLL.HTTP.Read.HTTPGain(pageUrl[0]), url);
                if (ranking != 0)
                {
                    return ranking;
                }
            }
            else if (number > 20 && number <= 30)
            {
                //第一页查看排名
                int ranking = ComputingRanking(0, httpstr, url);
                if (ranking != 0)
                {
                    return ranking;
                }

                //第二页查看排名
                ranking = ComputingRanking(1, FeaturesBLL.HTTP.Read.HTTPGain(pageUrl[0]), url);
                if (ranking != 0)
                {
                    return ranking;
                }

                //第三页查看排名
                ranking = ComputingRanking(2, FeaturesBLL.HTTP.Read.HTTPGain(pageUrl[1]), url);
                if (ranking != 0)
                {
                    return ranking;
                }
                return 0;

            }

            return 0;
        }

        /// <summary>
        /// 计算排名
        /// </summary>
        /// <param name="page">当前页数</param>
        /// <param name="httpstr">源文本</param>
        /// <param name="url">判断的链接</param>
        /// <returns>返回排名</returns>
        private int ComputingRanking(int page, string httpstr, string url)
        {
            //去除前缀
            url = url.Replace("https://", "");
            url = url.Replace("http://", "");
            
            
            //范围正则
            string RangerRegular = string.Empty;

            //获取标题的正则
            string TitleRegular = string.Empty;

            //获取未302地址的正则
            string TempUrlRegular = string.Empty;

            //获取快照正则
            string SnapshotDateRegular = string.Empty;

            //分隔符
            string Separator = string.Empty;
            //如果类型是百度
            if (this.facilitator == "baidu")
            {
                RangerRegular = "<div id=\"content_left\">([\\s\\S]*?)<div style=\"clear:both;height:0;\">";
                Separator = "<div class=\"result c-container \"";
                TitleRegular = "data-tools='{\"title\":\"([\\s\\S]*?)\"";
                TempUrlRegular="<div class=\"f13\"><a target=\"_blank\" href=\"([\\s\\S]*?)\" class=\"c-showurl\"";
                SnapshotDateRegular="<div class=\"f13\"><a target=\"_blank\" href=\"([\\s\\S]*?)\" class=\"c-showurl\"";
            }

            //如果类型是好搜
            if (this.facilitator == "so")
            {
                RangerRegular = "<li class=\"res-list\" data-urlfp=([\\s\\S]*?)<div id=\"side\">";
                Separator = "<h3(\\s+)class=\"";
                TitleRegular = "data-noref=\"1\"([\\s\\S]*?)</h3>";
                TempUrlRegular = "<a href=\"([\\s\\S]*?)\"  rel=\"noreferrer noopener\"";
                SnapshotDateRegular = "http://c.360webcache.com([\\s\\S]*?)\"";
            }
            //如果类型是搜狗
            if (this.facilitator == "sogou")
            {
                
            }

            //划分大概范围
            string first_step_httpstr = rl.GetRegexStr(httpstr, RangerRegular);

            //进一步分割
            string[] split_character = GetCharacter(first_step_httpstr,Separator); 

            //进行遍历
            for (int i = 1; i < split_character.Length; i++)
            {
                //网站标题
                string title = GetHandleTitle(rl.GetRegexStr(split_character[i], TitleRegular));

                //未经过302的链接
                string url_temp = rl.GetRegexStr(split_character[i], TempUrlRegular);

                //快照日期
                string snapshotDate = GetHandleSnapshotDateRegular(rl.GetRegexStr(split_character[i], SnapshotDateRegular));

                //302后真实地址
                string Url = Jump302(url_temp);

                if (Url.Contains(url) || Url == url)
                {
                    return (page*10) + i;
                }

            }

            return 0;
        }

        /// <summary>
        /// 处理标题
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>返回处理过的字符串</returns>
        private string GetHandleTitle(string str)
        {
            if (this.facilitator == "so")
            {
                string tempstr=rl.GetRegexStr(str, "target=\"_blank\">([\\s\\S]*?)</a>");
                tempstr=tempstr.Replace("<em>", "");
                tempstr=tempstr.Replace("</em>", "");
                return tempstr;

            }

            return str;
        
        }


        /// <summary>
        /// 处理进一步范围
        /// </summary>
        /// <param name="htmlstr">二次处理过的文本</param>
        /// <param name="separator">分隔符</param>
        /// <returns>返回处理结果</returns>
        private string[] GetCharacter(string htmlstr, string separator)
        {
            if (this.facilitator == "so")
            {
                string [] temps = Regex.Split(htmlstr, separator);
                //主数据存储
                string[] strs = new string[10];

                //数组key值
                int key = 0;

                //遍历数组
                foreach (string str in temps)
                {
                    //判断数组指定字符的长度，主要为了过滤空白和无效字符
                    if (str.Trim().Count() > 20)
                    {
                        strs[key] = str;
                        key++;
                    }
                }
                return strs;
            }

            return htmlstr.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries); ;

        }




        /// <summary>
        /// 处理快照
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>返回处理结果</returns>
        private string GetHandleSnapshotDateRegular(string str)
        {
            if (this.facilitator == "so")
            {
                return "http://c.360webcache.com" + str;

            }

            return str;

        }


        /// <summary>
        /// 跳转302
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Jump302(string url)
        {
            try
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = url,//URL     必需项  
                    Method = "GET",//URL     可选项 默认为Get  
                    Timeout = 100000,//连接超时时间     可选项默认为100000  
                    ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000  
                    IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写  
                    Cookie = "",//字符串Cookie     可选项  
                    UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0",//用户的浏览器类型，版本，操作系统     可选项有默认值  
                    Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值  
                    ContentType = "text/html",//返回类型    可选项有默认值  
                    Referer = "https://www.baidu.com",//来源URL     可选项  
                    Allowautoredirect = false,//是否根据３０１跳转     可选项  
                    AutoRedirectCookie = false,//是否自动处理Cookie     可选项  
                    Postdata = "",//Post数据     可选项GET时不需要写  
                    ResultType = ResultType.String,//返回数据类型，是Byte还是String  
                };
                HttpResult result = http.GetHtml(item);
                //string html = result.Html;
                //string cookie = result.Cookie;
                //获取302跳转URl
                if (result.RedirectUrl.Count() < 3)
                {
                    return url;
                }
                return result.RedirectUrl;
            }
            catch
            {
                return url;
            }
        }

    }
}
