using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTool.CLI.Hardcode;

namespace DBTool.CLI.Scaling
{
    class KeyAction
    {
        public string Text { get; set; }
        public ConsoleKey Key { get; set; }
        public Action<KeyAction> Action { get; set; }
        public KeyAction(string text, ConsoleKey key, Action<KeyAction> action, bool markText = true)
        {
            Text = markText?text.MarkLetter(key):text;
            Action = action;
            Key = key;
        }
        public KeyAction()
        {

        }
    }
}
