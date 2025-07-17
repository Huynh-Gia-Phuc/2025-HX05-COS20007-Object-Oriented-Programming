using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Swin_Adventure;

namespace TestSwin_Adventure
{
    [TestFixture]
    public class TestLookCommand
    {
        private Player _player;
        private Item _gem;
        private Bag _bag;
        private LookCommand _look;

        [SetUp]
        public void Setup()
        {
            _player = new Player("player", "the player");
            _gem = new Item(new string[] { "gem" }, "a gem", "a shiny gem");
            _bag = new Bag(new string[] { "bag" }, "a bag", "a small bag");
            _look = new LookCommand();
        }

        [Test]
        public void TestLookAtMe_ReturnsPlayerDescription_WhenLookingAtInventory()
        {
            string result = _look.Execute(_player, new string[] { "look", "at", "inventory" });
            Assert.That(result, Is.EqualTo(_player.FullDescription));
        }

        [Test]
        public void TestLookAtGem_ReturnsGemDescription_WhenGemInPlayerInventory()
        {
            _player.Inventory.Put(_gem);
            string result = _look.Execute(_player, new string[] { "look", "at", "gem" });
            Assert.That(result, Is.EqualTo(_gem.FullDescription));
        }

        [Test]
        public void TestLookAtUnk_ReturnsNotFound_WhenGemNotInInventory()
        {
            string result = _look.Execute(_player, new string[] { "look", "at", "gem" });
            Assert.That(result.ToLower(), Does.Contain("can't find the gem"));
        }

        [Test]
        public void TestLookAtGemInMe_ReturnsGemDescription_WhenLookingAtGemInInventory()
        {
            _player.Inventory.Put(_gem);
            string result = _look.Execute(_player, new string[] { "look", "at", "gem", "in", "inventory" });
            Assert.That(result, Is.EqualTo(_gem.FullDescription));
        }

        [Test]
        public void TestLookAtGemInBag_ReturnsGemDescription_WhenGemInBagInInventory()
        {
            _bag.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);
            string result = _look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(result, Is.EqualTo(_gem.FullDescription));
        }

        [Test]
        public void TestLookAtGemInNoBag_ReturnsNotFound_WhenBagNotInInventory()
        {
            string result = _look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(result.ToLower(), Does.Contain("can't find the bag"));
        }

        [Test]
        public void TestLookAtNoGemInBag_ReturnsNotFound_WhenGemNotInBag()
        {
            _player.Inventory.Put(_bag);
            string result = _look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(result.ToLower(), Does.Contain("can't find the gem"));
        }

        [Test]
        public void TestInvalidLook_ReturnsError_ForInvalidInputs()
        {
            Assert.That(_look.Execute(_player, new string[] { "look", "around" }), Does.Contain("don't know how to look"));
            Assert.That(_look.Execute(_player, new string[] { "hello", "105505856" }), Does.Contain("I don't know how to look like that"));
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "phuc" }), Does.Contain("can't find the phuc"));
        }
    }
}
