using NUnit.Framework;
using Swin_Adventure;

namespace TestSwin_Adventure
{
    public class TestPlayer
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Player player = new Player("Fred", "the mighty programmer");
            Assert.True(player.AreYou("me"));
            Assert.True(player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocateItems()
        {
            Player player = new Player("PlayerName", "PlayerDescription");
            Item sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
            player.Inventory.Put(sword);
            GameObject located = player.Locate("sword");
            Assert.AreEqual(sword, located);
        }

        [Test]
        public void TestPlayerLocateSelf()
        {
            Player player = new Player("PlayerName", "PlayerDescription");
            GameObject located = player.Locate("me");
            Assert.AreEqual(player, located);
        }

        [Test]
        public void TestPlayerLocateNothing()
        {
            Player player = new Player("PlayerName", "PlayerDescription");
            GameObject located = player.Locate("nonexistent");
            Assert.Null(located);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Player player = new Player("PlayerName", "a mighty adventurer");
            Item sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
            Item gem = new Item(new string[] { "gem" }, "shiny gem", "a shiny gem");
            player.Inventory.Put(sword);
            player.Inventory.Put(gem);

            string expectedDesc = "You are PlayerName, a mighty adventurer\nYour inventory contains:\n  bronze sword (sword)\n  shiny gem (gem)\n";
            Assert.AreEqual(expectedDesc, player.FullDescription);
        }
    }
} 