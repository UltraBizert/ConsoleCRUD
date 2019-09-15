using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    abstract class Command : ICommand
    {
        protected StorageProvider Storage;

        public Command(StorageProvider storage)
        {
            Storage = storage;
        }

        public abstract void Execute();

        public abstract bool ValidateData(string data);

        public abstract string DataExample { get; }
    }
}