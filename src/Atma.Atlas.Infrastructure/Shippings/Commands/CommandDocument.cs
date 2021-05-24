using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Atma.Atlas.Shippings.Commands
{
    [BsonKnownTypes(typeof(AddItemsCommandDocument))]
    public abstract class CommandDocument : BaseDocument
    {
        public virtual string? CartonId { get; set; }
        public virtual DateTime CreatedTime { get; set; }
    }

    [BsonDiscriminator(discriminator: "add-items", Required = true, RootClass = false)]
    public class AddItemsCommandDocument : CommandDocument
    {
        public string? BusinessLocation { get; set; }
        public string? ReadPoint { get; set; }
        public IReadOnlyCollection<string>? ItemIdentifiers { get; set; }
    }
}
