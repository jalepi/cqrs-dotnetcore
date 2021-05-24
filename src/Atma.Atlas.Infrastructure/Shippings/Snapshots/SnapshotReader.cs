using Atma.Atlas.Shippings.DataObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atma.Atlas.Shippings.Snapshots
{
    public class SnapshotReader : ISnapshotReader
    {
        private readonly SnapshotCollectionProvider _provider;

        public SnapshotReader(SnapshotCollectionProvider provider)
        {
            _provider = provider;
        }

        public async Task<SnapshotEntity?> Read(GetLatestSnapshotQueryEntity request, CancellationToken cancellationToken)
        {
            using var cursor = await _provider.Collection.FindAsync(
                filter: Builders<SnapshotDocument>.Filter.Eq(o => o.PartitionKey, PartitionKey.Get(request)),
                options: new FindOptions<SnapshotDocument> 
                {
                    Sort = Builders<SnapshotDocument>.Sort.Descending(o => o.UpdatedTime),
                    Limit = 1,
                });

            if (await cursor.MoveNextAsync(cancellationToken))
            {
                if (cursor.Current.FirstOrDefault() is SnapshotDocument document)
                {
                    return document.ToEntity();
                }
            }

            return default;
        }
    }
}
