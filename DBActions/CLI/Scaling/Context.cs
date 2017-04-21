using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBActions.CLI.Scaling
{
    class Context
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public List<KeyAction> KeyActions { get; set; }
        public Context Parent { get; set; }
        public Context()
        {

        }
        public Context(string name, Context parent, string text, bool withParentActions = false, bool withMainParentActions = true, params KeyAction[] keyActions)
        {
            Name = name;
            Parent = parent;
            Text = text;
            KeyActions = keyActions.ToList();
            if (withParentActions) AddParentActions();
            if (withMainParentActions) AddGlobalActions();

        }
        public Context(string name, Context parent, string text, params KeyAction[] keyActions)
        {
            Name = name;
            Parent = parent;
            Text = text;
            KeyActions = keyActions.ToList();
        }
        public Context(string name, Context parent, string text, List<KeyAction> keyActions)
        {
            Name = name;
            Parent = parent;
            Text = text;
            KeyActions = keyActions;
        }
        public void AddParentActions()
        {
            AddActions(Parent.KeyActions);
        }
        public void AddGlobalActions()
        {
            var globalActions = GetGlobalParent().KeyActions;
            AddActions(globalActions);
        }
        public void AddActions(params KeyAction[] keyActions)
        {
            foreach (var action in keyActions)
            {
                if (!this.KeyActions.Contains(action)) this.KeyActions.Add(action);
            }
        }
        public void AddActions(IEnumerable<KeyAction> keyActions)
        {
            foreach (var action in keyActions)
            {
                if (!this.KeyActions.Contains(action)) this.KeyActions.Add(action);
            }
        }
        public Context GetGlobalParent()
        {
            var main = this;
            while (main != null)
            {
                main = main.Parent;
            }
            return main;
        }
    }
}
