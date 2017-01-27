using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActions.CLI
{
    class DBCLI
    {
        private ConsoleColor color = ConsoleColor.DarkMagenta;
        private CLIExtensions.ColorGroundType groundType = CLIExtensions.ColorGroundType.Foreground;
        private Contexts context = new Contexts();
        private InContext current;
        public Config.Config Config { get; private set; }
        public DBCLI(Config.Config config)
        {
            CLIExtensions.DefaultColor = color;
            CLIExtensions.DefaultGroundType = groundType;
            Config = config;
            Console.Title = Contexts.Messages.TITLE;


            current = context[Contexts.Context.Global];
            current.Print();
            Console.WriteLine();

            current = context[Contexts.Context.Main];
            current.Print(false);
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                var action = current.ActionFromKey(key);
                switch (action)
                {
                    case Contexts.Action.ClearScreen:
                        ClearScreen();
                        break;
                    case Contexts.Action.CreateBackup:
                        CreateBackup();
                        break;
                    case Contexts.Action.RestoreBackup:
                        RestoreBackup();
                        break;
                    case Contexts.Action.GoToMain:
                        GoToMain();
                        break;
                    case Contexts.Action.PreviosContext:
                        PreviosContext();
                        break;
                    case Contexts.Action.Quit:
                        Quit();
                        break;
                    default:
                        break;
                }

            }
        }
        public void ClearScreen()
        {
            Console.Clear();
        }
        public void CreateBackup()
        {

        }
        public void RestoreBackup()
        {

        }
        public void Quit()
        {

        }
        public void PreviosContext()
        {

        }
        public void GoToMain()
        {

        }
    }

}
