using ServiceStack;
using ServiceStack.FluentValidation;
using System.Linq;

namespace ApiAssignment.ServiceModel
{
    [Route("/Cars/UpdateCar/{Id}", "PUT")]
    public class UpdateCar : CarViewModel, IReturn<UpdateCarResponse>
    {
        public string Id { get; set; }
    }

    public class UpdateCarResponse
    {
        public CarViewModel Car { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

    //Validation For Request
    public class UpdateCarValidator : AbstractValidator<UpdateCar>
    {
        public UpdateCarValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
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