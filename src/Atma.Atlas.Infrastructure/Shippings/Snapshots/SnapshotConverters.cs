using Atma.Atlas.Shippings.DataObjects;
using System;
using System.Linq;

namespace Atma.Atlas.Shippings.Snapshots
{
    public static class SnapshotConverters
    {
        public static SnapshotEntity ToEntity(this SnapshotDocument document)
        {
            return new SnapshotEntity(
                organization: document.Organization,
                tenant: document.Tenant,
                site: document.Site,
                cartonId: document.CartonId ?? "",
                createdTime: document.CreatedTime,
                updatedTime: document.UpdatedTime,
                businessLocation: document.BusinessLocation,
                readPoint: document.ReadPoint,
                products: (document.Products ?? Array.Empty<SnapshotDocument.Product>()).Select(ToEntity).ToArray());
        }

        public static SnapshotEntity.Product ToEntity(this SnapshotDocument.Product product)
        {
            return new SnapshotEntity.Product(
                sku: product.Sku ?? "",
                targetQuantity: product.TargetQuantity ?? 0,
                items: product.Items ?? Array.Empty<string>());
        }

        public static SnapshotDocument ToDocument(this SnapshotEntity currentSnapshot)
        {
            return new SnapshotDocument
            {
                PartitionKey = PartitionKey.Get(currentSnapshot),
                Organization = currentSnapshot.Organization,
                Tenant = currentSnapshot.Tenant,
                Site = currentSnapshot.Site,
                CartonId = currentSnapshot.CartonId,
                CreatedTime = currentSnapshot.CreatedTime,
                UpdatedTime = currentSnapshot.UpdatedTime,
                BusinessLocation = currentSnapshot.BusinessLocation,
                ReadPoint = currentSnapshot.ReadPoint,
                DeliveryNoteNumber = default,
                DestinationSite = default,
                Products = (currentSnapshot.Products ?? Array.Empty<SnapshotEntity.Product>()).Select(ToDocument).ToArray(),
            };
        }

        public static SnapshotDocument.Product ToDocument(this SnapshotEntity.Product product)
        {
            return new SnapshotDocument.Product
            {
                Sku = product.Sku ?? "",
                TargetQuantity = product.TargetQuantity,
                Items = product.Items ?? Array.Empty<string>(),
            };
        }
    }
}
