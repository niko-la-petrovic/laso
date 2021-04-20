using Laso.Driver.Interop;
using System;

namespace Laso.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(CoreInterop.Method(true));
        }
    }
}
