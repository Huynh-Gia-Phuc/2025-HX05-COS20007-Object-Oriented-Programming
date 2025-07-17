using NUnit.Framework;
using Swin_Adventure;
using System.Collections.Generic;

namespace TestSwin_Adventure
{
    public class TestInventory
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInventoryPutItem()
        {
            Inventory inv = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
            inv.Put(sword);
            Assert.True(inv.HasItem("sword"));
        }

        [Test]
        public void TestInventoryHasItem()
        {
            Inventory inv = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
            inv.Put(sword);
            Assert.True(inv.HasItem("sword"));
            Assert.False(inv.HasItem("shovel"));
        }

        [Test]
        public void TestInventoryFetchItem()
        {
            Inventory inv = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
            inv.Put(sword);
            Item fetchedItem = inv.Fetch("sword");
            Assert.AreEqual(sword, fetchedItem);
            Assert.True(inv.HasItem("sword")); // Should still have the item after fetching
        }

        [Test]
        public void TestInventoryTakeItem()
        {
            Inventory inv = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
            inv.Put(sword);
            Item takenItem = inv.Take("sword");
            Assert.AreEqual(sword, takenItem);
            Assert.False(inv.HasItem("sword")); // Should no longer have the item after taking
        }

        [Test]
        public void TestInventoryNoItemFetch()
        {
            Inventory inv = new Inventory();
            Item fetchedItem = inv.Fetch("nonexistent");
            Assert.Null(fetchedItem);
        }

        [Test]
        public void TestInventoryTakeNoItem()
        {
            Inventory inv = new Inventory();
            Item takenItem = inv.Take("nonexistent");
            Assert.Null(takenItem);
        }

        [Test]
        public void TestInventoryItemList()
        {
            Inventory inv = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
            Item gem = new Item(new string[] { "gem" }, "shiny gem", "a shiny gem");
            inv.Put(sword);
            inv.Put(gem);
            string expectedList = "  bronze sword (sword)\n  shiny gem (gem)\n";
            Assert.AreEqual(expectedList, inv.ItemList);
        }
    }
} 