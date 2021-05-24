namespace Atma.Atlas.Shippings
{
    public static class Fixtures
    {
        const string ConnectionString = @"mongodb://atma-next-database:ZSBCA5Gy69NoLCj7KKaMYAArcqXPtRHCuGC8rNSn5dzOKQDCvt2bW8Aw17wOlc9uD3mDw9DsfhFMz5zJnVjvHA==@atma-next-database.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@atma-next-database@";

        public static ShippingsConfiguration Configuration = new ShippingsConfiguration
        {
            Commands = new Commands.CommandCollectionProviderConfiguration
            {
                ConnectionString = ConnectionString,
                DatabaseName = "CQRS",
                CollectionName = "Commands",
            },
            Queries = new Queries.QueryCollectionProviderConfiguration
            {
                ConnectionString = ConnectionString,
                DatabaseName = "CQRS",
                CollectionName = "Queries",
            },
            Snapshots = new Snapshots.SnapshotCollectionProviderConfiguration
            {
                ConnectionString = ConnectionString,
                DatabaseName = "CQRS",
                CollectionName = "Snapshots",
            },
        };
    }
}
