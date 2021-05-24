using Atma.Atlas.Shippings.DataObjects;
using System;
using System.Collections.Generic;

namespace Atma.Atlas.Shippings.Commands
{
    public static class CommandConverters
    {
        public static ICommandEntity ToEntity(this CommandDocument document)
        {
            return document switch
            {
                AddItemsCommandDocument addItems => ToEntity(addItems),
                _ => new MissingCommandEntity(
                    organization: document.Organization,
                    tenant: document.Tenant,
                    site: document.Site,
                    cartonId: document.CartonId ?? "",
                    createdTime: DateTime.MinValue),
            };
        }

        public static AddItemsCommandEntity ToEntity(this AddItemsCommandDocument document)
        {
            return new AddItemsCommandEntity(
                organization: document.Organization,
                tenant: document.Tenant,
                site: document.Site,
                cartonId: document.CartonId ?? "",
                createdTime: document.CreatedTime,
                businessLocation: document.BusinessLocation,
                readPoint: document.ReadPoint,
                itemIdentifiers: document.ItemIdentifiers ?? new HashSet<string>());
        }
    }
}
