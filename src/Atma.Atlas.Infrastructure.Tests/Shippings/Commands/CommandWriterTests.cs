using System.Threading.Tasks;
using Xunit;

namespace Atma.Atlas.Shippings.Commands
{
    public class CommandWriterTests
    {
        [Fact]
        public async Task Write_AddItemsEntity_Succeeds()
        {
            var provider = new CommandCollectionProvider(Fixtures.Configuration.Commands);

            var mongoWriter = new CommandWriter(provider);

            await mongoWriter.Write(
                entity: new DataObjects.InsertAddItemsCommandEntity(
                    organization: "avy",
                    tenant: "atma",
                    site: "graz",
                    cartonId: "abc123",
                    businessLocation: "Home Office",
                    readPoint: "Couch",
                    itemIdentifiers: new[] { "001", "002", "003" }),
                cancellationToken: default);
        }
    }
}
