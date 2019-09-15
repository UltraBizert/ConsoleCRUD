using System;
using System.IO;
using Newtonsoft.Json;
using UltraBizert.CarsCRUD.DataStructures;

namespace UltraBizert.CarsCRUD.IO
{
    public class StorageProvider
    {
        private readonly string pathToSave = $"{Path.GetTempPath()}/save.json";

        public StorageProvider()
        {
            try
            {
                var file = File.ReadAllText(pathToSave);
                var car = JsonConvert.DeserializeObject<Car>(file);
                Console.WriteLine(car.Year);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void SaveNewCar(Car car)
        {
            using (StreamWriter file = File.CreateText(pathToSave))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, car);
            }
        }
    }
}