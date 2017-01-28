using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBActions.CLI.Scaling;
using DBActions.CLI.Hardcode;

namespace DBActions.CLI
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
        }
    }
}
