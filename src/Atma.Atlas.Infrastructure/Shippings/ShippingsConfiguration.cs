namespace Atma.Atlas.Shippings
{
    public class ShippingsConfiguration
    {
        public Commands.CommandCollectionProviderConfiguration Commands { get; set; } = new Commands.CommandCollectionProviderConfiguration();
        public Queries.QueryCollectionProviderConfiguration Queries { get; set; } = new Queries.QueryCollectionProviderConfiguration();
        public Snapshots.SnapshotCollectionProviderConfiguration Snapshots { get; set; } = new Snapshots.SnapshotCollectionProviderConfiguration();
    }
}
