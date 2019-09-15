using System;
using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    class ListCommand : Command
    {
        public override void Execute()
        {
            Console.WriteLine("ListCommand");
        }

        public override bool ValidateData(string data) => string.IsNullOrEmpty(data);

        public override string DataExample => "";

        public ListCommand(StorageProvider storage) : base(storage)
        {
        }
    }
}