using Atma.Atlas.Shippings.DataObjects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Atma.Atlas.Shippings
{
    public interface ISnapshotReader
    {
        Task<SnapshotEntity?> Read(GetLatestSnapshotQueryEntity request, CancellationToken cancellationToken);
    }
}
