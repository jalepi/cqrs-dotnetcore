using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Atma.Atlas.Shippings.Queries
{
    [BsonDiscriminator("entity", Required = true, RootClass = true)]
    [BsonKnownTypes(typeof(CartonQueryDocument))]
    public abstract class QueryDocument : BaseDocument
    {
        public virtual DateTime CreatedTime { get; set; }
        public virtual DateTime UpdatedTime { get; set; }
    }

    public class CartonQueryDocument : QueryDocument
    {

    }
}
