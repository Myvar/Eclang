namespace AddinInstaller.Wizard.Designers
{
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using System.Windows.Forms;

    using AddinInstaller.Wizard.Collection;
    using AddinInstaller.Wizard.Converters;
    using AddinInstaller.Wizard.Steps;

    using WizardBase;

    internal class WizardDesignerActionList : DesignerActionList
    {
        public WizardDesignerActionList(IComponent component) : base(component)
        {
        }

        protected internal virtual void AddFinishStep()
        {
            IDesignerHost service = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (this.WizardControl == null || service == null)
            {
                return;
            }
            FinishStep step = (FinishStep) service.CreateComponent(typeof (FinishStep));
            if (this.WizardControl.WizardSteps.Count != 0)
            {
                this.WizardControl.WizardSteps.Insert(this.WizardControl.CurrentStepIndex, step);
                this.RemoveWizardFromSelection();
                this.SelectWizard();
                return;
            }
            this.WizardControl.WizardSteps.Add(step);
            this.RemoveWizardFromSelection();
            this.SelectWizard();
        }

        protected internal virtual void AddCustomStep()
        {
            IDesignerHost service = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (this.WizardControl == null || service == null)
            {
                return;
            }
            IntermediateStep step = (IntermediateStep) service.CreateComponent(typeof (IntermediateStep));
            if (this.WizardControl.WizardSteps.Count != 0)
            {
                this.WizardControl.WizardSteps.Insert(this.WizardControl.CurrentStepIndex, step);
                this.RemoveWizardFromSelection();
                this.SelectWizard();
            }
            else
            {
                this.WizardControl.WizardSteps.Add(step);
                this.RemoveWizardFromSelection();
                this.SelectWizard();
            }
        }

        protected internal virtual void AddStartStep()
        {
            IDesignerHost service = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (this.WizardControl == null || service == null)
            {
                return;
            }
            StartStep step = (StartStep) service.CreateComponent(typeof (StartStep));
            if (this.WizardControl.WizardSteps.Count != 0)
            {
                this.WizardControl.WizardSteps.Insert(this.WizardControl.CurrentStepIndex, step);
                this.RemoveWizardFromSelection();
                this.SelectWizard();
                return;
            }
            else
            {
                this.WizardControl.WizardSteps.Add(step);
                this.RemoveWizardFromSelection();
                this.SelectWizard();
                return;
            }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            if (this.WizardControl == null)
            {
                return new DesignerActionItemCollection();
            }
            if (this.WizardControl.CurrentStepIndex != -1)
            {
                DesignerActionItemCollection items = new DesignerActionItemCollection();
                items.Add(new DesignerActionHeaderItem("Add Steps"));
                items.Add(new DesignerActionPropertyItem("WizardSteps", "New Wizard Step", "Add Steps"));
                items.Add(new DesignerActionMethodItem(this, "AddStartStep", "Add Start Step", "Add Steps", true));
                items.Add(new DesignerActionMethodItem(this, "AddCustomStep", "Add Custom Step", "Add Steps", true));
                items.Add(new DesignerActionMethodItem(this, "AddFinishStep", "Add Finish Step", "Add Steps", true));
                if (this.WizardControl.CurrentStepIndex == -1)
                {
                    return items;
                }
                items.Add(new DesignerActionHeaderItem("Remove Step"));
                items.Add(new DesignerActionMethodItem(this, "RemoveStep", "Remove Step", "Remove Step", true));
                items.Add(new DesignerActionMethodItem(this, "RemoveAllSteps", "Remove All Steps", "Remove Step", true));
                if (this.WizardControl.WizardSteps.Count >= 1)
                {
                    items.Add(new DesignerActionHeaderItem("Step navigation"));
                    if (this.WizardControl.CurrentStepIndex > 0)
                    {
                        items.Add(new DesignerActionMethodItem(this, "PreviousStep", "Previous Step", "Step navigation", true));
                    }
                    if (this.WizardControl.CurrentStepIndex != (this.WizardControl.WizardSteps.Count - 1))
                    {
                        items.Add(new DesignerActionMethodItem(this, "NextStep", "Next Step", "Step navigation", true));
                    }
                }
                items.Add(new DesignerActionHeaderItem("Layout"));
                items.Add(new DesignerActionPropertyItem("DockStyle", "Dock editor", "Layout"));
                return items;
            }
            return new DesignerActionItemCollection();
        }

        protected internal virtual void NextStep()
        {
            if (this.WizardControl == null)
            {
                return;
            }
            this.WizardControl.CurrentStepIndex++;
            this.RemoveWizardFromSelection();
            this.SelectWizard();
        }

        protected internal virtual void PreviousStep()
        {
            WizardControl wizardControl = this.WizardControl;
            if (wizardControl == null)
            {
                return;
            }
            wizardControl.CurrentStepIndex--;
            this.RemoveWizardFromSelection();
            this.SelectWizard();
        }

        protected internal virtual void RemoveAllSteps()
        {
            IDesignerHost service = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (this.WizardControl == null || service == null)
            {
                return;
            }
            if (MessageBox.Show(this.WizardControl.FindForm(), "Are you sure you want to remove all the steps?", "Remove Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            WizardStep[] array = new WizardStep[this.WizardControl.WizardSteps.Count];
            ((ICollection)this.WizardControl.WizardSteps).CopyTo(array, 0);
            this.WizardControl.WizardSteps.Clear();
            WizardStep[] stepArray2 = array;
            for (int index = 0; index < stepArray2.Length; index++)
            {
                WizardStep component = stepArray2[index];
                service.DestroyComponent(component);
                index++;
            }
            this.SelectWizard();
        }

        protected internal virtual void RemoveStep()
        {
            IDesignerHost service = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (this.WizardControl == null || service == null)
            {
                return;
            }
            if (MessageBox.Show(this.WizardControl.FindForm(), "Are you sure you want to remove the step?", "Remove Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                WizardStep step = this.WizardControl.WizardSteps[this.WizardControl.CurrentStepIndex];
                this.WizardControl.WizardSteps.Remove(step);
                service.DestroyComponent(step);
                step.Dispose();
            }
            this.SelectWizard();
        }

        protected void RemoveWizardFromSelection()
        {
            ISelectionService service = (ISelectionService)this.GetService(typeof(ISelectionService));
            if (this.WizardControl == null || service == null)
            {
                return;
            }
            object[] components = new object[] { this.WizardControl };
            service.SetSelectedComponents(components, SelectionTypes.Remove);
            return;
        }

        protected void SelectWizard()
        {
            ISelectionService service = (ISelectionService)this.GetService(typeof(ISelectionService));
            if (this.WizardControl == null || service == null)
            {
                return;
            }
            object[] components = new object[] {this.WizardControl};
            service.SetSelectedComponents(components, SelectionTypes.Replace);
            return;
        }

        protected virtual WizardControl WizardControl
        {
            get { return (WizardControl) this.Component; }
        }

        [TypeConverter(typeof(GenericCollectionConverter<GenericCollection<WizardStep>>)), Editor(typeof(WizardStepCollectionEditor), typeof(UITypeEditor))]
        public GenericCollection<WizardStep> WizardSteps
        {
            get
            {
                if (this.WizardControl == null)
                {
                    return null;
                }
                return this.WizardControl.WizardSteps;
            }
        }

        public virtual DockStyle DockStyle
        {
            get { return this.WizardControl.Dock; }
            set
            {
                if (this.WizardControl.Dock != value)
                {
                    this.WizardControl.Dock = value;
                    this.WizardControl.Invalidate();
                }
            }
        }
    }
}