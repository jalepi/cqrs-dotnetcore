namespace Atma.Atlas.Shippings.Queries
{
    class QueryWriter
    {
        private readonly QueryCollectionProvider _provider;

        public QueryWriter(QueryCollectionProvider provider)
        {
            _provider = provider;
        }
    }
}
