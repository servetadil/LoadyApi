using Loady.Api.Core.Entities;
using Loady.Api.Core.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Loady.Api.Core.UnitTests
{
    public class UnitTest1
    {
        private Mock<MongoClient> _mongoClientMock;
        private Mock<IMongoDatabase> _database;
        private Mock<IMongoCollection<Driver>> _mockCollection;
        private BaseRepository<Driver> _baseRepository;
        private Mock<IConfiguration> _configurationMock;
        public UnitTest1()
        {
            _mongoClientMock = new Mock<MongoClient>();
            _configurationMock = new Mock<IConfiguration>();
            _configurationMock.SetupGet(x => x[It.Is<string>(s => s == "MongoDbSettings:DatabaseName")]).Returns("loadyapidb-driverstorage-db");

            _database = new Mock<IMongoDatabase>();
            
            var _list = new List<Driver>() { new Driver() { Name = "Test" }, new Driver() { Name = "Test" } };

            Mock<IAsyncCursor<Driver>> _resultCursor = new Mock<IAsyncCursor<Driver>>();
            _resultCursor.Setup(_ => _.Current).Returns(_list);
            _resultCursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);
            _resultCursor
                .SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true))
                .Returns(Task.FromResult(false));


            _mockCollection = new Mock<IMongoCollection<Driver>>();
            _mockCollection.Setup(_ => _.FindAsync(
                It.IsAny<FilterDefinition<Driver>>(),
                It.IsAny<FindOptions<Driver, Driver>>(),
                It.IsAny<CancellationToken>()
            ))
            .ReturnsAsync(_resultCursor.Object);

            _baseRepository = new BaseRepository<Driver>(_mongoClientMock.Object, _configurationMock.Object);
        }

        [Fact]
        public async Task FilterBy_Should_Call_FindAsync_AtLeast_Once()
        {
            var result = await _baseRepository.FilterBy(It.IsAny<Expression<Func<Driver, bool>>>());

            _mockCollection.Verify(x => x.FindAsync(
                It.IsAny<FilterDefinition<Driver>>(),
                It.IsAny<FindOptions<Driver, Driver>>(),
                It.IsAny<CancellationToken>()), Times.AtLeastOnce());
        }
    }
}