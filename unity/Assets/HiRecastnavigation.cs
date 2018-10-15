/***************************************************************
 * Description: This used to export obj file
 * Document: https://github.com/hiramtan/HiRecastnavigation
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace HiRecastnavigation
{
    public static class Navigation
    {
        private const string PluginsName = "HiRecastnavigation";

        #region glue
        //csharp call c++
        [DllImport(PluginsName)]
        public static extern int TestCsharpCallC(int a, int b);


        //c++ call csharp
        public static void Init()
        {
            Func<int, int, int> delTestCCallCsharp = new Func<int, int, int>(CsharpFunction);
            IntPtr funcPtr = Marshal.GetFunctionPointerForDelegate(delTestCCallCsharp);
            TestCCallCsharp(funcPtr);
        }

        [DllImport(PluginsName)]
        static extern int TestCCallCsharp(IntPtr csharPtr);

        private static int CsharpFunction(int a, int b)
        {
            return a + b;
        }
        #endregion
    }
}
