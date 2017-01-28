using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActions.CLI.Hardcode
{
    static class Names
    {
        public static class Contexts
        {
            public const string Global = "Global";
            public const string Main = "Main";
            public const string Config = "Config";
        }
        public static class Actions
        {
            public const string RestoreBackup = "Restore Backup";
            public const string CreateBackup = "Create Backup";
            public const string ReadConfig = "Read Config";
            public const string SaveConfig = "Save Config";
            public const string ClearScreen = "Clear Screen";
            public const string Quit = "Quit";
            public const string GoBack = "Go Back";

        }

    }
}
