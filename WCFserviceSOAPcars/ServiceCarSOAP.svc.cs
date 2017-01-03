using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFserviceSOAPcars
{
    public class ServiceCarSOAP : IServiceCarSOAP
    {
        CarModel azureDB = new CarModel();

        /// <summary>
        /// Returns all of the Car objects
        /// </summary>
        /// <returns>List of cars</returns>
        public IList<Car> GetAllCars()
        {
            return azureDB.Cars.ToList();
        }

        /// <summary>
        /// Returns a Car by based on matching Id number
        /// </summary>
        /// <param name="id">The search criteria by Id number</param>
        /// <returns>A Car found by Id or the default</returns>
        public Car GetById(string id)
        {
            int idNumber = int.Parse(id);
            Car found = azureDB.Cars.FirstOrDefault(c => c.Id == idNumber);

            return found;
        }

        /// <summary>
        /// Adds a Car to the generic collection
        /// </summary>
        /// <param name="newCar">The Car object to be added</param>
        /// <returns>The new car which has been added currently</returns>
        public Car AddCar(Car newCar)
        {
            if (newCar == null)
            {
                throw new ArgumentNullException(nameof(newCar));
            }
            azureDB.Cars.Add(newCar);
            azureDB.SaveChanges();
            return newCar;

        }

        /// <summary>
        /// Updates the matching Car object in the generic collection
        /// </summary>
        /// <param name="updatedCar">Car to be uodated</param>
        public bool UpdateCar(Car updatedCar)
        {
            if (updatedCar == null)
            {
                throw new ArgumentNullException(nameof(updatedCar));
                return false;
            }
            string idString = updatedCar.Id.ToString();
            Car matching = GetById(idString);

            matching.Model = updatedCar.Model;
            matching.Price = updatedCar.Price;
            matching.Year = updatedCar.Year;

            azureDB.SaveChanges();

            return true;

        }

        /// <summary>
        /// Deletes a Car from the generic collection
        /// </summary>
        /// <param name="id">The id of the Car to be deleted</param>
        /// <returns>True if successful, false in case of error</returns>
        public bool DeleteCar(string id)
        {
            Car matching = GetById(id);
            if (matching == null)
            {
                throw new ArgumentNullException(nameof(matching));
                return false;
            }
            
            azureDB.Cars.Remove(matching);
            azureDB.SaveChanges();

            return true;

        }

        /// <summary>
        /// Returns a car by searching criteria
        /// </summary>
        /// <param name="text">The query of the Model</param>
        /// <returns>A list of matched Car objects</returns>
        public IList<Car> GetCarByModel(string text)
        {
            return azureDB.Cars.Where(c => c.Model.ToLower().Contains(text.ToLower())).ToList();
        }
    }
}
