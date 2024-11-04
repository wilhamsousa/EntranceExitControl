namespace Cronis.VehicleControl.Domain.Model.DTOs.CheckList
{
    public readonly record struct CheckListCreateRequest(
        Guid UserId, 
        string VehiclePlate
    );
}
