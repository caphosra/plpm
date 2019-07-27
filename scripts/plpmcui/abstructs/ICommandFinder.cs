using System.Collections.Generic;

namespace PrivateLocatedPackageManager.CUI
{
    /// <summary>
    /// 
    /// This supports you to find a package you need.
    /// 
    /// </summary>
    interface ICommandFinder
    {
        /// <summary>
        /// 
        /// Initialize it.
        /// 
        /// </summary>
        void Initialize();

        /// <summary>
        /// 
        /// Search a package by name.
        /// When a package can't be found, it will return "null". 
        /// 
        /// </summary>
        /// <param name="name">a name of a package which this will be looking for.</param>
        ICommand Search(string name);

        /// <summary>
        /// 
        /// Get all commands which are contained in this finder.
        /// 
        /// </summary>
        List<ICommand> GetAllCommands();
    }
}