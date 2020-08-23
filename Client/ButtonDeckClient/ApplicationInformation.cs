using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient
{
    class ApplicationInformation
    {
        private readonly Assembly _assembly;

        public ApplicationInformation()
        {
            _assembly = Assembly.GetExecutingAssembly();
        }

        public string AssemblyName => GetAttribute<AssemblyTitleAttribute>().Title;
        public string UniqueIdentifier => GetAttribute<GuidAttribute>().Value;
        public string InformationVersion => GetAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;


        private T GetAttribute<T>()
            where T : Attribute
        {
            return _assembly.GetCustomAttribute<T>();
        }
    }
}
