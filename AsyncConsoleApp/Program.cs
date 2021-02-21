using System;
using System.Threading.Tasks;

namespace AsyncConsoleApp
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await InnerMethod();
        }

        private static Task InnerMethod()
        {
            return Task.Run(InnerInnerMethod);
        }

        private static void InnerInnerMethod()
        {
            throw new Exception("Async test exception");
        }
    }
}
