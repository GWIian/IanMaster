using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Common;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //XMessage msg = new XMessage("<XMessage><Type>cmd</Type><Params><Param><Pname>from</Pname><Pvalue>Ian</Pvalue></Param><Param><Pname>msg</Pname><Pvalue>Hi!</Pvalue></Param></Params></XMessage>");
            XMessage msg = new XMessage("asd");
            //<XMessage><Type>cmd</Type><Params><Param><Pname>ping</Pname><Pvalue>127.0.0.1</Pvalue></Param></Params></XMessage>
            Console.WriteLine("{0}说：{1}",msg.Params["from"],msg.Params["msg"]);
            Console.ReadKey();
        }
    }
}
