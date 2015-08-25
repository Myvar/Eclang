namespace AddinInstaller.Wizard.Steps
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Windows.Forms;

    using AddinInstaller.Wizard.Collection;
    using AddinInstaller.Wizard.Converters;
    using AddinInstaller.Wizard.Designers;
    using AddinInstaller.Wizard.EventArgs;

    using WizardBase;

    [DefaultEvent("Click"), Designer(typeof (WizardDesigner))]
    public class WizardControl : Control
    {
        #region Private Fields

        protected internal Button BackButton = new Button();
        private readonly Panel buttonHost = new Panel();
        protected internal Button CancelButton = new Button();
        private int currentStepIndex = -1;
        private string finishButtonText;
        protected internal Button NextButton = new Button();
        private string nextButtonText;
        internal int indexer;
        private readonly GenericCollection<WizardStep> wizardStepCollection;
        private readonly Panel controlHost = new Panel();

        #endregion

        #region Events

        [Category("Button events"), Description("The back button is clicked.")]
        public event CancelEventHandler BackButtonClick;

        [Description("The cancel button is clicked."), Category("Button events")]
        public event EventHandler CancelButtonClick;

        [Category("Property Changed"), Description("Ocurres after a current step index is changed.")]
        public event EventHandler CurrentStepIndexChanged;

        [Description("The finish button is clicked."), Category("Button events")]
        public event EventHandler FinishButtonClick;

        [Category("Button events"), Description("The help button is clicked.")]
        public event EventHandler HelpButtonClick;

        [Description("The next button is clicked."), Category("Button events")]
        public event GenericCancelEventHandler<WizardControl> NextButtonClick;

        #endregion

        #region Constructor

        public WizardControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.finishButtonText = "Finish";
            this.nextButtonText = "Next >";
            this.InitializeComponent();
            this.wizardStepCollection = new GenericCollection<WizardStep>(this);
            this.wizardStepCollection.Inserted += this.wizardStepCollection_Inserted;
            this.wizardStepCollection.Cleared += this.wizardStepCollection_Cleared;
            this.wizardStepCollection.Removed += this.wizardStepCollection_Removed;
        }

        void wizardStepCollection_Removed(int index, WizardStep value)
        {
            value.Dispose();
            if (this.wizardStepCollection.Count != 1)
            {
                this.UpdateButtons();
            }
            else
            {
                this.OnSetFirstStep();
            }
        }

        private void wizardStepCollection_Cleared()
        {
            this.OnResetWizardSteps();
        }

        private void wizardStepCollection_Inserted(int index, WizardStep value)
        {
            if (this.wizardStepCollection.Count != 1)
            {
                this.UpdateButtons();
            }
            else
            {
                this.OnSetFirstStep();
            }
        }

        #endregion

        #region Private Methods

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.BackButton.Location = new Point(233, 7);
            this.BackButton.Size = new Size(65, 23);
            this.BackButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.BackButton.Text = "< Back";
            this.BackButton.Name = "BackButton";
            this.BackButton.Click += this.OnBackButtonClick;
            
            this.NextButton.Location = new Point(308, 7);
            this.NextButton.Size = new Size(75, 23);
            this.NextButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.NextButton.Text = "Next >";
            this.NextButton.Name = "NextButton";
            this.NextButton.Click += delegate(object sender, EventArgs e)
                                    {
                                        if (this.CurrentStepIndex == (this.WizardSteps.Count - 1))
                                        {
                                            if (this.FinishButtonClick != null)
                                            {
                                                this.FinishButtonClick(sender, e);
                                            }
                                            return;
                                        }
                                        this.OnNextButtonClick(sender, e);
                                    };
            this.CancelButton.Location = new Point(390, 7);
            this.CancelButton.Size = new Size(75, 23);
            this.CancelButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Click += delegate (object sender, EventArgs e)
                                      {
                                          if (this.CancelButtonClick != null)
                                          {
                                              this.CancelButtonClick(sender, e);
                                          }
                                      };
            this.controlHost.Size = new Size(534, 363);
            this.controlHost.Location = Point.Empty;
            this.controlHost.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.controlHost.Name = "WizardStepsPanel";
            this.controlHost.Visible = false;
            this.buttonHost.Size = new Size(534, 38);
            this.buttonHost.Location = new Point(0, 365);
            this.buttonHost.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.buttonHost.Name = "ButtonsPanel";
            this.buttonHost.Visible = false;
            this.buttonHost.Controls.Add(this.BackButton);
            this.buttonHost.Controls.Add(this.NextButton);
            this.buttonHost.Controls.Add(this.CancelButton);
            this.Size = new Size(534, 403);
            this.Controls.Add(this.controlHost);
            this.Controls.Add(this.buttonHost);
            this.ResumeLayout();
        }

        private void DoReLayout(int newIndex)
        {
            this.SuspendLayout();
            if (this.controlHost.Controls.Count > 0)
            {
                this.controlHost.Controls.RemoveAt(0);
            }
            this.controlHost.Controls.Add(this.WizardSteps[newIndex]);
            this.currentStepIndex = newIndex;
            if (this.CurrentStepIndex != 0)
            {
                this.BackButton.Enabled = true;
            }
            else
            {
                this.BackButton.Enabled = false;
            }
            if (this.CurrentStepIndex != (this.wizardStepCollection.Count - 1))
            {
                this.NextButton.Text = this.nextButtonText;
            }
            else
            {
                this.NextButton.Text = this.finishButtonText;
            }
            this.ResumeLayout();
        }

        private void ResetBackButtonEnabled()
        {
            if (this.currentStepIndex <= 0)
            {
                this.BackButton.Enabled = false;
            }
            else
            {
                if (this.currentStepIndex > 0)
                {
                    this.BackButton.Enabled = true;
                }
            }
        }

        private void ResetBackButtonVisible()
        {
            this.BackButtonVisible = true;
        }

        private void ResetCancelButtonEnabled()
        {
            this.CancelButtonEnabled = true;
        }

        private void ResetCancelButtonVisible()
        {
            this.CancelButtonVisible = true;
        }

        private void ResetNextButtonEnabled()
        {
            this.NextButtonEnabled = true;
        }

        private void ResetNextButtonVisible()
        {
            this.NextButtonVisible = true;
        }

        internal void UpdateButtons()
        {
            this.SuspendLayout();
            if (this.CurrentStepIndex != 0)
            {
                this.BackButton.Enabled = true;
            }
            else
            {
                this.BackButton.Enabled = false;
            }
            if (this.CurrentStepIndex != (this.wizardStepCollection.Count - 1))
            {
                this.NextButton.Text = this.nextButtonText;
            }
            else
            {
                this.NextButton.Text = this.finishButtonText;
            }
            this.ResumeLayout();
        }

        #endregion

        #region Virtual Methods

        protected virtual void OnBackButtonClick(object sender, EventArgs e)
        {
            if (this.CurrentStepIndex == 0)
            {
                return;
            }
            if (this.DesignMode)
            {
                this.CurrentStepIndex--;
                return;
            }
            if (this.BackButtonClick == null)
            {
                int backStepIndex = this.WizardSteps[this.CurrentStepIndex].BackStepIndex;
                if (backStepIndex != -1)
                {
                    this.CurrentStepIndex = backStepIndex;
                    return;
                }
                this.CurrentStepIndex--;
                return;
            }
            else
            {
                CancelEventArgs args = new CancelEventArgs();
                this.BackButtonClick(this, args);
                if (args.Cancel)
                {
                    return;
                }
                int num = this.WizardSteps[this.CurrentStepIndex].BackStepIndex;
                if (num != -1)
                {
                    this.CurrentStepIndex = num;
                    return;
                }
                this.CurrentStepIndex--;
                return;
            }
        }

        protected internal virtual void OnChangeCurrentStepIndex(int newIndex, bool force)
        {
            if (newIndex < 0 || newIndex >= this.WizardSteps.Count)
            {
                throw new ArgumentOutOfRangeException("newIndex", "The new index must be a valid index of the WizardSteps collection property.");
            }
            if (this.CurrentStepIndex != newIndex)
            {
                this.DoReLayout(newIndex);
                if (this.CurrentStepIndexChanged != null)
                {
                    this.CurrentStepIndexChanged(this, EventArgs.Empty);
                }
            }
            else if (force)
            {
                this.DoReLayout(newIndex);
            }
        }

        protected virtual void OnNextButtonClick(object sender, EventArgs e)
        {
            int num;
            if (this.DesignMode)
            {
                this.CurrentStepIndex++;
                return;
            }
            else
            {
                num = 0;
                if (!(this.WizardSteps[this.CurrentStepIndex] is StartStep))
                {
                    if ((this.WizardSteps[this.CurrentStepIndex] is FinishStep))
                    {
                        num = -1;
                    }
                }
                else
                {
                    num = 1;
                }
            }
            if (this.NextButtonClick == null)
            {
                bool noFinish = false;
                int num2 = 0;
                if (!(this.WizardSteps[this.CurrentStepIndex + 1] is StartStep))
                {
                    if (!(this.WizardSteps[this.CurrentStepIndex + 1] is FinishStep))
                    {
                        noFinish = true;
                    }
                    else
                    {
                        num2 = -1;
                    }
                }
                else
                {
                    num2 = 1;
                }
                if (((this.indexer + num) + num2) >= 0)
                {
                    if ((((this.indexer + num) + num2) != 0) || !noFinish)
                    {
                        this.WizardSteps[this.CurrentStepIndex + 1].BackStepIndex = this.CurrentStepIndex;
                        this.CurrentStepIndex++;
                        this.indexer += num;
                    }
                }
                else
                {
                    throw new InvalidOperationException("The steps must be well formed, so there cannot be an IntermediateStep without enclosing.");
                }
            }
            else
            {
                GenericCancelEventArgs<WizardControl> args = new GenericCancelEventArgs<WizardControl>(this);
                this.NextButtonClick(this, args);
                if (args.Cancel)
                {
                    return;
                }
                int nextStep = this.GetNextStep();
                if ( nextStep != -1)
                {
                    this.WizardSteps[nextStep].BackStepIndex = this.CurrentStepIndex;
                    this.CurrentStepIndex = nextStep;
                    this.indexer += num;
                    return;
                }
                this.WizardSteps[this.CurrentStepIndex + 1].BackStepIndex = this.CurrentStepIndex;
                this.CurrentStepIndex++;
                this.indexer += num;
                return;
            }
        }

        private int GetNextStep()
        {
            int num;
            num = 0;
            if (!(this.WizardSteps[this.CurrentStepIndex] is StartStep))
            {
                if ((this.WizardSteps[this.CurrentStepIndex] is FinishStep))
                {
                    num = -1;
                }
            }
            else
            {
                num = 1;
            }
            bool noFinish = false;
            int num2 = 0;
            if (!(this.WizardSteps[this.CurrentStepIndex + 1] is StartStep))
            {
                if (!(this.WizardSteps[this.CurrentStepIndex + 1] is FinishStep))
                {
                    noFinish = true;
                }
                else
                {
                    num2 = -1;
                }
            }
            else
            {
                num2 = 1;
            }
            if (((this.indexer + num) + num2) >= 0 && ((this.indexer + num) + num2) != 0 || !noFinish)
            {
                return this.CurrentStepIndex + 1;
            }
            else
            {
                throw new InvalidOperationException("The step must be well formed, so there cannot be a Finishstep without a Startstep.");
            }
        }

        protected internal virtual void OnResetWizardSteps()
        {
            this.SuspendLayout();
            if (this.controlHost.Controls.Count > 0)
            {
                this.controlHost.Controls.RemoveAt(0);
            }
            this.buttonHost.Visible = false;
            this.controlHost.Visible = false;
            this.BackButton.Enabled = true;
            this.currentStepIndex = -1;
            Rectangle rectangle = new Rectangle(this.buttonHost.Left, this.buttonHost.Top - 2, this.buttonHost.Width, 2);
            this.Invalidate(rectangle, false);
            this.ResumeLayout();
            if (this.CurrentStepIndexChanged != null)
            {
                this.CurrentStepIndexChanged(this, EventArgs.Empty);
            }
        }

        protected internal virtual void OnSetFirstStep()
        {
            this.CurrentStepIndex = 0;
            this.SuspendLayout();
            this.controlHost.Visible = true;
            this.buttonHost.Visible = true;
            Rectangle rectangle = new Rectangle(this.buttonHost.Left, this.buttonHost.Top - 2, this.buttonHost.Width, 2);
            this.Invalidate(rectangle, false);
            this.ResumeLayout();
        }

        #endregion

        #region Overrides

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        ///</summary>
        ///
        ///<param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.WizardSteps.Count != 0)
            {
                ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(this.buttonHost.Left, this.buttonHost.Top - 2, this.buttonHost.Width, 2), Border3DStyle.Etched, Border3DSide.Top);
            }
            base.OnPaint(e);
        }

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.TabIndexChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnTabIndexChanged(EventArgs e)
        {
            base.TabIndex = 0;
        }

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.TabStopChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnTabStopChanged(EventArgs e)
        {
            base.TabStop = false;
        }

        ///<summary>
        ///Gets or sets the font of the text displayed by the control.
        ///</summary>
        ///
        ///<returns>
        ///The <see cref="T:System.Drawing.Font"></see> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"></see> property.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        ///<summary>
        ///Gets or sets the foreground color of the control.
        ///</summary>
        ///
        ///<returns>
        ///The foreground <see cref="T:System.Drawing.Color"></see> of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultForeColor"></see> property.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        ///<summary>
        ///Gets or sets a value indicating whether the control can accept data that the user drags onto it.
        ///</summary>
        ///
        ///<returns>
        ///true if drag-and-drop operations are allowed in the control; otherwise, false. The default is false.
        ///</returns>
        ///<filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AllowDrop
        {
            get { return base.AllowDrop; }
#pragma warning disable ValueParameterNotUsed
            set { base.AllowDrop = true; }
#pragma warning restore ValueParameterNotUsed
        }

        ///<summary>
        ///Gets or sets the background color for the control.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Drawing.Color"></see> that represents the background color of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor"></see> property.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
