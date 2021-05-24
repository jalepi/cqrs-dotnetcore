using System;
using System.Collections.Generic;

namespace Atma.Atlas.Shippings.DataObjects
{
    public interface ICommandEntity : IPartitioned
    {
        string CartonId { get; }
        DateTime CreatedTime { get; }
    }

    public class MissingCommandEntity : ICommandEntity
    {
        public MissingCommandEntity(
            string organization,
            string tenant,
            string site,
            string cartonId,
            DateTime createdTime)
        {
            Organization = organization;
            Tenant = tenant;
            Site = site;
            CartonId = cartonId;
            CreatedTime = createdTime;
        }

        public string Organization { get; }
        public string Tenant { get; }
        public string Site { get; }
        public string CartonId { get; }
        public DateTime CreatedTime { get; }
    }

    public class AddItemsCommandEntity : ICommandEntity
    {
        public AddItemsCommandEntity(
            string organization,
            string tenant,
            string site,
            string cartonId,
            DateTime createdTime,
            string? businessLocation,
            string? readPoint,
            IReadOnlyCollection<string> itemIdentifiers)
        {
            Organization = organization;
            Tenant = tenant;
            Site = site;
            CartonId = cartonId;
            CreatedTime = createdTime;
            BusinessLocation = businessLocation;
            ReadPoint = readPoint;
            ItemIdentifiers = itemIdentifiers;
        }

        public string Organization { get; }
        public string Tenant { get; }
        public string Site { get; }
        public string CartonId { get; }
        public DateTime CreatedTime { get; }
        public string? BusinessLocation { get; }
        public string? ReadPoint { get; }
        public IReadOnlyCollection<string> ItemIdentifiers { get; }
    }
}
