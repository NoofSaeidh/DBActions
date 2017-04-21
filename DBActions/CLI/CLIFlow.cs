using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBActions.CLI.Scaling;
using DBActions.CLI.Hardcode;

namespace DBActions.CLI
{
    class CLIFlow
    {
        public GraphContext Graph { get; private set; }
        public Context Current { get; private set; }
        public Context this[string context] => Graph[context];
        public CLIFlow()
        {
            Graph = new GraphContext();
            var global = new Context(Names.Contexts.Global, null, null,
                KeyActions.ClearScreen,
                KeyActions.Quit);
            var main = new Context(Names.Contexts.Main, null, Messages.Greeting,
                KeyActions.CreateBackup,
                KeyActions.RestoreBackup);
            Graph.AddRange(global, main);
            Current = global;
        }
        static class KeyActions
        {
            public static readonly KeyAction RestoreBackup = new KeyAction(Names.Actions.RestoreBackup, ConsoleKey.R, Actions.RestoreBackup);
            public static readonly KeyAction CreateBackup = new KeyAction(Names.Actions.CreateBackup, ConsoleKey.B, Actions.CreateBackup);
            public static readonly KeyAction ClearScreen = new KeyAction(Names.Actions.ClearScreen, ConsoleKey.C, Actions.ClearScreen);
            public static readonly KeyAction Quit = new KeyAction(Names.Actions.Quit, ConsoleKey.Q, Actions.Quit);
        }
    }
}
