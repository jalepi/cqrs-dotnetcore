using System;
using System.Collections.Generic;

namespace Atma.Atlas.Shippings.DataObjects
{
    public class SnapshotEntity : IPartitioned
    {
        public SnapshotEntity(
            string organization,
            string tenant,
            string site,
            string cartonId,
            DateTime createdTime,
            DateTime updatedTime,
            string? businessLocation,
            string? readPoint,
            IReadOnlyCollection<Product> products)
        {
            Organization = organization;
            Tenant = tenant;
            Site = site;
            CartonId = cartonId;
            CreatedTime = createdTime;
            UpdatedTime = updatedTime;
            BusinessLocation = businessLocation;
            ReadPoint = readPoint;
            Products = products;
        }

        public string Organization { get; }
        public string Tenant { get; }
        public string Site { get; }
        public string CartonId { get; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string? BusinessLocation { get; }
        public string? ReadPoint { get; }
        public IReadOnlyCollection<Product> Products { get; }

        public class Product
        {
            public Product(
                string sku,
                int targetQuantity,
                IReadOnlyCollection<string> items)
            {
                Sku = sku;
                TargetQuantity = targetQuantity;
                Items = items;
            }

            public string Sku { get; }
            public int TargetQuantity { get; }
            public IReadOnlyCollection<string> Items { get; }
        }
    }
}
