using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static DBActions.CLI.CLIExtensions;

namespace DBActions.CLI
{
    class InContext
    {
        public Contexts.Context Context { get; set; }
        public string[] Messages { get; set; }
        public InContext Parent { get; set; }
        public bool AppliesToChildren { get; set; }
        public Contexts.Action[] Actions { get; set; }
        public void Print(bool clearScreen = true)
        {
            if (clearScreen) Console.Clear();
            foreach (var message in Messages)
            {
                message.WriteLineColor();
            }
        }
        public void Print(ConsoleColor highlighColor, ColorGroundType grountType, bool clearScreen = true)
        {
            if (clearScreen) Console.Clear();
            foreach (var message in Messages)
            {
                message.WriteLineColor(highlighColor,grountType);
            }
        }
        public Contexts.Action? ActionFromKey(ConsoleKey key)
        {
            if (!Contexts.ActionFromKey.ContainsKey(key)) return null;
            var action = Actions.GetAction(key);
            if (action != null) return action;
            var parent = Parent;
            while (parent != null)
            {
                if (!parent.AppliesToChildren)
                {
                    parent = parent.Parent;
                    continue;
                }
                action = parent.Actions.GetAction(key);
                if (action != null) return action;
                parent = parent.Parent;
            }
            return null;
        }
    }

    public class KeyAttribute : Attribute
    {
        public ConsoleKey Key { get; set; }
        public KeyAttribute(ConsoleKey key)
        {
            Key = key;
        }
    }
    public static class ContextExtensions
    {
        public static ConsoleKey GetKey(this Contexts.Action action)
        {
            return action.GetType().GetField(action.ToString()).GetCustomAttribute<KeyAttribute>().Key;
        }
        public static Contexts.Action? GetAction(this Contexts.Action[] actions,ConsoleKey key)
        {
            foreach (var action in actions)
            {
                if (action.GetKey() == key) return action;
            }
            return null;
        }
    }

}
