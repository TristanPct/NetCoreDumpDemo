using System;

namespace SyncConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            InnerMethod();
        }

        private static void InnerMethod()
        {
            throw new Exception("Sync test exception");
        }
    }
}
