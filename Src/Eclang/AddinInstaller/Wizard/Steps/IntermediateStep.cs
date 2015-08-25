namespace AddinInstaller.Wizard.Steps
{
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    using AddinInstaller.Properties;
    using AddinInstaller.Wizard.Designers;
    using AddinInstaller.Wizard.Structures;

    using WizardBase;

    [ToolboxItem(false), Designer(typeof (WizardStepDesigner)), DefaultEvent("Click")]
    public class IntermediateStep : WizardStep
    {
        #region Private Fields

        private ColorPair headerPair = new ColorPair();
        private Image bindingImage = Resources.Top;
        private string subtitle = "Description for the new step.";
        TextAppearence subtitleAppearence = new TextAppearence();
        private string title = "New WizardControl step.";
        private TextAppearence titleAppearence = new TextAppearence();

        #endregion

        #region Constructor

        public IntermediateStep()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
#pragma warning disable DoNotCallOverridableMethodsInConstructor
            this.Reset();
#pragma warning restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Virtual Methods

        protected virtual void GetTextBounds(out RectangleF titleRect, out RectangleF subtitleRect, Graphics graphics)
        {
            StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);
            format.Trimming = StringTrimming.EllipsisCharacter;
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.None;
            SizeF sz = graphics.MeasureString(this.Title, this.titleAppearence.Font, this.Width, format);
            titleRect = new RectangleF(this.subtitleAppearence.Font.SizeInPoints, this.subtitleAppearence.Font.SizeInPoints, sz.Width, sz.Height);
            SizeF sz1 = graphics.MeasureString(this.Subtitle, this.subtitleAppearence.Font, this.Width, format);
            subtitleRect = new RectangleF(2 * this.subtitleAppearence.Font.SizeInPoints, titleRect.Height + this.subtitleAppearence.Font.SizeInPoints, sz1.Width, sz1.Height);
        }

        #endregion

        #region Private Methods

        protected void GetTextBounds(out RectangleF titleRect, out RectangleF subtitleRect)
        {
            Graphics graphics = this.CreateGraphics();
            try
            {
                this.GetTextBounds(out titleRect, out subtitleRect, graphics);
            }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }
        }

        protected Region GetTextBounds()
        {
            RectangleF titleRect;
            RectangleF subtitleRect;
            this.GetTextBounds(out titleRect, out subtitleRect);
            return this.GetTextBounds(titleRect, subtitleRect);
        }

        protected Region GetTextBounds(RectangleF titleRect, RectangleF subtitleRectangle)
        {
            if (!titleRect.IsEmpty)
            {
                if (!subtitleRectangle.IsEmpty)
                {
                    return new Region(new RectangleF(6f, this.Width - 12, (this.Width - 66), (6f + titleRect.Height) + subtitleRectangle.Height));
                }
                else
                {
                    return new Region(titleRect);
                }
            }
            else
            {
                if (!subtitleRectangle.IsEmpty)
                {
                    return new Region(subtitleRectangle);
                }
                return new Region(RectangleF.Empty);
            }
        }

        #endregion

        #region Override

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        ///</summary>
        ///
        ///<param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            Rectangle rect = this.HeaderRectangle;
            Rectangle rectangle;
            RectangleF titleRect;
            RectangleF subtitleRect;
            this.GetTextBounds(out titleRect, out subtitleRect);
            if (this.bindingImage != null)
            {
                graphics.DrawImage(this.bindingImage, rect);
                rectangle = new Rectangle(rect.Left, rect.Bottom, rect.Width, 2);
                ControlPaint.DrawBorder3D(graphics, rectangle);
            }
            else
            {
                using (Brush brush = new LinearGradientBrush(rect, this.headerPair.BackColor1, this.headerPair.BackColor2, this.headerPair.Gradient))
                {
                    graphics.FillRectangle(brush, rect);
                    rectangle = new Rectangle(rect.Left, rect.Bottom, rect.Width, 2);
                    ControlPaint.DrawBorder3D(graphics, rectangle);
                }
            }
            this.DrawText(graphics, titleRect, this.title, this.titleAppearence);
            this.DrawText(graphics, subtitleRect, this.subtitle, this.subtitleAppearence);
        }

        internal override void Reset()
        {
            this.ResetHeaderPair();
            this.ResetBindingImage();
            this.ResetBackColor();
            this.ResetBindingImage();
            this.ResetTitleAppearence();
            this.ResetSubtitleAppearence();
            this.BackgroundImage = null;
            this.ForeColor = SystemColors.ControlText;
            this.Title = "New Wizard step.";
            this.Subtitle = "Description for the new step.";
        }

        #endregion

        #region Public Property

        [Description("The title text appearence of step."), Category("Appearance")]
        public TextAppearence TitleAppearence
        {
            get { return this.titleAppearence; }
            set
            {
                if (this.titleAppearence != value)
                {
                    this.titleAppearence = value;
                    this.Invalidate();
                }
            }
        }

        [Description("The sub title appearence of step."), Category("Appearance")]
        public TextAppearence SubtitleAppearence
        {
            get { return this.subtitleAppearence; }
            set
            {
                if (this.subtitleAppearence != value)
                {
                    this.subtitleAppearence = value;
                    this.Invalidate();
                }
            }
        }

        [Description("The background image of the panel."), Category("Appearance")]
        public Image BindingImage
        {
            get { return this.bindingImage; }
            set
            {
                if (value != this.bindingImage)
                {
                    this.bindingImage = value;
                    this.Invalidate();
                    this.OnBindingImageChanged();
                }
            }
        }

        protected virtual Rectangle HeaderRectangle
        {
            get { return new Rectangle(0, 0, this.Width, 60); }
        }

        [Category("Appearance"), DefaultValue("Description for the new step."), Description("The subtitle of the step."), Editor(typeof (MultilineStringEditor), typeof (UITypeEditor))]
        public string Subtitle
        {
            get { return this.subtitle; }
            set
            {
                if (!string.IsNullOrEmpty(this.subtitle) && value != this.subtitle)
                {
                    Region refreshRegion = this.GetTextBounds();
                    this.subtitle = value;
                    refreshRegion.Union(this.GetTextBounds());
                    this.Invalidate(refreshRegion);
                }
            }
        }

        [Description("The title of the step."), DefaultValue("New Wizard step."), Editor(typeof (MultilineStringEditor), typeof (UITypeEditor)), Category("Appearance")]
        public string Title
        {
            get { return this.title; }
            set
            {
                if (!string.IsNullOrEmpty(this.title) && value != this.title)
                {
                    Region refreshRegion = this.GetTextBounds();
                    this.title = value;
                    refreshRegion.Union(this.GetTextBounds());
                    this.Invalidate(refreshRegion);
                }
            }
        }

        [Description("Appearence of header."), Category("Appearance")]
        public ColorPair HeaderPair
        {
            get { return this.headerPair; }
            set
            {
                if (value != this.headerPair)
                {
                    this.headerPair = value;
                    this.Invalidate(this.HeaderRectangle);
                }
            }
        }

        #endregion

        #region Should Serialize implementation

        protected virtual bool ShouldSerializeSubtitleAppearence()
        {
            TextAppearence sa = new TextAppearence();
            sa.Font = new Font("Microsoft Sans", 8.25f, GraphicsUnit.Point);
            return this.SubtitleAppearence != sa;
        }

        protected virtual bool ShouldSerializeTitleAppearence()
        {
            return this.TitleAppearence.DefaultChanged();
        }

        protected virtual bool ShouldSerializeBindingImage()
        {
            return this.bindingImage != Resources.Top;
        }

        protected virtual bool ShouldSerializeHeaderPair()
        {
            return this.headerPair != new ColorPair();
        }

        #endregion

        protected virtual void ResetTitleAppearence()
        {
            this.titleAppearence = new TextAppearence();
        }

        protected virtual void ResetHeaderPair()
        {
            this.headerPair = new ColorPair();
        }

        protected virtual void ResetSubtitleAppearence()
        {
            this.subtitleAppearence = new TextAppearence();
            this.subtitleAppearence.Font = new Font("Microsoft Sans", 8.25f, GraphicsUnit.Point);
        }

        protected virtual void ResetBindingImage()
        {
            this.bindingImage = Resources.Top;
        }

    }
}