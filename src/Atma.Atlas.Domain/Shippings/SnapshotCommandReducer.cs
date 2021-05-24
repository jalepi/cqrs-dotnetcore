using Atma.Atlas.Shippings.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atma.Atlas.Shippings
{
    public static class SnapshotCommandReducer
    {
        public static SnapshotEntity Reduce(SnapshotEntity snapshot, IReadOnlyCollection<ICommandEntity> commands)
        {
            DateTime createdTime = snapshot.CreatedTime;
            DateTime updatedTime = snapshot.UpdatedTime;
            string? businessLocation = snapshot.BusinessLocation;
            string? readPoint = snapshot.ReadPoint;

            Dictionary<string, (HashSet<string> items, int targetQuantity)> productDictionary = (
                from product in snapshot.Products
                group product by product.Sku into @group
                let items = @group.SelectMany(o => o.Items).ToHashSet()
                let targetQuantity = @group.Sum(o => o.TargetQuantity)
                select (key: @group.Key, value: (items, targetQuantity))
            ).ToDictionary(o => o.key, o => o.value);

            foreach (ICommandEntity command in commands)
            {
                createdTime = createdTime > DateTime.MinValue ? createdTime : command.CreatedTime;
                updatedTime = command.CreatedTime;

                switch (command)
                {
                    case AddItemsCommandEntity addItems:
                        Apply(productDictionary, addItems.ItemIdentifiers);
                        if (!string.IsNullOrEmpty(addItems.BusinessLocation))
                            businessLocation = addItems.BusinessLocation;
                        if (!string.IsNullOrEmpty(addItems.ReadPoint))
                            readPoint = addItems.ReadPoint;
                        break;
                    default:
                        break;
                };
            }

            var products = FromDictionary(productDictionary);

            return new SnapshotEntity(
                 organization: snapshot.Organization,
                 tenant: snapshot.Tenant,
                 site: snapshot.Site,
                 cartonId: snapshot.CartonId,
                 createdTime: createdTime,
                 updatedTime: updatedTime,
                 businessLocation: businessLocation,
                 readPoint: readPoint,
                 products: products);
        }

        private static IReadOnlyCollection<SnapshotEntity.Product> FromDictionary(
            IReadOnlyDictionary<string, (HashSet<string> items, int targetQuantity)> productDictionary)
        {
            return (from entry in productDictionary
                    let targetQuantity = entry.Value.targetQuantity
                    let items = entry.Value.items
                    select new SnapshotEntity.Product(
                        sku: entry.Key,
                        targetQuantity: targetQuantity,
                        items: items)).ToArray();
        }

        public static Dictionary<string, (HashSet<string> items, int targetQuantity)> AsDictionary(IReadOnlyCollection<SnapshotEntity.Product> products)
        {
            return (
                from product in products
                group product by product.Sku into @group
                let items = @group.SelectMany(o => o.Items).ToHashSet()
                let targetQuantity = @group.Sum(o => o.TargetQuantity)
                select (key: @group.Key, value: (items, targetQuantity))
            ).ToDictionary(o => o.key, o => o.value);
        }

        public static void Apply(
            this Dictionary<string, (HashSet<string> items, int targetQuantity)> products,
            IReadOnlyCollection<string> itemIdentifiers)
        {
            var groups = (
                from id in itemIdentifiers
                group id by id[..2] into gid
                select (sku: gid.Key, items: gid.ToHashSet())
            ).ToDictionary(o => o.sku, o => o.items);

            foreach (var item in groups)
            {
                if (products.TryGetValue(item.Key, out var tuple))
                {
                    tuple.items = Enumerable.Concat(tuple.items, item.Value).ToHashSet();
                }
                else
                {
                    products.Add(item.Key, (items: item.Value, targetQuantity: -1));
                }
            }
        }
    }
}
