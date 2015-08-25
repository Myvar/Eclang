namespace EcIDE.Internals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using FastColoredTextBoxNS;

    public class IntellisenseManager
    {
        #region Public Methods and Operators

        public static void PopulateAssembly(List<AutocompleteItem> acm, Assembly ass)
        {
            foreach (Type type in ass.GetTypes())
            {
                if (type.IsPublic)
                {
                    PopulateClass(acm, type);
                }
            }
        }

        public static void PopulateClass(List<AutocompleteItem> acm, Type cls)
        {
            var l = new List<string>();

            acm.Add(new AutocompleteItem(cls.Name));

            foreach (MethodInfo memberInfo in cls.GetMethods())
            {
                if (memberInfo.IsPublic)
                {
                    string s = cls.Name + "." + memberInfo.Name + "()";
                    if (!l.Contains(s))
                    {
                        if (!s.StartsWith(cls.Name + ".get_"))
                        {
                            if (!s.StartsWith(cls.Name + ".set_"))
                            {
                                if (!s.StartsWith(cls.Name + ".add_"))
                                {
                                    if (!s.StartsWith(cls.Name + ".remove_"))
                                    {
                                        l.Add(s);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (FieldInfo memberInfo in cls.GetFields())
            {
                string s = cls.Name + "." + memberInfo.Name;
                if (memberInfo.IsPublic)
                {
                    if (!l.Contains(s))
                    {
                        l.Add(s);
                    }
                }
            }
            foreach (PropertyInfo memberInfo in cls.GetProperties())
            {
                string s = cls.Name + "." + memberInfo.Name;
                if (!l.Contains(s))
                {
                    l.Add(s);
                }
            }

            acm.AddRange(l.Select(li => new MethodAutocompleteItem2(li)));
        }

        #endregion
    }
}