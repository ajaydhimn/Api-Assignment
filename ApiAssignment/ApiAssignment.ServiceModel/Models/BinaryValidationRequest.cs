using ServiceStack;
using ServiceStack.FluentValidation;

namespace ApiAssignment.ServiceModel
{
    [Route("/Binary/Validate", "POST")]
    public class BinaryValidationRequest : IReturn<IReturnVoid>
    {
        public string Binary { get; set; }
    }

    //Validation For Request
    public class BinaryValidationRequestValidator : AbstractValidator<BinaryValidationRequest>
    {
        public BinaryValidationRequestValidator()
        {
            RuleFor(x => x.Binary).NotEmpty();
        }
    }
}