using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (AreYou(text[0].ToLower()))
            {
                if (text.Length == 1)
                {
                    return "Where do you want to go?";
                }
                else if (text.Length == 2)
                {
                    return Move(p, text[1]);
                }
                else
                {
                    return "Move command error (dev's fault)";
                }
            }
            else
            {
                return "Error in move input";
            }
        }

        public string Move(Player p, string direction)
        {
            Direction moveDirection;
            if (Enum.TryParse(direction, true, out moveDirection))
            {
                if (p.Location.Path != null)
                {
                    Path path = p.Location.Path;
                    if (path.Egress.Contains(moveDirection))
                    {
                        p.Location = path.Destination;
                        return $"You have moved {direction}. You are now at {p.Location.Name}.";
                    }
                    else 
                    {
                        return $"You cannot move {direction} from your current location.";
                    }
                }
                else
                {
                    return "There are no paths available from your current location.";
                }
            }
            else
            {
                return "Invalid direction. Please specify a valid direction (e.g. North, South, NorthEast, SouthWest).";
            }
        }

    }
}

