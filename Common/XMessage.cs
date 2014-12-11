using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Common
{
    /// <summary>
    /// 定义了客户端与服务端之间数据传输的协议
    /// </summary>
    public class XMessage
    {
        /// <summary>
        /// 协议的根模版
        /// </summary>
        private static string tplRoot = "<XMessage><Type>{0}</Type><Params>{1}</Params></XMessage>";
        /// <summary>
        /// 协议的参数模版
        /// </summary>
        private static string tplParam = "<Param><Pname>{0}</Pname><Pvalue>{1}</Pvalue></Param>";

        /// <summary>
        /// 数据的明文形式
        /// </summary>
        private string raw;

        /// <summary>
        /// 获取或设置协议内容的类型
        /// </summary>
        public string Type
        {
            get
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(raw);
                return xml["XMessage"]["Type"].InnerText.Trim();
            }
            set
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(raw);
                xml["XMessage"]["Type"].InnerText = value.Trim();
                raw = xml.InnerXml.Trim();
            }
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        public Dictionary<string, string> Params
        {
            get
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(raw);
                Dictionary<string, string> ret = new Dictionary<string, string>();
                XmlNodeList list = xml.SelectNodes("XMessage/Params/Param");
                foreach (XmlNode x in list)
                {
                    ret.Add(x["Pname"].InnerText.Trim(), x["Pvalue"].InnerText.Trim());
                }
                return ret;
            }
        }

        /// <summary>
        /// 为协议添加参数
        /// </summary>
        /// <param name="pname">参数名</param>
        /// <param name="pvalue">参数值</param>
        public void AddParam(string pname, string pvalue)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(raw);
            xml["XMessage"]["Params"].InnerXml += string.Format(tplParam, pname, pvalue);
            raw = xml.InnerXml.Trim();
        }

        /// <summary>
        /// 构建一个空的协议
        /// </summary>
        public XMessage()
        {
            raw = string.Format(tplRoot, string.Empty, string.Empty);
        }

        /// <summary>
        /// 解析协议
        /// </summary>
        /// <param name="data">数据源</param>
        public XMessage(string data)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(data);
            }
            catch (Exception)
            {
                throw new Exception("解析协议失败,数据源不是正确的协议格式");
            }
            raw = data;
        }
    }
}
