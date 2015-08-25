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
    using System.Windows.Forms;

    #region PropertyControl

    /// <summary>
    /// 
    /// </summary>
    public sealed class ProjectProperties : ScrollableControl
    {
        #region Declares

        private readonly TabStrip m_Strip;
        private readonly TabPageContainer m_TabPageContainer;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public ProjectProperties()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.DoubleBuffer
                     | ControlStyles.Selectable | ControlStyles.UserMouse, true);

            this.m_Strip = new TabStrip(this);

            this.Controls.Add(this.m_Strip);

            this.m_TabPageContainer = new TabPageContainer();

            this.Controls.Add(this.m_TabPageContainer);


            this.AutoScroll = true;
        }

        #endregion Constructo

        #region OnPaint

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(TabBrushes.GetPropertyControlGradient(Screen.PrimaryScreen.Bounds), this.ClientRectangle);
        }

        #endregion

        #region OnResize

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.m_Strip.Left = 20;
            this.m_Strip.Top = 10;

            this.m_Strip.Height = this.ClientRectangle.Height - 20;

            if (this.m_Strip.Height <= 300)
                this.m_Strip.Height = 300;


            this.m_TabPageContainer.Left = this.m_Strip.Left + this.m_Strip.Width;
            this.m_TabPageContainer.Height = this.m_Strip.Height;
            this.m_TabPageContainer.Top = this.m_Strip.Top;
            this.m_TabPageContainer.Width = this.ClientRectangle.Width - 5 - this.m_Strip.Left - this.m_Strip.Width;

            this.Invalidate();
        }

        #endregion

        #region AddCurrentTabPage

        internal void AddCurrentTabPage(Control control)
        {
            this.m_TabPageContainer.AddCurrentControl(control);
            base.OnResize(new EventArgs());
        }

        #endregion

        #region TabStrip

        internal TabStrip TabStrip
        {
            get { return this.m_Strip; }
        }

        #endregion

        #region TabItems

        /// <summary>
        /// Return The collection of TabItem for this PropertyControl
        /// </summary>
        /// <value>Return a TabItemCollection</value>
        public TabItemCollection TabItems
        {
            get { return this.m_Strip.Items; }
        }

        #endregion
    }

    #endregion
}