using NUnit.Framework;
using Swin_Adventure;

namespace TestSwin_Adventure
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        //TestIdentifiableObject
        [Test]
        public void TestAreYou()
        { 
            IdentifiableObject obj = new IdentifiableObject(new string[] { "01358", "Phuc", "Trung" });
            Assert.True(obj.AreYou("01358"));
            Assert.True(obj.AreYou("phuc"));
            Assert.True(obj.AreYou("trung"));
        }

        [Test]
        public void TestNotAreYou()
        {
            IdentifiableObject obj = new IdentifiableObject(new string[] { "01358", "Phuc", "Trung" });
            Assert.False(obj.AreYou("O1358"));
            Assert.False(obj.AreYou("nonexistent"));
            Assert.False(obj.AreYou("another_non_match"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            IdentifiableObject obj = new IdentifiableObject(new string[] { "Phuc", "Trung" });
            Assert.True(obj.AreYou("PHUC"));
            Assert.True(obj.AreYou("TrUnG"));
        }

        [Test]
        public void TestFirstID()
        {
            IdentifiableObject obj = new IdentifiableObject(new string[] { "first", "second", "third" });
            Assert.AreEqual("first", obj.FirstId);
        }

        [Test]
        public void TestFirstIDWithNoIDs()
        {
            IdentifiableObject obj = new IdentifiableObject(new string[] { });
            Assert.AreEqual("", obj.FirstId);
        }

        [Test]
        public void TestAddID()
        {
            IdentifiableObject obj = new IdentifiableObject(new string[] { "seekers", "athol", "keith", "bruce" });
            obj.AddIdentifier("Mary");
            Assert.True(obj.AreYou("mary"));
            Assert.True(obj.AreYou("seekers"));
            Assert.True(obj.AreYou("athol"));
            Assert.True(obj.AreYou("keith"));
            Assert.True(obj.AreYou("bruce"));
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            IdentifiableObject obj = new IdentifiableObject(new string[] { "007", "james" });
            // Assuming the student ID last 4 digits is 1358 and tutorial ID is 2106 based on IdentifiableObject.cs
            obj.PrivilegeEscalation("1358");
            Assert.AreEqual("2106", obj.FirstId);
            Assert.True(obj.AreYou("james"));
            Assert.False(obj.AreYou("007")); // The original first ID should no longer identify the object
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}