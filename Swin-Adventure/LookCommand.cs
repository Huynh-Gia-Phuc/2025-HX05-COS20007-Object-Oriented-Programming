using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" }) { }


        public override string Execute(Player p, string[] text)
        {
            // Support 'look around'
            if (text.Length == 2 && text[0] == "look" && text[1] == "around")
            {
                if (p.Location != null)
                    return p.Location.FullDescription;
                else
                    return "You are nowhere.";
            }

            // Support 'look at location'
            if (text.Length == 3 && text[0] == "look" && text[1] == "at" && text[2] == "location")
            {
                if (p.Location != null)
                    return p.Location.FullDescription;
                else
                    return "You are nowhere.";
            }

            if (text.Length != 3 && text.Length != 5)
                return "I don't know how to look like that";

            if (text[0] != "look")
                return "Error in look input";

            if (text[1] != "at")
                return "What do you want to look at";

            string itemId = text[2];
            IHaveInventory container;

            if (text.Length == 3)
            {
                container = p;
            }
            else
            {
                if (text[3] != "in")
                    return "What do you want to look in";

                string containerId = text[4];
                container = FetchContainer(p, containerId);
                if (container == null)
                    return $"can't find the {containerId}";
            }

            return LookAtIn(itemId, container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            GameObject obj = p.Locate(containerId);
            return obj as IHaveInventory;    
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject item = container.Locate(thingId);
            if (item == null)
                return $"can't find the {thingId}";
            return item.FullDescription;
        }
    }
}