#pragma warning disable ValueParameterNotUsed
            set { base.BackColor = SystemColors.Control; }
#pragma warning restore ValueParameterNotUsed
        }

        ///<summary>
        ///Gets or sets the background image displayed in the control.
        ///</summary>
        ///
        ///<returns>
        ///An <see cref="T:System.Drawing.Image"></see> that represents the image to display in the background of the control.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
#pragma warning disable ValueParameterNotUsed
            set { base.BackgroundImage = null; }
#pragma warning restore ValueParameterNotUsed
        }

        ///<summary>
        ///Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout"></see> enumeration.
        ///</summary>
        ///
        ///<returns>
        ///One of the values of <see cref="T:System.Windows.Forms.ImageLayout"></see> (<see cref="F:System.Windows.Forms.ImageLayout.Center"></see> , <see cref="F:System.Windows.Forms.ImageLayout.None"></see>, <see cref="F:System.Windows.Forms.ImageLayout.Stretch"></see>, <see cref="F:System.Windows.Forms.ImageLayout.Tile"></see>, or <see cref="F:System.Windows.Forms.ImageLayout.Zoom"></see>). <see cref="F:System.Windows.Forms.ImageLayout.Tile"></see> is the default value.
        ///</returns>
        ///
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified enumeration value does not exist. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
#pragma warning disable ValueParameterNotUsed
            set { base.BackgroundImageLayout = ImageLayout.None; }
