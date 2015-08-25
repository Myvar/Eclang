namespace EcIDE.Contracts.ServiceProviders
{
    using EcIDE.Addins;

    public class OptionsService : IServiceProvider
    {
        #region Public Methods and Operators

        public T Get<T>(string k)
        {
            if (OptionsManager.Contains(k)) 
                return OptionsManager.Get<T>(k);
            return default(T);
        }

        public void Set<T>(string k, T v) where T : class
        {
            OptionsManager.Set(k, v);
        }
        public void Add<T>(string k, T v)
        {
            if(!OptionsManager.Contains(k))
                OptionsManager.Add(k, v);
            else
                OptionsManager.Set(k, v);
        }

        public bool Contains(string k)
        {
            return OptionsManager.Contains(k);
        }

        #endregion

        public void Save()
        {
            OptionsManager.Save();
        }
    }
}