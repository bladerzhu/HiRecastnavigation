
using System.Runtime.InteropServices;

namespace HiRecastnavigation
{
    public static class Navigation
    {
        private const string PluginsName = "HiRecastnavigation";

        public static void Init()
        {

        }



        #region glue

        [DllImport(PluginsName)]
        public static extern int TestCSharpCallC(int a, int b);


        [DllImport(PluginsName)]
        public static extern int TestCCallCSharp(int a, int b);

        #endregion
    }
}
