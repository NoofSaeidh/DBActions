using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActions.CLI.Scaling
{
    class Scale : List<Context>
    {
        public void Add(string name, Context parent, params KeyAction[] keyActions)
        {
            this.Add(new Context(name, parent, keyActions));
        }
        public void Add(string name, Context parent, IEnumerable<KeyAction> keyActions)
        {
            this.Add(new Context(name, parent, keyActions.ToArray()));
        }
    }
}
