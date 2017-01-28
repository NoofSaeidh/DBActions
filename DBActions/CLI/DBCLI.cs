using DBActions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBActions.CLI.Hardcode;

namespace DBActions.CLI
{
    class DBCLI
    {
        public Config Config { get; private set; }
        public DBCLI(Config config)
        {
            CLIExtensions.DefaultColor = Highlight.Color;
            CLIExtensions.DefaultGroundType = Highlight.GroundType;
            Config = config;
            Console.Title = Messages.Title;
            KeyActions.ClearScreen.Action = null;
            KeyActions.ClearScreen.Text.WriteColor();
            Messages.Greeting.WriteColor();
            "Put [some] text i[n] her[e]".WriteColor();
            
            "[] not [] wrong [  ;kashrioy384y89--------_____ ]".WriteColor();
          }
    }
}


