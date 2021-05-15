using ServiceStack;
using ServiceStack.FluentValidation;

namespace ApiAssignment.ServiceModel
{
    [Route("/Cars/Delete/{Id}", "DELETE")]
    public class DeleteCar : IReturn<IReturnVoid>
    {
        public string Id { get; set; }
    }

    //Validation For Request
    public class DeleteCarValidator : AbstractValidator<DeleteCar>
    {
        public DeleteCarValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}