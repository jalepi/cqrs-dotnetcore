namespace Atma.Atlas.Shippings
{
    public static class PartitionKey
    {
        public static string Get(string organization, string tenant, string site) => $"{organization}/{tenant}/{site}";
        public static string Get(IPartitioned partitioned)
        {
            return Get(organization: partitioned.Organization, tenant: partitioned.Tenant, site: partitioned.Site);
        }
    }
}
