using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Util
    {
        /// <summary>
        /// 处理文本中的非法字符
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EncodingText(string text)
        {
            return text.Replace("<", "&lt;").Replace(">", "&gt;");
        }

        /// <summary>
        /// 还原文本
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string DecodingText(string text)
        {
            return text.Replace("&lt;", "<").Replace("&gt;", ">");
        }
    }
}
