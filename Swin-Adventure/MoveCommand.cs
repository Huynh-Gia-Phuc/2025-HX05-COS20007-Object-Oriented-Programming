using System;

namespace Swin_Adventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length < 2)
                return "Move where?";

            string direction = text[1].ToLower();
            Location currentLocation = p.Location;
            Path path = currentLocation.GetPath(direction);

            if (path != null)
            {
                p.MoveTo(path.Destination);
                return $"You move {direction}.";
            }
            else
            {
                return $"You can't go '{direction}'.";
            }
        }
    }
} 