using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DBTool.CLI;
using DBTool.Configuration;
using System.ComponentModel;
using System.Reflection;

namespace DBTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToConfig = Environment.CurrentDirectory + "\\Configuration\\Config.xml";
            var config = Config.ReadConfig(pathToConfig);
            var cli = new DBCLI(config);
        }
    }
}
