using System;

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

            // Create the player and assign the location
            Player player = new Player(playerName, playerDesc);
            player.Location = forest;


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

            // Create LookCommand
            LookCommand look = new LookCommand();

            // Loop reading commands from the user, and getting the look command to execute them.
            Console.WriteLine("\nType commands (e.g., 'look at sword', 'look at potion in bag', 'look at inventory'). Type 'quit' to exit.");
            while (true)
            {
                Console.Write("\n> ");
                string input = Console.ReadLine();
                if (input == null || input.Trim().ToLower() == "quit")
                    break;
                string[] commandWords = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string result = look.Execute(player, commandWords);
                Console.WriteLine(result);
            }
        }
    }
}