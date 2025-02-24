using HotelRoomManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement.Domain.CommandModels.Interfaces
{
    public interface IHotelRoomCommandModel
    {
        string Name { get; set; }
        decimal Size { get; set; }
        RoomType RoomType { get; set; }
        bool IsAvailable { get; set; }
        ReasonOfOccupation? ReasonOfOccupation { get; set; }
        ReasonOfMaintenance? ReasonOfMaintenance { get; set; }
        string? AdditionalDetails { get; set; }
    }
}
