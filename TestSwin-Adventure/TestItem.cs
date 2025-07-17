using NUnit.Framework;
using Swin_Adventure;

namespace TestSwin_Adventure
{
    public class TestItem
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Item item = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty shovel");
            Assert.True(item.AreYou("shovel"));
            Assert.True(item.AreYou("spade"));
            Assert.False(item.AreYou("sword"));
        }

        [Test]
        public void TestShortDescription()
        {
            Item item = new Item(new string[] { "shovel" }, "a shovel", "This is a mighty shovel");
            Assert.AreEqual("a shovel (shovel)", item.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            Item item = new Item(new string[] { "shovel" }, "a shovel", "This is a mighty shovel");
            Assert.AreEqual("This is a mighty shovel", item.FullDescription);
        }

        [Test]
        public void TestItemPrivilegeEscalation()
        {
            Item item = new Item(new string[] { "oldid", "anotherid" }, "an item", "a description");
            // Assuming StudentId last 4 digits is 1358 and TutorialId is 2106 from IdentifiableObject.cs
            item.PrivilegeEscalation("1358"); 
            Assert.AreEqual("2106", item.FirstId);
            Assert.True(item.AreYou("anotherid"));
            Assert.False(item.AreYou("oldid")); // The original first ID should no longer identify the object
        }
    }
} 