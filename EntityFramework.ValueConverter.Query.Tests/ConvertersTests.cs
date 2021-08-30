using System.Linq;
using System.Threading.Tasks;
using EntityFramework.ValueConverter.Query.Extensions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EntityFramework.ValueConverter.Query.Tests
{
    public class ConvertersTests : IClassFixture<TestFixture>
    {
        private readonly TestFixture _fixture;

        public ConvertersTests(TestFixture fixture)
        {
            _fixture = fixture;
        }
        
        [Fact]
        public async Task Test_OK()
        {
            var result = await _fixture.Context.TestEntities.Where(q => EF.Functions.Contains(q.Values, "1")).ToArrayAsync();
            
            Assert.NotNull(result);
        }
    }
}