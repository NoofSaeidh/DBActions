using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTool.CLI.Hardcode
{
    static class Highlight
    {
        public const ConsoleColor Color = ConsoleColor.DarkMagenta;
        public const CLIExtensions.ColorGroundType GroundType = CLIExtensions.ColorGroundType.Foreground;
        public static char SeparatorLeft = '[';
        public static char SeparatorRight = ']';
    }
}
