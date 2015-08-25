namespace EcIDE.Contracts.UI.Options
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Drawing;
    using System.Windows.Forms;

    [ToolboxItem(true)]
    public partial class OptionsForm : Form
    {

        #region Fields

        OptionsPanelList _Panels = new OptionsPanelList();

        private ApplicationSettingsBase _AppSettings;
        private SettingsPropertyCollection _Settings;
        private Dictionary<String, Object> _ChangedSettings;

        private Color _BoxBackgroundColor = SystemColors.ControlLight;

        private bool _FirstLoad = true;
        private int _CategoryTreeWidth;

        private bool _Saving;

        private String _OptionsNoDescription = String.Empty;
        private bool _SelectFirstPanel;
        private bool _AutomaticSaveSettings = true;
        private bool _ApplyAlwaysEnabled;
        private bool _OkClicked;

        [Browsable(true)]
        [Category("Action")]
        [Description("This event occurs when the form options must be saved (click on Apply or OK form buttons)")]
        public event EventHandler OptionsSaving;

        [Browsable(true)]
        [Category("Action")]
        [Description("This event occurs when the form options have been saved")]
        public event EventHandler OptionsSaved;

        [Browsable(true)]
        [Category("Action")]
        [Description("This event occurs when the form items must be reset (click on Cancel form button)")]
        public event EventHandler ResetForm;

        #endregion


        #region Properties

        public override Size MinimumSize
        {
            get
            {
                Size msz = base.MinimumSize;
                int w = this.OptionsFormSplit.Panel2MinSize + this.OptionsFormSplit.SplitterWidth + this.OptionsFormSplit.SplitterDistance + 3;

                if (base.MinimumSize.Width < w)
                {
                    msz.Width = w;
                }

                return msz;
            }
            set
            {
                base.MinimumSize = value;
            }
        }        

        [Browsable(false)]
        [Category("Options Form")]
        [Description("The panels loaded in the OptionsForm")]
        public OptionsPanelList Panels
        {
            get
            {
                return this._Panels;
            }
        }

        [Browsable(false)]
        [Category("Options Form")]
        [Description("The ApplicationSettingsBase object to use for options synchronization")]
        public ApplicationSettingsBase AppSettings
        {
            get
            {
                return this._AppSettings;
            }
            set
            {
                this._AppSettings = value;
            }
        }

        [Browsable(false)]
        [Category("Options Form")]
        [Description("The Settings object to use for options synchronization")]
        public SettingsPropertyCollection Settings
        {
            get
            {
                return this._Settings;
            }
        }

        [Category("Options Form")]
        [Description("Images used in the category tree")]
        public ImageList CategoryImages
        {
            get
            {
                return this.CatTree.ImageList;
            }
            set
            {
                this.CatTree.ImageList = value;
            }
        }


        [Category("Options Form")]
        [Description("Indicates the width of the Category Tree Box")]
        public int CategoryTreeWidth
        {
            get
            {
                if (this._FirstLoad && this._CategoryTreeWidth > 0)
                {
                    this.OptionsFormSplit.SplitterDistance = this._CategoryTreeWidth;
                    return this._CategoryTreeWidth;
                }

                return this.OptionsFormSplit.SplitterDistance;
            }
            set
            {
                this.OptionsFormSplit.SplitterDistance = value;
                this._CategoryTreeWidth = value;
            }
        }

        [Category("Options Form")]
        [Description("This is the Text for the category header box")]
        public String CategoryHeaderText
        {
            get
            {
                return this.CatHeader.Text;
            }
            set
            {
                this.CatHeader.Text = value;
            }
        }

        [Category("Options Form")]
        [Description("This is the Text for the OK button")]
        public String OkButtonText
        {
            get
            {
                return this.OKBtn.Text;
            }
            set
            {
                this.OKBtn.Text = value;
            }
        }

        [Category("Options Form")]
        [Description("This is the Text for the Apply button")]
        public String ApplyButtonText
        {
            get
            {
                return this.ApplyBtn.Text;
            }
            set
            {
                this.ApplyBtn.Text = value;
            }
        }

        [Category("Options Form")]
        [Description("This is the Text for the Cancel button")]
        public String CancelButtonText
        {
            get
            {
                return this.CancelBtn.Text;
            }
            set
            {
                this.CancelBtn.Text = value;
            }
        }

        [Category("Options Form")]
        [Description("This is the Text for the Application Must Restart label box")]
        public String AppRestartText
        {
            get
            {
                return this.AppRestartLabel.Text;
            }
            set
            {
                this.AppRestartLabel.Text = value;
            }
        }

        [Category("Options Form Colors")]
        [Description("Indicates the background color for each box")]
        public Color BoxBackColor
        {
            get
            {
               return this._BoxBackgroundColor;
            }
            set
            {
                if (value != null && this._BoxBackgroundColor != value)
                {
                    this._BoxBackgroundColor = value;

                    this.CatHeader.BackColor = this._BoxBackgroundColor;
                    this.CatDescr.BackColor = this._BoxBackgroundColor;
                    this.OptionsPanelPath.BackColor = this._BoxBackgroundColor;
                    this.OptionDescrLabel.BackColor = this._BoxBackgroundColor;
                    this.AppRestartLabel.BackColor = this._BoxBackgroundColor;
                }
            }
        }

        [Category("Options Form Colors")]
        [Description("Indicates the foreground color for the options panel path box")]
        public Color OptionsPathForeColor
        {
            get
            {
                return this.OptionsPanelPath.ForeColor;
            }
            set
            {
                this.OptionsPanelPath.ForeColor = value;
            }
        }

        [Category("Options Form Colors")]
        [Description("Indicates the foreground color for the Application Must Restart label box")]
        public Color AppRestartForeColor
        {
            get
            {
                return this.AppRestartLabel.ForeColor;
            }
            set
            {
                this.AppRestartLabel.ForeColor = value;
            }
        }

        [Category("Options Form Descriptions")]
        [Description("This is the default Text for the description box when no description is available")]
        public String OptionsNoDescription
        {
            get
            {
                return this._OptionsNoDescription;
            }
            set
            {
                this._OptionsNoDescription = value;
            }
        }

        [Category("Options Form Descriptions")]
        [Description("This is the description for the Category Header box when the mouse hover it")]
        public String CategoryHeaderDescription
        {
            get
            {
                return this.CatHeader.AccessibleDescription;
            }
            set
            {
                this.CatHeader.AccessibleDescription = value;
            }
        }

        [Category("Options Form Descriptions")]
        [Description("This is the description for the Options Panel Path box when the mouse hover it")]
        public String OptionsPanelPathDescription
        {
            get
            {
                return this.OptionsPanelPath.AccessibleDescription;
            }
            set
            {
                this.OptionsPanelPath.AccessibleDescription = value;
            }
        }

        [Category("Options Form Descriptions")]
        [Description("This is the description for the Category Tree box when the mouse hover it")]
        public String CategoryTreeDescription
        {
            get
            {
                return this.CatTree.AccessibleDescription;
            }
            set
            {
                this.CatTree.AccessibleDescription = value;
            }
        }

        [Category("Options Form Descriptions")]
        [Description("This is the description for the Category Description box when the mouse hover it")]
        public String CategoryDescrDescription
        {
            get
            {
                return this.CatDescr.AccessibleDescription;
            }
            set
            {
                this.CatDescr.AccessibleDescription = value;
            }
        }

        [Category("Options Form Descriptions")]
        [Description("This is the description for the Option Description box when the mouse hover it")]
        public String OptionDescrDescription
        {
            get
            {
                return this.OptionDescrLabel.AccessibleDescription;
            }
            set
            {
                this.OptionDescrLabel.AccessibleDescription = value;
            }
        }

        [Category("Options Form Descriptions")]
        [Description("This is the description for the Application Must Restart box when the mouse hover it")]
        public String ApplicationRestartDescription
        {
            get
            {
                return this.AppRestartLabel.AccessibleDescription;
            }
            set
            {
                this.AppRestartLabel.AccessibleDescription = value;
            }
        }

        [Category("Options Form Descriptions")]
        [Description("This is the description for the OK Form Button when the mouse hover it")]
        public String OkButtonDescription
        {
            get
            {
                return this.OKBtn.AccessibleDescription;
            }
            set
            {
                this.OKBtn.AccessibleDescription = value;
            }
        }

        [Category("Options Form Descriptions")]
        [Description("This is the description for the Apply Form Button when the mouse hover it")]
        public String ApplyButtonDescription
        {
            get
            {
                return this.ApplyBtn.AccessibleDescription;
            }
            set
            {
                this.ApplyBtn.AccessibleDescription = value;
            }
        }

        [Category("Options Form Descriptions")]
        [Description("This is the description for the Cancel Form Button when the mouse hover it")]
        public String CancelButtonDescription
        {
            get
            {
                return this.CancelBtn.AccessibleDescription;
            }
            set
            {
                this.CancelBtn.AccessibleDescription = value;
            }
        }

        [Category("Options Form Flags")]
        [Description("Indicates if the Application Must Restart box must appear")]
        public bool ApplicationMustRestart
        {
            get
            {
                return !this.OptDescrSplit.Panel2Collapsed;
            }
            set
            {
                this.OptDescrSplit.Panel2Collapsed = !value;
            }
        }

        [Category("Options Form Flags")]
        [Description("Indicates if the Category Header box must be visible")]
        public bool ShowCategoryHeader
        {
            get
            {
                return this.CatHeaderPanel.Visible;
            }
            set
            {
                this.CatHeaderPanel.Visible = value;
            }
        }

        [Category("Options Form Flags")]
        [Description("Indicates if the Category Description box must be visible")]
        public bool ShowCategoryDescription
        {
            get
            {
                return this.CatDescrPanel.Visible;
            }
            set
            {
                this.CatDescrPanel.Visible = value;
            }
        }

        [Category("Options Form Flags")]
        [Description("Indicates if the Options Description box must be visible")]
        public bool ShowOptionsDescription
        {
            get
            {
                return !this.OptionsSplitContainer.Panel2Collapsed;
            }
            set
            {
                this.OptionsSplitContainer.Panel2Collapsed = !value;
            }
        }

        [Category("Options Form Flags")]
        [Description("Indicates if first Panel must be selected when selection is on a parent Category.")]
        public bool SelectFirstPanel
        {
            get
            {
                return this._SelectFirstPanel;
            }
            set
            {
                this._SelectFirstPanel = value;
            }
        }


        [Category("Options Form Flags")]
        [Description("Indicates if the Options Panel Path box must be visible")]
        public bool ShowOptionsPanelPath
        {
            get
            {
                return this.OptionsPanelPath.Visible;
            }
            set
            {
                this.OptionsPanelPath.Visible = value;
            }
        }

        [Category("Options Form Flags")]
        [Description("Indicates if the Splitter capacity is enabled for the Options Form")]
        public bool EnableFormSplitter
        {
            get
            {
                return !this.OptionsFormSplit.IsSplitterFixed;
            }
            set
            {
                this.OptionsFormSplit.IsSplitterFixed = !value;
            }
        }

        [Category("Options Form Flags")]
        [Description("Indicates if the Options form will automatically save the Application Settings")]
        public bool AutomaticSaveSettings
        {
            get
            {
                return this._AutomaticSaveSettings;
            }
            set
            {
                this._AutomaticSaveSettings = value;
            }
        }

        [Category("Options Form Flags")]
        [Description("Indicates if the Apply button must be always enabled (and not only when an option change)")]
        public bool ApplyAlwaysEnabled
        {
            get
            {
                return this._ApplyAlwaysEnabled;
            }
            set
            {
                this._ApplyAlwaysEnabled = value;

                if (this._ApplyAlwaysEnabled)
                {
                    this.ApplyBtn.Enabled = true;
                }
            }
        }

        [Category("Options Form Flags")]
        [Description("Indicates if the Apply button must be always enabled (and not only when an option change)")]
        public bool SaveAndCloseOnReturn
        {
            get
            {
                return this.AcceptButton != null;
            }
            set
            {
                if (value)
                {
                    this.AcceptButton = this.OKBtn;
                }
                else
                {
                    this.AcceptButton = null;
                }
            }
        }

        [Browsable(false)]
        [Category("Options Form Flags")]
        [Description("Indicates if the OK button was clicked on form close.")]
        public bool OkClicked
        {
            get
            {
                return this._OkClicked;
            }
            set
            {
                this._OkClicked = value;
            }
        }

        #endregion


        #region Construction

        public OptionsForm() : this(new Settings())
        {
           
        }

        public OptionsForm(ApplicationSettingsBase settings)
        {
            this.InitializeComponent();

            this.BoxBackColor = SystemColors.ControlLight;
            this.OptionsNoDescription = "Description.";

            this._Panels.PanelAdded += new OptionsPanelEventHandler(this._Panels_PanelAdded);

            this.ApplyBtn.Enabled = this._ApplyAlwaysEnabled;

            this._AppSettings = settings;
            this._Settings = new SettingsPropertyCollection();
            this._ChangedSettings = new Dictionary<String, Object>();

            this._AppSettings.SettingChanging += new SettingChangingEventHandler(this._AppSettings_SettingChanging);
        }

        #endregion


        #region Methods

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (this._CategoryTreeWidth > 0 && this._FirstLoad)
            {
                this.OptionsFormSplit.Dock = DockStyle.None;
                this.OptionsFormSplit.Dock = DockStyle.Fill;
                this.OptionsFormSplit.SplitterDistance = this._CategoryTreeWidth;
                this._FirstLoad = false;
            }
        }

        void _Panels_PanelAdded(object sender, OptionsPanelEventArgs e)
        {
            this.AddPanel(e.Panel);
        }

        private void AddPanel(OptionsPanel panel)
        {
            String optionCategory = panel.CategoryPath;
            String displayName = panel.DisplayName;

            String[][] lpaths = this.GetPaths(optionCategory);
            String[] paths = lpaths[0];
            String[] labs = lpaths[1];

            TreeNode pnode = null;
            TreeNode nnode = null;

            if (paths.Length > 1)
            {
                TreeNode[] search = this.CatTree.Nodes.Find(paths[0], false);

                if (search != null && search.Length > 0)
                {
                    pnode = search[0];
                }
                else
                {
                    this.CatTree.Nodes.Add(paths[0], labs[0], paths[0], paths[0]);
                    pnode = this.CatTree.Nodes[this.CatTree.Nodes.Count - 1];
                }

                int i = 1;
                int sub = paths.Length - 1;
                for (; i < sub; i++)
                {
                    search = pnode.Nodes.Find(paths[i], false);

                    if (search != null && search.Length > 0)
                    {
                        pnode = search[0];
                    }
                    else
                    {
                        pnode.Nodes.Add(paths[i], labs[i], String.Join("\\", paths, 0, i + 1), String.Join("\\", paths, 0, i + 1));
                        pnode = pnode.Nodes[pnode.Nodes.Count - 1];
                    }
                }

                if (i < sub)
                {
                    pnode = null;
                }
            }

            if (pnode != null)
            {
                nnode = new TreeNode(displayName);
                nnode.Name = optionCategory;
                nnode.ImageKey = String.Join("\\", paths);
                nnode.SelectedImageKey = String.Join("\\", paths);
                pnode.Nodes.Add(nnode);

                if (panel != null)
                {
                    panel.OptionsChanged += new EventHandler(this.panel_OptionsChanged);
                    panel.Dock = DockStyle.Fill;
                    panel.PanelAdded(this);

                    this.EnableDescrControl(panel);
                }
            }
            else if (paths.Length == 1)
            {
                nnode = new TreeNode(displayName);
                nnode.Name = optionCategory;
                this.CatTree.Nodes.Add(nnode);

                if (panel != null)
                {
                    panel.OptionsChanged += new EventHandler(this.panel_OptionsChanged);
                    panel.Dock = DockStyle.Fill;
                    panel.PanelAdded(this);

                    this.EnableDescrControl(panel);
                }
            }
        }

        private String[][] GetPaths(String path)
        {
            String[][] ret;

            String[] p = path.Split(new String[] { this.CatTree.PathSeparator }, StringSplitOptions.RemoveEmptyEntries);

            ret = new String[][] { new String[p.Length], new String[p.Length] };

            int i1, i2;
            for (int i = 0; i < p.Length; i++)
            {
                String sp = p[i];

                if ((i1 = sp.IndexOf("{\"")) > -1
                    && (i2 = sp.IndexOf("\"}")) > -1)
                {
                    ret[0][i] = sp.Substring(0, i1);
                    ret[1][i] = sp.Substring(i1 + 2, i2 - (i1 + 2));
                }
                else
                {
                    ret[0][i] = sp;
                    ret[1][i] = sp;
                }
            }

            return ret;
        }

        void panel_OptionsChanged(object sender, EventArgs e)
        {
            if (!this._ApplyAlwaysEnabled)
            {
                this.ApplyBtn.Enabled = true;
            }
        }

        private void EnableDescrControl(Control ctrl)
        {
            ctrl.MouseEnter += new EventHandler(this.MouseEnterDescr);
            ctrl.MouseLeave += new EventHandler(this.MouseLeaveDescr);

            foreach (Control ctrln in ctrl.Controls)
            {
                this.EnableDescrControl(ctrln);
            }
        }

        public OptionsPanel SwitchPanel(String optionCategory)
        {
            try
            {
                this.OptionsPanelPath.Text = "";

                if (this._Panels.Count > 0)
                {
                    OptionsPanel pn = null;

                    for (int i = 0; i < this._Panels.Count; i++)
                    {
                        if (this._Panels[i].CategoryPath == optionCategory)
                        {
                            pn = this._Panels[i];
                            break;
                        }
                    }

                    if (pn != null)
                    {
                        String displayName = pn.DisplayName;

                        String[][] lpaths = this.GetPaths(optionCategory);
                        String[] paths = lpaths[0];

                        if (paths.Length > 1)
                        {
                            TreeNode[] search = this.CatTree.Nodes.Find(paths[0], false);

                            if (search != null && search.Length > 0)
                            {
                                this.OptionsPanelPath.Text += search[0].Text + " » ";

                                int i = 1;
                                int sub = paths.Length - 1;
                                for (; i < sub; i++)
                                {
                                    search = search[0].Nodes.Find(paths[i], false);

                                    if (search != null && search.Length > 0)
                                    {
                                        this.OptionsPanelPath.Text += search[0].Text + " » ";
                                    }
                                }

                            }
                        }

                        this.OptionsPanelPath.Text += displayName;

                        if (this.OptionPanelContainer.Controls.Count == 0 || !this.OptionPanelContainer.Controls[0].Equals(pn))
                        {
                            this.OptionPanelContainer.Controls.Clear();
                            this.OptionPanelContainer.Controls.Add(pn);

                            pn.Visible = true;
                        }

                        return pn;
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private void CatTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.GoToFirstPanel(e.Node);
        }

        private void GoToFirstPanel(TreeNode selectedNode)
        {
            if (selectedNode.Nodes != null && selectedNode.Nodes.Count > 0)
            {
                selectedNode.Expand();

                if (this._SelectFirstPanel)
                {
                    selectedNode.TreeView.SelectedNode = selectedNode.Nodes[0];
                }
                else
                {
                    this.GoToFirstPanel(selectedNode.Nodes[0]);
                }
            }
            else
            {
                OptionsPanel pn = this.SwitchPanel(selectedNode.Name);

                if (pn != null && !String.IsNullOrEmpty(pn.AccessibleDescription))
                {
                    this.CatDescr.Text = pn.AccessibleDescription;
                }
                else
                {
                    this.CatDescr.Text = this.OptionsNoDescription;
                }
            }
        }

        void _AppSettings_SettingChanging(object sender, SettingChangingEventArgs e)
        {
            if (!this._Saving)
            {
                try
                {
                    SettingsProperty value = (SettingsProperty)this._Settings[e.SettingName];
                    Object sval = this._AppSettings[e.SettingName];

                    if (value != null && sval != null)
                    {
                        if (!sval.Equals(e.NewValue))
                        {
                            try
                            {
                                if (!this._ChangedSettings.ContainsKey(e.SettingName))
                                {
                                    this._ChangedSettings.Add(e.SettingName, value.DefaultValue);
                                }
                            }
                            catch
                            {
                                this._ChangedSettings.Add(e.SettingName, value.DefaultValue);
                            }
                        }
                        else
                        {
                            try
                            {
                                this._ChangedSettings.Remove(e.SettingName);
                            }
                            catch
                            { }
                        }

                        if (!this._ApplyAlwaysEnabled)
                        {
                            if (this._ChangedSettings.Count > 0)
                            {
                                this.ApplyBtn.Enabled = true;
                            }
                            else
                            {
                                this.ApplyBtn.Enabled = false;
                            }
                        }

                        value.DefaultValue = e.NewValue;
                        e.Cancel = true;
                    }
                }
                catch
                { }
            }
        }

        public void OnSaveOptions()
        {
            this._Saving = true;

            if (this.OptionsSaving != null)
            {
                this.OptionsSaving(this, EventArgs.Empty);
            }

            foreach (SettingsProperty sett in this._Settings)
            {
                try
                {
                    this._AppSettings[sett.Name] = sett.DefaultValue;
                }
                catch
                { }
            }

            if (this._AutomaticSaveSettings)
            {
                this._AppSettings.Save();
                this._AppSettings.Reload();

                if (this.OptionsSaved != null)
                {
                    this.OptionsSaved(this, EventArgs.Empty);
                }
            }

            this._Saving = false;
        }

        public void OnResetOptions()
        {
            if (this.ResetForm != null)
            {
                this.ResetForm(this, EventArgs.Empty);
            }

            if (!this._ApplyAlwaysEnabled)
            {
                this.ApplyBtn.Enabled = false;
            }
        }

        public void MouseEnterDescr(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;

            if (ctrl != null && !String.IsNullOrEmpty(ctrl.AccessibleDescription))
            {
                this.OptionDescrLabel.Text = ctrl.AccessibleDescription;
            }
            else
            {
                this.OptionDescrLabel.Text = this.OptionsNoDescription;
            }
        }

        public void MouseLeaveDescr(object sender, EventArgs e)
        {
            this.OptionDescrLabel.Text = this._OptionsNoDescription;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this._OkClicked = true;
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            this.OnSaveOptions();

            if (!this._ApplyAlwaysEnabled)
            {
                this.ApplyBtn.Enabled = false;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this._OkClicked = false;
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Visible = false;

            if (this._OkClicked)
            {
                this.OnSaveOptions();
            }
            else
            {
                this.OnResetOptions();
            }
        }

        #endregion
    }

    internal sealed class Settings : ApplicationSettingsBase
    {
    }
}