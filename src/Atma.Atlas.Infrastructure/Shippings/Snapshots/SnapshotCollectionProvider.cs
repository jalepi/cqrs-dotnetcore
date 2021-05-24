using MongoDB.Driver;

namespace Atma.Atlas.Shippings.Snapshots
{
    public class SnapshotCollectionProvider : ICollectionProvider<SnapshotDocument>
    {
        public SnapshotCollectionProvider(SnapshotCollectionProviderConfiguration configuration)
        {
            Collection = new MongoClient(configuration.ConnectionString)
                .GetDatabase(configuration.DatabaseName)
                .GetCollection<SnapshotDocument>(configuration.CollectionName);
        }

        public IMongoCollection<SnapshotDocument> Collection { get; }
    }
}
