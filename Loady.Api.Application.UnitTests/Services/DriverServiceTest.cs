using AutoMapper;
using Loady.Api.Application.Dto;
using Loady.Api.Application.Services;
using Loady.Api.Core.Entities;
using Loady.Api.Core.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace Loady.Api.Application.UnitTests.Services
{
    public class DriverServiceTest
    {
        private Mock<IBaseRepository<Driver>> _driverRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private DriverService _driverService;

        public DriverServiceTest()
        {
            _driverRepositoryMock = new Mock<IBaseRepository<Driver>>();
            _mapperMock = new Mock<IMapper>();
            _driverService = new DriverService(_driverRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void GetByCity_WhenCalled_ShouldRequest_Repository()
        {
            var result = _driverService.GetByCity(It.IsAny<string>());

            _driverRepositoryMock.Verify(x => x.FilterBy(It.IsAny<Expression<Func<Driver, bool>>>()), Times.AtLeastOnce());
        }

        [Fact]
        public void GetByCity_WhenCalled_Should_Map_Returned_Result()
        {
            var result = _driverService.GetByCity(It.IsAny<string>());

            _mapperMock.Verify(x => x.Map<IEnumerable<It.IsAnyType>>(It.IsAny<IEnumerable<It.IsAnyType>>()), Times.AtLeastOnce());
        }
    }
}
