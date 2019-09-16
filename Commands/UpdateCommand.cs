using System;
using UltraBizert.CarsCRUD.DataStructures;
using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    class UpdateCommand : Command
    {
        public override string DataExample => "3 Year Brand Model BodyType";

        protected override int ParamsCount => 5;

        private int index;
        private ushort year;
        private string brand;
        private string model;
        private string bodyType;

        public UpdateCommand(StorageProvider storage) : base(storage)
        {
        }

        public override void Execute()
        {
            if (Storage.UpdateCar(new Car(year, brand, model, bodyType), index))
                Console.WriteLine("Car was updated");
        }

        protected override bool ValidateParams(string[] @params)
        {
            if (!CheckIndex(@params[0], out index) || !CheckYear(@params[1], out year))
            {
                return false;
            }

            brand = @params[2];
            model = @params[3];
            bodyType = @params[4];

            return true;
        }
    }
}