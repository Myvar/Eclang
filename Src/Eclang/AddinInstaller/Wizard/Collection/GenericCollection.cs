namespace AddinInstaller.Wizard.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.Serialization;

    using AddinInstaller.Wizard.EventArgs;

    using WizardBase;

    public class GenericCollection<T> : CollectionBase, IDeserializationCallback, IDisposable, ISerializable
    {
        #region Delegates

        public delegate void CollectionChangedHandler(int index, T value);

        public delegate void CollectionChangingHandler(int index, GenericCancelEventArgs<T> value);

        public delegate void CollectionClearHandler();

        public delegate void CollectionClearingHandler(GenericCancelEventArgs<GenericCollection<T>> value);

        public delegate void ItemChangeHandler(int index, T oldValue, T newValue);

        public delegate void ItemChangingHandler(int index, GenericChangeEventArgs<T> e);

        public delegate void ValidateHandle(T value);

        #endregion

        #region Constructor

        public GenericCollection()
        {
        }

        public GenericCollection(object owner)
        {
            this.owner = owner;
        }

        protected GenericCollection(SerializationInfo info, StreamingContext context)
        {
            this.siInfo = info;
        }

        public GenericCollection(IEnumerable<T> items)
            : this()
        {
            foreach (T barItem in items)
            {
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                this.OnInsert(this.InnerList.Count, barItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
                this.InnerList.Add(barItem);
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                this.OnInsertComplete(this.InnerList.Count - 1, barItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
            }
        }

        public GenericCollection(GenericCollection<T> items)
            : this()
        {
            foreach (T item in items)
            {
                T newItem = (T)(item is ICloneable ? (item as ICloneable).Clone() : item);
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                this.OnInsert(this.InnerList.Count, newItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
                this.InnerList.Add(newItem);
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                this.OnInsertComplete(this.InnerList.Count - 1, newItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
            }
        }

        #endregion

        #region Property

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public T this[int index]
        {
            get { return (T)this.InnerList[index]; }
            set { this.InnerList[index] = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        #endregion

        #region Events

        public event CollectionClearHandler Cleared;

        public event CollectionClearingHandler Clearing;

        public event CollectionChangedHandler Inserted;

        public event CollectionChangingHandler Inserting;

        public event CollectionChangedHandler Removed;

        public event CollectionChangingHandler Removing;

        public event ItemChangingHandler Changing;

        public event ItemChangeHandler Changed;

        public event ValidateHandle Validating;

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an item to the end of the collection.
        /// </summary>
        /// <param name="item">The item to be added to the end of the Collection. The value can be null.</param>
        /// <returns>The index at which the value has been added.</returns>
        public int Add(T item)
        {
            this.OnInsert(this.InnerList.Count, item);
            int index = this.InnerList.Add(item);
            this.OnInsertComplete(this.InnerList.Count, item);
            return index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(T[] items)
        {
            foreach (T item in items)
            {
                this.OnInsert(this.InnerList.Count, item);
                this.InnerList.Add(item);
                this.OnInsertComplete(this.InnerList.Count, item);
            }
        }

        /// <summary>
        /// Adds an item(s) to the end of the collection.
        /// </summary>
        /// <param name="items">The item to be added to the end of the Collection. The value can be null. </param>
        public void Add(T[] items)
        {
            foreach (T item in items)
            {
                this.OnInsert(this.InnerList.Count, item);
                this.InnerList.Add(item);
                this.OnInsertComplete(this.InnerList.Count, item);
            }
        }

        /// <summary>
        /// Inserts an element into the Collection at the specified index.
        /// </summary>
        /// <param name="index">Index at which item has to be inserted.</param>
        /// <param name="item">Item to be inserted</param>
        public void Insert(int index, T item)
        {
            this.OnInsert(index, item);
            this.InnerList.Insert(index, item);
            this.OnInsertComplete(index, item);
        }

        /// <summary>
        /// Removes item from the collection.
        /// </summary>
        /// <param name="item">Item to be removed.</param>
        public void Remove(T item)
        {
            int index = this.IndexOf(item);
            this.OnRemove(index, item);
            this.InnerList.Remove(item);
            this.OnRemoveComplete(index, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int LastIndexOf(T item)
        {
            return this.InnerList.LastIndexOf(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int LastIndexOf(T item, int startIndex)
        {
            return this.InnerList.LastIndexOf(item, startIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int LastIndexOf(T item, int startIndex, int count)
        {
            return this.InnerList.LastIndexOf(item, startIndex, count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="items"></param>
        public void InsertRange(int index, GenericCollection<T> items)
        {
            this.InnerList.InsertRange(index, items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return this.InnerList.Contains(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(T value)
        {
            return this.InnerList.IndexOf(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int IndexOf(T value, int startIndex)
        {
            return this.InnerList.IndexOf(value, startIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int IndexOf(T value, int startIndex, int count)
        {
            return this.InnerList.IndexOf(value, startIndex, count);
        }

        #endregion

        #region Overrides

        ///<summary>
        ///Performs additional custom processes when clearing the contents of the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        protected override void OnClear()
        {
            GenericCancelEventArgs<GenericCollection<T>> e = new GenericCancelEventArgs<GenericCollection<T>>(this);
            if (this.Clearing != null)
            {
                this.Clearing(e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnClear();
        }

        ///<summary>
        ///Performs additional custom processes after clearing the contents of the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        protected override void OnClearComplete()
        {
            base.OnClearComplete();
            if (this.Cleared != null)
            {
                this.Cleared();
            }
        }

        ///<summary>
        ///Performs additional custom processes before inserting a new element into the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="value">The new value of the element at index.</param>
        ///<param name="index">The zero-based index at which to insert value.</param>
        protected override void OnInsert(int index, object value)
        {
            GenericCancelEventArgs<T> e = new GenericCancelEventArgs<T>((T)value);
            if (this.Inserting != null)
            {
                this.Inserting(index, e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnInsert(index, value);
        }

        ///<summary>
        ///Performs additional custom processes after inserting a new element into the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="value">The new value of the element at index.</param>
        ///<param name="index">The zero-based index at which to insert value.</param>
        protected override void OnInsertComplete(int index, object value)
        {
            base.OnInsertComplete(index, value);
            if (this.Inserted != null)
            {
                this.Inserted(index, (T)value);
            }
        }

        ///<summary>
        ///Performs additional custom processes when removing an element from the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="value">The value of the element to remove from index.</param>
        ///<param name="index">The zero-based index at which value can be found.</param>
        protected override void OnRemove(int index, object value)
        {
            GenericCancelEventArgs<T> e = new GenericCancelEventArgs<T>((T)value);
            if (this.Removing != null)
            {
                this.Removing(index, e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnRemove(index, value);
        }

        ///<summary>
        ///Performs additional custom processes after removing an element from the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="value">The value of the element to remove from index.</param>
        ///<param name="index">The zero-based index at which value can be found.</param>
        protected override void OnRemoveComplete(int index, object value)
        {
            base.OnRemoveComplete(index, value);
            if (this.Removed != null)
            {
                this.Removed(index, (T)value);
            }
        }

        ///<summary>
        ///Performs additional custom processes when validating a value.
        ///</summary>
        ///
        ///<param name="value">The object to validate.</param>
        protected override void OnValidate(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            if (this.Validating != null)
            {
                this.Validating((T)value);
            }
            base.OnValidate(value);
        }

        ///<summary>
        ///Performs additional custom processes before setting a value in the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="oldValue">The value to replace with newValue.</param>
        ///<param name="newValue">The new value of the element at index.</param>
        ///<param name="index">The zero-based index at which oldValue can be found.</param>
        protected override void OnSet(int index, object oldValue, object newValue)
        {
            GenericChangeEventArgs<T> e = new GenericChangeEventArgs<T>((T)oldValue, (T)newValue);
            if (this.Changing != null)
            {
                this.Changing(index, e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnSet(index, oldValue, newValue);
        }

        ///<summary>
        ///Performs additional custom processes after setting a value in the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="oldValue">The value to replace with newValue.</param>
        ///<param name="newValue">The new value of the element at index.</param>
        ///<param name="index">The zero-based index at which oldValue can be found.</param>
        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            base.OnSetComplete(index, oldValue, newValue);
            if (this.Changed != null)
            {
                this.Changed(index, (T)oldValue, (T)newValue);
            }
        }

        #endregion

        private object owner;

        private SerializationInfo siInfo;

        #region IDeserializationCallback Members

        ///<summary>
        ///Runs when the entire object graph has been deserialized.
        ///</summary>
        ///
        ///<param name="sender">The object that initiated the callback. The functionality for this parameter is not currently implemented. </param>
        public void OnDeserialization(object sender)
        {
            if (this.siInfo != null)
            {
                this.Clear();
                if (this.siInfo.GetInt32("Count") != 0)
                {
                    this.Clear();
                    int num = this.siInfo.GetInt32("Count");
                    for (int i = 0; i < num; i++)
                    {
                        this.Add((T)this.siInfo.GetValue("Items" + i, typeof(T)));
                    }
                }
                this.siInfo = null;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.owner = null;
            this.List.Clear();
            this.InnerList.Clear();
            this.siInfo = null;
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("Count", this.Count);
            if (this.Count != 0)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    info.AddValue("Items" + i, this[i]);
                }
            }
        }

        #endregion

        public void SetChildIndex(T item, int index)
        {
            if (this.List.Count > 0)
            {
                int num = this.IndexOf(item);
                if (index < 0)
                {
                    index = 0;
                }
                if (index >= this.List.Count)
                {
                    index = this.List.Count - 1;
                }
                if ((index >= 0) && (index < this.List.Count))
                {
                    if (num < index)
                    {
                        for (int i = num; i < index; i++)
                        {
                            this.List[i] = this.List[i + 1];
                        }
                        this.List[index] = item;
                    }
                    else if (num > index)
                    {
                        for (int j = num; j > index; j--)
                        {
                            this.List[j] = this.List[j - 1];
                        }
                        this.List[index] = item;
                    }
                }
            }
        }

        public void Sort(IComparer comparer)
        {
            if ((this.List.Count > 0) && (comparer != null))
            {
                object[] array = new object[this.List.Count];
                for (int i = 0; i < this.List.Count; i++)
                {
                    array[i] = this.List[i];
                }
                Array.Sort(array, comparer);
                this.List.Clear();
                for (int j = 0; j < array.Length; j++)
                {
                    this.List.Add(array[j]);
                }
            }
        }
    }
}
