namespace AddinInstaller.Wizard.Steps
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    using AddinInstaller.Properties;
    using AddinInstaller.Wizard.Converters;
    using AddinInstaller.Wizard.EventArgs;
    using AddinInstaller.Wizard.Structures;

    using WizardBase;

    public class LicenceStep : WizardStep
    {
        #region Private Fields

        private ColorPair headerPair = new ColorPair();
        private Image bindingImage;
        private string subtitle = "Please read the following important information before continuing.";
        private TextAppearence subtitleAppearence = new TextAppearence();
        private string title = "License Agreement.";
        private TextAppearence titleAppearence = new TextAppearence();
        private Font warningFont = new Font("Microsoft Sans", 8.25f, GraphicsUnit.Point);
        private string warning = "Please read the following license agreement. You must accept the terms  of this agreement before continuing.";
        private readonly RichTextBox rtbLicense = new RichTextBox();
        private readonly RadioButton rbtnAccept = new RadioButton();
        private readonly RadioButton rbtnDecline = new RadioButton();
        private bool? accepted = null;
        private string licenseFile = string.Empty;

        #endregion

        public event GenericEventHandler<bool> AgreementChanged;

        #region Constructor

        public LicenceStep()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.InitializeComponent();
#pragma warning disable DoNotCallOverridableMethodsInConstructor
            this.ResetBindingImage();
            this.ResetSubtitleAppearence();
            this.ResetTitleAppearence();
            this.ResetWarningFont();
#pragma warning restore DoNotCallOverridableMethodsInConstructor
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            RectangleF titleRect;
            RectangleF subtitleRect;
            RectangleF descRect;
            this.GetTextBounds(out titleRect, out subtitleRect, out descRect);

            this.rtbLicense.Location = new Point(50, 99);
            this.rtbLicense.Name = "rtbLicense";
            this.rtbLicense.Size = new Size(this.Size.Width - 100, this.Size.Height -200);
            this.rtbLicense.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.rtbLicense.TabIndex = 0;
            this.rtbLicense.Text = "Please select the licence file.";

            this.rbtnAccept.AutoSize = true;
            this.rbtnAccept.Location = new Point(50, 314);
            this.rbtnAccept.Name = "rbtnAccept";
            this.rbtnAccept.TabIndex = 1;
            this.rbtnAccept.TabStop = true;
            this.rbtnAccept.Text = "I &accept the agreement";
            this.rbtnAccept.UseVisualStyleBackColor = true;
            this.rbtnAccept.CheckedChanged += this.rbtnAccept_CheckedChanged;

            this.rbtnDecline.AutoSize = true;
            this.rbtnDecline.Location = new Point(50, 337);
            this.rbtnDecline.Name = "rbtnDecline";
            this.rbtnDecline.TabIndex = 2;
            this.rbtnDecline.TabStop = true;
            this.rbtnDecline.Text = "I do &not accept the agreement";
            this.rbtnDecline.UseVisualStyleBackColor = true;
            this.rbtnDecline.Checked = true;
            this.rbtnDecline.CheckedChanged += this.rbtnDecline_CheckedChanged;
            this.Controls.AddRange(new Control[] {this.rtbLicense, this.rbtnAccept, this.rbtnDecline});
            this.ResumeLayout();
        }


        #endregion

        #region Virtual Methods

        protected virtual void GetTextBounds(out RectangleF titleRect, out RectangleF subtitleRect, out RectangleF descriptionRect, Graphics graphics)
        {
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Trimming = StringTrimming.EllipsisCharacter;
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.None;
            SizeF sz = graphics.MeasureString(this.Title, this.titleAppearence.Font, this.Width, format);
            titleRect = new RectangleF(this.subtitleAppearence.Font.SizeInPoints, this.subtitleAppearence.Font.SizeInPoints, sz.Width, sz.Height);
            SizeF sz1 = graphics.MeasureString(this.Subtitle, this.subtitleAppearence.Font, this.Width, format);
            subtitleRect = new RectangleF(2 * this.subtitleAppearence.Font.SizeInPoints, titleRect.Height + this.subtitleAppearence.Font.SizeInPoints, sz1.Width, sz1.Height);
            SizeF sz2 = graphics.MeasureString(this.warning, this.warningFont, (int) (this.Width - (4 * this.warningFont.SizeInPoints)), format);
            descriptionRect = new RectangleF(2 * this.warningFont.SizeInPoints, this.HeaderRect.Height + this.warningFont.SizeInPoints, sz2.Width, sz2.Height);
        }

        #endregion

        #region Private Methods

        protected void GetTextBounds(out RectangleF titleRect, out RectangleF subtitleRect, out RectangleF descriptionRect)
        {
            Graphics graphics = this.CreateGraphics();
            try
            {
                this.GetTextBounds(out titleRect, out subtitleRect, out descriptionRect, graphics);
                this.rtbLicense.Location = new Point((int)(2 * this.warningFont.SizeInPoints), (int) (descriptionRect.Bottom + this.warningFont.SizeInPoints));
                this.rtbLicense.Size = new Size((int)(this.Width - 4*this.warningFont.SizeInPoints), (int)(this.Height - descriptionRect.Height - this.rbtnAccept.Height - this.HeaderRect.Height - 38));
                this.rbtnAccept.Location = new Point((int)(2 * this.warningFont.SizeInPoints), this.rtbLicense.Bottom + 10);
                this.rbtnDecline.Location = new Point((int)(2 * this.warningFont.SizeInPoints) + this.rtbLicense.Width/2, this.rtbLicense.Bottom + 10);
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
            RectangleF descriptionRect;
            this.GetTextBounds(out titleRect, out subtitleRect, out descriptionRect);
            return this.GetTextBounds(titleRect, subtitleRect);
        }

        protected Region GetTextBounds(RectangleF titleRect, RectangleF subtitleRect)
        {
            if (!titleRect.IsEmpty)
            {
                if (!subtitleRect.IsEmpty)
                {
                    return new Region(new RectangleF(6f, this.Width - 12, (this.Width - 66), (6f + titleRect.Height) + subtitleRect.Height));
                }
                else
                {
                    return new Region(titleRect);
                }
            }
            else
            {
                if (!subtitleRect.IsEmpty)
                {
                    return new Region(subtitleRect);
                }
                return new Region(RectangleF.Empty);
            }
        }

        private void DrawText(RectangleF empty, Graphics graphics, RectangleF titleRect, RectangleF warningRect)
        {
            if (!titleRect.IsEmpty)
            {
                this.DrawText(graphics,  titleRect, this.title, this.titleAppearence);
            }
            if (!empty.IsEmpty)
            {
                this.DrawText(graphics, empty, this.subtitle, this.subtitleAppearence);
            }
            if (!warningRect.IsEmpty)
            {
                graphics.DrawString(this.warning, this.warningFont, new SolidBrush(this.ForeColor), warningRect);
            }
        }

        #endregion

        #region Override

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            Rectangle rect = this.HeaderRect;
            Rectangle rectangle;
            RectangleF titleRect;
            RectangleF subtitleRect;
            RectangleF warningRect;
            this.GetTextBounds(out titleRect, out subtitleRect, out warningRect);
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
            this.DrawText(subtitleRect, graphics, titleRect, warningRect);
        }

        internal override void Reset()
        {
            this.ResetBindingImage();
            this.ResetSubtitleAppearence();
            this.ResetAccepted();
            this.ResetTitleAppearence();
            this.BackgroundImage = null;
            this.ResetWarningFont();
            this.Title = "License Agreement.";
            this.Subtitle = "Please read the following important information before continuing.";
        }

        #endregion

        #region Public Property

        [Description("Appearence of header."), Category("Appearance")]
        public ColorPair HeaderPair
        {
            get { return this.headerPair; }
            set
            {
                if (value != this.headerPair)
                {
                    this.headerPair = value;
                    this.Invalidate(this.HeaderRect);
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
                    this.Invalidate(this.HeaderRect);
                    this.OnBindingImageChanged();
                }
            }
        }

        protected virtual Rectangle HeaderRect
        {
            get { return new Rectangle(0, 0, this.Width, 60); }
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
        [Description("The warning text appearence of step."), Category("Appearance")]
        public Font WarningFont
        {
            get { return this.warningFont; }
            set
            {
                if (this.warningFont != value)
                {
                    this.warningFont = value;
                    this.Invalidate();
                }
            }
        }
        [Category("Appearance"), DefaultValue("Please read the following important information before continuing."), Description("The subtitle of the step."), Editor(typeof (MultilineStringEditor), typeof (UITypeEditor))]
        public string Subtitle
        {
            get { return this.subtitle; }
            set
            {
                if (value != this.subtitle)
                {
                    Region refreshRegion = this.GetTextBounds();
                    this.subtitle = value;
                    refreshRegion.Union(this.GetTextBounds());
                    this.Invalidate(refreshRegion);
                }
            }
        }
        [Category("Appearance"), Description("Warning text."), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Warning
        {
            get { return this.warning; }
            set
            {
                if (value != this.warning)
                {
                    this.warning = value;
                    this.Invalidate();
                }
            }
        }
        [Description("License Agreement."), Editor(typeof (MultilineStringEditor), typeof (UITypeEditor)), Category("Appearance")]
        public string Title
        {
            get { return this.title; }
            set
            {
                if (value != this.title)
                {
                    Region refreshRegion = this.GetTextBounds();
                    this.title = value;
                    refreshRegion.Union(this.GetTextBounds());
                    this.Invalidate(refreshRegion);
                }
            }
        }
        [Description("Accept text."), Category("Appearance")]
        public string AcceptText
        {
            get { return this.rbtnAccept.Text; }
            set
            {
                if(this.rbtnAccept.Text != value)
                {
                    this.rbtnAccept.Text = value;
                    this.Invalidate();
                }
            }
        }

        [Description("Decline text."), Category("Appearance")]
        public string DeclineText
        {
            get { return this.rbtnDecline.Text; }
            set
            {
                if (this.rbtnDecline.Text != value)
                {
                    this.rbtnDecline.Text = value;
                    this.Invalidate();
                }
            }
        }
        [Description("Status of license agreement."), Category("Behavior")]
        public bool? Accepted
        {
            get { return this.accepted; }
            set
            {
                if (this.accepted != value)
                {
                    this.accepted = value;
                    if(!this.accepted.HasValue)
                    {
                        this.rbtnAccept.Checked = false;
                        this.rbtnDecline.Checked = false;
                    }
                    else if(this.accepted.HasValue && this.accepted.Value)
                    {
                        this.rbtnAccept.Checked = true;
                        this.rbtnDecline.Checked = false;
                    }
                    else
                    {
                        this.rbtnAccept.Checked = false;
                        this.rbtnDecline.Checked = true;
                    }
                    this.Invalidate();
                }
            }
        }
        [Editor(typeof(CustomFileNameEditor), typeof(UITypeEditor))]
        [Description("License to display."), Category("Behavior")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string License
        {
            get { return this.licenseFile; }
            set
            {
                this.rtbLicense.Text = value;
                this.licenseFile = value;
            }
        }

        #endregion

        protected virtual void ResetTitleAppearence()
        {
            this.titleAppearence = new TextAppearence();
            this.titleAppearence.Font = new Font("Microsoft Sans", 8.25f, FontStyle.Bold, GraphicsUnit.Point);
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

        protected virtual void ResetWarningFont()
        {
            this.warningFont = new Font("Microsoft Sans", 8.25f, GraphicsUnit.Point);
        }

        protected virtual void ResetAccepted()
        {
            this.accepted = null;
        }

        protected virtual void ResetAcceptText()
        {
            this.AcceptText = "I &accept the agreement";
        }

        protected virtual void ResetDeclineText()
        {
            this.DeclineText = "I do &not accept the agreement";
        }

        protected virtual void ResetHeaderPair()
        {
            this.headerPair = new ColorPair();
        }

        protected virtual bool ShouldSerializeTitleAppearence()
        {
            TextAppearence ta = new TextAppearence();
            ta.Font = new Font("Microsoft Sans", 8.25f, FontStyle.Bold, GraphicsUnit.Point);
            return ta != this.titleAppearence;
        }

        protected virtual bool ShouldSerializeSubtitleAppearence()
        {
            TextAppearence sa = new TextAppearence();
            sa.Font = new Font("Microsoft Sans", 8.25f, GraphicsUnit.Point);
            return sa != this.subtitleAppearence;
        }

        protected virtual bool ShouldSerializeWarningFont()
        {
            return this.warningFont != new Font("Microsoft Sans", 8.25f, GraphicsUnit.Point);
        }

        protected virtual bool ShouldSerializeBindingImage()
        {
            return this.bindingImage != Resources.Top;
        }

        protected virtual bool ShouldSerializeAccepted()
        {
            return this.accepted != null;
        }

        protected virtual bool ShouldSerializeAcceptText()
        {
            return this.AcceptText != "I &accept the agreement";
        }

        protected virtual bool ShouldSerializeDeclineText()
        {
            return this.DeclineText != "I do &not accept the agreement";
        }

        protected virtual bool ShouldSerializeHeaderPair()
        {
            return this.headerPair != new ColorPair();
        }


        private void rbtnDecline_CheckedChanged(object sender, EventArgs e)
        {
            this.OnAgreementChanged();
        }

        private void rbtnAccept_CheckedChanged(object sender, EventArgs e)
        {
            this.OnAgreementChanged();
        }

        protected virtual void OnAgreementChanged()
        {
            if(this.AgreementChanged != null)
            {
                this.AgreementChanged(this, new GenericEventArgs<bool>(this.rbtnAccept.Checked));
            }
        }
    }
}