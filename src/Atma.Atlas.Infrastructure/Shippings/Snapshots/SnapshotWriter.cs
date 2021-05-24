using Atma.Atlas.Shippings.DataObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atma.Atlas.Shippings.Snapshots
{
    public class SnapshotWriter : ISnapshotWriter
    {
        private readonly SnapshotCollectionProvider _provider;
        private readonly FilterDefinitionBuilder<SnapshotDocument> _filter;

        public SnapshotWriter(SnapshotCollectionProvider provider)
        {
            _provider = provider;
            _filter = Builders<SnapshotDocument>.Filter;
        }

        public async Task Write(SnapshotEntity currentSnapshot, CancellationToken cancellationToken)
        {
            var document = currentSnapshot.ToDocument();

            await _provider.Collection.InsertOneAsync(
                document: document,
                cancellationToken: cancellationToken);
        }
    }
}
