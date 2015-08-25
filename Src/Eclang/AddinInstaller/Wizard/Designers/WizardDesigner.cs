namespace AddinInstaller.Wizard.Designers
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    using AddinInstaller.Wizard.Steps;

    using WizardBase;

    internal class WizardDesigner : ParentControlDesigner
    {
        #region Private Fields

        private readonly DesignerActionListCollection actionListCollection = new DesignerActionListCollection();
        private bool forwardOnDrag;
        private bool isSelected;
        private WizardDesignerActionList wizardDesignerActionList;

        #endregion

        protected override void Dispose(bool disposing)
        {
            ISelectionService service = (ISelectionService) this.GetService(typeof (ISelectionService));
            if (service != null)
            {
                service.SelectionChanged -= this.OnSelectionChanged;
            }
            WizardControl control = (WizardControl) this.Control;
            control.CurrentStepIndexChanged -= this.CurrentStepIndexChanged;
            control.WizardSteps.Inserted -= this.RefreshComponent;
            IDesignerHost host = (IDesignerHost) this.GetService(typeof (IDesignerHost));
            IEnumerator enumerator = control.WizardSteps.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    WizardStep component = (WizardStep) enumerator.Current;
                    host.DestroyComponent(component);
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void CurrentStepIndexChanged(object sender, EventArgs e)
        {
            this.RefreshComponent(-1, null);
        }

        private WizardStepDesigner GetDesigner()
        {
            WizardControl control = this.Control as WizardControl;
            WizardStep component = null;
            IDesignerHost service = null;
            WizardStepDesigner designer = null;
            if (control != null && control.WizardSteps.Count >= 0)
            {
                component = control.WizardSteps[control.CurrentStepIndex];
                service = (IDesignerHost) this.GetService(typeof (IDesignerHost));
                designer = null;
            }
            if (service == null)
            {
                return designer;
            }
            if (component == null)
            {
                return designer;
            }
            designer = (WizardStepDesigner) service.GetDesigner(component);
            return designer;
        }

        private WizardStepDesigner GetWizardStepDesigner(IComponent step)
        {
            IDesignerHost service = (IDesignerHost) this.GetService(typeof (IDesignerHost));
            WizardStepDesigner designer = null;
            if (service == null)
            {
                return designer;
            }
            designer = (WizardStepDesigner) service.GetDesigner(step);
            return designer;
        }

        ///<summary>
        ///Initializes the designer with the specified component.
        ///</summary>
        ///
        ///<param name="component">The <see cref="T:System.ComponentModel.IComponent"></see> to associate with the designer. </param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.AutoResizeHandles = true;
            ISelectionService service = (ISelectionService) this.GetService(typeof (ISelectionService));
            if (service != null)
            {
                service.SelectionChanged += this.OnSelectionChanged;
            }
            WizardControl control = (WizardControl) this.Control;
            this.wizardDesignerActionList = new WizardDesignerActionList(control);
            this.actionListCollection.Add(this.wizardDesignerActionList);
            control.CurrentStepIndexChanged += this.CurrentStepIndexChanged;
            control.WizardSteps.Inserted += this.RefreshComponent;
        }

        ///<param name="defaultValues">TBD</param>
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            WizardControl control = this.Control as WizardControl;
            if (control == null)
            {
                return;
            }
            IDesignerHost service = (IDesignerHost) this.GetService(typeof (IDesignerHost));
            if (service == null)
            {
                return;
            }
            StartStep step = (StartStep) service.CreateComponent(typeof (StartStep));
            control.WizardSteps.Add(step);
            LicenceStep licStep = (LicenceStep)service.CreateComponent(typeof(LicenceStep));
            control.WizardSteps.Add(licStep);
            IntermediateStep step2 = (IntermediateStep) service.CreateComponent(typeof (IntermediateStep));
            control.WizardSteps.Add(step2);
            FinishStep step3 = (FinishStep) service.CreateComponent(typeof (FinishStep));
            control.WizardSteps.Add(step3);
        }

        ///<summary>
        ///Called in order to clean up a drag-and-drop operation.
        ///</summary>
        ///
        ///<param name="de">A <see cref="T:System.Windows.Forms.DragEventArgs"></see> that provides data for the event.</param>
        protected override void OnDragComplete(DragEventArgs de)
        {
            if (this.forwardOnDrag)
            {
                this.forwardOnDrag = false;
                this.GetDesigner().OnDragCompleteInternal(de);
            }
            else
            {
                base.OnDragComplete(de);
            }
        }

        ///<summary>
        ///Called when a drag-and-drop object is dropped onto the control designer view.
        ///</summary>
        ///
        ///<param name="de">A <see cref="T:System.Windows.Forms.DragEventArgs"></see> that provides data for the event. </param>
        protected override void OnDragDrop(DragEventArgs de)
        {
            if (this.forwardOnDrag)
            {
                this.forwardOnDrag = false;
                WizardStepDesigner currentWizardStepDesigner = this.GetDesigner();
                if (currentWizardStepDesigner != null)
                {
                    currentWizardStepDesigner.OnDragDropInternal(de);
                }
            }
            else
            {
                de.Effect = DragDropEffects.None;
            }
        }

        ///<summary>
        ///Called when a drag-and-drop operation enters the control designer view.
        ///</summary>
        ///
        ///<param name="de">A <see cref="T:System.Windows.Forms.DragEventArgs"></see> that provides data for the event. </param>
        protected override void OnDragEnter(DragEventArgs de)
        {
            WizardControl control = (WizardControl) this.Control;
            if (control.WizardSteps.Count <= 0)
            {
                base.OnDragEnter(de);
                return;
            }
            WizardStep step = control.WizardSteps[control.CurrentStepIndex];
            Point pt = step.PointToClient(new Point(de.X, de.Y));
            Rectangle clientRectangle = step.ClientRectangle;
            if (!clientRectangle.Contains(pt))
            {
                base.OnDragEnter(de);
                return;
            }
            this.GetWizardStepDesigner(step).OnDragEnterInternal(de);
            this.forwardOnDrag = true;
        }

        ///<summary>
        ///Called when a drag-and-drop operation leaves the control designer view.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that provides data for the event. </param>
        protected override void OnDragLeave(EventArgs e)
        {
            if (this.forwardOnDrag)
            {
                this.forwardOnDrag = false;
                WizardStepDesigner currentWizardStepDesigner = this.GetDesigner();
                if (currentWizardStepDesigner == null)
                {
                    return;
                }
                currentWizardStepDesigner.OnDragLeaveInternal(e);
                return;
            }
            base.OnDragLeave(e);
        }

        ///<summary>
        ///Called when a drag-and-drop object is dragged over the control designer view.
        ///</summary>
        ///
        ///<param name="de">A <see cref="T:System.Windows.Forms.DragEventArgs"></see> that provides data for the event. </param>
        protected override void OnDragOver(DragEventArgs de)
        {
            WizardControl control = this.Control as WizardControl;
            if (control == null || control.WizardSteps.Count <= 0)
            {
                de.Effect = DragDropEffects.None;
                return;
            }
            WizardStep step = control.WizardSteps[control.CurrentStepIndex];
            Point pt = step.PointToClient(new Point(de.X, de.Y));
            WizardStepDesigner wizardStepDesigner = this.GetWizardStepDesigner(step);
            Rectangle clientRectangle = step.ClientRectangle;
            if (!clientRectangle.Contains(pt))
            {
                if (!this.forwardOnDrag)
                {
                    de.Effect = DragDropEffects.None;
                    return;
                }
                this.forwardOnDrag = false;
                wizardStepDesigner.OnDragLeaveInternal(EventArgs.Empty);
                base.OnDragEnter(de);
                return;
            }
            else
            {
                if (!this.forwardOnDrag)
                {
                    base.OnDragLeave(EventArgs.Empty);
                    wizardStepDesigner.OnDragEnterInternal(de);
                    this.forwardOnDrag = true;
                    return;
                }
                wizardStepDesigner.OnDragOverInternal(de);
                return;
            }
        }

        ///<summary>
        ///Receives a call when a drag-and-drop operation is in progress to provide visual cues based on the location of the mouse while a drag operation is in progress.
        ///</summary>
        ///
        ///<param name="e">A <see cref="T:System.Windows.Forms.GiveFeedbackEventArgs"></see> that provides data for the event. </param>
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            if (this.forwardOnDrag)
            {
                WizardStepDesigner currentWizardStepDesigner = this.GetDesigner();
                if (currentWizardStepDesigner == null)
                {
                    return;
                }
                currentWizardStepDesigner.OnGiveFeedbackInternal(e);
            }
            else
            {
                base.OnGiveFeedback(e);
            }
        }

        ///<summary>
        ///Called when the control that the designer is managing has painted its surface so the designer can paint any additional adornments on top of the control.
        ///</summary>
        ///
        ///<param name="pe">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that provides data for the event. </param>
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            WizardControl control = (WizardControl) this.Control;
            if (control == null)
            {
                return;
            }
            if (control.WizardSteps.Count != 0)
            {
                return;
            }
            Pen pen = new Pen(SystemColors.ControlDark);
            try
            {
                pen.DashStyle = DashStyle.Dash;
                Rectangle rect = control.Bounds;
                rect.Location = new Point(0, 0);
                rect.Width--;
                rect.Height--;
                pe.Graphics.DrawRectangle(pen, rect);
                return;
            }
            finally
            {
                pen.Dispose();
            }
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            ISelectionService service = (ISelectionService) this.GetService(typeof (ISelectionService));
            if (service == null)
            {
                return;
            }
            this.isSelected = false;
            ICollection selectedComponents = service.GetSelectedComponents();
            if (selectedComponents == null)
            {
                return;
            }
            WizardControl control = (WizardControl) this.Control;
            IEnumerator enumerator = selectedComponents.GetEnumerator();
            if (enumerator == null)
            {
                return;
            }
            try
            {
                while (enumerator.MoveNext())
                {
                    object current = enumerator.Current;
                    if (current == control)
                    {
                        this.isSelected = true;
                        break;
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null) disposable.Dispose();
            }
        }

        private void RefreshComponent(int index, WizardStep value)
        {
            DesignerActionUIService service = this.GetService(typeof (DesignerActionUIService)) as DesignerActionUIService;
            if (service == null)
            {
                return;
            }
            service.Refresh(this.Control);
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
            get { return this.actionListCollection; }
        }

        ///<summary>
        ///Gets the collection of components associated with the component managed by the designer.
        ///</summary>
        ///
        ///<returns>
        ///The components that are associated with the component managed by the designer.
        ///</returns>
        ///
        public override ICollection AssociatedComponents
        {
            get { return ((WizardControl) this.Control).WizardSteps; }
        }
    }
}