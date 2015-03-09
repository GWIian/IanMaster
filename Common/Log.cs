using System.IO;
using System;

namespace Common
{
    /// <summary>
    /// 日志操作类
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="module">模块名</param>
        /// <param name="msg">消息</param>
        public static void WriteLog(string module, string msg)
        {
            //检查日志目录是否存在，不存在则创建。
            if (!Directory.Exists("log/"))
            {
                Directory.CreateDirectory("log/");
            }

            string filename = DateTime.Now.ToString("yyyyMMdd");
            StreamWriter sw = new StreamWriter("log/" + filename + ".txt", true);
            sw.WriteLine("[{0}] [{1}] [{2}]", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), module, msg);
            sw.Close();
        }
    }
}
