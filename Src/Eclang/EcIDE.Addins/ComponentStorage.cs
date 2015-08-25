namespace EcIDE.Addins
{
    using System.Collections.Generic;

    public class ComponentStorage
    {
        #region Static Fields

        private static readonly Dictionary<string, object> components = new Dictionary<string, object>();

        #endregion

        #region Public Methods and Operators

        public static void Add(string name, object com)
        {
            components.Add(name, com);
        }

        public static void Add<T>(T com) where T : class, new()
        {
            Add(com.GetType().Name, com);
        }

        public static object Get(string name)
        {
            return components[name];
        }

        public static T Get<T>() where T : class, new()
        {
            return (T)Get(typeof(T).Name);
        }

        #endregion
    }
}