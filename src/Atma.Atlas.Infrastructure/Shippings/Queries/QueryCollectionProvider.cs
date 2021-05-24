using MongoDB.Driver;

namespace Atma.Atlas.Shippings.Queries
{
    public class QueryCollectionProvider : ICollectionProvider<QueryDocument>
    {
        public QueryCollectionProvider(QueryCollectionProviderConfiguration configuration)
        {
            Collection = new MongoClient(configuration.ConnectionString)
                .GetDatabase(configuration.DatabaseName)
                .GetCollection<QueryDocument>(configuration.CollectionName);
        }

        public IMongoCollection<QueryDocument> Collection { get; }
    }
}
