using System;
using System.Collections.Generic;
using System.Text;

namespace Atma.Atlas.Shippings.DataObjects
{
    public class GetCommandsQueryEntity : IPartitioned
    {
        public GetCommandsQueryEntity(
            string organization,
            string tenant,
            string site,
            string cartonId,
            DateTime fromTime,
            DateTime toTime)
        {
            Organization = organization;
            Tenant = tenant;
            Site = site;
            CartonId = cartonId;
            FromTime = fromTime;
            ToTime = toTime;
        }

        public string Organization { get; }
        public string Tenant { get; }
        public string Site { get; }
        public string CartonId { get; }
        public DateTime FromTime { get; }
        public DateTime ToTime { get; }
    }
}