#pragma warning restore ValueParameterNotUsed
        }

        ///<summary>
        ///Gets the default size of the control.
        ///</summary>
        ///
        ///<returns>
        ///The default <see cref="T:System.Drawing.Size"></see> of the control.
        ///</returns>
        ///
        protected override Size DefaultSize
        {
            get { return new Size(534, 403); }
        }

        ///<summary>
        ///Gets or sets the text associated with this control.
        ///</summary>
        ///
        ///<returns>
        ///The text associated with this control.
        ///</returns>
        ///<filterpriority>1</filterpriority>
        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        ///<summary>
        ///Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        ///</summary>
        ///
        ///<returns>
        ///One of the <see cref="T:System.Windows.Forms.RightToLeft"></see> values. The default is <see cref="F:System.Windows.Forms.RightToLeft.Inherit"></see>.
        ///</returns>
        ///
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:System.Windows.Forms.RightToLeft"></see> values. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false)]
        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                for (int i = 0; i < this.WizardSteps.Count; i++)
                {
                    this.WizardSteps[i].Dispose();
                    this.WizardSteps[i] = null;
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Public Property

        [Category("WizardControl Buttons Behavior"), Description("Defines if the back button is enabled or disabled.")]
        public bool BackButtonEnabled
        {
            get { return this.BackButton.Enabled; }
            set { this.BackButton.Enabled = value; }
        }

        [Description("Gets or sets the back button text."), Category("WizardControl Buttons Appearance"), DefaultValue("< Back")]
        public string BackButtonText
        {
            get { return this.BackButton.Text; }
            set { this.BackButton.Text = value; }
        }

        [Description("Defines the visibility of the back button."), Category("WizardControl Buttons Behavior")]
        public bool BackButtonVisible
        {
            get { return this.BackButton.Visible; }
            set { this.BackButton.Visible = value; }
        }

        [Description("Defines if the cancel button is enabled or disabled."), Category("WizardControl Buttons Behavior")]
        public bool CancelButtonEnabled
        {
            get { return this.CancelButton.Enabled; }
            set { this.CancelButton.Enabled = value; }
        }

        [Description("Gets or sets the cancel button text."), DefaultValue("Cancel"), Category("WizardControl Buttons Appearance")]
        public string CancelButtonText
        {
            get { return this.CancelButton.Text; }
            set { this.CancelButton.Text = value; }
        }

        [Description("Defines the visibility of the cancel button."), Category("WizardControl Buttons Behavior")]
        public bool CancelButtonVisible
        {
            get { return this.CancelButton.Visible; }
            set { this.CancelButton.Visible = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("Gets or sets the value of the current wizard step index based on the WizardSteps collection property."), DefaultValue(0), Category("Behavior")]
        public int CurrentStepIndex
        {
            get { return this.currentStepIndex; }
            set { this.OnChangeCurrentStepIndex(value, false); }
        }


        [Description("Gets or sets the finish button text."), DefaultValue("Finish"), Category("WizardControl Buttons Appearance")]
        public string FinishButtonText
        {
            get { return this.finishButtonText; }
            set
            {
                this.finishButtonText = value;
                if (this.CurrentStepIndex == (this.wizardStepCollection.Count - 1))
                {
                    this.NextButton.Text = this.finishButtonText;
                }
                else
                {
                    this.NextButton.Text = this.nextButtonText;
                }
            }
        }

        [Description("Defines if the next button is enabled or disabled."), Category("WizardControl Buttons Behavior")]
        public bool NextButtonEnabled
        {
            get { return this.NextButton.Enabled; }
            set { this.NextButton.Enabled = value; }
        }

        [DefaultValue("Next >"), Category("WizardControl Buttons Appearance"), Description("Gets or sets the next button text.")]
        public string NextButtonText
        {
            get { return this.nextButtonText; }
            set
            {
                this.nextButtonText = value;
                if (this.CurrentStepIndex != (this.wizardStepCollection.Count - 1))
                {
                    this.NextButton.Text = this.nextButtonText;
                    return;
                }
                this.NextButton.Text = this.finishButtonText;
            }
        }

        [Category("WizardControl Buttons Behavior"), Description("Defines the visibility of the next button.")]
        public bool NextButtonVisible
        {
            get { return this.NextButton.Visible; }
            set { this.NextButton.Visible = value; }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public new int TabIndex
        {
            get { return base.TabIndex; }
#pragma warning disable ValueParameterNotUsed
            private set { base.TabIndex = 0; }
#pragma warning restore ValueParameterNotUsed
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public new bool TabStop
        {
            get { return base.TabStop; }
#pragma warning disable ValueParameterNotUsed
            private set { base.TabStop = false; }
#pragma warning restore ValueParameterNotUsed
        }

        [Editor(typeof(WizardStepCollectionEditor), typeof(UITypeEditor)), Description("Gets a collection containing the step. This property returns the same collection than the Controls property."), TypeConverter(typeof(GenericCollectionConverter<WizardStep>)), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual GenericCollection<WizardStep> WizardSteps
        {
            get { return this.wizardStepCollection; }
        }

        #endregion
    }
}