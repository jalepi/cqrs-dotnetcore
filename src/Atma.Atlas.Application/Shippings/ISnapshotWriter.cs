using Atma.Atlas.Shippings.DataObjects;
using System.Threading;
using System.Threading.Tasks;

namespace Atma.Atlas.Shippings
{
    public interface ISnapshotWriter
    {
        Task Write(SnapshotEntity currentSnapshot, CancellationToken cancellationToken);
    }
}
