using DBTool.CLI.Scaling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTool.CLI.Hardcode
{
    static class Actions
    {
        public static void ClearScreen(KeyAction owner)
        {
            Console.Clear();
        }
        public static void GoBack(KeyAction owner)
        {
            Console.WriteLine(owner);
            ////
        }
        public static void WriteActions(Context context)
        {
            var top = Console.CursorTop;
            var left = Console.CursorLeft;
            Console.SetCursorPosition(0, Console.WindowHeight-1);
            foreach (var action in context.KeyActions)
            {
                action.Text.WriteColor();
                Console.Write("\t");
            }

            Console.SetCursorPosition(left, top);
        }

        internal static void Quit(KeyAction owner)
        {
            Environment.Exit(0);
        }
    }
}
