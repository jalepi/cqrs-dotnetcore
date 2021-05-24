using Atma.Atlas.Shippings.DataObjects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Atma.Atlas.Shippings
{
    public interface ICommandReader
    {
        Task<IReadOnlyCollection<ICommandEntity>> Read(GetCommandsQueryEntity query, CancellationToken cancellationToken);
    }
}
