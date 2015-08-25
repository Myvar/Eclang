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
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    using TabPage = EcIDE.Internals.UI.Properties.TabPage;

    #region TabItem

    /// <summary>
    /// TabItem class
    /// </summary>
    public sealed class TabItem : Control
    {
        #region Declares

        private int leftPadding = 10;
        private DrawSeparatorMode m_DrawMode = DrawSeparatorMode.DrawSeparatorBottom;

        private bool m_MouseOver;

        private bool m_Selected;
        private string m_Text;

        #endregion

        #region DrawSeparatorMode

        internal enum DrawSeparatorMode
        {
            DrawSeparatorTop = 0,
            DrawSeparatorBottom = 1,
            DrawSeparatorTopBottom = 2
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Inzialize a new Istance of the control
        /// </summary>
        /// <param name="text"></param>
        /// <param name="TabControl"></param>
        public TabItem(string text, Properties.TabPage TabControl) : this(text)
        {
            this.TabPageControl = TabControl;
        }

        /// <summary>
        /// Inzialize a new Istance of the control
        /// </summary>
        /// <param name="text"></param>
        public TabItem(string text) : this()
        {
            this.Text = text;
        }

        /// <summary>
        /// Inzialize a new Istance of the control
        /// </summary>
        public TabItem()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.DoubleBuffer, true);

            this.Font = new Font("Microsoft Sans Serif", 8.5F);

            this.Size = new Size(108, 32);
        }

        #endregion /Constructors

        #region OnPaint

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            this.DrawTab(e.Graphics);
        }

        #endregion

        #region Paint Methods

        private void DrawText(Graphics g)
        {
            if (this.m_Text != null)
            {
                SizeF textSize = g.MeasureString(this.m_Text, this.Font);

                var pos = new Point(this.leftPadding, this.Height/2 - ((int) textSize.Height/2));

                string temp = this.m_Text;

                if (textSize.Width > this.Width - this.leftPadding - 5)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        SizeF tempSize = g.MeasureString(temp, this.Font);

                        if (tempSize.Width >= this.ClientRectangle.Width - this.leftPadding - 5)
                            temp.Remove(temp.Length - 2, 1);
                        else
                            break;
                    }
                }

                g.DrawString(temp, this.Font, new SolidBrush(this.ForeColor), pos);
            }
        }

        private void DrawTab(Graphics g)
        {
            this.DrawTabGradient(g);
            this.DrawSeparator(g);

            this.DrawHighLight(g);
            this.DrawSelected(g);
            this.DrawText(g);
        }

        private void DrawTabGradient(Graphics g)
        {
            g.FillRectangle(TabBrushes.GetTabGradient(this.ClientRectangle), this.ClientRectangle);
        }

        private void DrawSeparator(Graphics g)
        {
            if (this.m_MouseOver) return;

            var darkPen = new Pen(Color.FromArgb(232, 231, 222));

            int leftPadding = 8;
            int rightPadding = 8;

            if (this.m_DrawMode == DrawSeparatorMode.DrawSeparatorBottom)
            {
                g.DrawLine(Pens.White, leftPadding, this.ClientRectangle.Height - 3, this.ClientRectangle.Width - rightPadding,
                           this.ClientRectangle.Height - 3);
                g.DrawLine(darkPen, leftPadding, this.ClientRectangle.Height - 2, this.ClientRectangle.Width - rightPadding,
                           this.ClientRectangle.Height - 2);
            }
            else if (this.m_DrawMode == DrawSeparatorMode.DrawSeparatorTop)
            {
                g.DrawLine(Pens.White, leftPadding, 0, this.ClientRectangle.Width - rightPadding, 0);
                g.DrawLine(darkPen, leftPadding, 1, this.ClientRectangle.Width - rightPadding, 1);
            }
            else if (this.m_DrawMode == DrawSeparatorMode.DrawSeparatorTopBottom)
            {
                //TOP
                g.DrawLine(Pens.White, leftPadding, 0, this.ClientRectangle.Width - rightPadding, 0);
                g.DrawLine(darkPen, leftPadding, 1, this.ClientRectangle.Width - rightPadding, 1);
                //BOTTOM
                g.DrawLine(Pens.WhiteSmoke, 0, this.ClientRectangle.Height - 3, this.ClientRectangle.Width - rightPadding,
                           this.ClientRectangle.Height - 3);
                g.DrawLine(darkPen, leftPadding, this.ClientRectangle.Height - 1, this.ClientRectangle.Width - rightPadding,
                           this.ClientRectangle.Height - 1);
            }
        }

        private void DrawHighLight(Graphics g)
        {
            Color border = Color.FromArgb(127, 157, 185);

            if (this.m_MouseOver)
            {
                var gp = new GraphicsPath();

                gp.AddLine(2, 0, 1, 0);
                gp.AddLine(3, 0, 3, this.ClientRectangle.Height - 1);
                gp.AddLine(3, this.ClientRectangle.Height, 2, this.ClientRectangle.Height);
                gp.AddLine(2, this.ClientRectangle.Height, 0, this.ClientRectangle.Height - 2);
                gp.AddLine(0, 2, 2, 0);
                gp.CloseAllFigures();

                g.DrawLine(new Pen(border), 3, this.ClientRectangle.Height - 1, this.ClientRectangle.Width - 2,
                           this.ClientRectangle.Height - 1);
                g.DrawLine(new Pen(border), 3, 0, this.ClientRectangle.Width - 2, 0);
                //Draw the Vertical right border
                g.DrawLine(new Pen(border), this.ClientRectangle.Width - 1, 0,
                           this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);

                g.FillPath(Brushes.Orange, gp);

                //Draw the Vertical right border
                g.DrawLine(new Pen(border), this.ClientRectangle.Width - 1, 0,
                           this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
            }
            else
            {
                g.DrawLine(new Pen(border), 1, 0, 1, this.ClientRectangle.Height);

                if (!this.m_Selected)
                {
                    //Draw the Vertical right border
                    g.DrawLine(new Pen(border), this.ClientRectangle.Width - 1, 0,
                               this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
                }
            }
        }

        private void DrawSelected(Graphics g)
        {
            if (this.m_Selected)
            {
                Color border = Color.FromArgb(127, 157, 185);

                var gp = new GraphicsPath();

                gp.AddLine(2, 0, 1, 0);
                gp.AddLine(3, 0, 3, this.ClientRectangle.Height - 1);
                gp.AddLine(3, this.ClientRectangle.Height, 2, this.ClientRectangle.Height);
                gp.AddLine(2, this.ClientRectangle.Height, 0, this.ClientRectangle.Height - 2);
                gp.AddLine(0, 2, 2, 0);
                gp.CloseAllFigures();

                g.DrawLine(new Pen(border), 3, this.ClientRectangle.Height - 1, this.ClientRectangle.Width - 2,
                           this.ClientRectangle.Height - 1);
                g.DrawLine(new Pen(border), 3, 0, this.ClientRectangle.Width - 2, 0);


                g.FillPath(Brushes.Orange, gp);


                //Draw the Vertical right border
                g.DrawLine(new Pen(Color.FromArgb(130, border)), this.ClientRectangle.Width - 1, 0,
                           this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
            }
        }

        #endregion Paint Methods

        #region OnClick

        /// <summary>
        /// This event is Raised when the tabitem is clicked
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnClick(EventArgs e)
        {
            this.m_Selected = true;
            this.Invalidate();
            base.OnClick(e);
        }

        #endregion

        #region UnSelect

        internal void UnSelect()
        {
            this.m_Selected = false;
            this.Invalidate();
        }

        #endregion

        #region Mouse Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.m_MouseOver = true;
            this.Invalidate();
            base.OnMouseHover(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            this.m_MouseOver = false;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        #endregion Mouse Events

        #region Properties

        /// <summary>
        /// Get/Set the text for this TabItem
        /// </summary>
        /// <value></value>
        public new string Text
        {
            get { return this.m_Text; }
            set
            {
                this.m_Text = value;
                this.Invalidate();
            }
        }

        internal DrawSeparatorMode SeparatorMode
        {
            get { return this.m_DrawMode; }
            set
            {
                this.m_DrawMode = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Get/Set the TabPage associated with this TabItem , the TabPage is a control that contain
        /// other control to show as property editor
        /// </summary>
        /// <value></value>
        public Properties.TabPage TabPageControl { get; set; }

        #endregion Properties
    }

    #endregion
}