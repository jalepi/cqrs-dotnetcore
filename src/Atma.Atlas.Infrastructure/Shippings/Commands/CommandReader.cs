using Atma.Atlas.Shippings.DataObjects;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Atma.Atlas.Shippings.Commands
{
    public class CommandReader : ICommandReader
    {
        private readonly CommandCollectionProvider _provider;
        private readonly FilterDefinitionBuilder<CommandDocument> _filter;
        private readonly SortDefinitionBuilder<CommandDocument> _sort;

        public CommandReader(CommandCollectionProvider provider)
        {
            _provider = provider;
            _filter = Builders<CommandDocument>.Filter;
            _sort = Builders<CommandDocument>.Sort;
        }

        public async Task<IReadOnlyCollection<ICommandEntity>> Read(GetCommandsQueryEntity request, CancellationToken cancellationToken)
        {
            using var cursor = await _provider.Collection.FindAsync(
                filter: _filter.Eq(o => o.PartitionKey, PartitionKey.Get(request))
                    & _filter.Eq(o => o.CartonId, request.CartonId)
                    & _filter.Gt(o => o.CreatedTime, request.FromTime)
                    & _filter.Lt(o => o.CreatedTime, request.ToTime),
                options: new FindOptions<CommandDocument> 
                {
                    Sort = _sort.Ascending(o => o.CreatedTime),
                },
                cancellationToken: cancellationToken);

            List<ICommandEntity> entities = new List<ICommandEntity>();

            while (await cursor.MoveNextAsync(cancellationToken))
            {
                foreach (var document in cursor.Current)
                {
                    if (CommandConverters.ToEntity(document) is ICommandEntity response)
                    {
                        entities.Add(response);
                    }
                }
            }

            return entities;
        }
    }
}
