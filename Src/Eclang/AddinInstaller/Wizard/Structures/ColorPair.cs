namespace AddinInstaller.Wizard.Structures
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    using AddinInstaller.Wizard.EventArgs;

    /// <summary>
    /// Represents two color pair with gradient angle.
    /// </summary>
    [Editor(typeof(ColorPairEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class ColorPair : ICloneable
    {
        #region Fields

        private Color backColor1;
        private Color backColor2;
        private int gradient;
        private readonly int currentDefaultGradient = 90;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPair"/> class.
        /// </summary>
        public ColorPair()
        {
            this.backColor1 = Color.Empty;
            this.backColor2 = Color.Empty;
            this.gradient = 90;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPair"/> class.
        /// </summary>
        /// <param name="backColor1">Start color.</param>
        /// <param name="backColor2">End color</param>
        /// <param name="gradient">Gradient of the brush.</param>
        public ColorPair(Color backColor1, Color backColor2, int gradient)
        {
            this.backColor1 = backColor1;
            this.backColor2 = backColor2;
            this.gradient = gradient;
            this.currentDefaultGradient = gradient;
        }

        #endregion

        #region Override

        ///<summary>
        ///Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override string ToString()
        {
            return "BackColor1 : " + this.backColor1 + ";" + "BackColor2 : " + this.backColor2 + ";" + "Gradient : " + this.gradient;
        }

        ///<summary>
        ///Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        ///</summary>
        ///
        ///<returns>
        ///A hash code for the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        ///<summary>
        ///Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///
        ///<returns>
        ///true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        ///</returns>
        ///
        ///<param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            ColorPair pair = obj as ColorPair;
            if (pair != null)
            {
                return pair.BackColor1.Equals(this.backColor1) && pair.BackColor2.Equals(this.backColor2) && pair.Gradient.Equals(this.gradient);
            }
            return false;
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets Start color.
        /// </summary>
        public Color BackColor1
        {
            get { return this.backColor1; }
            set
            {
                if (!this.backColor1.Equals(value))
                {
                    this.backColor1 = value;
                    this.OnAppearenceChanged(new GenericEventArgs<bool>(true));
                }
            }
        }

        /// <summary>
        /// Gets or sets End color.
        /// </summary>
        public Color BackColor2
        {
            get { return this.backColor2; }
            set
            {
                if (!this.backColor2.Equals(value))
                {
                    this.backColor2 = value;
                    this.OnAppearenceChanged(new GenericEventArgs<bool>(true));
                }
            }
        }

        /// <summary>
        /// Gets or sets Gradient.
        /// </summary>
        [Editor(typeof(GradientAngleEditor), typeof(UITypeEditor))]
        public int Gradient
        {
            get { return this.gradient; }
            set
            {
                if (!this.gradient.Equals(value))
                {
                    this.gradient = value;
                    this.OnAppearenceChanged(new GenericEventArgs<bool>(true));
                }
            }
        }

        #endregion

        public static bool operator ==(ColorPair p1, ColorPair p2)
        {
            if (ReferenceEquals(p1, null))
            {
                return ReferenceEquals(p2, null);
            }
            return p1.Equals(p2);

        }

        public static bool operator !=(ColorPair p1, ColorPair p2)
        {
            return !(p1 == p2);
        }

        public event GenericEventHandler<bool> AppearenceChanged;

        protected virtual void OnAppearenceChanged(GenericEventArgs<bool> e)
        {
            if (this.AppearenceChanged != null)
            {
                this.AppearenceChanged(this, e);
            }
        }

        #region IClonable member

        ///<summary>
        ///Creates a new object that is a copy of the current instance.
        ///</summary>
        ///
        ///<returns>
        ///A new object that is a copy of this instance.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public object Clone()
        {
            ColorPair pair = new ColorPair();
            pair.backColor1 = this.backColor1;
            pair.backColor2 = this.backColor2;
            pair.gradient = this.gradient;
            return pair;
        }

        #endregion

        #region Reset methods used by IDE

        public void ResetBackColor1()
        {
            this.backColor1 = Color.Empty;
        }

        public void ResetBackColor2()
        {
            this.backColor2 = Color.Empty;
        }

        public void ResetGradient()
        {
            this.gradient = 90;
        }

        #endregion

        #region Should Serialize methods used by IDE

        public bool ShouldSerializeBackColor1()
        {
            return !this.backColor1.IsEmpty;
        }

        public bool ShouldSerializeBackColor2()
        {
            return !this.backColor2.IsEmpty;
        }

        public bool ShouldSerializeGradient()
        {
            return this.gradient != this.currentDefaultGradient;
        }

        #endregion


        #region Nested class

        #region Nested type: ColorPairEditor

        /// <summary>
        /// UITypeEditor for <see cref="ColorPair"/> type.
        /// </summary>
        public class ColorPairEditor : UITypeEditor
        {
            #region Fields

            private DisplayStyleUI display;

            #endregion

            #region Override

            ///<summary>
            ///Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> method.
            ///</summary>
            ///
            ///<returns>
            ///The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
            ///</returns>
            ///
            ///<param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
            ///<param name="value">The object to edit. </param>
            ///<param name="provider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services. </param>
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                if (provider != null)
                {
                    IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                    if (edSvc == null)
                    {
                        return value;
                    }
                    if (this.display == null)
                    {
                        this.display = new DisplayStyleUI();
                    }
                    this.display.Start(edSvc, value);
                    edSvc.DropDownControl(this.display);
                    value = this.display.Value;
                    this.display.End();
                }
                return value;
            }

            ///<summary>
            ///Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
            ///</summary>
            ///
            ///<returns>
            ///A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"></see> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
            ///</returns>
            ///
            ///<param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.DropDown;
            }

            ///<summary>
            ///Indicates whether the specified context supports painting a representation of an object's value within the specified context.
            ///</summary>
            ///
            ///<returns>
            ///true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)"></see> is implemented; otherwise, false.
            ///</returns>
            ///
            ///<param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
            public override bool GetPaintValueSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            ///<summary>
            ///Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs"></see>.
            ///</summary>
            ///
            ///<param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs"></see> that indicates what to paint and where to paint it. </param>
            public override void PaintValue(PaintValueEventArgs e)
            {
                base.PaintValue(e);
                ColorPair pair = e.Value as ColorPair;
                if (pair != null)
                {
                    LinearGradientBrush br = new LinearGradientBrush(e.Bounds, pair.BackColor1, pair.BackColor2, pair.Gradient);
                    e.Graphics.FillRectangle(br, e.Bounds);
                }
            }

            #endregion
        }

        #endregion

        #region Nested type: DisplayStyleUI
        [ToolboxItem(false)]
        private class DisplayStyleUI : UserControl
        {
            #region Fields

            private Label lblBack1;
            private Label lblBack2;
            private Label lblCurrent;
            private Label lblGrad;
            private Label lblNew;
            private Label lblOldGrad;
            private Label lblPreview;
            private Panel pnlNewBack1;
            private Panel pnlNewBack2;
            private Panel pnlOldBack1;
            private Panel pnlOldBack2;
            private Panel pnlPreview;
            private GradientAngleEditor.GradientEditorUI gradUI;
            private ColorPair value;
            private IWindowsFormsEditorService edSvc;

            #endregion

            #region Constructor

            internal DisplayStyleUI()
            {
                this.InitializeComponent();
            }

            #endregion

            ///<summary>
            ///Raises the <see cref="E:System.Windows.Forms.Control.Validated"></see> event.
            ///</summary>
            ///
            ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
            protected override void OnValidated(EventArgs e)
            {
                this.value.BackColor1 = this.pnlNewBack1.BackColor;
                this.value.BackColor2 = this.pnlNewBack2.BackColor;
                this.value.Gradient = this.gradUI.Value;
            }

            #region Private Methods

            private void PaintPanel(PaintEventArgs e)
            {
                LinearGradientBrush brush1 = new LinearGradientBrush(this.pnlPreview.ClientRectangle, this.value.BackColor1, this.value.BackColor2, this.value.Gradient);
                e.Graphics.FillRectangle(brush1, this.pnlPreview.ClientRectangle);
            }

            #endregion

            #region Public property

            public ColorPair Value
            {
                get { return this.value; }
            }


            #endregion

            #region Designer generated code

            private void InitializeComponent()
            {
                this.pnlPreview = new System.Windows.Forms.Panel();
                this.lblPreview = new System.Windows.Forms.Label();
                this.lblBack1 = new System.Windows.Forms.Label();
                this.lblBack2 = new System.Windows.Forms.Label();
                this.lblGrad = new System.Windows.Forms.Label();
                this.pnlOldBack1 = new System.Windows.Forms.Panel();
                this.pnlOldBack2 = new System.Windows.Forms.Panel();
                this.lblOldGrad = new System.Windows.Forms.Label();
                this.lblCurrent = new System.Windows.Forms.Label();
                this.lblNew = new System.Windows.Forms.Label();
                this.pnlNewBack2 = new System.Windows.Forms.Panel();
                this.pnlNewBack1 = new System.Windows.Forms.Panel();
                this.gradUI = new GradientAngleEditor.GradientEditorUI();
                this.SuspendLayout();
                // 
                // pnlPreview
                // 
                this.pnlPreview.Location = new System.Drawing.Point(3, 20);
                this.pnlPreview.Name = "pnlPreview";
                this.pnlPreview.Size = new System.Drawing.Size(64, 136);
                this.pnlPreview.TabIndex = 0;
                this.pnlPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
                // 
                // lblPreview
                // 
                this.lblPreview.AutoSize = true;
                this.lblPreview.Location = new System.Drawing.Point(0, 4);
                this.lblPreview.Name = "lblPreview";
                this.lblPreview.Size = new System.Drawing.Size(69, 13);
                this.lblPreview.TabIndex = 1;
                this.lblPreview.Text = "&Preview area";
                // 
                // lblBack1
                // 
                this.lblBack1.AutoSize = true;
                this.lblBack1.Location = new System.Drawing.Point(73, 20);
                this.lblBack1.Name = "lblBack1";
                this.lblBack1.Size = new System.Drawing.Size(62, 13);
                this.lblBack1.TabIndex = 2;
                this.lblBack1.Text = "BackColor1";
                // 
                // lblBack2
                // 
                this.lblBack2.AutoSize = true;
                this.lblBack2.Location = new System.Drawing.Point(73, 45);
                this.lblBack2.Name = "lblBack2";
                this.lblBack2.Size = new System.Drawing.Size(62, 13);
                this.lblBack2.TabIndex = 3;
                this.lblBack2.Text = "BackColor2";
                // 
                // lblGrad
                // 
                this.lblGrad.AutoSize = true;
                this.lblGrad.Location = new System.Drawing.Point(73, 102);
                this.lblGrad.Name = "lblGrad";
                this.lblGrad.Size = new System.Drawing.Size(47, 13);
                this.lblGrad.TabIndex = 4;
                this.lblGrad.Text = "Gradient";
                // 
                // pnlOldBack1
                // 
                this.pnlOldBack1.BorderStyle = BorderStyle.FixedSingle;
                this.pnlOldBack1.Location = new System.Drawing.Point(169, 20);
                this.pnlOldBack1.Name = "pnlOldBack1";
                this.pnlOldBack1.Size = new System.Drawing.Size(13, 13);
                this.pnlOldBack1.TabIndex = 5;
                // 
                // pnlOldBack2
                // 
                this.pnlOldBack2.BorderStyle = BorderStyle.FixedSingle;
                this.pnlOldBack2.Location = new System.Drawing.Point(169, 45);
                this.pnlOldBack2.Name = "pnlOldBack2";
                this.pnlOldBack2.Size = new System.Drawing.Size(13, 13);
                this.pnlOldBack2.TabIndex = 6;
                // 
                // lblOldGrad
                // 
                this.lblOldGrad.AutoSize = true;
                this.lblOldGrad.Location = new System.Drawing.Point(166, 69);
                this.lblOldGrad.Name = "lblOldGrad";
                this.lblOldGrad.Size = new System.Drawing.Size(0, 13);
                this.lblOldGrad.TabIndex = 7;
                // 
                // lblCurrent
                // 
                this.lblCurrent.AutoSize = true;
                this.lblCurrent.Location = new System.Drawing.Point(145, 4);
                this.lblCurrent.Name = "lblCurrent";
                this.lblCurrent.Size = new System.Drawing.Size(70, 13);
                this.lblCurrent.TabIndex = 8;
                this.lblCurrent.Text = "&Current value";
                // 
                // lblNew
                // 
                this.lblNew.AutoSize = true;
                this.lblNew.Location = new System.Drawing.Point(243, 4);
                this.lblNew.Name = "lblNew";
                this.lblNew.Size = new System.Drawing.Size(58, 13);
                this.lblNew.TabIndex = 12;
                this.lblNew.Text = "&New value";
                // 
                // pnlNewBack2
                // 
                this.pnlNewBack2.BorderStyle = BorderStyle.FixedSingle;
                this.pnlNewBack2.Location = new System.Drawing.Point(269, 45);
                this.pnlNewBack2.Name = "pnlNewBack2";
                this.pnlNewBack2.Size = new System.Drawing.Size(13, 13);
                this.pnlNewBack2.TabIndex = 10;
                this.pnlNewBack2.Click += new System.EventHandler(this.pnlNewBack2_Click);
                // 
                // pnlNewBack1
                // 
                this.pnlNewBack1.BorderStyle = BorderStyle.FixedSingle;
                this.pnlNewBack1.Location = new System.Drawing.Point(269, 20);
                this.pnlNewBack1.Name = "pnlNewBack1";
                this.pnlNewBack1.Size = new System.Drawing.Size(13, 13);
                this.pnlNewBack1.TabIndex = 9;
                this.pnlNewBack1.Click += new System.EventHandler(this.pnlNewBack1_Click);
                // 
                // gradUI
                // 
                this.gradUI.AutoSize = true;
                this.gradUI.Location = new System.Drawing.Point(169, 64);
                this.gradUI.Name = "gradUI";
                this.gradUI.Size = new System.Drawing.Size(113, 90);
                this.gradUI.TabIndex = 14;
                this.gradUI.ValueChanged += new EventHandler(this.label1_ValueChanged);
                // 
                // DisplayStyleUI
                // 
                this.Controls.Add(this.gradUI);
                this.Controls.Add(this.lblNew);
                this.Controls.Add(this.pnlNewBack2);
                this.Controls.Add(this.pnlNewBack1);
                this.Controls.Add(this.lblCurrent);
                this.Controls.Add(this.lblOldGrad);
                this.Controls.Add(this.pnlOldBack2);
                this.Controls.Add(this.pnlOldBack1);
                this.Controls.Add(this.lblGrad);
                this.Controls.Add(this.lblBack2);
                this.Controls.Add(this.lblBack1);
                this.Controls.Add(this.lblPreview);
                this.Controls.Add(this.pnlPreview);
                this.Name = "DisplayStyleUI";
                this.Size = new System.Drawing.Size(314, 159);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            #region Public Method

            public void Start(IWindowsFormsEditorService service, object val)
            {
                this.edSvc = service;
                this.value = val as ColorPair;
                if (val != null)
                {
                    this.pnlOldBack1.BackColor = this.value.BackColor1;
                    this.pnlOldBack2.BackColor = this.value.BackColor2;
                    this.pnlNewBack1.BackColor = this.value.BackColor1;
                    this.pnlNewBack2.BackColor = this.value.BackColor2;
                    this.lblOldGrad.Text = this.value.Gradient.ToString();
                    this.gradUI.Value = this.value.Gradient;
                    this.pnlPreview.Refresh();
                }
            }

            public void End()
            {
                this.edSvc = null;
                this.value = null;
            }

            #endregion

            #region Event handler

            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                this.PaintPanel(e);
            }

            private void pnlNewBack2_Click(object sender, EventArgs e)
            {
                ColorDialog dlg = new ColorDialog();
                dlg.AllowFullOpen = true;
                dlg.AnyColor = true;
                dlg.Color = this.value.BackColor2;
                dlg.FullOpen = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.value.BackColor2 = dlg.Color;
                    this.pnlNewBack2.BackColor = dlg.Color;
                }
                this.pnlPreview.Refresh();
            }

            private void pnlNewBack1_Click(object sender, EventArgs e)
            {
                ColorDialog dlg = new ColorDialog();
                dlg.AllowFullOpen = true;
                dlg.AnyColor = true;
                dlg.Color = this.value.BackColor1;
                dlg.FullOpen = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.value.BackColor1 = dlg.Color;
                    this.pnlNewBack1.BackColor = dlg.Color;
                }
                this.pnlPreview.Refresh();
            }

            private void label1_ValueChanged(object sender, EventArgs e)
            {
                this.value.Gradient = this.gradUI.GetValue();
                this.pnlPreview.Refresh();
            }

            #endregion
        }

        #endregion

        private class GradientAngleEditor : UITypeEditor
        {
            ///<summary>
            ///Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
            ///</summary>
            ///
            ///<returns>
            ///A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"></see> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
            ///</returns>
            ///
            ///<param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                if (context != null && context.Instance != null)
                {
                    return UITypeEditorEditStyle.DropDown;
                }
                return base.GetEditStyle(context);
            }

            ///<summary>
            ///Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> method.
            ///</summary>
            ///
            ///<returns>
            ///The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
            ///</returns>
            ///
            ///<param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
            ///<param name="value">The object to edit. </param>
            ///<param name="provider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services. </param>
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                IWindowsFormsEditorService editorService;
                GradientEditorUI editor;

                if (context != null && context.Instance != null && provider != null)
                {
                    editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                    if (!(value is int && (int)value < 360 && (int)value >= 0))
                    {
                        value = 0;
                    }
                    if (editorService != null)
                    {
                        int currentValue = (int)value;
                        editor = new GradientEditorUI(currentValue);
                        editor.Dock = DockStyle.Fill;
                        editorService.DropDownControl(editor);
                        value = editor.GetValue();
                    }
                }
                editorService = null;
                return value;
            }

            ///<summary>
            ///Indicates whether the specified context supports painting a representation of an object's value within the specified context.
            ///</summary>
            ///
            ///<returns>
            ///true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)"></see> is implemented; otherwise, false.
            ///</returns>
            ///
            ///<param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
            public override bool GetPaintValueSupported(ITypeDescriptorContext context)
            {
                return false;
            }

            #region Nested type: GradientEditorUI

            [ToolboxItem(false)]
            internal class GradientEditorUI : UserControl
            {
                /// <summary> 
                /// Required designer variable.
                /// </summary>
                private readonly IContainer components = null;
                private int diameter;
                private int hoverValue;
                private int midx;
                private int midy;
                private int value;

                internal event EventHandler ValueChanged;

                internal virtual void OnValueChanged()
                {
                    if (this.ValueChanged != null)
                    {
                        this.ValueChanged(this, EventArgs.Empty);
                    }
                }

                internal GradientEditorUI()
                {
                    this.value = 0;
                    this.InitializeComponent();
                }

                internal GradientEditorUI(int value)
                {
                    this.value = value;
                    this.InitializeComponent();
                }

                public int Value
                {
                    get { return this.value; }
                    set
                    {
                        if (value != this.value)
                        {
                            this.value = value;
                            this.OnValueChanged();
                        }
                    }
                }

                ///<summary>
                ///Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
                ///</summary>
                ///
                ///<param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data. </param>
                protected override void OnPaint(PaintEventArgs e)
                {
                    this.PaintValue(e);
                }

                ///<summary>
                ///Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"></see> event.
                ///</summary>
                ///
                ///<param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data. </param>
                protected override void OnMouseDown(MouseEventArgs e)
                {
                    base.OnMouseDown(e);
                    if (this.HitTest(e.Location))
                    {
                        int angle = this.GetAngle(e.Location);
                        if (angle != -1)
                        {
                            this.value = angle;
                            this.OnValueChanged();
                        }
                        this.Invalidate();
                    }
                }

                ///<summary>
                ///Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"></see> event.
                ///</summary>
                ///
                ///<param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data. </param>
                protected override void OnMouseMove(MouseEventArgs e)
                {
                    base.OnMouseMove(e);
                    if (this.HitTest(e.Location))
                    {
                        int angle = this.GetAngle(e.Location);
                        if (angle != -1)
                        {
                            this.hoverValue = angle;
                        }
                        this.Invalidate(new Rectangle((int)(this.Width - this.diameter * 0.25), 1, (int)(0.25 * this.diameter), (int)(2 * this.Font.SizeInPoints)));
                    }
                }

                private bool HitTest(Point point)
                {
                    int distance = (int)Math.Sqrt((point.X - this.midx) * (point.X - this.midx) + (point.Y - this.midy) * (point.Y - this.midy));
                    return distance <= (this.diameter * 0.7) / 2;
                }

                private int GetAngle(Point p)
                {
                    if ((p.X - this.midx) != 0)
                    {
                        int ret = (int)((Math.Atan((p.Y - this.midy) / (float)(p.X - this.midx))) * (180) / Math.PI);
                        if ((p.Y - this.midy) >= 0 && (p.X - this.midx) <= 0)
                        {
                            ret = 180 + ret;
                        }
                        else if ((p.Y - this.midy) <= 0 && (p.X - this.midx) <= 0)
                        {
                            ret = 180 + ret;
                        }
                        else if ((p.Y - this.midy) <= 0 && (p.X - this.midx) >= 0)
                        {
                            ret = 360 + ret;
                        }
                        return ret;
                    }
                    else
                    {
                        if ((p.Y - this.midy) > 0)
                        {
                            return 90;
                        }
                        else if ((p.Y - this.midy) < 0)
                        {
                            return 270;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }

                private void PaintValue(PaintEventArgs e)
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    this.diameter = Math.Min(this.Height, this.Width);
                    this.midx = this.ClientSize.Width / 2;
                    this.midy = this.ClientSize.Height / 2;
                    this.DrawFrame(e);
                    e.Graphics.DrawString(this.value.ToString(), this.Font, Brushes.Red, 1, 1);
                    e.Graphics.DrawString(this.hoverValue.ToString(), this.Font, Brushes.Green, (float)(this.Width - this.diameter * 0.25), 1);
                    this.DrawLine(e, this.value, Color.Red);
                    if (this.HitTest(MousePosition))
                    {
                        this.DrawLine(e, this.hoverValue, Color.Green);
                    }
                }

                private void DrawLine(PaintEventArgs e, int val, Color color)
                {
                    Pen p = new Pen(color, 2);
                    Point current = this.GetCurrentPoint(val);
                    e.Graphics.DrawLine(p, this.midx, this.midy, current.X, current.Y);
                }

                private Point GetCurrentPoint(int val)
                {
                    return new Point((int)(this.midx + Math.Cos(val * Math.PI / 180) * this.diameter * 0.8 / 2), (int)(this.midy + Math.Sin(val * Math.PI / 180) * this.diameter * 0.8 / 2));
                }

                ///<summary>
                ///Processes a command key.
                ///</summary>
                ///
                ///<returns>
                ///true if the character was processed by the control; otherwise, false.
                ///</returns>
                ///
                ///<param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key to process. </param>
                ///<param name="msg">A <see cref="T:System.Windows.Forms.Message"></see>, passed by reference, that represents the window message to process. </param>
                protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
                {
                    if ((this.Enabled) && ((msg.Msg == 256) || (msg.Msg == 260)))
                    {
                        switch (keyData)
                        {
                            case Keys.Left:
                                if (this.value > 0)
                                {
                                    this.value--;
                                }
                                break;

                            case Keys.Up:
                                if (this.value < 360)
                                {
                                    this.value++;
                                }
                                break;

                            case Keys.Right:
                                if (this.value < 360)
                                {
                                    this.value++;
                                }
                                break;

                            case Keys.Down:
                                if (this.value > 0)
                                {
                                    this.value--;
                                }
                                break;
                        }
                        this.OnValueChanged();
                    }
                    if (this.value == 360)
                    {
                        this.value = 0;
                    }
                    this.Invalidate();
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                private void DrawFrame(PaintEventArgs e)
                {
                    Pen p = new Pen(Color.Black, 2);
                    Rectangle drawRect = new Rectangle((int)(this.midx - 0.7 * this.diameter / 2), (int)(this.midy - 0.7 * this.diameter / 2), (int)(0.7 * this.diameter), (int)(0.7 * this.diameter));
                    e.Graphics.DrawEllipse(p, drawRect);
                    drawRect.Inflate(1, 1);
                    e.Graphics.TranslateClip(1, 1);
                    e.Graphics.DrawEllipse(Pens.Gray, drawRect);
                    e.Graphics.DrawLine(Pens.Black, this.midx, this.midy - this.diameter / 2, this.midx, this.midy + this.diameter / 2);
                    e.Graphics.DrawLine(Pens.Black, this.midx - this.diameter / 2, this.midy, this.midx + this.diameter / 2, this.midy);
                    e.Graphics.DrawString("0", this.Font, Brushes.LimeGreen, (float)(this.midx + 0.8 * this.diameter / 2), this.midy);
                    e.Graphics.DrawString("180", this.Font, Brushes.LimeGreen, (this.midx - this.diameter / 2), this.midy);
                    e.Graphics.DrawString("90", this.Font, Brushes.LimeGreen, this.midx, (float)(this.midy + 0.8 * this.diameter / 2));
                    e.Graphics.DrawString("270", this.Font, Brushes.LimeGreen, this.midx, (this.midy - this.diameter / 2));
                }

                internal int GetValue()
                {
                    return this.value;
                }

                /// <summary> 
                /// Clean up any resources being used.
                /// </summary>
                /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
                protected override void Dispose(bool disposing)
                {
                    if (disposing && (this.components != null))
                    {
                        this.components.Dispose();
                    }
                    base.Dispose(disposing);
                }

                #region Component Designer generated code

                /// <summary> 
                /// Required method for Designer support - do not modify 
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
                    this.SuspendLayout();
                    // 
                    // GradientEditorUI
                    // 
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.BackColor = System.Drawing.SystemColors.Window;
                    this.Name = "GradientEditorUI";
                    this.ResumeLayout(false);
                }

                #endregion
            }

            #endregion
        }

        #endregion

    }
}
