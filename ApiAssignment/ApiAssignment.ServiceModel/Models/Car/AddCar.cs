using ServiceStack;
using ServiceStack.FluentValidation;
using System.Linq;

namespace ApiAssignment.ServiceModel
{
    [Route("/Cars/Add", "POST")]
    public class AddCar : CarViewModel, IReturn<AddCarResponse>
    {
    }

    public class AddCarResponse
    {
        public string Id { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

    //Request Validation
    public class AddCarValidator : AbstractValidator<AddCar>
    {
        public AddCarValidator()
        {
            RuleFor(x => x.CarName).NotEmpty();
            RuleFor(x => x.CarCode).NotEmpty();
            RuleFor(x => x.Variants).NotEmpty();

            RuleFor(x => x.Variants.Any(y => string.IsNullOrEmpty(y.VariantName)))
                .NotEqual(true).WithMessage("Variant Name can't be blank")
                .When(x => x.Variants != null);

            RuleFor(x => x.Variants.Any(y => string.IsNullOrEmpty(y.VariantCode))).NotEqual(true)
                .WithMessage("Variant Code can't be blank")
                .When(x => x.Variants != null);
        }
    }
}