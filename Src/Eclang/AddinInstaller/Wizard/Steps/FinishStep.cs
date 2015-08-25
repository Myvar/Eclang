namespace AddinInstaller.Wizard.Steps
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    using AddinInstaller.Properties;
    using AddinInstaller.Wizard.Designers;
    using AddinInstaller.Wizard.Structures;

    using WizardBase;

    [ToolboxItem(false), Designer(typeof (WizardStepDesigner)), DefaultEvent("Click")]
    public class FinishStep : WizardStep
    {
        private ColorPair pair = new ColorPair();

        public FinishStep()
        {
#pragma warning disable DoNotCallOverridableMethodsInConstructor
            this.Reset();
#pragma warning restore DoNotCallOverridableMethodsInConstructor
        }

        internal override void Reset()
        {
            this.BackColor = SystemColors.ControlLightLight;
            this.BindingImage = Resources.back;
            this.BackgroundImageLayout = ImageLayout.Tile;
        }

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        ///</summary>
        ///
        ///<param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush brush = new LinearGradientBrush(this.ClientRectangle, this.pair.BackColor1, this.pair.BackColor2, this.pair.Gradient))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [Description("Backgroung of the finish step."), Category("Appearance")]
        public Image BindingImage
        {
            get { return base.BackgroundImage; }
            set
            {
                if (value != base.BackgroundImage)
                {
                    base.BackgroundImage = value;
                    this.Invalidate();
                    this.OnBindingImageChanged();
                }
            }
        }
        [Description("Appearence of body."), Category("Appearance")]
        public ColorPair Pair
        {
            get { return this.pair; }
            set
            {
                if (this.pair != value)
                {
                    this.pair = value;
                    this.Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        public bool ShouldSerializeBindingImage()
        {
            return this.BindingImage != Resources.back;
        }

        public void ResetBindingImage()
        {
            this.BindingImage = Resources.back; ;
        }

        public bool ShouldSerializePair()
        {
            return this.pair != new ColorPair();
        }

        public void ResetPair()
        {
            this.pair = new ColorPair();
        }
    }
}