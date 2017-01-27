using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActions.CLI.Scaling
{
    class KeyAction
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
        public KeyAction()
        {

        }
    }
    class ParentKeyAction : KeyAction
    {
        public Context Parent { get; set; }
        public ParentKeyAction()
        {

        }
        public ParentKeyAction(string name, ConsoleKey key, Action action, Context parent) : base(name, key, action)
        {
            Parent = parent;
        }
    }

}
