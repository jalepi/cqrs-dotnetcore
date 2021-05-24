using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Atma.Atlas.Shippings.Commands.CreateSnapshot
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly ICommandReader _commandReader;
        private readonly ISnapshotReader _snapshotReader;
        private readonly ISnapshotWriter _snapshotWriter;
        private readonly ILogger _logger;

        public Handler(
            ICommandReader commandReader,
            ISnapshotReader snapshotReader,
            ISnapshotWriter snapshotWriter,
            ILogger<Handler> logger)
        {
            _commandReader = commandReader;
            _snapshotReader = snapshotReader;
            _snapshotWriter = snapshotWriter;
            _logger = logger;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var entity = new DataObjects.GetLatestSnapshotQueryEntity(
                organization: request.Organization,
                tenant: request.Tenant,
                site: request.Site,
                cartonId: request.CartonId);

            var latestSnapshot = await _snapshotReader.Read(entity, cancellationToken) 
                ?? new DataObjects.SnapshotEntity(
                    organization: request.Organization,
                    tenant: request.Tenant,
                    site: request.Site,
                    cartonId: request.CartonId,
                    createdTime: default,
                    updatedTime: default,
                    businessLocation: default,
                    readPoint: default,
                    products: Array.Empty<DataObjects.SnapshotEntity.Product>());

            var commands = await _commandReader.Read(
                query: new DataObjects.GetCommandsQueryEntity(
                    organization: request.Organization,
                    tenant: request.Tenant,
                    site: request.Site,
                    cartonId: request.CartonId,
                    fromTime: latestSnapshot.UpdatedTime,
                    toTime: DateTime.UtcNow - request.Latency),
                cancellationToken: cancellationToken);

            var currentSnapshot = SnapshotCommandReducer.Reduce(
                snapshot: latestSnapshot,
                commands: commands);

            await _snapshotWriter.Write(currentSnapshot, cancellationToken);


            return Response.Success;
        }
    }
}
