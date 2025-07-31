using NUnit.Framework;
using System.Collections.Generic;

namespace TestSwin_Adventure
{
    [TestFixture]
    public class TestMoveCommand
    {
        private Swin_Adventure.Player _player;
        private Swin_Adventure.Location _loc1;
        private Swin_Adventure.Location _loc2;
        private Swin_Adventure.Path _northPath;
        private Swin_Adventure.MoveCommand _moveCommand;

        [SetUp]
        public void Setup()
        {
            _loc1 = new Swin_Adventure.Location(new string[] { "room1" }, "Room 1", "The first room.");
            _loc2 = new Swin_Adventure.Location(new string[] { "room2" }, "Room 2", "The second room.");
            _player = new Swin_Adventure.Player("TestPlayer", "A test player");
            _player.Location = _loc1;
            var direction = new Swin_Adventure.Direction("north");
            _northPath = new Swin_Adventure.Path(new List<string> { "north", "n" }, direction, _loc2);
            _loc1.AddPath(_northPath);
            _moveCommand = new Swin_Adventure.MoveCommand();
        }

        [Test]
        public void TestPathMovesPlayerToDestination()
        {
            _moveCommand.Execute(_player, new string[] { "move", "north" });
            Assert.AreEqual(_loc2, _player.Location);
        }

        [Test]
        public void TestGetPathFromLocationByIdentifier()
        {
            var path = _loc1.GetPath("north");
            Assert.AreEqual(_northPath, path);
            path = _loc1.GetPath("n");
            Assert.AreEqual(_northPath, path);
        }

        [Test]
        public void TestPlayerRemainsInSameLocationWithInvalidPath()
        {
            _moveCommand.Execute(_player, new string[] { "move", "south" });
            Assert.AreEqual(_loc1, _player.Location);
        }

        [Test]
        public void TestMoveCommandReturnsCorrectMessages()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move", "north" });
            Assert.That(result, Does.Contain("You move north"));
            _player.Location = _loc1;
            result = _moveCommand.Execute(_player, new string[] { "move", "south" });
            Assert.That(result, Does.Contain("can't go 'south'"));
        }

