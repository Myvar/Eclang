namespace EcIDE.Contracts.UI.Options
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;

    public class OptionsPanelEventArgs : EventArgs
    {
        private OptionsPanel _Panel;

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public OptionsPanel Panel
        {
            get
            {
                return this._Panel;
            }
        }

        #endregion

        public OptionsPanelEventArgs(OptionsPanel panel)
        {
            this._Panel = panel;
        }
    }

    public delegate void OptionsPanelEventHandler(object sender, OptionsPanelEventArgs e);

    [Editor(typeof(OptionsPanelListEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public class OptionsPanelList : IList<OptionsPanel>, ICollection<OptionsPanel>, IEnumerable<OptionsPanel>
    {
        private List<OptionsPanel> _Panels;

        [Browsable(true)]
        [Category("Options Panel")]
        public event OptionsPanelEventHandler PanelAdded;

        #region Properties

        public OptionsPanel this[int index]
        {
            get
            {
                return this._Panels[index];
            }
            set
            {
                this._Panels[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return this._Panels.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        #endregion


        #region Construction


        public OptionsPanelList()
        {
            this._Panels = new List<OptionsPanel>();
        }

        public OptionsPanelList(IEnumerable<OptionsPanel> collection)
        {
            this._Panels = new List<OptionsPanel>(collection);
        }

        public OptionsPanelList(int capacity)
        {
            this._Panels = new List<OptionsPanel>(capacity);
        }

        #endregion


        #region Methods

        public int IndexOf(OptionsPanel item)
        {
            return this._Panels.IndexOf(item);
        }

        public int IndexOf(OptionsPanel item, int index)
        {
            return this._Panels.IndexOf(item, index);
        }

        public int IndexOf(OptionsPanel item, int index, int count)
        {
            return this._Panels.IndexOf(item, index, count);
        }

        public void Insert(int index, OptionsPanel item)
        {
            this._Panels.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this._Panels.RemoveAt(index);
        }

        public void Add(OptionsPanel item)
        {
            this._Panels.Add(item);

            if (this.PanelAdded != null)
            {
                OptionsPanelEventArgs args = new OptionsPanelEventArgs(item);

                this.PanelAdded(this, args);
            }
        }

        public void Clear()
        {
            this._Panels.Clear();
        }

        public bool Contains(OptionsPanel item)
        {
            return this._Panels.Contains(item);
        }

        public void CopyTo(OptionsPanel[] array)
        {
            this._Panels.CopyTo(array);
        }

        public void CopyTo(OptionsPanel[] array, int arrayIndex)
        {
            this._Panels.CopyTo(array, arrayIndex);
        }

        public void CopyTo(int index, OptionsPanel[] array, int arrayIndex, int count)
        {
            this._Panels.CopyTo(index, array, arrayIndex, count);
        }

        public bool Remove(OptionsPanel item)
        {
            return this._Panels.Remove(item);
        }

        IEnumerator<OptionsPanel> IEnumerable<OptionsPanel>.GetEnumerator()
        {
            return this._Panels.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._Panels.GetEnumerator();
        }

        #endregion
    }

    public class OptionsPanelListEditor : CollectionEditor
    {
        public OptionsPanelListEditor()
            : base(typeof(OptionsPanelList))
        {
        }

        protected override object SetItems(object editValue, object[] value)
        {
            return base.SetItems(editValue, value);
        }
    }
}
