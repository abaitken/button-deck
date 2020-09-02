using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient
{
    internal interface ISettings
    {
        string PreviousCOMPort { get; set; }

        void Save();
    }
}

namespace ButtonDeckClient.Properties
{
    partial class Settings : ISettings
    {
    }
}
