using System;
using System.Threading.Tasks;
using Xunit;

namespace Atma.Atlas.Shippings.Commands
{
    public class CommandReaderTests
    {
        [Fact]
        public async Task Read_GetCommandEntities_ReturnsValidResult()
        {
            var provider = new CommandCollectionProvider(Fixtures.Configuration.Commands);

            var reader = new CommandReader(provider);

            var request = new DataObjects.GetCommandsQueryEntity(
                organization: "avy",
                tenant: "atma",
                site: "graz",
                cartonId: "abc123",
                fromTime: DateTime.MinValue.ToUniversalTime(),
                toTime: DateTime.MaxValue.ToUniversalTime());

            var response = await reader.Read(request: request, cancellationToken: default);

            Assert.NotNull(response);
        }
    }
}
