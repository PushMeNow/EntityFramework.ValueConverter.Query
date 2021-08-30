using System;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.ValueConverter.Query.Extensions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EntityFramework.ValueConverter.Query.Tests
{
    public class ConvertersTests : IDisposable
    {
        private readonly TestFixture _fixture;

        public ConvertersTests()
        {
            _fixture = new TestFixture();
        }

        [Fact]
        public async Task CustomContains_OK()
        {
            var result = await _fixture.Context
                                       .TestEntities
                                       .Where(q => EF.Functions.Contains(q.Values, "1"))
                                       .ToArrayAsync();

            Assert.NotNull(result);
            Assert.Single(result);
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}