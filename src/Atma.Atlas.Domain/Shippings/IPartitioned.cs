namespace Atma.Atlas.Shippings
{
    public interface IPartitioned
    {
        string Organization { get; }
        string Tenant { get; }
        string Site { get; }
    }
}