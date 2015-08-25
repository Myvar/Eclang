namespace AddinInstaller.Wizard.EventArgs
{
    using System;

    public delegate void GenericEventHandler<T>(object sender, GenericEventArgs<T> tArgs);

    public class GenericEventArgs<T> : EventArgs
    {
        private T value;

        public GenericEventArgs()
        {
            this.value = default(T);
        }

        public GenericEventArgs(T value)
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