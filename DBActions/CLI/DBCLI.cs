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
        private _oldContexts context = new _oldContexts();
        private _oldInContext current;
        public Config.Config Config { get; private set; }
        public DBCLI(Config.Config config)
        {
            CLIExtensions.DefaultColor = color;
            CLIExtensions.DefaultGroundType = groundType;
            Config = config;
            Console.Title = _oldContexts.Messages.TITLE;


            current = context[_oldContexts.Context.Global];
            current.Print();
            Console.WriteLine();

            current = context[_oldContexts.Context.Main];
            current.Print(false);
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                var action = current.ActionFromKey(key);
                switch (action)
                {
                    case _oldContexts.Action.ClearScreen:
                        ClearScreen();
                        break;
                    case _oldContexts.Action.CreateBackup:
                        CreateBackup();
                        break;
                    case _oldContexts.Action.RestoreBackup:
                        RestoreBackup();
                        break;
                    case _oldContexts.Action.GoToMain:
                        GoToMain();
                        break;
                    case _oldContexts.Action.PreviosContext:
                        PreviosContext();
                        break;
                    case _oldContexts.Action.Quit:
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
