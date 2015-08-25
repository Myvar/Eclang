namespace EcIDE.Addins
{
    using System;
    using System.Collections.ObjectModel;

    public class CommandCollection<T> : Collection<T>
    {
        #region Constructors and Destructors

        public CommandCollection(T[] source)
        {
            foreach (T s in source)
            {
                this.Add(s);
            }
        }

        public CommandCollection()
        {
        }

        #endregion

        #region Public Methods and Operators

        public void ForEach(Action<T> act)
        {
            foreach (T item in this.Items)
            {
                act(item);
            }
        }

        public CommandCollection<T> Where(Predicate<T> pred)
        {
            var cc = new CommandCollection<T>();
            foreach (T item in this.Items)
            {
                if (pred(item))
                {
                    cc.Add(item);
                }
            }
            return cc;
        }

        #endregion
    }
}