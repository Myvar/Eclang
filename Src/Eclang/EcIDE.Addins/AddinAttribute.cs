namespace EcIDE.Addins
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly)]
    public class AddinAttribute : Attribute
    {
        #region Constructors and Destructors

        public AddinAttribute()
        {
            this.Priority = Priority.Normal;
        }

        #endregion

        #region Public Properties

        public Priority Priority { get; set; }

        #endregion
    }
}