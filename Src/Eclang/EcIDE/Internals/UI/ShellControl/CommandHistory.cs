namespace EcIDE.Internals.UI.ShellControl
{
    using System.Collections;

    internal class CommandHistory
    {
        #region Fields

        private readonly ArrayList commandHistory = new ArrayList();

        private int currentPosn;

        private string lastCommand;

        #endregion

        #region Properties

        internal string LastCommand
        {
            get
            {
                return this.lastCommand;
            }
        }

        #endregion

        #region Methods

        internal void Add(string command)
        {
            if (command != this.lastCommand)
            {
                this.commandHistory.Add(command);
                this.lastCommand = command;
                this.currentPosn = this.commandHistory.Count;
            }
        }

        internal bool DoesNextCommandExist()
        {
            return this.currentPosn < this.commandHistory.Count - 1;
        }

        internal bool DoesPreviousCommandExist()
        {
            return this.currentPosn > 0;
        }

        internal string[] GetCommandHistory()
        {
            return (string[])this.commandHistory.ToArray(typeof(string));
        }

        internal string GetNextCommand()
        {
            this.lastCommand = (string)this.commandHistory[++this.currentPosn];
            return this.LastCommand;
        }

        internal string GetPreviousCommand()
        {
            this.lastCommand = (string)this.commandHistory[--this.currentPosn];
            return this.lastCommand;
        }

        #endregion
    }
}