        [Test]
        public void TestMoveBetweenFantasyLocations()
        {
            // Create locations
            var elfMountain = new Swin_Adventure.Location(new string[] { "elfmountain", "mountain", "elf" }, "Mountain of Elf", "A mystical mountain where elves dwell among the clouds.");
            var dwarfMine = new Swin_Adventure.Location(new string[] { "dwarfmine", "mine", "dwarf" }, "Mine of Dwarf", "A deep, echoing mine filled with the sounds of dwarven hammers.");
            var enchantedForest = new Swin_Adventure.Location(new string[] { "enchantedforest", "forest", "enchanted" }, "Enchanted Forest", "A magical forest with glowing plants and hidden secrets.");
            var dragonCave = new Swin_Adventure.Location(new string[] { "dragoncave", "cave", "dragon" }, "Dragon's Cave", "A dark, smoky cave where a dragon is rumored to sleep.");
            var wizardTower = new Swin_Adventure.Location(new string[] { "wizardtower", "tower", "wizard" }, "Wizard's Tower", "A tall, spiraling tower filled with arcane energy.");

            // Add items
            elfMountain.Inventory.Put(new Swin_Adventure.Item(new string[] { "elvenbow", "bow" }, "Elven Bow", "A finely crafted bow of the elves."));
            elfMountain.Inventory.Put(new Swin_Adventure.Item(new string[] { "moonstone" }, "Moonstone", "A glowing stone said to hold the power of the moon."));
            dwarfMine.Inventory.Put(new Swin_Adventure.Item(new string[] { "pickaxe" }, "Dwarven Pickaxe", "A sturdy pickaxe used by dwarves."));
            dwarfMine.Inventory.Put(new Swin_Adventure.Item(new string[] { "mithril" }, "Mithril Ingot", "A rare and precious metal ingot."));
            enchantedForest.Inventory.Put(new Swin_Adventure.Item(new string[] { "fairydust", "dust" }, "Fairy Dust", "Sparkling dust with magical properties."));
            enchantedForest.Inventory.Put(new Swin_Adventure.Item(new string[] { "ancientoakleaf", "oakleaf" }, "Ancient Oak Leaf", "A leaf from the oldest tree in the forest."));
            dragonCave.Inventory.Put(new Swin_Adventure.Item(new string[] { "dragonscale", "scale" }, "Dragon Scale", "A tough, shimmering scale from a dragon."));
            dragonCave.Inventory.Put(new Swin_Adventure.Item(new string[] { "goldhoard", "gold" }, "Gold Hoard", "A pile of gold coins and treasures."));
            wizardTower.Inventory.Put(new Swin_Adventure.Item(new string[] { "spellbook" }, "Spellbook", "A book filled with mysterious spells."));
            wizardTower.Inventory.Put(new Swin_Adventure.Item(new string[] { "crystalball", "crystal" }, "Crystal Ball", "A crystal ball that reveals distant places."));

            // Connect locations
            elfMountain.AddPath(new Swin_Adventure.Path(new List<string> { "south", "to forest" }, new Swin_Adventure.Direction("south"), enchantedForest));
            enchantedForest.AddPath(new Swin_Adventure.Path(new List<string> { "north", "to mountain" }, new Swin_Adventure.Direction("north"), elfMountain));
            enchantedForest.AddPath(new Swin_Adventure.Path(new List<string> { "east", "to mine" }, new Swin_Adventure.Direction("east"), dwarfMine));
            dwarfMine.AddPath(new Swin_Adventure.Path(new List<string> { "west", "to forest" }, new Swin_Adventure.Direction("west"), enchantedForest));
            enchantedForest.AddPath(new Swin_Adventure.Path(new List<string> { "south", "to cave" }, new Swin_Adventure.Direction("south"), dragonCave));
            dragonCave.AddPath(new Swin_Adventure.Path(new List<string> { "north", "to forest" }, new Swin_Adventure.Direction("north"), enchantedForest));
            dragonCave.AddPath(new Swin_Adventure.Path(new List<string> { "east", "to tower" }, new Swin_Adventure.Direction("east"), wizardTower));
            wizardTower.AddPath(new Swin_Adventure.Path(new List<string> { "west", "to cave" }, new Swin_Adventure.Direction("west"), dragonCave));

            // Place player in Enchanted Forest
            var player = new Swin_Adventure.Player("Tester", "A test player");
            player.Location = enchantedForest;
            var moveCommand = new Swin_Adventure.MoveCommand();

            // Move north to Mountain of Elf
            string result = moveCommand.Execute(player, new string[] { "move", "north" });
            Assert.That(player.Location, Is.EqualTo(elfMountain));
            Assert.That(result, Does.Contain("You move north"));
            // Check items in Mountain of Elf
            Assert.IsNotNull(elfMountain.Inventory.Fetch("elvenbow"));
            Assert.IsNotNull(elfMountain.Inventory.Fetch("moonstone"));

            // Move south back to Enchanted Forest
            result = moveCommand.Execute(player, new string[] { "move", "south" });
            Assert.That(player.Location, Is.EqualTo(enchantedForest));
            // Move east to Mine of Dwarf
            result = moveCommand.Execute(player, new string[] { "move", "east" });
            Assert.That(player.Location, Is.EqualTo(dwarfMine));
            // Check items in Mine of Dwarf
            Assert.IsNotNull(dwarfMine.Inventory.Fetch("pickaxe"));
            Assert.IsNotNull(dwarfMine.Inventory.Fetch("mithril"));

            // Move west back to Enchanted Forest, then south to Dragon's Cave, then east to Wizard's Tower
            result = moveCommand.Execute(player, new string[] { "move", "west" });
            Assert.That(player.Location, Is.EqualTo(enchantedForest));
            result = moveCommand.Execute(player, new string[] { "move", "south" });
            Assert.That(player.Location, Is.EqualTo(dragonCave));
            // Check items in Dragon's Cave
            Assert.IsNotNull(dragonCave.Inventory.Fetch("dragonscale"));
            Assert.IsNotNull(dragonCave.Inventory.Fetch("goldhoard"));
            result = moveCommand.Execute(player, new string[] { "move", "east" });
            Assert.That(player.Location, Is.EqualTo(wizardTower));
            // Check items in Wizard's Tower
            Assert.IsNotNull(wizardTower.Inventory.Fetch("spellbook"));
            Assert.IsNotNull(wizardTower.Inventory.Fetch("crystalball"));
        }
    }
} 