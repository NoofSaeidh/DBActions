using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActions.CLI
{
    static class CLIExtensions
    {
        public static void Write(this string line)
        {
            Console.Write(line);
        }
        public static void Write(this string line, params object[] args)
        {
            Console.Write(line, args);
        }
        public static void WriteColor(this string line, ConsoleColor? color =null, ColorGroundType? type = null)
        {
            if (type == null)
                type = DefaultGroundType;
            if (color == null)
                color = DefaultColor;

            if (type == ColorGroundType.Foreground)
            {
                var defColor = Console.ForegroundColor;
                foreach (var cline in Separate(line, (ConsoleColor)color))
                {
                    Console.ForegroundColor = cline.Color ?? defColor;
                    Console.Write(cline.String);
                }
                Console.ForegroundColor = defColor;
            }
            else
            {
                var defColor = Console.BackgroundColor;
                foreach (var cline in Separate(line, (ConsoleColor)color))
                {
                    Console.BackgroundColor = cline.Color ?? defColor;
                    Console.Write(cline.String);
                }
                Console.BackgroundColor = defColor;
            }
        }
        public static void WriteLine(this string line)
        {
            Console.WriteLine(line);
        }
        public static void WriteLine(this string line, params object[] args)
        {
            Console.WriteLine(line, args);
        }
        public static void WriteLineColor(this string line, ConsoleColor? color = null, ColorGroundType? type = null)
        {
            if (type == null)
                type = DefaultGroundType;
            if (color == null)
                color = DefaultColor;

            if (type == ColorGroundType.Foreground)
            {
                var defColor = Console.ForegroundColor;
                foreach (var cline in Separate(line, (ConsoleColor)color))
                {
                    Console.ForegroundColor = cline.Color ?? defColor;
                    Console.Write(cline.String);
                }
                Console.ForegroundColor = defColor;
            }
            else
            {
                var defColor = Console.BackgroundColor;
                foreach (var cline in Separate(line, (ConsoleColor)color))
                {
                    Console.BackgroundColor = cline.Color ?? defColor;
                    Console.Write(cline.String);
                }
                Console.BackgroundColor = defColor;
            }
            Console.WriteLine();
        }
        
        public static ConsoleColor DefaultColor { get; set; }
        public static ColorGroundType DefaultGroundType { get; set; }
        //For Highlighted function required exatly two separators. They must be different
        public static char[] Separators { get; set; } = { '[', ']' };
        //Be careful separator separates straight sequently -
        //"Some [te]xt" the same as "Some ]te]xt 
        private static ColorString[] Separate(string line, ConsoleColor color)
        {
            var strings = line.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            var cStrings = new ColorString[strings.Length];
            int i = 0;
            bool colorFlag = Separators.Contains(line[0]) ? true : false;
            foreach (var str in strings)
            {
                cStrings[i] = new ColorString(str, colorFlag ? color : default(ConsoleColor?));
                colorFlag = !colorFlag;
                i++;
            }
            return cStrings;
        }
        private struct ColorString
        {
            public string String;
            public ConsoleColor? Color;
            public ColorString(string cstring, ConsoleColor? color)
            {
                String = cstring;
                Color = color;
            }
        }
        public enum ColorGroundType
        {
            Foreground,
            Background,
        }


    }

}
