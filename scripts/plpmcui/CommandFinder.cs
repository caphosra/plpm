using System.Collections.Generic;
using System.Linq;

namespace PrivateLocatedPackageManager.CUI
{
    partial class CommandFinder : ICommandFinder
    {
        private List<ICommand> commands = 
            new List<ICommand>();

        public ICommand Search(string name)
        {
            return commands.Where(command => command.Name == name).FirstOrDefault();
        }

        public List<ICommand> GetAllCommands()
        {
            return commands;
        }
    }
}