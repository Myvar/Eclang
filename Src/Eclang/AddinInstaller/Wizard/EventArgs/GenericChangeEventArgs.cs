namespace AddinInstaller.Wizard.EventArgs
{
    using System.ComponentModel;

    public class GenericChangeEventArgs<T> : CancelEventArgs
    {
        private readonly T oldValue;
        private T newValue;

        public GenericChangeEventArgs(T oldValue, T newValue) : base(false)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public GenericChangeEventArgs(T oldValue, T newValue, bool cancel) : base(cancel)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public T OldValue
        {
            get { return this.oldValue; }
        }

        public T NewValue
        {
            get { return this.newValue; }
            set { this.newValue = value; }
        }
    }
}