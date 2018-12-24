using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace 排名查询.BLL
{
    public class XMLS
    {
        /// <summary>
        /// XML地址
        /// </summary>
        private static string xmlpath = AppDomain.CurrentDomain.BaseDirectory + "data.xml";

        /// <summary>
        /// 获取关键词列表
        /// </summary>
        /// <param name="url">获取指定url的关键词</param>
        /// <returns>返回查询结果</returns>
        public List<string> GetKeyWords(string url)
        {
            List<string> keywords = new List<string>();
            if (File.Exists(xmlpath))
            {
                //省略了判定xml文件存在
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlpath);
                XElement root = xd.Root;
                //获取根节点下所有子节点
                IEnumerable<XElement> xe = root.Elements();
                foreach (XElement fxe in xe)
                {
                    foreach (XElement sxe in fxe.Elements())
                    {
                        if (fxe.LastAttribute.Value == url)
                        {
                            string[] Keywords = sxe.Value.Split(new string[] { "^-@" }, StringSplitOptions.RemoveEmptyEntries);//字符串分割
                            for (int i = 0; i < Keywords.Length; i++)
                            {
                                keywords.Add(Keywords[i]);
                            }

                        }
                    }
                }
            }
            return keywords;
        }


        /// <summary>
        /// 获取关键词列表(字符串形态)
        /// </summary>
        /// <param name="url">查询的URL</param>
        /// <returns>返回查询结果</returns>
        public string GetKyewordStr(string url)
        {
            if (File.Exists(xmlpath))
            {
                //省略了判定xml文件存在
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlpath);
                XElement root = xd.Root;
                //获取根节点下所有子节点
                IEnumerable<XElement> xe = root.Elements();
                foreach (XElement fxe in xe)
                {
                    foreach (XElement sxe in fxe.Elements())
                    {
                        if (fxe.LastAttribute.Value == url)
                        {
                            return sxe.Value;

                        }
                    }
                }
            }
            return string.Empty;
        }

        Start st = new Start();

        /// <summary>
        /// XML增加数据
        /// </summary>
        /// <param name="url">增加的URL</param>
        /// <returns>返回增加结果</returns>
        public bool AddXmlUrl(string url)
        {
            try
            {
                //判断是否存在该值
                if (JudgeUrl(url)) return false;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlpath);
                //查找<data>   
                XmlNode root = xmlDoc.SelectSingleNode("data");
                //创建一个<ur>节点 
                XmlElement xe1 = xmlDoc.CreateElement("ur");
                //设置该节点id属性   
                xe1.SetAttribute("id", url);
                //设置节点名称
                XmlElement xesub1 = xmlDoc.CreateElement("keyword");
                //设置文本节点,新创建的暂时未NULL
                xesub1.InnerText = "";
                //添加到<keyword>节点中 
                xe1.AppendChild(xesub1);
                //添加到<data>节点中   
                root.AppendChild(xe1);
                xmlDoc.Save(xmlpath);
            }
            catch
            {
                return false;
            }
            st.ChuShiHua();
            //修改状态
            DAL.GlobalValue.State = true;
            return true;
        }

        /// <summary>
        /// 更新指定url的关键词
        /// </summary>
        /// <param name="url">指定的URL</param>
        /// <param name="kyewords">关键词库</param>
        /// <returns>返回更新结果</returns>
        public bool UpdateXmlKyewords(string url, string[] kyewords)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlpath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("data").ChildNodes;//获取data节点的所有子节点   
            foreach (XmlNode xn in nodeList)//遍历所有子节点   
            {
                //将子节点类型转换为XmlElement类型   
                XmlElement xe = (XmlElement)xn;
                //如果id属性值为url 
                if (xe.GetAttribute("id") == url)
                {
                    //继续获取xe子节点的所有子节点   
                    XmlNodeList nls = xe.ChildNodes;
                    foreach (XmlNode xn1 in nls)  
                    {
                        //转换类型   
                        XmlElement xe2 = (XmlElement)xn1;
                        //如果找到   
                        if (xe2.Name == "keyword")
                        {
                            //判断是更新还是直接创建
                            if (xe2.InnerText.Trim().Length > 1)
                            {
                                xe2.InnerText = xe2.InnerText + "^-@" + string.Join("^-@", kyewords);
                                //找到退出来就可以了 
                                break; 
                            }
                            else
                            {
                                xe2.InnerText = string.Join("^-@", kyewords);
                                //找到退出来就可以了  
                                break;
                            }

                        }
                    }
                    break;
                }
            }

            xmlDoc.Save(xmlpath);//保存。
            st.ChuShiHua();
            //修改状态
            DAL.GlobalValue.State = true;
            return true;
        }

        /// <summary>
        /// 获取链接列表
        /// </summary>
        /// <returns>返回链接列表</returns>
        public List<string> GetUrls()
        {
            List<string> urls = new List<string>();
            if (File.Exists(xmlpath))
            {
                //省略了判定xml文件存在
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlpath);
                XElement root = xd.Root;
                //获取根节点下所有子节点
                IEnumerable<XElement> xe = root.Elements();
                foreach (XElement fxe in xe)
                {
                    urls.Add(fxe.LastAttribute.Value);
                }
            }
            return urls;
        }


        /// <summary>
        /// 判断URL是否存在
        /// </summary>
        /// <param name="url">判断的URL</param>
        /// <returns>返回判断结果</returns>
        public bool JudgeUrl(string url)
        {
            if (File.Exists(xmlpath))
            {
                //省略了判定xml文件存在
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlpath);
                XElement root = xd.Root;
                //获取根节点下所有子节点
                IEnumerable<XElement> xe = root.Elements();
                foreach (XElement fxe in xe)
                {
                    if (fxe.LastAttribute.Value == url)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
