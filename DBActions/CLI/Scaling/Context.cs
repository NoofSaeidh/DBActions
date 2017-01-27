using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActions.CLI.Scaling
{
    class Context
    {
        public string Name { get; set; }
        public KeyAction[] KeyActions { get; set; }
        public Context Parent { get; set; }
        public Context()
        {

        }
        public Context(string name, Context parent, params KeyAction[] keyActions)
        {
            Name = name;
            KeyActions = keyActions;
            Parent = parent;
        }
    }
}
