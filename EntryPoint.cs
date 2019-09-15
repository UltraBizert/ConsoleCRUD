using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD
{
    internal static class EntryPoint
    {
        public static void Main(string[] args)
        {
            new InputProvider().StartListen();
        }
    }
}