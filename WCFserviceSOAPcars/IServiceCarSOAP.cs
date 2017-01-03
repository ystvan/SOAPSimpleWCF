using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFserviceSOAPcars
{
    [ServiceContract]
    public interface IServiceCarSOAP
    {
        [OperationContract]
        IList<Car> GetAllCars();

        [OperationContract]
        Car GetById(string id);

        [OperationContract]
        IList<Car> GetCarByModel(string text);

        [OperationContract]
        Car AddCar(Car newCar);

        [OperationContract]
        bool UpdateCar(Car updatedCar);

        [OperationContract]
        bool DeleteCar(string id);


    }
}
