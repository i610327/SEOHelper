using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 新排名获取规则
{
    public class Multithreading
    {
        /// <summary>
        /// 构造函数，初始化时进行操作
        /// </summary>
        /// <param name="url"></param>
        public Multithreading(string url)
        {
            _url = url;
        }

        /// <summary>
        /// 查询的URL
        /// </summary>
        private string _url = string.Empty;

        /// <summary>
        /// 实例化类
        /// </summary>
        Operate op = new Operate("so");

        /// <summary>
        /// 返回关键词排名
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <returns>返回排名</returns>
        public int GetRanking(object keyword)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.GetRanking2), keyword);
            
            return ranking;
        }


        private int ranking = 0;
        private void GetRanking2(object keyword)
        {
            ranking = op.GetRanking(keyword.ToString(), _url, 30);
        }

       
        
    }
}
