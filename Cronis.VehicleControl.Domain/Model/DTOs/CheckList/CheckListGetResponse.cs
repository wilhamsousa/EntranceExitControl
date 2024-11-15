namespace Cronis.VehicleControl.Domain.Model.DTOs.CheckList
{
    public readonly record struct CheckListGetResponse(
        Guid UserId,
        string VehiclePlate,
        DateTime StartDateTime,
        DateTime? EndDateTime,
        string Status,
        string User
    );
}
