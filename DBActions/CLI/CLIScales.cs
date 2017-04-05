using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTool.CLI.Scaling;
using DBTool.CLI.Hardcode;

namespace DBTool.CLI
{
    static class CLIScales
    {
        public static Scale Scale { get; private set; }
        static CLIScales()
        {
            Scale = new Scale
            {
                { Names.Contexts.Main, null }
            };
            Scale.Add(Names.Contexts.Global, null, new KeyAction[]
            {
                new KeyAction(Names.Actions.ClearScreen,ConsoleKey.C,Actions.ClearScreen),
                new KeyAction(Names.Actions.Quit,ConsoleKey.Q,Actions.Quit)
            });
        }
    }
}
