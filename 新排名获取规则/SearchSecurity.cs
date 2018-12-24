using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新排名获取规则
{
    /// <summary>
    /// 搜索引擎安全监测
    /// </summary>
    public abstract class SearchSecurity
    {
        /*
         * 先检测是哪个搜索引擎
         * 获取非法关键词列表
         * 根据非法词库进行site指令操作，然后返回http代码
         * 然后根据获取到的结果进行基本判定，如果非法词汇出现的吻合度过高，那么就返回疑似有问题的标题和链接
         * 如果出现次数超过阀值，就警告用户网站被黑
         * 
         */

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
        /// 非法词汇出现次数
        /// </summary>
        protected int count=0;

        /// <summary>
        /// 累计的可疑标题及链接
        /// </summary>
        protected List<string> title_url = new List<string>();


        /// <summary>
        /// 非法屏蔽关键词
        /// </summary>
        protected string[] keywords = { "娱乐城", "国际娱乐城", "赌博", "奖金", "娛樂城", "官 网", "亚洲娱乐", "娱乐国际", "乐电子游戏", "权威平台", "合彩", "老虎机", "水上娱乐城", "澳博", "娱乐注册", "娱乐城赌博", "娱乐城官网", "娱乐城电子游戏", "天上人间", "亚洲最火", "百家乐", "博彩网", "色情", "成人" };


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


        /// <summary>
        /// 判断是否被黑
        /// </summary>
        /// <returns>返回结果</returns>
        protected bool IllegalDecision()
        {
            return (count >= 3)?true:false;
        }


        /// <summary>
        /// 循环遍历非法词库
        /// </summary>
        protected abstract void ForKeywords();

        /// <summary>
        /// 获取第一条（标题+链接）
        /// </summary>
        /// <param name="html">源文本</param>
        /// <returns>返回标题&链接</returns>
        protected abstract string GetTitle_Url(string html);


        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        /// <param name="html">源文本</param>
        /// <returns>返回判定结果</returns>
        protected abstract bool IsNull(string html);
    }
}
