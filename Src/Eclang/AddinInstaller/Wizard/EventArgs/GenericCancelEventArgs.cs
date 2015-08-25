namespace AddinInstaller.Wizard.EventArgs
{
    using System.ComponentModel;

    public delegate void GenericCancelEventHandler<T>(object sender, GenericCancelEventArgs<T> tArgs);

    public class GenericCancelEventArgs<T> : CancelEventArgs
    {
        private T value;

        public GenericCancelEventArgs(T value) : base(false)
        {
            this.value = value;
        }

        public GenericCancelEventArgs(T value, bool cancel) : base(cancel)
        {
            this.value = value;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}