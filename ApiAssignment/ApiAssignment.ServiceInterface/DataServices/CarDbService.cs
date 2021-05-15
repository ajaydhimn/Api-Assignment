using ApiAssignment.Entities;
using MongoDB.Driver;

namespace ApiAssignment.ServiceInterface
{
    public interface ICarDbService : IBaseDbService<Car>
    {
    }

    public class CarDbService : BaseDbService<Car>, ICarDbService
    {
        public CarDbService(IMongoDatabase db) : base(db)
        {
        }
    }
}