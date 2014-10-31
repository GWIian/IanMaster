using System.Xml;
using System;

namespace MasterServer
{
    /// <summary>
    /// 配置文件常数类
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 应用程序版本号
        /// </summary>
        public static string Version;

        /// <summary>
        /// 服务监听的IP
        /// </summary>
        public static string Listen;

        /// <summary>
        /// 服务监听的端口号
        /// </summary>
        public static string Port;

        /// <summary>
        /// 最大终端连接数
        /// </summary>
        public static string MaxConnection;

        /// <summary>
        /// 载入配置
        /// </summary>
        public static void LoadConfig()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("config/app.xml");
                XmlNode nConf = xml.SelectSingleNode("Conf");
                Version = nConf["Application"]["Version"].InnerText;
                Listen = nConf["Network"]["Listen"].InnerText;
                Port = nConf["Network"]["Port"].InnerText;
                MaxConnection = nConf["Network"]["MaxConnection"].InnerText;
            }
            catch (Exception e)
            {
                Log.WriteLog("Config.LoadConfig", e.Message);
            }
        }

        /// <summary>
        /// 清空配置常数
        /// </summary>
        public void Reset()
        {
            Version = string.Empty;
            Listen = string.Empty;
            Port = string.Empty;
            MaxConnection = string.Empty;
        }
    }
}
