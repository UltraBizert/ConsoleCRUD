using System;
using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    class RemoveCommand : Command
    {
        protected override int ParamsCount => 1;
        private int index;

        public RemoveCommand(StorageProvider storage) : base(storage)
        {
        }

        public override void Execute()
        {
            if (Storage.RemoveCar(index))
                Console.WriteLine("Car was deleted!");
        }

        protected override bool ValidateParams(string[] @params) => CheckIndex(@params[0], out index);

        public override string DataExample => $"Some int value in range {0}-{Storage.Cars.Count-1}";
    }
}