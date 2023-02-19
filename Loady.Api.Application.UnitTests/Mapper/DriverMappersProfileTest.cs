using AutoMapper;
using Loady.Api.Application.Mapper;
using Xunit;

namespace Loady.Api.Application.UnitTests
{
    public class DriverMappersProfileTest
    {
        [Fact]
        public void Given_DriversMappingProfile_Should_Valid()
        {
            var config = new MapperConfiguration(
            cfg =>
            {
                 cfg.AddProfile(new DriversMapperProfile());
            });

            IMapper mapper = new AutoMapper.Mapper(config);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}