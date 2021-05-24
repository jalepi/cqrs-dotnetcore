namespace Atma.Atlas.Shippings.Commands
{
    public class CommandCollectionProviderConfiguration : ICollectionConfiguration
    {
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
        public string CollectionName { get; set; } = "";
    }
}
