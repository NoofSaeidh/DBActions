using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DBActions.CLI;
using DBActions.Configuration;
using System.ComponentModel;
using System.Reflection;

namespace DBActions
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
