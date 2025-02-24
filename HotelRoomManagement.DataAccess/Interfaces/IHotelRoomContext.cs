using HotelRoomManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManagement.DataAccess.Interfaces
{
    public interface IHotelRoomContext : IDbContext
    {
        DbSet<HotelRoom> HotelRooms { get; set; }
    }
}
