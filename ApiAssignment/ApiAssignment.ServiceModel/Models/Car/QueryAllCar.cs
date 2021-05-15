using ServiceStack;
using ServiceStack.FluentValidation;
using System.Collections.Generic;

namespace ApiAssignment.ServiceModel
{
    [Route("/Cars/QueryAllCar", "GET")]
    public class QueryAllCar : IReturn<QueryCarResponse>
    {
        public string FuelType { get; set; }
    }

    public class QueryAllCarResponse
    {
        public List<CarViewModel> Cars { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

    //Validation For Request
    public class QueryAllCarValidator : AbstractValidator<QueryAllCar>
    {
        public QueryAllCarValidator()
        {
            RuleFor(x => x.FuelType).NotEmpty();
        }
    }
}