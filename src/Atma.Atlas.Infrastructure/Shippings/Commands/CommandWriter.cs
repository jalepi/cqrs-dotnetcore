using Atma.Atlas.Shippings.DataObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Atma.Atlas.Shippings.Commands
{
    public class CommandWriter : ICommandWriter
    {
        private readonly CommandCollectionProvider _provider;

        public CommandWriter(CommandCollectionProvider provider)
        {
            _provider = provider;
        }

        public async Task Write(InsertAddItemsCommandEntity entity, CancellationToken cancellationToken)
        {
            var document = new AddItemsCommandDocument
            {
                PartitionKey = PartitionKey.Get(entity),
                Organization = entity.Organization,
                Tenant = entity.Tenant,
                Site = entity.Site,
                CartonId = entity.CartonId,
                BusinessLocation = entity.BusinessLocation,
                ReadPoint = entity.ReadPoint,
                ItemIdentifiers = entity.ItemIdentifiers,
                CreatedTime = DateTime.UtcNow,
            };

            await _provider.Collection.InsertOneAsync(
                document: document,
                cancellationToken: cancellationToken);
        }
    }
}
