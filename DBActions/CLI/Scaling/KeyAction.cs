using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBActions.CLI.Hardcode;

namespace DBActions.CLI.Scaling
{
    class KeyAction
    {
        public string Text { get; set; }
        public ConsoleKey Key { get; set; }
        public Action<KeyAction> Action { get; set; }
        public Context NextContext { get; set; }
        public string UserInput { get; set; }
        public KeyAction(string text, ConsoleKey key, Action<KeyAction> action, bool markText = true, Context nextContext = null)
        {
            Text = markText?text.MarkLetter(key):text;
            Action = action;
            Key = key;
            NextContext = nextContext;
        }
        public KeyAction()
        {

        }
    }
}
