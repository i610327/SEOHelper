using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 排名查询.DAL
{
    /// <summary>
    /// 全局变量
    /// </summary>
    public class GlobalValue
    {
        /// <summary>
        /// 网站和对应的关键词
        /// </summary>
        public static Dictionary<string, string> Url_Kyewords = new Dictionary<string, string>();

        /// <summary>
        /// 是否处于被修改状态
        /// </summary>
        public static bool State = false;

    }
}
