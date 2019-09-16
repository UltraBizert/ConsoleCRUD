using System;
using UltraBizert.CarsCRUD.DataStructures;
using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    class AddCommand : Command
    {
        protected override int ParamsCount => 4;

        private ushort year;
        private string brand;
        private string model;
        private string bodyType;

        public AddCommand(StorageProvider storage) : base(storage)
        {
        }

        public override string DataExample => "1234 Brand Model BodyType";

        protected override bool ValidateParams(string[] @params)
        {
            if (!CheckYear(@params[0], out year))
                return false;

            brand = @params[1];
            model = @params[2];
            bodyType = @params[3];

            return true;
        }

        public override void Execute()
        {
            if(Storage.AddCar(new Car(year, brand, model, bodyType)))
                Console.WriteLine("Car was added");
        }
    }
}