using ServiceStack;
using ServiceStack.FluentValidation;

namespace ApiAssignment.ServiceModel
{
    [Route("/Cars")]//TODO:Demonstrate, Added just to demonstrate the validation of request
    [Route("/Cars/{id}", "GET")]
    public class QueryCar : IReturn<QueryCarResponse>
    {
        public string Id { get; set; }
    }

    public class QueryCarResponse
    {
        public CarViewModel Car { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

    //Validation For Request
    public class QueryCarValidator : AbstractValidator<QueryCar>
    {
        public QueryCarValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}