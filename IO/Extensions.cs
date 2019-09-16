using System;
using System.Linq;

namespace UltraBizert.CarsCRUD
{
    public static class Extensions
    {
        public static bool IsCommand(this string input, string[] command) =>
            command.Any(c => c.Equals(input, StringComparison.OrdinalIgnoreCase));
    }
}