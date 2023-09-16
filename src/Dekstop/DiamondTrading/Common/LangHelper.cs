using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiamondTrading
{
    public static class LangHelper
    {
        private static ResourceManager _rm;
        static LangHelper()
        {
            _rm = new ResourceManager("DiamondTrading.strings", Assembly.GetExecutingAssembly());
        }

        public static string GetString(string name)
        {
            return _rm.GetString(name);
        }
    }
}
