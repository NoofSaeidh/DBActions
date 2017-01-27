using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DBActions.CLI
{
    class Contexts
    {
        private readonly Dictionary<Context, InContext> collection;
        public Contexts()
        {
            collection = new Dictionary<Context, InContext>();

            var global = new InContext()
            {
                Context = Context.Global,
                AppliesToChildren = true,
                Parent = null,
                Messages = new string[]
                {
                    Messages.GREETING,
                    Messages.GLOBAL_ACTIONS
                },
                Actions = new Action[]
                {
                    Action.Quit,
                    Action.ClearScreen,
                    Action.GoToMain
                }
            };
            var main = new InContext()
            {
                Context = Context.Main,
                AppliesToChildren = false,
                Parent = global,
                Messages = new string[]
                {
                    Messages.MAIN_ACTIONS
                },
                Actions = new Action[]
                {
                    Action.ReadConfig,
                    Action.SaveConfig,
                    Action.ViewConfig,
                    Action.GoToDBActions
                }
            };
            var dbactions = new InContext()
            {
                Context = Context.DBActions,
                AppliesToChildren = false,
                Parent = main,
                Messages = new string[]
                {
                    Messages.DB_ACTIONS
                },
                Actions = new Action[]
                {
                    Action.RestoreBackup,
                    Action.CreateBackup
                }
            };
            AddToCollection(global, main, dbactions);

        }
        private Dictionary<Context, InContext> AddToCollection(params InContext[] contexts)
        {
            foreach (var conx in contexts)
            {
                collection.Add(conx.Context, conx);
            }
            return collection;
        }
        public InContext this[Context context] => collection[context];
        public enum Action
        {
            [Key(ConsoleKey.Q)]
            Quit,
            [Key(ConsoleKey.P)]
            PreviosContext,
            [Key(ConsoleKey.R)]
            RestoreBackup,
            [Key(ConsoleKey.B)]
            CreateBackup,
            [Key(ConsoleKey.M)]
            GoToMain,
            [Key(ConsoleKey.C)]
            ClearScreen,
            [Key(ConsoleKey.R)]
            ReadConfig,
            [Key(ConsoleKey.S)]
            SaveConfig,
            [Key(ConsoleKey.V)]
            ViewConfig,
            [Key(ConsoleKey.D)]
            GoToDBActions,
        }
        public static Dictionary<ConsoleKey, Action> ActionFromKey { get; }
        static Contexts()
        {
            ActionFromKey = new Dictionary<ConsoleKey, Action>();
            var aT = typeof(Action);
            foreach (var field in Enum.GetValues(aT))
            {
                var value = (Action)field;
                var key = value.GetKey();
                ActionFromKey.Add(key, value);
            }
        }
        public enum Context
        {
            Global,
            Main,
            DBActions,
            Config
        }
        #region Messages
        public static class Messages
        {
            public const string TITLE = "Database Actions";

            public const string GREETING =
@"This tool allows you to restore and backup databases.
Actions that you can do will be highlight in the words, describes logic of this actions.";

            public const string GLOBAL_ACTIONS =
@"Anywhere in program you can: 
[Q]uit the program;
[C]lear the screen;
Go to [M]ain screen";

            public const string MAIN_ACTIONS = "You can [R]ead config, [V]iew current config, [S]ave current config, of start making [D]atabase actions.";

            public const string DB_ACTIONS = "You can [B]ackup and [R]estore database.";



        }
        #endregion
    }

}
