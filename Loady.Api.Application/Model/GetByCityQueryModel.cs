using FluentValidation;

namespace Loady.Api.Application.Model
{
    public class GetByCityQueryModel
    {
        public string City { get; set; }
    }

    public class GetByCityQueryModelValidator : AbstractValidator<GetByCityQueryModel>
    {
        public GetByCityQueryModelValidator()
        {
            RuleFor(x => x.City).NotNull();
            RuleFor(x => x.City).Matches("[A-Z]");
            RuleFor(x => x.City).Matches("[a-z]");
            RuleFor(x => x.City).Length(0, 100);
        }
    }
}
