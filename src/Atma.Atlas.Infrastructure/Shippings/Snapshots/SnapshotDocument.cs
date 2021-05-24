using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Atma.Atlas.Shippings.Snapshots
{
    [BsonIgnoreExtraElements]
    public class SnapshotDocument : BaseDocument
    {
        public string? CartonId { get; set; }
        public virtual DateTime CreatedTime { get; set; }
        public virtual DateTime UpdatedTime { get; set; }
        public string? BusinessLocation { get; set; }
        public string? DestinationSite { get; set; }
        public string? DeliveryNoteNumber { get; set; }
        public string? ReadPoint { get; set; }
        public IReadOnlyCollection<Product>? Products { get; set; }

        [BsonIgnoreExtraElements]
        public class Product
        {
            public string? Sku { get; set; }
            public int? TargetQuantity { get; set; }
            public IReadOnlyCollection<string>? Items { get; set; }
        }
    }
}
