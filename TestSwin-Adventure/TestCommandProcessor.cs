using NUnit.Framework;
using Swin_Adventure;

namespace TestSwin_Adventure
{
    [TestFixture]
    public class TestCommandProcessor
    {
        private CommandProcessor _processor;
        private Player _player;
        private LookCommand _look;
        private MoveCommand _move;

        [SetUp]
        public void Setup()
        {
            _processor = new CommandProcessor();
            _look = new LookCommand();
            _move = new MoveCommand();
            _processor.AddCommand(_look);
            _processor.AddCommand(_move);
            _player = new Player("TestPlayer", "A test player");
        }

        [Test]
        public void Test_UnknownCommand_ReturnsUnknown()
        {
            string result = _processor.ExecuteCommand(_player, "fly north");
            Assert.That(result, Is.EqualTo("Unknown command: fly"));
        }

        [Test]
        public void Test_EmptyInput_ReturnsPrompt()
        {
            string result = _processor.ExecuteCommand(_player, "");
            Assert.That(result, Is.EqualTo("Please enter a command."));
        }

        [Test]
        public void Test_LookCommand_ExecutesSuccessfully()
        {
            // Create a location with exits for the player
            Location testLocation = new Location(new string[] { "closet" }, "a small Closet", "A small dark closet, with an odd smell");
            testLocation.AddPath(new Swin_Adventure.Path(new List<string> { "north" }, new Direction("north"), testLocation));
            testLocation.AddPath(new Swin_Adventure.Path(new List<string> { "east" }, new Direction("east"), testLocation));
            _player.Location = testLocation;
            
            string result = _processor.ExecuteCommand(_player, "look around");
            Assert.That(result, Does.Contain("You are in a small Closet"));
            Assert.That(result, Does.Contain("A small dark closet, with an odd smell"));
            Assert.That(result, Does.Contain("There are exits to the north, east"));
        }

        [Test]
        public void Test_MoveCommand_ExecutesSuccessfully()
        {
            // Assign a dummy location to the player
            Location dummyLocation = new Location(new string[] { "dummy" }, "Dummy Location", "A test location.");
            _player.Location = dummyLocation;
            string result = _processor.ExecuteCommand(_player, "move north");
            Assert.That(result, Does.Contain("can't go 'north'"));
        }
    }
} 