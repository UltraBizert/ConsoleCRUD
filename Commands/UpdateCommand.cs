using System;
using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    class UpdateCommand : Command
    {
        public UpdateCommand(StorageProvider storage) : base(storage)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("Update command");
        }

        public override bool ValidateData(string data)
        {
            return false;
        }

        public override string DataExample => "3";
    }
}