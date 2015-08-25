namespace EcIDE.Contracts.UI.Options
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    [
    TypeConverter(typeof(ExpandableObjectConverter))
    ]
    [ToolboxItem(true)]
    public partial class OptionsPanel : UserControl
    {
        private OptionsForm _OptionsForm;
        private String _Path;
        private String _DisplayName;

        private bool _OptionsUpdated;

        [Browsable(true)]
        [Description("This event is fired when the panel options are changed")]
        public event EventHandler OptionsChanged;

        #region Properties
        /// <summary>
        /// Gets the options form.
        /// </summary>
        /// <value>The options form.</value>
        [Browsable(false)]
        public OptionsForm OptionsForm
        {
            get
            {
                return this._OptionsForm;
            }
        }

        [Category("Options Form")]
        [Description("The path of the OptionsPanel (determines the location in the Category TreeView in the parent OptionsForm form)")]
        public String CategoryPath
        {
            get
            {
                return this._Path;
            }
            set
            {
                this._Path = value;
            }
        }

        [Category("Options Form")]
        [Description("The name displayed for this panel in the Category TreeView in the parent OptionsForm form")]
        public String DisplayName
        {
            get
            {
                return this._DisplayName;
            }
            set
            {
                this._DisplayName = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether application must restart.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if application must restart to apply options otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool ApplicationMustRestart
        {
            get
            {
                if (this.OptionsForm != null)
                {
                    return this.OptionsForm.ApplicationMustRestart;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (this.OptionsForm != null)
                {
                    this.OptionsForm.ApplicationMustRestart = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [options changed].
        /// </summary>
        /// <value><c>true</c> if [options changed]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool OptionsUpdated
        {
            get
            {
                return this._OptionsUpdated;
            }
            set
            {
                this._OptionsUpdated = value;

                if (this._OptionsUpdated)
                {
                    this.OnOptionsChanged();
                }
            }
        }

        #endregion

        public OptionsPanel()
        {
            this.InitializeComponent();
        }

        virtual public void PanelAdded(OptionsForm optf)
        {
            this._OptionsForm = optf;

            this.InitPanelForControl(this);

            this._OptionsForm.OptionsSaving += new EventHandler(this.OptionsSaving);
            this._OptionsForm.OptionsSaved += new EventHandler(this.OptionsSaved);
            this._OptionsForm.ResetForm += new EventHandler(this.ResetForm);
        }

        protected void SetOption(String OptionName, Object value)
        {
            this._OptionsForm.AppSettings[OptionName] = value;
            this.OptionsUpdated = true;
        }

        protected void OnOptionsChanged()
        {
            if (this.OptionsChanged != null)
            {
                this.OptionsChanged(this, EventArgs.Empty);
            }
        }

        protected void OptionsSaving(object sender, EventArgs e)
        {
        }

        protected void OptionsSaved(object sender, EventArgs e)
        {
            this.ReloadValues(this);
        }

        protected virtual void ResetForm(object sender, EventArgs e)
        {
            this.ReloadValues(this);
        }
        
        private void ReloadValues(Control ctrl)
        {
            for (int i = 0; i < ctrl.Controls.Count; i++)
            {
                Control ctrl2 = ctrl.Controls[i];

                for (int l = 0; l < ctrl2.DataBindings.Count; l++)
                {
                    Binding bind = ctrl2.DataBindings[l];
                    bind.ReadValue();
                }

                this.ReloadValues(ctrl2);
            }
        }

        private void InitPanelForControl(Control ctrl)
        {
            for (int i = 0; i < ctrl.Controls.Count; i++)
            {
                Control ctrl2 = ctrl.Controls[i];

                for (int l = 0; l < ctrl2.DataBindings.Count; l++)
                {
                    Binding bind = ctrl2.DataBindings[l];
                    String prop = bind.BindingMemberInfo.BindingMember;

                    try
                    {
                        Object value = this._OptionsForm.AppSettings[prop];

                        if (value != null)
                        {
                            bind.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                            bind.ControlUpdateMode = ControlUpdateMode.Never;
                            System.Configuration.SettingsProperty sett = new System.Configuration.SettingsProperty(prop);
                            sett.DefaultValue = value;
                            this._OptionsForm.Settings.Add(sett);
                        }
                    }
                    catch
                    { }
                }

                this.InitPanelForControl(ctrl2);
            }
        }
    }
}
