using System.Collections.Generic;

namespace Atma.Atlas.Shippings.DataObjects
{
    public class InsertAddItemsCommandEntity : IPartitioned
    {
        public InsertAddItemsCommandEntity(
            string organization,
            string tenant,
            string site,
            string cartonId,
            string? businessLocation,
            string? readPoint,
            IReadOnlyCollection<string> itemIdentifiers)
        {
            Organization = organization;
            Tenant = tenant;
            Site = site;
            CartonId = cartonId;
            BusinessLocation = businessLocation;
            ReadPoint = readPoint;
            ItemIdentifiers = itemIdentifiers;
        }

        public string Organization { get; }
        public string Tenant { get; }
        public string Site { get; }
        public string CartonId { get; }
        public string? BusinessLocation { get; }
        public string? ReadPoint { get; }
        public IReadOnlyCollection<string> ItemIdentifiers { get; }
    }
}
