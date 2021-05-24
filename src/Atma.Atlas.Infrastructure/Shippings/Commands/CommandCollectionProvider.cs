using MongoDB.Driver;

namespace Atma.Atlas.Shippings.Commands
{
    public class CommandCollectionProvider : ICollectionProvider<CommandDocument>
    {
        public CommandCollectionProvider(CommandCollectionProviderConfiguration configuration)
        {
            Collection = new MongoClient(configuration.ConnectionString)
                .GetDatabase(configuration.DatabaseName)
                .GetCollection<CommandDocument>(configuration.CollectionName);
        }

        public IMongoCollection<CommandDocument> Collection { get; }
    }
}
