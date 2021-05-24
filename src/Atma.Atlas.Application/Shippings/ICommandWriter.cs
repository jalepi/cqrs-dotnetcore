using Atma.Atlas.Shippings.DataObjects;
using System.Threading;
using System.Threading.Tasks;

namespace Atma.Atlas.Shippings
{
    public interface ICommandWriter
    {
        Task Write(InsertAddItemsCommandEntity entity, CancellationToken cancellationToken);
    }
}
