using MediatR;
using System;

namespace Atma.Atlas.Shippings.Commands.CreateSnapshot
{
    public class Request : IRequest<Response>
    {
        public Request(
            string organization, 
            string tenant,
            string site,
            string cartonId,
            TimeSpan latency)
        {
            Organization = organization;
            Tenant = tenant;
            Site = site;
            CartonId = cartonId;
            Latency = latency;
        }

        public string Organization { get; }
        public string Tenant { get; }
        public string Site { get; }
        public string CartonId { get; }
        public TimeSpan Latency { get; }
    }
}
