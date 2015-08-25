﻿// one line to give the program's name and an idea of what it does.
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
    using System.Drawing;
    using System.Drawing.Drawing2D;

    #region TabBrushes

    internal class TabBrushes
    {
        #region Methods

        public static LinearGradientBrush GetTabGradient(Rectangle rect)
        {
            Rectangle newRect = rect;

            return new LinearGradientBrush(newRect, Color.FromArgb(255, 255, 255), Color.FromArgb(240, 240, 234),
                                           LinearGradientMode.Horizontal);
        }

        public static LinearGradientBrush GetPropertyControlGradient(Rectangle rect)
        {
            Rectangle newRect = rect;

            return new LinearGradientBrush(newRect, Color.FromArgb(255, 255, 255), SystemColors.Control,
                                           LinearGradientMode.Vertical);
        }

        #endregion Methods
    }

    #endregion
}