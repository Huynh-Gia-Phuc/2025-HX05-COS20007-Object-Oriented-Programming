using System;
using System.Collections.Generic; // Added for List

namespace Swin_Adventure
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            // Get the player's name and description from the user, and use these details to create a Player object.
            Console.Write("Enter player name: ");
            string playerName = Console.ReadLine();
            Console.Write("Enter player description: ");
            string playerDesc = Console.ReadLine();

            // Create a sample location
            Location forest = new Location(new string[] { "forest", "clearing", "location" }, "Forest Clearing", "A peaceful clearing surrounded by tall trees.");
            // Add an item to the location
            Item stone = new Item(new string[] { "stone", "rock" }, "smooth stone", "A small, smooth stone lies here.");
            forest.Inventory.Put(stone);

            // Create fantasy locations
            Location elfMountain = new Location(new string[] { "elfmountain", "mountain", "elf" }, "Mountain of Elf", "A mystical mountain where elves dwell among the clouds.");
            Location dwarfMine = new Location(new string[] { "dwarfmine", "mine", "dwarf" }, "Mine of Dwarf", "A deep, echoing mine filled with the sounds of dwarven hammers.");
            Location enchantedForest = new Location(new string[] { "enchantedforest", "forest", "enchanted" }, "Enchanted Forest", "A magical forest with glowing plants and hidden secrets.");
            Location dragonCave = new Location(new string[] { "dragoncave", "cave", "dragon" }, "Dragon's Cave", "A dark, smoky cave where a dragon is rumored to sleep.");
            Location wizardTower = new Location(new string[] { "wizardtower", "tower", "wizard" }, "Wizard's Tower", "A tall, spiraling tower filled with arcane energy.");

            // Add items to each location
            elfMountain.Inventory.Put(new Item(new string[] { "elvenbow", "bow" }, "Elven Bow", "A finely crafted bow of the elves."));
            elfMountain.Inventory.Put(new Item(new string[] { "moonstone" }, "Moonstone", "A glowing stone said to hold the power of the moon."));

            dwarfMine.Inventory.Put(new Item(new string[] { "pickaxe" }, "Dwarven Pickaxe", "A sturdy pickaxe used by dwarves."));
            dwarfMine.Inventory.Put(new Item(new string[] { "mithril" }, "Mithril Ingot", "A rare and precious metal ingot."));

            enchantedForest.Inventory.Put(new Item(new string[] { "fairydust", "dust" }, "Fairy Dust", "Sparkling dust with magical properties."));
            enchantedForest.Inventory.Put(new Item(new string[] { "ancientoakleaf", "oakleaf" }, "Ancient Oak Leaf", "A leaf from the oldest tree in the forest."));

            dragonCave.Inventory.Put(new Item(new string[] { "dragonscale", "scale" }, "Dragon Scale", "A tough, shimmering scale from a dragon."));
            dragonCave.Inventory.Put(new Item(new string[] { "goldhoard", "gold" }, "Gold Hoard", "A pile of gold coins and treasures."));

            wizardTower.Inventory.Put(new Item(new string[] { "spellbook" }, "Spellbook", "A book filled with mysterious spells."));
            wizardTower.Inventory.Put(new Item(new string[] { "crystalball", "crystal" }, "Crystal Ball", "A crystal ball that reveals distant places."));

            // Connect locations with paths
            elfMountain.AddPath(new Path(new List<string> { "south", "to forest" }, new Direction("south"), enchantedForest));
            enchantedForest.AddPath(new Path(new List<string> { "north", "to mountain" }, new Direction("north"), elfMountain));
            enchantedForest.AddPath(new Path(new List<string> { "east", "to mine" }, new Direction("east"), dwarfMine));
            dwarfMine.AddPath(new Path(new List<string> { "west", "to forest" }, new Direction("west"), enchantedForest));
            enchantedForest.AddPath(new Path(new List<string> { "south", "to cave" }, new Direction("south"), dragonCave));
            dragonCave.AddPath(new Path(new List<string> { "north", "to forest" }, new Direction("north"), enchantedForest));
            dragonCave.AddPath(new Path(new List<string> { "east", "to tower" }, new Direction("east"), wizardTower));
            wizardTower.AddPath(new Path(new List<string> { "west", "to cave" }, new Direction("west"), dragonCave));

            // Place player in the Enchanted Forest for testing
            Player player = new Player(playerName, playerDesc);
            player.Location = enchantedForest;


            // Create two items and add to player's inventory
            Item sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword look like it coming from a small village near by");
            Item gem = new Item(new string[] { "gem" }, "shiny gem", "a shiny gem, look expensive maybe can trade for some monney");
            player.Inventory.Put(sword);
            player.Inventory.Put(gem);

            // Create a bag and add to player's inventory
            Bag bag = new Bag(new string[] { "bag" }, "leather bag", "a sturdy leather bag, a bag that can carry lots of stuff, maybe star fruit maybe gold? but dont be greedy");
            player.Inventory.Put(bag);

            // Create another item and add to the bag
            Item potion = new Item(new string[] { "potion" }, "healing potion", "a small bottle of healing potion, help with small injury but not for dead people its a potion not dark magic!");
            bag.Inventory.Put(potion);
            //Bag pocket = new Bag(new string[] { "pocket" }, "small pocket", "a small pocket for litle thing or maybe just maybe ilegal thing that need to hide just maybe.");
            //bag.Inventory.Put(pocket);
            //Item coca = new Item(new string[] { "coca" }, "cocacola", "a pack of cocacola powder mix with water to make cocacola, people hate sweet drink so it illegal");
            //pocket.Inventory.Put(coca);

            // Create commands and a command processor
            LookCommand look = new LookCommand();
            MoveCommand moveCommand = new MoveCommand();
            CommandProcessor commandProcessor = new CommandProcessor();
            commandProcessor.AddCommand(look);
            commandProcessor.AddCommand(moveCommand);

            // Loop reading commands from the user, and getting the correct command to execute them.
            Console.WriteLine("\nType commands (e.g., 'look at sword', 'move north', 'look at inventory'). Type 'quit' to exit.");
            while (true)
            {
                Console.Write("\n> ");
                string input = Console.ReadLine();
                if (input == null || input.Trim().ToLower() == "quit")
                    break;
                string result = commandProcessor.ExecuteCommand(player, input);
                Console.WriteLine(result);
            }
        }
    }
}