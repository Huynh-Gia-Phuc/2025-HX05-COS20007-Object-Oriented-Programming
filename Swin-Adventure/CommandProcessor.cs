using System;
using System.Collections.Generic;
using System.Linq;

namespace Swin_Adventure
{
    public class CommandProcessor
    {
        private List<Command> _commands = new List<Command>();

        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public string ExecuteCommand(Player player, string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please enter a command.";

            string[] commandWords = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (commandWords.Length == 0)
                return "Please enter a command.";

            string verb = commandWords[0].ToLower();
            Command foundCommand = _commands.FirstOrDefault(cmd => cmd.AreYou(verb));
            if (foundCommand != null)
            {
                return foundCommand.Execute(player, commandWords);
            }
            else
            {
                return $"Unknown command: {verb}";
            }
        }
    }
} 