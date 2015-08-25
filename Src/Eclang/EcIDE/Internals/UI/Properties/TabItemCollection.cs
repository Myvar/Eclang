// one line to give the program's name and an idea of what it does.
// Copyright (C) 2004  Sebastian Faltoni creator of dotnetfireball.org
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

#region Using directives



#endregion

namespace EcIDE.Internals.UI.Properties
{
    using System;
    using System.Collections;

    #region TabItemCollection

    /// <summary>
    /// The collection of TabItem
    /// </summary>
    public sealed class TabItemCollection
    {
        #region Declares

        private readonly ArrayList m_Items;
        private readonly ProjectProperties m_Parent;

        #endregion

        #region TabItemCollection

        /// <summary>
        /// TabItemCollection Constructor
        /// </summary>
        /// <param name="parent"></param>
        public TabItemCollection(ProjectProperties parent)
        {
            this.m_Items = new ArrayList();
            this.m_Parent = parent;
        }

        #endregion

        /// <summary>
        /// Get/Set the TabItem with index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The request TabItem</returns>
        public TabItem this[int index]
        {
            get { return (TabItem) this.m_Items[index]; }

            set { this.m_Items[index] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Count
        {
            get { return this.m_Items.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Get the index on the collection the specified TabItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(TabItem item)
        {
            return this.m_Items.IndexOf(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, TabItem item)
        {
            this.m_Items.Insert(index, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            this.m_Items.RemoveAt(index);
        }

        /// <summary>
        /// Add a TabItem object to the collection
        /// </summary>
        /// <param name="item"></param>
        public void Add(TabItem item)
        {
            item.Click += this.item_Click;
            this.m_Items.Add(item);
            this.m_Parent.TabStrip.ReAlignItems();
        }

        /// <summary>
        /// Remove all Item from the collection
        /// </summary>
        public void Clear()
        {
            this.m_Items.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(TabItem item)
        {
            return this.m_Items.Contains(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(TabItem[] array, int arrayIndex)
        {
            this.m_Items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Remove(TabItem item)
        {
            this.m_Items.Remove(item);
            ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return this.m_Items.GetEnumerator();
        }

        #region item_Click

        private void item_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.m_Items.Count; i++)
            {
                if (!(this.m_Items[i].Equals(sender)))
                {
                    ((TabItem) this.m_Items[i]).UnSelect();
                }
            }

            if (((TabItem) sender).TabPageControl != null)
                this.m_Parent.AddCurrentTabPage(((TabItem) sender).TabPageControl);
        }

        #endregion
    }

    #endregion
}