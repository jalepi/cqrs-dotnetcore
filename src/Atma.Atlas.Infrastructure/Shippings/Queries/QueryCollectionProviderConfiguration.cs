namespace Atma.Atlas.Shippings.Queries
{
    public class QueryCollectionProviderConfiguration : ICollectionConfiguration
    {
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
        public string CollectionName { get; set; } = "";
    }
}
