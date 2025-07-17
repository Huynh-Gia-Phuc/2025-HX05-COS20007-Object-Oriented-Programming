using NUnit.Framework;
using cl;

namespace Counter_test
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
            Assert.That(counter.Ticks, Is.EqualTo(0));
        }

        [Test]
        public void Counter_Increment_AddsOne()
        {
            var counter = new Counter("Test");
            counter.Increment();
            Assert.That(counter.Ticks, Is.EqualTo(1));
        }

        [Test]
        public void Counter_Increment_MultipleTimes()
        {
            var counter = new Counter("Test");
            for (int i = 0; i < 5; i++) counter.Increment();
            Assert.That(counter.Ticks, Is.EqualTo(5));
        }

        [Test]
        public void Counter_Reset_SetsToZero()
        {
            var counter = new Counter("Test");
            counter.Increment();
            counter.Increment();
            counter.Reset();
            Assert.That(counter.Ticks, Is.EqualTo(0));
        }
    }
}
