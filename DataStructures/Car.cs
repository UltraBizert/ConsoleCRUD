using System;

namespace UltraBizert.CarsCRUD.DataStructures
{
    [Serializable]
    public class Car
    {
        public ushort Year { get; }
        public string Brand { get; }
        public string Model { get; }
        public string BodyType { get; }

        public Car(ushort year, string brand, string model, string bodyType)
        {
            Year = year;
            Brand = brand;
            Model = model;
            BodyType = bodyType;
        }
    }
}