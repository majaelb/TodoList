using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Cli
{
    internal class UserInteraction : IUserInteraction
    {
        private readonly IConsoleWrapper _consoleWrapper;

        public UserInteraction(IConsoleWrapper consoleWrapper)
        {
            _consoleWrapper = consoleWrapper;
        }

        public string GetStringInput(string prompt)
        {
            string input = " ";

            _consoleWrapper.WriteLine(prompt);

            while (string.IsNullOrWhiteSpace(input))
            {
                input = _consoleWrapper.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    _consoleWrapper.WriteLine("Incorrect input, please try again");
                    _consoleWrapper.WriteLine(prompt);
                }
            }
            return input;
        }
        public int GetIntInput(string prompt)
        {
            int value;

            _consoleWrapper.WriteLine(prompt);

            while (!int.TryParse(_consoleWrapper.ReadLine(), out value))
            {
                _consoleWrapper.WriteLine("Incorrect input, please enter a valid integer.");
                _consoleWrapper.WriteLine(prompt);
            }

            return value;
        }
        public void DisplayMessage(string s)
        {
            _consoleWrapper.WriteLine(s);
        }
        public string GetStringInput() => _consoleWrapper.ReadLine();
        public void ClearConsole() => _consoleWrapper.Clear();
        public ConsoleKey GetKeyInput() => _consoleWrapper.ConsoleKey();
    }
}
