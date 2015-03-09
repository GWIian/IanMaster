using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MasterClient
{
    public class Config
    {
        /// <summary>
        /// 应用程序版本号
        /// </summary>
        public static string Version;

        /// <summary>
        /// 设备号
        /// </summary>
        public static string DeviceId;

        /// <summary>
        /// 服务监听的IP
        /// </summary>
        public static string Ip;

        /// <summary>
        /// 服务监听的端口号
        /// </summary>
        public static string Port;

        /// <summary>
        /// 载入配置
        /// </summary>
        public static void LoadConfig()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("config/MasterClient.xml");
                XmlNode nConf = xml.SelectSingleNode("Conf");
                Version = nConf["Application"]["Version"].InnerText;
                DeviceId = nConf["Application"]["DeviceId"].InnerText;
                Ip = nConf["Network"]["Ip"].InnerText;
                Port = nConf["Network"]["Port"].InnerText;
            }
            catch (Exception e)
            {
                Common.Log.WriteLog("Config.LoadConfig", e.Message);
            }
        }

        /// <summary>
        /// 清空配置常数
        /// </summary>
        public void Reset()
        {
            Version = string.Empty;
            DeviceId = string.Empty;
            Ip = string.Empty;
            Port = string.Empty;
        }
    }
}
