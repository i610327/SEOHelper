using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 新排名获取规则
{
    /// <summary>
    /// 排名抽象类
    /// </summary>
    public abstract class Ranking
    {
        
        /// <summary>
        /// 搜索引擎服务商
        /// </summary>
        protected string facilitator { set; get; }

        /// <summary>
        /// 服务商前缀地址
        /// </summary>
        protected string facilitatorUrl { set; get; } 

        /// <summary>
        /// 查询链接的后缀链接
        /// </summary>
        protected string url { set; get; }

        /// <summary>
        ///查询的关键词
        /// </summary>
        protected string keyword { set; get; }


        /// <summary>
        /// 每页地址
        /// </summary>
        protected string[] pageUrl { get; set; }


        /// <summary>
        /// 查询收录
        /// </summary>
        /// <param name="url">查看的URL</param>
        /// <returns>返回收录结果</returns>
        public abstract bool Included(string url);

        /*
        /// <summary>
        /// 查询快照日期
        /// </summary>
        /// <param name="snapshotUrl">快照链接</param>
        /// <returns>返回快照日期</returns>
        public abstract string SnapshotDate(string snapshotUrl);
        */


        /// <summary>
        /// 查询分页地址
        /// </summary>
        /// <param name="httpStr">第一页的源代码</param>
        /// <returns>返回分页地址</returns>
        public abstract void PageUrl(string httpStr);



        /// <summary>
        /// 查询网站关键词的排名
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="url">网址</param>
        /// <param name="number">查看排名数限制</param>
        /// <returns>返回排名</returns>
        public abstract int GetRanking(string keyword, string url, int number);


        /// <summary>
        /// 自动获取前置搜索引擎链接
        /// </summary>
        /// <returns>返回前置链接</returns>
        protected string GetFacilitatorUrl()
        {
            if (this.facilitator == "baidu")
            {
                return "https://www.baidu.com/s?ie=UTF-8&wd=";
            }
            else if (this.facilitator == "so")
            {
                return "https://www.so.com/s?src=opensearch&q=";
            }
            else if (this.facilitator == "sogou")
            {
                return "https://www.sogou.com/web?ie=UTF-8&query=";
            }


            return string.Empty;
        }
         
    }
}
