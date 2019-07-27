namespace PrivateLocatedPackageManager.CUI
{
    /// <summary>
    /// 
    /// This expresses a command.
    /// 
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// 
        /// The name of the command.
        /// 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 
        /// This text contains the information of how to use this command.
        /// 
        /// </summary>
        string Usage { get; }

        /// <summary>
        /// 
        /// When an user watches the help of this command, it will be shown.
        /// 
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 
        /// Run this command.
        /// 
        /// </summary>
        /// <param name="args">Argments</param>
        void Execute(string[] args);
    }
}