namespace Cronis.VehicleControl.Domain.Model.DTOs.CheckList
{
    public readonly record struct CheckListItemUpdateRequest(
        Guid CheckListItemId
    );
}
