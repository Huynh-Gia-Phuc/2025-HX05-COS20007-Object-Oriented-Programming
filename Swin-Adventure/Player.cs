using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Player : GameObject, IHaveInventory    
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _location = null;
        }

        public Player(string name, string desc, Location location) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _location = location;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            Item locatedItem = _inventory.Fetch(id);
            if (locatedItem != null)
            {
                return locatedItem;
            }

            if (_location != null)
            {
                GameObject locatedInLocation = _location.Locate(id);
                if (locatedInLocation != null)
                {
                    return locatedInLocation;
                }
            }
            return null;
        }

        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {base.FullDescription}\nYour inventory contains:\n{_inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }
    }
}
