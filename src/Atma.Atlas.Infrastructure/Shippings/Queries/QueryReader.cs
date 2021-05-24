namespace Atma.Atlas.Shippings.Queries
{
    public class QueryReader : IQueryReader
    {
        private readonly QueryCollectionProvider _provider;

        public QueryReader(QueryCollectionProvider provider)
        {
            _provider = provider;
        }
    }
}
