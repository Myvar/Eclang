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
    using System.Drawing;
    using System.Windows.Forms;

    #region TabPageContainer

    internal sealed class TabPageContainer : Control
    {
        #region Declares

        private readonly TabPageContainerPanel m_TabPageContainerPanel;

        #endregion Declares

        #region Constructor

        public TabPageContainer()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.DoubleBuffer
                     | ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.Transparent;

            this.m_TabPageContainerPanel = new TabPageContainerPanel();

            this.m_TabPageContainerPanel.AutoScroll = true;

            this.m_TabPageContainerPanel.AutoScrollMinSize = new Size(10, 10);

            this.Controls.Add(this.m_TabPageContainerPanel);
        }

        #endregion Constructor

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color border = Color.FromArgb(127, 157, 185);

            Rectangle rect = this.ClientRectangle;

            rect.X -= 1;
            //rect.Width;
            rect.Height -= 2;
            rect.Y++;

            e.Graphics.DrawRectangle(new Pen(border), rect);

            rect.Width -= 5;

            rect.Y += 5;

            rect.Height -= 9;

            e.Graphics.DrawRectangle(new Pen(border), rect);
        }

        #endregion /OnPaint

        #region AddCurrentControl

        public void AddCurrentControl(Control panel)
        {
            this.m_TabPageContainerPanel.Controls.Clear();
            this.m_TabPageContainerPanel.Controls.Add(panel);
            base.OnResize(new EventArgs());
            panel.Dock = DockStyle.Fill;
        }

        #endregion

        #region OnResize

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.m_TabPageContainerPanel.Left = 3;
            this.m_TabPageContainerPanel.Top = 8;
            this.m_TabPageContainerPanel.Width = this.ClientRectangle.Width - 11;
            this.m_TabPageContainerPanel.Height = this.ClientRectangle.Height - 16;


            this.Invalidate();
        }

        #endregion
    }

    #endregion

    #region TabPageContainerPanel

    internal class TabPageContainerPanel : ScrollableControl
    {
        #region Constructor

        public TabPageContainerPanel()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.DoubleBuffer
                     | ControlStyles.SupportsTransparentBackColor
                     | ControlStyles.ResizeRedraw
                     | ControlStyles.StandardClick
                     | ControlStyles.ContainerControl, true);

            this.BackColor = Color.Transparent;
        }

        #endregion Constructor
    }

    #endregion
}