using FluentAssertions;
using Loady.Api.Application.Model;
using Xunit;

namespace Loady.Api.Application.UnitTests.Model
{
    public class GetByCityQueryModelTest
    {
        private GetByCityQueryModelValidator validator { get; }
        public  GetByCityQueryModelTest()
        {
            validator = new GetByCityQueryModelValidator();
        }

        [Fact]
        public void Given_Invalid_Char_Should_Return_ValidationError()
        {
            var query = new GetByCityQueryModel() { City = "?@" };
            validator.Validate(query).IsValid.Should().BeFalse();
        }

        [Fact]
        public void Given_Invalid_Numeric_Should_Return_ValidationError()
        {
            var query = new GetByCityQueryModel() { City = "123" };
            validator.Validate(query).IsValid.Should().BeFalse();
        }

        [Fact]
        public void Given_Correct_Format_Should_Return_NoErrors()
        {
            var query = new GetByCityQueryModel() { City = "Köln" };
            validator.Validate(query).IsValid.Should().BeTrue();
        }
    }
}
