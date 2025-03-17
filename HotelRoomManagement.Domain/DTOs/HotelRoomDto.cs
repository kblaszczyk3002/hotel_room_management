using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManagement.Domain.Enums;

namespace HotelRoomManagement.Domain.DTOs
{
    public class HotelRoomDto
    {
        public int HotelRoomId { get; set; }
        public Guid HotelRoomGuid { get; set; }
        public string Name { get; set; }
        public decimal Size { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsAvailable { get; set; }
        public ReasonOfOccupation? ReasonOfOccupation { get; set; }
        public ReasonOfMaintenance? ReasonOfMaintenance { get; set; }
        public string? AdditionalDetails { get; set; }
    }
}
