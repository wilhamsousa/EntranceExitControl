using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Model.DTOs
{
    public record CheckListOptionCreateRequest
    {
        public string Name { get; init; }
        public string Note { get; init; }

        public CheckListOptionCreateRequest(string name, string note)
        {
            Name = name;
            Note = note;
        }

        public static implicit operator CheckListOption(CheckListOptionCreateRequest dto) =>
            new CheckListOption(Guid.NewGuid(), dto.Name, dto.Note);
        
    }
}
