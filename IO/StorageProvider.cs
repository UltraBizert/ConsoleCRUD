using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UltraBizert.CarsCRUD.DataStructures;

namespace UltraBizert.CarsCRUD.IO
{
    public class StorageProvider
    {
        public List<Car> Cars => cars;

        private readonly string pathToSave = $"{Path.GetTempPath()}/save.json";
        private readonly List<Car> cars;
        private readonly JsonSerializer serializer;

        public StorageProvider()
        {
            serializer = new JsonSerializer();

            try
            {
                var file = File.ReadAllText(pathToSave);
                var savedCars = JsonConvert.DeserializeObject<List<Car>>(file);
                cars = savedCars;
            }
            catch (Exception e)
            {
                Console.WriteLine("Miss saved cars. Init default");
                cars = new List<Car>
                {
                    new Car(2006, "subaru", "outback", "universal"),
                    new Car(2014, "toyota", "corolla filder", "universal"),
                    new Car(2006, "mitsubishi", "pajero", "suv"),
                };

                try
                {
                    using (var file = File.CreateText(pathToSave))
                    {
                        serializer.Serialize(file, cars);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Ups, save not working :/ Sr, buy buy! \n {exception}");
                    throw;
                }
            }
        }

        public bool AddCar(Car car)
        {
            cars.Add(car);
            return SaveCars();
        }

        public bool UpdateCar(Car newCar, int index)
        {
            cars[index] = newCar;
            return SaveCars();
        }

        public bool RemoveCar(int index)
        {
            cars.RemoveAt(index);
            return SaveCars();
        }

        private bool SaveCars()
        {
            try
            {
                using (var file = File.CreateText(pathToSave))
                {
                    serializer.Serialize(file, cars);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"something wrong with save: \n {e}");
                return false;
            }

            return true;
        }
    }
}