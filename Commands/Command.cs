using System;
using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    abstract class Command : ICommand
    {
        protected StorageProvider Storage { get; }

        public Command(StorageProvider storage)
        {
            Storage = storage;
        }

        public virtual bool InputRequired() => true;

        public abstract string DataExample { get; }

        public abstract void Execute();

        public bool ValidateData(string data)
        {
            var @params = SplitToParams(data);

            if (@params.Length != ParamsCount)
            {
                Console.WriteLine($"need {ParamsCount} but have {@params.Length}");
                return false;
            }

            return ValidateParams(@params);
        }

        protected virtual bool ValidateParams(string[] @params) => true;

        protected virtual int ParamsCount => 0;

        protected bool CheckIndex(string param, out int index)
        {
            if (!int.TryParse(param, out index))
                return false;

            if (Storage.Cars.Count < index || index < 0)
            {
                Console.WriteLine($"index {index} not in {0}-{Storage.Cars.Count-1} range");
                return false;
            }

            return true;
        }

        protected bool CheckYear(string param, out ushort year) => ushort.TryParse(param, out year);

        private string[] SplitToParams(string data) => data.Split(' ');
    }
}