using DBActions.CLI.Scaling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActions.CLI.Hardcode
{
    static class KeyActions
    {
        public static readonly KeyAction RestoreBackup;
        public static readonly KeyAction ClearScreen;

        static KeyActions()
        {
            RestoreBackup = new KeyAction(Names.Actions.RestoreBackup, ConsoleKey.R, null);
            ClearScreen = new KeyAction(Names.Actions.ClearScreen, ConsoleKey.C, null);
        }
    }
}
