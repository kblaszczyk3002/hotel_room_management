using HotelRoomManagement.Domain.CommandModels.Interfaces;
using HotelRoomManagement.Domain.Enums;

namespace HotelRoomManagement.Domain.CommandModels
{
    public class CreateNewHotelRoomModel : IHotelRoomCommandModel
    {
        public string Name { get; set; }
        public decimal Size { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsAvailable { get; set; }
        public ReasonOfOccupation? ReasonOfOccupation { get; set; }
        public ReasonOfMaintenance? ReasonOfMaintenance { get; set; }
        public string? AdditionalDetails { get; set; }
    }
}
