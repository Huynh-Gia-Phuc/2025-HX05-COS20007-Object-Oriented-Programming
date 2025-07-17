using NUnit.Framework;
using Swin_Adventure;

namespace TestSwin_Adventure
{
    [TestFixture]
    public class TestLocation
    {
        private Location _location;
        private Item _item;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _location = new Location(new string[] { "forest", "clearing", "location" }, "Forest Clearing", "A peaceful clearing surrounded by tall trees.");
            _item = new Item(new string[] { "stone", "rock" }, "smooth stone", "A small, smooth stone lies here.");
            _location.Inventory.Put(_item);
            _player = new Player("TestPlayer", "A test player");
            _player.Location = _location;
        }

        [Test]
        public void TestLocationIdentifiesItself()
        {
            Assert.IsTrue(_location.AreYou("forest"));
            Assert.IsTrue(_location.AreYou("clearing"));
            Assert.IsTrue(_location.AreYou("location"));
        }

        [Test]
        public void TestLocationLocatesItem()
        {
            var found = _location.Locate("stone");
            Assert.AreEqual(_item, found);
        }

        [Test]
        public void TestPlayerLocatesItemInLocation()
        {
            var found = _player.Locate("stone");
            Assert.AreEqual(_item, found);
        }

        [Test]
        public void TestLookAroundReturnsLocationDescription()
        {
            var look = new LookCommand();
            string result = look.Execute(_player, new string[] { "look", "around" });
            Assert.That(result, Does.Contain("Forest Clearing"));
            Assert.That(result, Does.Contain("smooth stone"));
        }
    }
} 