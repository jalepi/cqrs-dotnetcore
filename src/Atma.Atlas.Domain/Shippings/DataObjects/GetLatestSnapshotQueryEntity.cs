namespace Atma.Atlas.Shippings.DataObjects
{
    public class GetLatestSnapshotQueryEntity : IPartitioned
    {
        public GetLatestSnapshotQueryEntity(
            string organization,
            string tenant,
            string site,
            string cartonId)
        {
            Organization = organization;
            Tenant = tenant;
            Site = site;
            CartonId = cartonId;
        }

        public string Organization { get; }
        public string Tenant { get; }
        public string Site { get; }
        public string CartonId { get; }
    }
}
