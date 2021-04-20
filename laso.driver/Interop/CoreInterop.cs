using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Laso.Driver.Interop
{
    public class CoreInterop
    {
        const string coreLibFilePath = "laso.core.dll";
        public static bool Method(bool test) => method(test);

        [DllImport(coreLibFilePath, CallingConvention = CallingConvention.Cdecl)]
        internal extern static bool method(bool test);

    }
}
