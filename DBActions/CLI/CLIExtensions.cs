﻿using DBActions.CLI.Hardcode;
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
        public static void WriteColor(this string line, ConsoleColor? color = null, ColorGroundType? type = null)
        {
            if (type == null)
                type = DefaultGroundType;
            if (color == null)
                color = DefaultHighlighColor;

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
                color = DefaultHighlighColor;

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

        public static ConsoleColor DefaultHighlighColor { get; set; }
        public static ColorGroundType DefaultGroundType { get; set; }


        private static IEnumerable<ColorString> Separate(string line, ConsoleColor color)
        {
            var poses = new List<ColorString>();
            var insep = false;

            string str = "";
            foreach (var ch in line)
            {
                if (insep)
                {
                    if (ch == Highlight.SeparatorLeft) throw new Exception($"Each left separator '{Highlight.SeparatorLeft}' must be to the left of right separator '{Highlight.SeparatorRight}'");
                    if (ch == Highlight.SeparatorRight)
                    {
                        if (!string.IsNullOrEmpty(str)) poses.Add(new ColorString(str, color));
                        str = "";
                        insep = false;
                        continue;
                    }
                    str += ch;
                    continue;
                }
                else
                {
                    if (ch == Highlight.SeparatorRight) throw new Exception($"Each right separator '{Highlight.SeparatorRight}' must be to the right of left separator '{Highlight.SeparatorLeft}'");
                    if (ch == Highlight.SeparatorLeft)
                    {
                        if(!string.IsNullOrEmpty(str)) poses.Add(new ColorString(str, null));
                        str = "";
                        insep = true;
                        continue;
                    }
                    str += ch;
                    continue;
                }
            }
            if(insep) throw new Exception($"Text must contains equals quantity of left separator '{Highlight.SeparatorLeft}' and right separator '{Highlight.SeparatorRight}'");
            if (!string.IsNullOrEmpty(str)) poses.Add(new ColorString(str, null));
            return poses;
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

        public static string MarkLetter(this string text, ConsoleKey key)
        {
            if (key < ConsoleKey.A || key > ConsoleKey.Z)
                throw new Exception("Key must be an english letter");
            char upkey = (char)key;
            char lokey = char.ToLower(upkey);
            if (!text.ToLower().Contains(lokey))
                throw new Exception("Text does not contains letter");
            int pos = text.IndexOf(upkey);
            var newkey = upkey;
            if (pos == -1)
            {
                pos = text.IndexOf(lokey);
                newkey = lokey;
            }
            if (pos == 0)
                return Highlight.SeparatorLeft + text.Substring(0, 1) + Highlight.SeparatorRight + text.Substring(1, text.Length - 1);
            return text.Substring(0, pos) + Highlight.SeparatorLeft + text.Substring(pos, 1) + Highlight.SeparatorRight + text.Substring(pos + 1, text.Length - pos - 1);
        }
    }

}
