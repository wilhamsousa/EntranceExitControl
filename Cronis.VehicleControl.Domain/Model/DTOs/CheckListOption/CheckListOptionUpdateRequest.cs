namespace Cronis.VehicleControl.Domain.Model.DTOs
{
    public readonly record struct CheckListOptionUpdateRequest(
        Guid Id,
        string Name,
        string Note
    );
}
