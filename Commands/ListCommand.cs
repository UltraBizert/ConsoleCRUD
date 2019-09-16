using System;
using System.Text;
using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    class ListCommand : Command
    {
        public override bool InputRequired() => false;

        public override string DataExample => "";

        public ListCommand(StorageProvider storage) : base(storage)
        {
        }

        public override void Execute()
        {
            var message = new StringBuilder();

            for (int i = 0; i < Storage.Cars.Count; i++)
            {
                var car = Storage.Cars[i];
                message.AppendLine($"{i} : {car.Year} {car.Brand} {car.Model} {car.BodyType}");
            }

            Console.WriteLine(message.ToString());
        }
    }
}