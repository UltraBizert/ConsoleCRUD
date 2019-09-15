using System;
using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    class RemoveCommand : Command
    {
        public RemoveCommand(StorageProvider storage) : base(storage)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("Remove command");
        }

        public override bool ValidateData(string data) => false;

        public override string DataExample => "1";
    }
}