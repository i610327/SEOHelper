using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 排名查询.BLL
{
    /// <summary>
    /// 搜索引擎安全监测
    /// </summary>
    public class Security
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
        /// 搜索引擎类型
        /// </summary>
        private string _genre = string.Empty;

        /// <summary>
        /// 敏感词库
        /// </summary>
        private string[] Keywords = { "娱乐城", "国际娱乐城", "赌博", "奖金", "娛樂城", "官网", "官 网", "亚洲娱乐", "娱乐国际", "乐电子游戏", "权威平台", "合彩", "老虎机", "水上娱乐城", "澳博", "娱乐注册", "娱乐城赌博", "娱乐城官网", "娱乐城电子游戏", "天上人间", "亚洲最火", "百家乐", "博彩网", "色情", "成人" };

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="genre">搜索引擎类型</param>
        public Security(string genre)
        {
            _genre = genre;
        }
    }
}
