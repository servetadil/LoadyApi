using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            RuleFor(x => x.City).Length(0, 100);
        }
    }
}
