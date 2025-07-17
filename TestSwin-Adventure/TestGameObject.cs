using NUnit.Framework;
using Swin_Adventure;

namespace TestSwin_Adventure
{
    public class TestGameObject
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGameObjectDetails()
        {
            GameObject gameObj = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
            Assert.AreEqual("bronze sword", gameObj.Name);
            Assert.AreEqual("bronze sword (sword)", gameObj.ShortDescription);
            Assert.AreEqual("a bronze sword", gameObj.FullDescription);
        }
    }
} 