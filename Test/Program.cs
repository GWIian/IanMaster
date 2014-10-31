using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            p.StartInfo.FileName = "MasterClient.exe";
            p.Start();
        }
    }
}
