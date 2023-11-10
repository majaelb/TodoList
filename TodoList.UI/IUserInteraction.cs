using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Cli
{
    internal interface IUserInteraction
    {
        void DisplayMessage(string s);
        void ClearConsole();
        ConsoleKey GetKeyInput();
        string GetStringInput();
        string GetStringInput(string prompt);
        int GetIntInput(string prompt);
    }
}
