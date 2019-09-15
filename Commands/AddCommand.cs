using System;
using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    class AddCommand : Command
    {
        private ushort year;

        public AddCommand(StorageProvider storage) : base(storage)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("AddCommand");
        }

        public override bool ValidateData(string data)
        {
            var ci = data.Split(' ');

            if (ci.Length != 4)
            {
                return false;
            }

            if (!ushort.TryParse(ci[0], out year))
            {
                return false;
            }

            return true;
        }

        public override string DataExample => "1234 Brand Model BodyType";
    }
}