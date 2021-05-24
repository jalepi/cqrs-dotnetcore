namespace Atma.Atlas.Shippings.Snapshots
{
    public class SnapshotCollectionProviderConfiguration : ICollectionConfiguration
    {
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
        public string CollectionName { get; set; } = "";
    }
}
