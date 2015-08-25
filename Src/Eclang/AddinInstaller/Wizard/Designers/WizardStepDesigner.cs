namespace AddinInstaller.Wizard.Designers
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    using AddinInstaller.Wizard.Converters;
    using AddinInstaller.Wizard.Steps;
    using AddinInstaller.Wizard.Structures;

    using WizardBase;

    internal class WizardStepDesigner : ParentControlDesigner
    {
        private WizardStep wizardStep;

        public override void Initialize(IComponent component)
        {
            this.wizardStep = (WizardStep) component;
            base.Initialize(component);
        }

        public WizardStepDesigner()
        {
            this.AutoResizeHandles = true;
        }

        ///<summary>
        ///Gets the design-time action lists supported by the component associated with the designer.
        ///</summary>
        ///
        ///<returns>
        ///The design-time action lists supported by the component associated with the designer.
        ///</returns>
        ///
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionListCollection = new DesignerActionListCollection();
                WizardStepDesignerActionList designerActionList = new WizardStepDesignerActionList(this.wizardStep);
                actionListCollection.Add(designerActionList);
                return actionListCollection;
            }
        }

        ///<summary>
        ///Indicates if this designer's control can be parented by the control of the specified designer.
        ///</summary>
        ///
        ///<returns>
        ///true if the control managed by the specified designer can parent the control managed by this designer; otherwise, false.
        ///</returns>
        ///
        ///<param name="parentDesigner">The <see cref="T:System.ComponentModel.Design.IDesigner"></see> that manages the control to check. </param>
        public override bool CanBeParentedTo(IDesigner parentDesigner)
        {
            if (parentDesigner == null)
            {
                return false;
            }
            return (parentDesigner.Component is WizardControl);
        }

        internal void OnDragCompleteInternal(DragEventArgs de)
        {
            this.OnDragComplete(de);
        }

        internal void OnDragDropInternal(DragEventArgs de)
        {
            this.OnDragDrop(de);
        }

        internal void OnDragEnterInternal(DragEventArgs de)
        {
            this.OnDragEnter(de);
        }

        internal void OnDragLeaveInternal(EventArgs e)
        {
            this.OnDragLeave(e);
        }

        internal void OnDragOverInternal(DragEventArgs e)
        {
            this.OnDragOver(e);
        }

        internal void OnGiveFeedbackInternal(GiveFeedbackEventArgs e)
        {
            this.OnGiveFeedback(e);
        }

        public override SelectionRules SelectionRules
        {
            get { return (base.SelectionRules & ~(SelectionRules.Moveable | SelectionRules.AllSizeable)); }
        }


        internal class WizardStepDesignerActionList : DesignerActionList
        {
            public WizardStepDesignerActionList(IComponent component) : base(component)
            {
            }

            protected virtual WizardStep WizardStep
            {
                get { return (WizardStep)this.Component; }
            }

            ///<summary>
            ///Gets or sets a value indicating whether the smart tag panel should automatically be displayed when it is created.
            ///</summary>
            ///
            ///<returns>
            ///true if the panel should be shown when the owning component is created; otherwise, false. The default is false.
            ///</returns>
            ///
            public override bool AutoShow
            {
                get
                {
                    return true;
                }
                set
                {
                    base.AutoShow = value;
                }
            }

            ///<summary>
            ///Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"></see> objects contained in the list.
            ///</summary>
            ///
            ///<returns>
            ///A <see cref="T:System.ComponentModel.Design.DesignerActionItem"></see> array that contains the items in this list.
            ///</returns>
            ///
            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection items = new DesignerActionItemCollection();
                items.Add(new DesignerActionHeaderItem("Appearence", "Appearence"));
                items.Add(new DesignerActionMethodItem(this, "ResetAppearence", "Reset Appearence", "Appearence", true));
                if(this.WizardStep is StartStep)
                {
                    items.Add(new DesignerActionPropertyItem("StartTitle", "Title", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("StartSubTitle", "SubTitle", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("StartBindingImage", "BindingImage", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("StartIcon", "Icon", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("StartLeftPair", "Left pane appearence", "Appearence"));
                }

                if (this.WizardStep is LicenceStep)
                {
                    items.Add(new DesignerActionPropertyItem("LicenceTitle", "Title", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("LicenceSubTitle", "SubTitle", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("LicenceBindingImage", "BindingImage", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("LicenceHeaderPair", "HeaderPair", "Appearence"));
                    items.Add(new DesignerActionHeaderItem("Licence", "Licence"));
                    items.Add(new DesignerActionPropertyItem("LicenceAccepted", "Licence Accepted", "Licence"));
                    items.Add(new DesignerActionPropertyItem("LicenceAcceptText", "Licence AcceptText", "Licence"));
                    items.Add(new DesignerActionPropertyItem("LicenceDeclineText", "Licence DeclineText", "Licence"));
                    items.Add(new DesignerActionPropertyItem("LicenceLicenseFile", "License File", "Licence"));
                }

                if (this.WizardStep is IntermediateStep)
                {
                    items.Add(new DesignerActionPropertyItem("IntermediateTitle", "Title", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("IntermediateSubTitle", "SubTitle", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("IntermediateBindingImage", "BindingImage", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("IntermediateHeaderPair", "HeaderPair", "Appearence"));
                }

                if(this.WizardStep is FinishStep)
                {
                    items.Add(new DesignerActionPropertyItem("FinishBindingImage", "BindingImage", "Appearence"));
                    items.Add(new DesignerActionPropertyItem("FinishPair", "Pair", "Appearence"));
                }
                return items;
            }

            #region Start page actions

            public virtual Image StartBindingImage
            {
                get { return ((StartStep)this.WizardStep).BindingImage ; }
                set
                {
                    if (((StartStep)this.WizardStep).BindingImage != value)
                    {
                        ((StartStep)this.WizardStep).BindingImage = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
            public virtual string StartTitle
            {
                get { return ((StartStep)this.WizardStep).Title; }
                set
                {
                    if (((StartStep)this.WizardStep).Title != value)
                    {
                        ((StartStep)this.WizardStep).Title = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
            public virtual string StartSubTitle
            {
                get { return ((StartStep)this.WizardStep).Subtitle; }
                set
                {
                    if (((StartStep)this.WizardStep).Subtitle != value)
                    {
                        ((StartStep)this.WizardStep).Subtitle = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }

            public virtual Image StartIcon
            {
                get { return ((StartStep)this.WizardStep).Icon; }
                set
                {
                    if (((StartStep)this.WizardStep).Icon != value)
                    {
                        ((StartStep)this.WizardStep).Icon = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            public virtual ColorPair StartLeftPair
            {
                get { return ((StartStep) this.WizardStep).LeftPair; }
                set
                {
                    if (((StartStep)this.WizardStep).LeftPair != value)
                    {
                        ((StartStep)this.WizardStep).LeftPair = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }

            #endregion

            #region Licence page actions

            public virtual Image LicenceBindingImage
            {
                get { return ((LicenceStep)this.WizardStep).BindingImage; }
                set
                {
                    if (((LicenceStep)this.WizardStep).BindingImage != value)
                    {
                        ((LicenceStep)this.WizardStep).BindingImage = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
            public virtual string LicenceTitle
            {
                get { return ((LicenceStep)this.WizardStep).Title; }
                set
                {
                    if (((LicenceStep)this.WizardStep).Title != value)
                    {
                        ((LicenceStep)this.WizardStep).Title = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
            public virtual string LicenceSubTitle
            {
                get { return ((LicenceStep)this.WizardStep).Subtitle; }
                set
                {
                    if (((LicenceStep)this.WizardStep).Subtitle != value)
                    {
                        ((LicenceStep)this.WizardStep).Subtitle = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }

            public virtual bool? LicenceAccepted
            {
                get { return ((LicenceStep)this.WizardStep).Accepted; }
                set
                {
                    if (((LicenceStep)this.WizardStep).Accepted != value)
                    {
                        ((LicenceStep)this.WizardStep).Accepted = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            [Editor(typeof(CustomFileNameEditor), typeof(UITypeEditor))]
            public virtual string Licence
            {
                get { return ((LicenceStep)this.WizardStep).License; }
                set
                {
                    if (((LicenceStep)this.WizardStep).License != value)
                    {
                        ((LicenceStep)this.WizardStep).License = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }

            public virtual string LicenceAcceptText
            {
                get { return ((LicenceStep)this.WizardStep).AcceptText; }
                set
                {
                    if (((LicenceStep)this.WizardStep).AcceptText != value)
                    {
                        ((LicenceStep)this.WizardStep).AcceptText = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            public virtual string LicenceDeclineText
            {
                get { return ((LicenceStep)this.WizardStep).DeclineText; }
                set
                {
                    if (((LicenceStep)this.WizardStep).DeclineText != value)
                    {
                        ((LicenceStep)this.WizardStep).DeclineText = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            public virtual ColorPair LicenceHeaderPair
            {
                get { return ((LicenceStep)this.WizardStep).HeaderPair; }
                set
                {
                    ((LicenceStep)this.WizardStep).HeaderPair = value;
                    this.WizardStep.Invalidate();
                }
            }
            #endregion

            #region Licence page actions

            public virtual Image IntermediateBindingImage
            {
                get { return ((IntermediateStep)this.WizardStep).BindingImage; }
                set
                {
                    if (((IntermediateStep)this.WizardStep).BindingImage != value)
                    {
                        ((IntermediateStep)this.WizardStep).BindingImage = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
            public virtual string IntermediateTitle
            {
                get { return ((IntermediateStep)this.WizardStep).Title; }
                set
                {
                    if (((IntermediateStep)this.WizardStep).Title != value)
                    {
                        ((IntermediateStep)this.WizardStep).Title = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
            public virtual string IntermediateSubTitle
            {
                get { return ((IntermediateStep)this.WizardStep).Subtitle; }
                set
                {
                    if (((IntermediateStep)this.WizardStep).Subtitle != value)
                    {
                        ((IntermediateStep)this.WizardStep).Subtitle = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }
            public virtual ColorPair IntermediateHeaderPair
            {
                get { return ((IntermediateStep)this.WizardStep).HeaderPair; }
                set
                {
                    if (((IntermediateStep)this.WizardStep).HeaderPair != value)
                    {
                        ((IntermediateStep)this.WizardStep).HeaderPair = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }

            #endregion

            #region Finish Step actions

            public virtual ColorPair FinishPair
            {
                get { return ((FinishStep)this.WizardStep).Pair; }
                set
                {
                    if (((FinishStep)this.WizardStep).Pair != value)
                    {
                        ((FinishStep)this.WizardStep).Pair = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }

            public virtual Image FinishBindingImage
            {
                get { return ((FinishStep)this.WizardStep).BindingImage; }
                set
                {
                    if (((FinishStep)this.WizardStep).BindingImage != value)
                    {
                        ((FinishStep)this.WizardStep).BindingImage = value;
                        this.WizardStep.Invalidate();
                    }
                }
            }

            #endregion



            protected virtual void ResetAppearence()
            {
                this.WizardStep.Reset();
                this.WizardStep.Invalidate();
            }
        }
    }
}