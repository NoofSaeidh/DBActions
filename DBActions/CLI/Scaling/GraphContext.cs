using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActions.CLI.Scaling
{
    class GraphContext : Dictionary<string,Context>
    {
        public void Add(string name, Context parent, string text, params KeyAction[] keyActions)
        {
            this.Add(name, new Context(name, parent, text, keyActions));
        }
        public void Add(string name, Context parent, string text, List<KeyAction> keyActions)
        {
            this.Add(name, new Context(name, parent, text, keyActions));
        }
        public void Add(Context context)
        {
            this.Add(context.Name, context);
        }
        public void AddRange(params Context[] contexts)
        {
            foreach(var con in contexts)
            {
                base.Add(con.Name, con);
            }
        }
    }
}
