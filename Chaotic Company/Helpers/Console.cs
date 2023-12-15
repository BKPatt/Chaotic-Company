using System;

namespace Chaotic_Company.Helpers
{
    public static partial class Helper
    {
        public static void PrintSystem(string? message)
        {
            if (message == null)
            {
                Console.WriteLine("SYSTEM: [null message]");
            }
            else
            {
                Console.WriteLine($"SYSTEM: {message}");
            }
        }
    }
}
