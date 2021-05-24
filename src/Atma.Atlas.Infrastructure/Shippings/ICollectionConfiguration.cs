namespace Atma.Atlas.Shippings
{
    public interface ICollectionConfiguration
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
    }
}
