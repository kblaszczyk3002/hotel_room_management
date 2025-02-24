using HotelRoomManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomManagement.Domain.Model
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Size), IsUnique = true)]
    [Index(nameof(IsAvailable), IsUnique = true)]
    [Table("HotelRoom", Schema = "hrm")]
    public class HotelRoom
    {
        public int HotelRoomId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Size { get; set; }
        [Required]
        public RoomType RoomType { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        public ReasonOfOccupation? ReasonOfOccupation { get; set; }
        public ReasonOfMaintenance? ReasonOfMaintenance { get; set; }
        public string? AdditionalDetails { get; set; }
    }
}
