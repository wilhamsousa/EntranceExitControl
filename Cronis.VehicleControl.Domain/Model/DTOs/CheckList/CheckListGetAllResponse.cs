using System.Xml.Linq;

namespace Cronis.VehicleControl.Domain.Model.DTOs.CheckList
{
    public readonly record struct CheckListGetAllResponse(
        Guid Id,
        Guid UserId,
        string VehiclePlate,
        DateTime StartDateTime,
        DateTime? EndDateTime,
        string Status,
        string UserName
    );
}
