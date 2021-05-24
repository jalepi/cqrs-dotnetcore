using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading.Tasks;
using Xunit;

namespace Atma.Atlas.Serverless.Tests
{
    public class ExampleFunctionTests
    {
        [Fact]
        public async Task Run_WithEmptyRequest_ReturnsEmptyResponse()
        {
            // arrange
            var context = new DefaultHttpContext();

            var function = new ExampleFunction(NullLogger<ExampleFunction>.Instance);

            // act
            var response = await function.Run(context.Request);

            // assert
            Assert.NotNull(response);
        }
    }
}
