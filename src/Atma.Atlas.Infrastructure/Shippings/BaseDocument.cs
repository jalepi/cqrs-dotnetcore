using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Atma.Atlas.Shippings
{
    public abstract class BaseDocument : IPartitioned
    {
        [BsonId]
        public virtual ObjectId Id { get; set; }
        public virtual string PartitionKey { get; set; } = "";
        public virtual string Organization { get; set; } = "";
        public virtual string Tenant { get; set; } = "";
        public virtual string Site { get; set; } = "";
    }
}
