using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Atma.Atlas.Shippings.Commands.AddItems
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly ICommandWriter _commandWriter;

        public Handler(ICommandWriter commandWriter)
        {
            _commandWriter = commandWriter;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var entity = new DataObjects.InsertAddItemsCommandEntity(
                organization: request.Organization,
                tenant: request.Tenant,
                site: request.Site,
                cartonId: request.CartonId,
                businessLocation: request.BusinessLocation,
                readPoint: request.ReadPoint,
                itemIdentifiers: request.ItemIdentifiers);
            
            await _commandWriter.Write(entity: entity, cancellationToken);

            return Response.Success;
        }
    }
}
