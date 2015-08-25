namespace EcIDE
{
    using Telerik.WinControls.UI;

    sealed partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.Docking.AutoHideGroup autoHideGroup1 = new Telerik.WinControls.UI.Docking.AutoHideGroup();
            Telerik.WinControls.UI.Docking.AutoHideGroup autoHideGroup2 = new Telerik.WinControls.UI.Docking.AutoHideGroup();
            Telerik.WinControls.UI.Docking.AutoHideGroup autoHideGroup3 = new Telerik.WinControls.UI.Docking.AutoHideGroup();
            Telerik.WinControls.UI.Docking.AutoHideGroup autoHideGroup4 = new Telerik.WinControls.UI.Docking.AutoHideGroup();
            Telerik.WinControls.UI.Docking.AutoHideGroup autoHideGroup5 = new Telerik.WinControls.UI.Docking.AutoHideGroup();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Properties");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("TestFile");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("TestFolder", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("main.ec");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Project", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3,
            treeNode4});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dockWindowPlaceholder4 = new Telerik.WinControls.UI.Docking.DockWindowPlaceholder();
            this.dockWindowPlaceholder5 = new Telerik.WinControls.UI.Docking.DockWindowPlaceholder();
            this.dockWindowPlaceholder1 = new Telerik.WinControls.UI.Docking.DockWindowPlaceholder();
            this.dockWindowPlaceholder2 = new Telerik.WinControls.UI.Docking.DockWindowPlaceholder();
            this.dockWindowPlaceholder3 = new Telerik.WinControls.UI.Docking.DockWindowPlaceholder();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadecbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.findReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.buildNoConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildShowConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildEcRuntimeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuView = new System.Windows.Forms.ToolStripMenuItem();
            this.projectExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NumberOfNotsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dock = new Telerik.WinControls.UI.Docking.RadDock();
            this.ProjectExplorerWindow = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.explorerTree = new System.Windows.Forms.TreeView();
            this.IconImageList = new System.Windows.Forms.ImageList(this.components);
            this.stateImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolTabStrip6 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.radSplitContainer2 = new Telerik.WinControls.UI.RadSplitContainer();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.documentWindow1 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolTabStrip1 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.DocumentWindow = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.documentMap1 = new FastColoredTextBoxNS.DocumentMap();
            this.toolTabStrip2 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.toolTabStrip3 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.toolTabStrip4 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.errorsWindow = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.errorLb = new System.Windows.Forms.ListBox();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.RadDesktopAlert = new Telerik.WinControls.UI.RadDesktopAlert(this.components);
            this.NotificationTimer = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new Telerik.WinControls.UI.RadStatusStrip();
            this.propertiesWindow = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.projectProperties1 = new EcIDE.Internals.UI.Properties.ProjectProperties();
            this.MapWindow = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.map1 = new EcIDE.CodeMap.Map();
            this.ConsoleWindow = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.console = new EcIDE.Internals.UI.ShellControl.ShellControl();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dock)).BeginInit();
            this.dock.SuspendLayout();
            this.ProjectExplorerWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip6)).BeginInit();
            this.toolTabStrip6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).BeginInit();
            this.radSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            this.documentWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).BeginInit();
            this.toolTabStrip1.SuspendLayout();
            this.DocumentWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip2)).BeginInit();
            this.toolTabStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip3)).BeginInit();
            this.toolTabStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip4)).BeginInit();
            this.toolTabStrip4.SuspendLayout();
            this.errorsWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBar)).BeginInit();
            this.propertiesWindow.SuspendLayout();
            this.MapWindow.SuspendLayout();
            this.ConsoleWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockWindowPlaceholder4
            // 
            this.dockWindowPlaceholder4.DockWindowName = "errorsWindow";
            this.dockWindowPlaceholder4.DockWindowText = "Errors";
            this.dockWindowPlaceholder4.Location = new System.Drawing.Point(0, 0);
            this.dockWindowPlaceholder4.Name = "dockWindowPlaceholder4";
            this.dockWindowPlaceholder4.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.dockWindowPlaceholder4.Size = new System.Drawing.Size(200, 200);
            this.dockWindowPlaceholder4.Text = "dockWindowPlaceholder4";
            // 
            // dockWindowPlaceholder5
            // 
            this.dockWindowPlaceholder5.DockWindowName = "ConsoleWindow";
            this.dockWindowPlaceholder5.DockWindowText = "Console";
            this.dockWindowPlaceholder5.Location = new System.Drawing.Point(0, 0);
            this.dockWindowPlaceholder5.Name = "dockWindowPlaceholder5";
            this.dockWindowPlaceholder5.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.dockWindowPlaceholder5.Size = new System.Drawing.Size(200, 200);
            this.dockWindowPlaceholder5.Text = "dockWindowPlaceholder5";
            // 
            // dockWindowPlaceholder1
            // 
            this.dockWindowPlaceholder1.DockWindowName = "ProjectExplorerWindow";
            this.dockWindowPlaceholder1.DockWindowText = "ProjectExplorer";
            this.dockWindowPlaceholder1.Location = new System.Drawing.Point(0, 0);
            this.dockWindowPlaceholder1.Name = "dockWindowPlaceholder1";
            this.dockWindowPlaceholder1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.dockWindowPlaceholder1.Size = new System.Drawing.Size(200, 200);
            this.dockWindowPlaceholder1.Text = "dockWindowPlaceholder1";
            // 
            // dockWindowPlaceholder2
            // 
            this.dockWindowPlaceholder2.DockWindowName = "DocumentWindow";
            this.dockWindowPlaceholder2.DockWindowText = "Document";
            this.dockWindowPlaceholder2.Location = new System.Drawing.Point(0, 0);
            this.dockWindowPlaceholder2.Name = "dockWindowPlaceholder2";
            this.dockWindowPlaceholder2.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.dockWindowPlaceholder2.Size = new System.Drawing.Size(200, 200);
            this.dockWindowPlaceholder2.Text = "dockWindowPlaceholder2";
            // 
            // dockWindowPlaceholder3
            // 
            this.dockWindowPlaceholder3.DockWindowName = "MapWindow";
            this.dockWindowPlaceholder3.DockWindowText = "Map";
            this.dockWindowPlaceholder3.Location = new System.Drawing.Point(0, 0);
            this.dockWindowPlaceholder3.Name = "dockWindowPlaceholder3";
            this.dockWindowPlaceholder3.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.dockWindowPlaceholder3.Size = new System.Drawing.Size(200, 200);
            this.dockWindowPlaceholder3.Text = "dockWindowPlaceholder3";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuEdit,
            this.MenuDebug,
            this.MenuBuild,
            this.MenuView,
            this.notificationsToolStripMenuItem,
            this.NumberOfNotsItem,
            this.extrasToolStripMenuItem});
            this.MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1059, 24);
            this.MainMenu.TabIndex = 0;
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.loadecbToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(37, 20);
            this.MenuFile.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadecbToolStripMenuItem
            // 
            this.loadecbToolStripMenuItem.Name = "loadecbToolStripMenuItem";
            this.loadecbToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.loadecbToolStripMenuItem.Text = "Load .ecb";
            this.loadecbToolStripMenuItem.Click += new System.EventHandler(this.loadecbToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // MenuEdit
            // 
            this.MenuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.findReplaceToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.toolStripSeparator2,
            this.goToToolStripMenuItem});
            this.MenuEdit.Name = "MenuEdit";
            this.MenuEdit.Size = new System.Drawing.Size(39, 20);
            this.MenuEdit.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(112, 6);
            // 
            // findReplaceToolStripMenuItem
            // 
            this.findReplaceToolStripMenuItem.Name = "findReplaceToolStripMenuItem";
            this.findReplaceToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.findReplaceToolStripMenuItem.Text = "Find";
            this.findReplaceToolStripMenuItem.Click += new System.EventHandler(this.findReplaceToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(112, 6);
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.goToToolStripMenuItem.Text = "GoTo";
            this.goToToolStripMenuItem.Click += new System.EventHandler(this.goToToolStripMenuItem_Click);
            // 
            // MenuDebug
            // 
            this.MenuDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.MenuDebug.Name = "MenuDebug";
            this.MenuDebug.Size = new System.Drawing.Size(54, 20);
            this.MenuDebug.Text = "Debug";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // MenuBuild
            // 
            this.MenuBuild.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildNoConsoleToolStripMenuItem,
            this.buildShowConsoleToolStripMenuItem,
            this.buildEcRuntimeFileToolStripMenuItem});
            this.MenuBuild.Name = "MenuBuild";
            this.MenuBuild.Size = new System.Drawing.Size(46, 20);
            this.MenuBuild.Text = "Build";
            this.MenuBuild.Click += new System.EventHandler(this.buildToolStripMenuItem_Click);
            // 
            // buildNoConsoleToolStripMenuItem
            // 
            this.buildNoConsoleToolStripMenuItem.Name = "buildNoConsoleToolStripMenuItem";
            this.buildNoConsoleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buildNoConsoleToolStripMenuItem.Text = "Build hide Console";
            this.buildNoConsoleToolStripMenuItem.Click += new System.EventHandler(this.buildNoConsoleToolStripMenuItem_Click);
            // 
            // buildShowConsoleToolStripMenuItem
            // 
            this.buildShowConsoleToolStripMenuItem.Name = "buildShowConsoleToolStripMenuItem";
            this.buildShowConsoleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buildShowConsoleToolStripMenuItem.Text = "Build show Console";
            this.buildShowConsoleToolStripMenuItem.Click += new System.EventHandler(this.buildShowConsoleToolStripMenuItem_Click);
            // 
            // buildEcRuntimeFileToolStripMenuItem
            // 
            this.buildEcRuntimeFileToolStripMenuItem.Name = "buildEcRuntimeFileToolStripMenuItem";
            this.buildEcRuntimeFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buildEcRuntimeFileToolStripMenuItem.Text = "Build ec runtime file";
            this.buildEcRuntimeFileToolStripMenuItem.Click += new System.EventHandler(this.buildEcRuntimeFileToolStripMenuItem_Click);
            // 
            // MenuView
            // 
            this.MenuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectExplorerToolStripMenuItem,
            this.consoleToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.documentToolStripMenuItem,
            this.errorsToolStripMenuItem});
            this.MenuView.Name = "MenuView";
            this.MenuView.Size = new System.Drawing.Size(44, 20);
            this.MenuView.Text = "View";
            // 
            // projectExplorerToolStripMenuItem
            // 
            this.projectExplorerToolStripMenuItem.Name = "projectExplorerToolStripMenuItem";
            this.projectExplorerToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.projectExplorerToolStripMenuItem.Text = "ProjectExplorer";
            this.projectExplorerToolStripMenuItem.Click += new System.EventHandler(this.projectExplorerToolStripMenuItem_Click);
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.mapToolStripMenuItem.Text = "Map";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click);
            // 
            // documentToolStripMenuItem
            // 
            this.documentToolStripMenuItem.Name = "documentToolStripMenuItem";
            this.documentToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.documentToolStripMenuItem.Text = "Document";
            this.documentToolStripMenuItem.Click += new System.EventHandler(this.documentToolStripMenuItem_Click);
            // 
            // errorsToolStripMenuItem
            // 
            this.errorsToolStripMenuItem.Name = "errorsToolStripMenuItem";
            this.errorsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.errorsToolStripMenuItem.Text = "Errors";
            this.errorsToolStripMenuItem.Click += new System.EventHandler(this.errorsToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.Image = global::EcIDE.Properties.Resources.notifications;
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            this.notificationsToolStripMenuItem.Click += new System.EventHandler(this.notificationsToolStripMenuItem_Click);
            // 
            // NumberOfNotsItem
            // 
            this.NumberOfNotsItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NumberOfNotsItem.ForeColor = System.Drawing.Color.Red;
            this.NumberOfNotsItem.Margin = new System.Windows.Forms.Padding(-10, 0, 0, 0);
            this.NumberOfNotsItem.Name = "NumberOfNotsItem";
            this.NumberOfNotsItem.Size = new System.Drawing.Size(25, 20);
            this.NumberOfNotsItem.Text = "0";
            this.NumberOfNotsItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.NumberOfNotsItem.Visible = false;
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.addinsToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.extrasToolStripMenuItem.Text = "Extras";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // addinsToolStripMenuItem
            // 
            this.addinsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installToolStripMenuItem});
            this.addinsToolStripMenuItem.Name = "addinsToolStripMenuItem";
            this.addinsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.addinsToolStripMenuItem.Text = "Addins";
            // 
            // installToolStripMenuItem
            // 
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            this.installToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.installToolStripMenuItem.Text = "Install";
            this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
            // 
            // dock
            // 
            this.dock.ActiveWindow = this.ProjectExplorerWindow;
            this.dock.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dock.CausesValidation = false;
            this.dock.Controls.Add(this.toolTabStrip6);
            this.dock.Controls.Add(this.radSplitContainer2);
            this.dock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dock.IsCleanUpTarget = true;
            this.dock.Location = new System.Drawing.Point(0, 24);
            this.dock.MainDocumentContainer = this.documentContainer1;
            this.dock.Name = "dock";
            this.dock.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.dock.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 24, 1059, 498);
            this.dock.RootElement.MinSize = new System.Drawing.Size(25, 25);
            autoHideGroup1.Windows.Add(this.dockWindowPlaceholder4);
            autoHideGroup2.Windows.Add(this.dockWindowPlaceholder5);
            this.dock.SerializableAutoHideContainer.BottomAutoHideGroups.Add(autoHideGroup1);
            this.dock.SerializableAutoHideContainer.BottomAutoHideGroups.Add(autoHideGroup2);
            autoHideGroup3.Windows.Add(this.dockWindowPlaceholder1);
            this.dock.SerializableAutoHideContainer.LeftAutoHideGroups.Add(autoHideGroup3);
            autoHideGroup4.Windows.Add(this.dockWindowPlaceholder2);
            autoHideGroup5.Windows.Add(this.dockWindowPlaceholder3);
            this.dock.SerializableAutoHideContainer.RightAutoHideGroups.Add(autoHideGroup4);
            this.dock.SerializableAutoHideContainer.RightAutoHideGroups.Add(autoHideGroup5);
            this.dock.Size = new System.Drawing.Size(1059, 498);
            this.dock.SplitterWidth = 3;
            this.dock.TabIndex = 1;
            this.dock.TabStop = false;
            this.dock.ThemeName = "Office2010Silver";
            // 
            // ProjectExplorerWindow
            // 
            this.ProjectExplorerWindow.Caption = null;
            this.ProjectExplorerWindow.Controls.Add(this.explorerTree);
            this.ProjectExplorerWindow.Location = new System.Drawing.Point(1, 23);
            this.ProjectExplorerWindow.Name = "ProjectExplorerWindow";
            this.ProjectExplorerWindow.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.ProjectExplorerWindow.Size = new System.Drawing.Size(198, 473);
            this.ProjectExplorerWindow.Text = "ProjectExplorer";
            // 
            // explorerTree
            // 
            this.explorerTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerTree.ImageIndex = 0;
            this.explorerTree.ImageList = this.IconImageList;
            this.explorerTree.Location = new System.Drawing.Point(0, 0);
            this.explorerTree.Name = "explorerTree";
            treeNode1.ImageKey = "gnome_document_properties.png";
            treeNode1.Name = "PropertiesNode";
            treeNode1.SelectedImageKey = "gnome_document_properties.png";
            treeNode1.StateImageKey = "(Keine)";
            treeNode1.Text = "Properties";
            treeNode2.ImageKey = "new_document.png";
            treeNode2.Name = "Knoten4";
            treeNode2.SelectedImageKey = "new_document.png";
            treeNode2.StateImageKey = "lock.png";
            treeNode2.Text = "TestFile";
            treeNode3.ImageKey = "folder.png";
            treeNode3.Name = "Knoten2";
            treeNode3.SelectedImageKey = "folder.png";
            treeNode3.Text = "TestFolder";
            treeNode4.ImageKey = "new_document.png";
            treeNode4.Name = "Knoten3";
            treeNode4.SelectedImageKey = "new_document.png";
            treeNode4.StateImageKey = "pencil_small.png";
            treeNode4.Text = "main.ec";
            treeNode5.ImageKey = "script.ico";
            treeNode5.Name = "ProjectTreeRoot";
            treeNode5.SelectedImageKey = "script.ico";
            treeNode5.StateImageKey = "(Keine)";
            treeNode5.Text = "Project";
            this.explorerTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.explorerTree.SelectedImageIndex = 0;
            this.explorerTree.ShowLines = false;
            this.explorerTree.ShowRootLines = false;
            this.explorerTree.Size = new System.Drawing.Size(198, 473);
            this.explorerTree.StateImageList = this.stateImageList;
            this.explorerTree.TabIndex = 2;
            this.explorerTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.explorerTree_AfterSelect);
            // 
            // IconImageList
            // 
            this.IconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconImageList.ImageStream")));
            this.IconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconImageList.Images.SetKeyName(0, "EClang-logo-icon-largefilesize.ico");
            this.IconImageList.Images.SetKeyName(1, "gnome_document_properties.png");
            this.IconImageList.Images.SetKeyName(2, "folder.png");
            this.IconImageList.Images.SetKeyName(3, "new_document.png");
            // 
            // stateImageList
            // 
            this.stateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateImageList.ImageStream")));
            this.stateImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.stateImageList.Images.SetKeyName(0, "folder_classic_opened_stuffed.png");
            this.stateImageList.Images.SetKeyName(1, "lock.png");
            this.stateImageList.Images.SetKeyName(2, "pencil_small.png");
            // 
            // toolTabStrip6
            // 
            this.toolTabStrip6.CanUpdateChildIndex = true;
            this.toolTabStrip6.Controls.Add(this.ProjectExplorerWindow);
            this.toolTabStrip6.Location = new System.Drawing.Point(0, 0);
            this.toolTabStrip6.Name = "toolTabStrip6";
            // 
            // 
            // 
            this.toolTabStrip6.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabStrip6.SelectedIndex = 0;
            this.toolTabStrip6.Size = new System.Drawing.Size(200, 498);
            this.toolTabStrip6.TabIndex = 1;
            this.toolTabStrip6.TabStop = false;
            this.toolTabStrip6.ThemeName = "Office2010Silver";
            // 
            // radSplitContainer2
            // 
            this.radSplitContainer2.CausesValidation = false;
            this.radSplitContainer2.Controls.Add(this.radSplitContainer1);
            this.radSplitContainer2.Controls.Add(this.toolTabStrip3);
            this.radSplitContainer2.Controls.Add(this.toolTabStrip4);
            this.radSplitContainer2.IsCleanUpTarget = true;
            this.radSplitContainer2.Location = new System.Drawing.Point(203, 0);
            this.radSplitContainer2.Name = "radSplitContainer2";
            this.radSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.radSplitContainer2.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.radSplitContainer2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer2.Size = new System.Drawing.Size(856, 498);
            this.radSplitContainer2.TabIndex = 0;
            this.radSplitContainer2.TabStop = false;
            this.radSplitContainer2.ThemeName = "Office2010Silver";
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radSplitContainer1.CausesValidation = false;
            this.radSplitContainer1.Controls.Add(this.documentContainer1);
            this.radSplitContainer1.Controls.Add(this.toolTabStrip1);
            this.radSplitContainer1.Controls.Add(this.toolTabStrip2);
            this.radSplitContainer1.IsCleanUpTarget = true;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            this.radSplitContainer1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 856, 129);
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer1.Size = new System.Drawing.Size(856, 129);
            this.radSplitContainer1.SizeInfo.AbsoluteSize = new System.Drawing.Size(200, 155);
            this.radSplitContainer1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 37);
            this.radSplitContainer1.TabIndex = 0;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.ThemeName = "Office2010Silver";
            // 
            // documentContainer1
            // 
            this.documentContainer1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.documentContainer1.CausesValidation = false;
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 450, 129);
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 3;
            this.documentContainer1.ThemeName = "Office2010Silver";
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.CausesValidation = false;
            this.documentTabStrip1.Controls.Add(this.propertiesWindow);
            this.documentTabStrip1.Controls.Add(this.documentWindow1);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 450, 129);
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.SelectedIndex = 1;
            this.documentTabStrip1.Size = new System.Drawing.Size(450, 129);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "Office2010Silver";
            // 
            // documentWindow1
            // 
            this.documentWindow1.Controls.Add(this.fastColoredTextBox1);
            this.documentWindow1.Location = new System.Drawing.Point(6, 27);
            this.documentWindow1.Name = "documentWindow1";
            this.documentWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow1.Size = new System.Drawing.Size(438, 96);
            this.documentWindow1.Text = "main.ec";
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(339, 126);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.CharHeight = 14;
            this.fastColoredTextBox1.CharWidth = 8;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Location = new System.Drawing.Point(0, 0);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(438, 96);
            this.fastColoredTextBox1.TabIndex = 0;
            this.fastColoredTextBox1.Text = "import System\r\nimport System.Windows.Forms\r\n\r\ndef Main() : string \r\n    #Show mes" +
    "sage that says hello world\r\n    Console.WriteLine(\"hello world\"); \r\nend def\r\n\r\nM" +
    "ain();";
            this.fastColoredTextBox1.Zoom = 100;
            this.fastColoredTextBox1.ToolTipNeeded += new System.EventHandler<FastColoredTextBoxNS.ToolTipNeededEventArgs>(this.fastColoredTextBox1_ToolTipNeeded);
            this.fastColoredTextBox1.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fastColoredTextBox1_TextChanged);
            this.fastColoredTextBox1.AutoIndentNeeded += new System.EventHandler<FastColoredTextBoxNS.AutoIndentEventArgs>(this.fastColoredTextBox1_AutoIndentNeeded);
            // 
            // toolTabStrip1
            // 
            this.toolTabStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolTabStrip1.CanUpdateChildIndex = true;
            this.toolTabStrip1.Controls.Add(this.DocumentWindow);
            this.toolTabStrip1.Location = new System.Drawing.Point(453, 0);
            this.toolTabStrip1.Name = "toolTabStrip1";
            // 
            // 
            // 
            this.toolTabStrip1.RootElement.ControlBounds = new System.Drawing.Rectangle(453, 0, 200, 129);
            this.toolTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabStrip1.SelectedIndex = 0;
            this.toolTabStrip1.Size = new System.Drawing.Size(200, 129);
            this.toolTabStrip1.TabIndex = 1;
            this.toolTabStrip1.TabStop = false;
            this.toolTabStrip1.ThemeName = "Office2010Silver";
            // 
            // DocumentWindow
            // 
            this.DocumentWindow.Caption = null;
            this.DocumentWindow.Controls.Add(this.documentMap1);
            this.DocumentWindow.Location = new System.Drawing.Point(1, 23);
            this.DocumentWindow.Name = "DocumentWindow";
            this.DocumentWindow.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.DocumentWindow.Size = new System.Drawing.Size(198, 104);
            this.DocumentWindow.Text = "Document";
            // 
            // documentMap1
            // 
            this.documentMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentMap1.ForeColor = System.Drawing.Color.Maroon;
            this.documentMap1.Location = new System.Drawing.Point(0, 0);
            this.documentMap1.Name = "documentMap1";
            this.documentMap1.Size = new System.Drawing.Size(198, 104);
            this.documentMap1.TabIndex = 0;
            this.documentMap1.Target = this.fastColoredTextBox1;
            // 
            // toolTabStrip2
            // 
            this.toolTabStrip2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolTabStrip2.CanUpdateChildIndex = true;
            this.toolTabStrip2.Controls.Add(this.MapWindow);
            this.toolTabStrip2.Location = new System.Drawing.Point(656, 0);
            this.toolTabStrip2.Name = "toolTabStrip2";
            // 
            // 
            // 
            this.toolTabStrip2.RootElement.ControlBounds = new System.Drawing.Rectangle(656, 0, 200, 129);
            this.toolTabStrip2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabStrip2.SelectedIndex = 0;
            this.toolTabStrip2.Size = new System.Drawing.Size(200, 129);
            this.toolTabStrip2.TabIndex = 2;
            this.toolTabStrip2.TabStop = false;
            this.toolTabStrip2.ThemeName = "Office2010Silver";
            // 
            // toolTabStrip3
            // 
            this.toolTabStrip3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolTabStrip3.CanUpdateChildIndex = true;
            this.toolTabStrip3.CausesValidation = false;
            this.toolTabStrip3.Controls.Add(this.ConsoleWindow);
            this.toolTabStrip3.Location = new System.Drawing.Point(0, 132);
            this.toolTabStrip3.Name = "toolTabStrip3";
            // 
            // 
            // 
            this.toolTabStrip3.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 132, 856, 163);
            this.toolTabStrip3.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabStrip3.SelectedIndex = 0;
            this.toolTabStrip3.Size = new System.Drawing.Size(856, 163);
            this.toolTabStrip3.SizeInfo.AbsoluteSize = new System.Drawing.Size(200, 163);
            this.toolTabStrip3.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -37);
            this.toolTabStrip3.TabIndex = 1;
            this.toolTabStrip3.TabStop = false;
            this.toolTabStrip3.ThemeName = "Office2010Silver";
            // 
            // toolTabStrip4
            // 
            this.toolTabStrip4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolTabStrip4.CanUpdateChildIndex = true;
            this.toolTabStrip4.Controls.Add(this.errorsWindow);
            this.toolTabStrip4.Location = new System.Drawing.Point(0, 298);
            this.toolTabStrip4.Name = "toolTabStrip4";
            // 
            // 
            // 
            this.toolTabStrip4.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 298, 856, 200);
            this.toolTabStrip4.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabStrip4.SelectedIndex = 0;
            this.toolTabStrip4.Size = new System.Drawing.Size(856, 200);
            this.toolTabStrip4.TabIndex = 2;
            this.toolTabStrip4.TabStop = false;
            this.toolTabStrip4.ThemeName = "Office2010Silver";
            // 
            // errorsWindow
            // 
            this.errorsWindow.Caption = null;
            this.errorsWindow.Controls.Add(this.errorLb);
            this.errorsWindow.Location = new System.Drawing.Point(1, 23);
            this.errorsWindow.Name = "errorsWindow";
            this.errorsWindow.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.errorsWindow.Size = new System.Drawing.Size(854, 175);
            this.errorsWindow.Text = "Errors";
            // 
            // errorLb
            // 
            this.errorLb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorLb.FormattingEnabled = true;
            this.errorLb.Location = new System.Drawing.Point(0, 0);
            this.errorLb.Name = "errorLb";
            this.errorLb.Size = new System.Drawing.Size(854, 175);
            this.errorLb.TabIndex = 0;
            // 
            // RadDesktopAlert
            // 
            this.RadDesktopAlert.AutoCloseDelay = 8;
            this.RadDesktopAlert.CanMove = false;
            this.RadDesktopAlert.CaptionText = "test";
            this.RadDesktopAlert.ContentText = "jnhgtrf";
            this.RadDesktopAlert.FadeAnimationFrames = 40;
            this.RadDesktopAlert.FadeAnimationSpeed = 40;
            this.RadDesktopAlert.Opacity = 1F;
            this.RadDesktopAlert.PopupAnimationDirection = Telerik.WinControls.UI.RadDirection.Left;
            this.RadDesktopAlert.ScreenPosition = Telerik.WinControls.UI.AlertScreenPosition.TopRight;
            this.RadDesktopAlert.ShowPinButton = false;
            this.RadDesktopAlert.ThemeName = "Office2010Silver";
            // 
            // NotificationTimer
            // 
            this.NotificationTimer.Enabled = true;
            this.NotificationTimer.Interval = 1;
            this.NotificationTimer.Tick += new System.EventHandler(this.NotificationTimer_Tick);
            // 
            // statusBar
            // 
            this.statusBar.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Overflow;
            this.statusBar.Location = new System.Drawing.Point(0, 522);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1059, 26);
            this.statusBar.TabIndex = 2;
            this.statusBar.ThemeName = "Office2010Silver";
            // 
            // propertiesWindow
            // 
            this.propertiesWindow.Controls.Add(this.projectProperties1);
            this.propertiesWindow.Location = new System.Drawing.Point(6, 27);
            this.propertiesWindow.Name = "propertiesWindow";
            this.propertiesWindow.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.propertiesWindow.Size = new System.Drawing.Size(438, 96);
            this.propertiesWindow.Text = "Properties";
            // 
            // projectProperties1
            // 
            this.projectProperties1.AutoScroll = true;
            this.projectProperties1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectProperties1.Location = new System.Drawing.Point(0, 0);
            this.projectProperties1.Name = "projectProperties1";
            this.projectProperties1.Size = new System.Drawing.Size(438, 96);
            this.projectProperties1.TabIndex = 0;
            this.projectProperties1.Text = "projectProperties1";
            // 
            // MapWindow
            // 
            this.MapWindow.Caption = null;
            this.MapWindow.Controls.Add(this.map1);
            this.MapWindow.Location = new System.Drawing.Point(1, 23);
            this.MapWindow.Name = "MapWindow";
            this.MapWindow.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.MapWindow.Size = new System.Drawing.Size(198, 104);
            this.MapWindow.Text = "Map";
            // 
            // map1
            // 
            this.map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map1.fctb = this.fastColoredTextBox1;
            this.map1.Location = new System.Drawing.Point(0, 0);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(198, 104);
            this.map1.TabIndex = 0;
            // 
            // ConsoleWindow
            // 
            this.ConsoleWindow.Caption = null;
            this.ConsoleWindow.Controls.Add(this.console);
            this.ConsoleWindow.Location = new System.Drawing.Point(1, 23);
            this.ConsoleWindow.Name = "ConsoleWindow";
            this.ConsoleWindow.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.ConsoleWindow.Size = new System.Drawing.Size(854, 138);
            this.ConsoleWindow.Text = "Console";
            // 
            // console
            // 
            this.console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Name = "console";
            this.console.Prompt = ">>>";
            this.console.ShellTextBackColor = System.Drawing.Color.Black;
            this.console.ShellTextFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.ShellTextForeColor = System.Drawing.Color.LawnGreen;
            this.console.Size = new System.Drawing.Size(854, 138);
            this.console.TabIndex = 0;
            this.console.CommandEntered += new EcIDE.Internals.UI.ShellControl.EventCommandEntered(this.console_CommandEntered);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 548);
            this.Controls.Add(this.dock);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "EcIDE Alpha";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dock)).EndInit();
            this.dock.ResumeLayout(false);
            this.ProjectExplorerWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip6)).EndInit();
            this.toolTabStrip6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).EndInit();
            this.radSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            this.documentWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).EndInit();
            this.toolTabStrip1.ResumeLayout(false);
            this.DocumentWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip2)).EndInit();
            this.toolTabStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip3)).EndInit();
            this.toolTabStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip4)).EndInit();
            this.toolTabStrip4.ResumeLayout(false);
            this.errorsWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBar)).EndInit();
            this.propertiesWindow.ResumeLayout(false);
            this.MapWindow.ResumeLayout(false);
            this.ConsoleWindow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private Telerik.WinControls.UI.Docking.RadDock dock;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;
        private Telerik.WinControls.UI.Docking.ToolWindow DocumentWindow;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip2;
        private Telerik.WinControls.UI.Docking.ToolWindow MapWindow;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private FastColoredTextBoxNS.DocumentMap documentMap1;
        private CodeMap.Map map1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuDebug;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem findReplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip3;
        private Telerik.WinControls.UI.Docking.ToolWindow ConsoleWindow;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip4;
        private Telerik.WinControls.UI.Docking.ToolWindow errorsWindow;
        private System.Windows.Forms.ListBox errorLb;
        private System.Windows.Forms.ToolStripMenuItem MenuBuild;
        private System.Windows.Forms.ToolStripMenuItem buildNoConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildShowConsoleToolStripMenuItem;
        private Telerik.WinControls.UI.RadDesktopAlert RadDesktopAlert;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NumberOfNotsItem;
        private System.Windows.Forms.Timer NotificationTimer;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip5;
        private System.Windows.Forms.ToolStripMenuItem buildEcRuntimeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadecbToolStripMenuItem;
        private Telerik.WinControls.UI.Docking.ToolWindow ProjectExplorerWindow;
        private System.Windows.Forms.TreeView explorerTree;
        private System.Windows.Forms.ImageList IconImageList;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip6;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer2;
        private Telerik.WinControls.UI.Docking.DockWindowPlaceholder dockWindowPlaceholder4;
        private Telerik.WinControls.UI.Docking.DockWindowPlaceholder dockWindowPlaceholder5;
        private Telerik.WinControls.UI.Docking.DockWindowPlaceholder dockWindowPlaceholder1;
        private Telerik.WinControls.UI.Docking.DockWindowPlaceholder dockWindowPlaceholder2;
        private Telerik.WinControls.UI.Docking.DockWindowPlaceholder dockWindowPlaceholder3;
        private Telerik.WinControls.UI.Docking.DocumentWindow propertiesWindow;
        private Internals.UI.Properties.ProjectProperties projectProperties1;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuView;
        private System.Windows.Forms.ToolStripMenuItem projectExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorsToolStripMenuItem;
        private System.Windows.Forms.ImageList stateImageList;
        private Internals.UI.ShellControl.ShellControl console;
        private System.Windows.Forms.ToolStripMenuItem addinsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
        private RadStatusStrip statusBar;
    }
}