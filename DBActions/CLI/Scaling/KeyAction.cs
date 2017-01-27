using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActions.CLI.Scaling
{
    struct KeyAction
    {
        public string Name { get; set; }
        public ConsoleKey Key { get; set; }
        public Action Action { get; set; }
        public KeyAction(string name, ConsoleKey key, Action action)
        {
            Name = name;
            Action = action;
            Key = key;
        }
    }

}
