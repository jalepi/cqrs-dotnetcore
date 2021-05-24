using MongoDB.Driver;

namespace Atma.Atlas.Shippings
{
    public interface ICollectionProvider<T>
    {
        IMongoCollection<T> Collection { get; }
    }
}
