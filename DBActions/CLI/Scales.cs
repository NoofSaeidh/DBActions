using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBActions.CLI.Scaling;

namespace DBActions.CLI
{
    class Scales
    {
        public Scale Scale { get; set; }
        public Scales()
        {
            Scale = new Scale();
            Scale.Add(new Context()
            {
                Name = "Global",
                Parent = null,
                KeyActions = new KeyAction[]{
                    new KeyAction()
                    {
                        Name = "Quit",
                        Key = ConsoleKey.Q,
                        Action = () => Environment.Exit(0)
                    },
                   new KeyAction()
                    {
                        Name = "Clear",
                        Key = ConsoleKey.C,
                        Action = () => Console.Clear()
                    }}
            });
            Scale.Add(new Context()
            {
                Name = "Main",
                Parent = Scale.Last(),
                KeyActions = new KeyAction[]{
                    new KeyAction()
                    {
                        Name = "Restore Backup",
                        Key = ConsoleKey.R,
                        Action = () => Environment.Exit(0)
                    },
                   new KeyAction()
                    {
                        Name = "Create Backup",
                        Key = ConsoleKey.R,
                        Action = () => Console.Clear()
                    },
                    new ParentKeyAction()
                    {
                        Name = "Create Backup",
                        Key = ConsoleKey.R,
                        Action = () => Console.Clear(),
                        Parent = Scale.Last()
                    }, }
            });

        }
    }
}
