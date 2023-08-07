using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor : Command
    {
        private List<Command> _commands;

        public CommandProcessor(string[] ids, Command[] commands) : base(ids)
        {
            _commands = new List<Command>(); 
            foreach (Command c in commands)
            {
                _commands.Add(c);
            }
        }

        public override string Execute(Player p, string[] command)
        {
            foreach (Command c in _commands)
            {
                if (c.AreYou(command[0]))
                {
                    return c.Execute(p, command);
                }
            }
            return "Invalid Command";
        }
    }
}
