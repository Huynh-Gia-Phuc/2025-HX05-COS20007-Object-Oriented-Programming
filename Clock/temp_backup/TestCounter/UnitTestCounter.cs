using CounterTask;
namespace TestCounter
{


    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Counter_InitializesAtZero()
        {
            var counter = new Counter("Test");
            Assert.AreEqual(0, counter.Ticks);
        }

        [Test]
        public void Counter_Increment_AddsOne()
        {
            var counter = new Counter("Test");
            counter.Increment();
            Assert.AreEqual(1, counter.Ticks);
        }

        [Test]
        public void Counter_Increment_MultipleTimes()
        {
            var counter = new Counter("Test");
            for (int i = 0; i < 5; i++) counter.Increment();
            Assert.AreEqual(5, counter.Ticks);
        }

        [Test]
        public void Counter_Reset_SetsToZero()
        {
            var counter = new Counter("Test");
            counter.Increment();
            counter.Increment();
            counter.Reset();
            Assert.AreEqual(0, counter.Ticks);
        }
    }
}