using ApiAssignment.Entities;
using ApiAssignment.ServiceModel;
using ServiceStack;
using System.Collections.Generic;
using System.Linq;

namespace ApiAssignment.ServiceInterface
{
    public class CarService : Service
    {
        private ICarDbService _carService;

        public CarService(ICarDbService carService)
        {
            _carService = carService;
        }

        public QueryCarResponse Get(QueryCar request)
        {
            var car = _carService.Get(request.Id);
            if (car == null)
            {
                throw HttpError.NotFound($"Invalid CarId");
            }
            return new QueryCarResponse { Car = car.ConvertTo<CarViewModel>() };
        }

        public QueryAllCarResponse Get(QueryAllCar request)
        {
            //Nested Query example
            var cars = _carService.GetAll(x => x.Variants.Any(v => v.FuelType == request.FuelType)).ToList();
            return new QueryAllCarResponse { Cars = cars.ConvertTo<List<CarViewModel>>() };
        }

        public AddCarResponse Post(AddCar request)
        {
            var car = _carService.Get(x => x.CarCode == request.CarCode);
            if (car != null)
            {
                throw HttpError.Conflict($"Duplicate CarCode");
            }
            var carDetails = _carService.Create(request.ConvertTo<Car>());
            return new AddCarResponse { Id = carDetails.Id };
        }

        public UpdateCarResponse Put(UpdateCar request)
        {
            var car = _carService.Get(request.Id);
            if (car == null)
            {
                throw HttpError.BadRequest($"Invalid CarId");
            }
            _carService.Update(request.Id, request.ConvertTo<Car>());
            return new UpdateCarResponse { Car = request.ConvertTo<CarViewModel>() };
        }

        public void Delete(DeleteCar request)
        {
            var car = _carService.Get(request.Id);
            if (car == null)
            {
                throw HttpError.NotFound($"Invalid CarId");
            }
            _carService.Remove(request.Id);
        }
    }
}