using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public interface IUserInteraction
    {
        public string GetUserChoice();
        public string GetUserInput(string instruction);
        public void DisplayToUser(string s);
    }
}
