using HotelRoomManagement.Domain.DTOs;
using HotelRoomManagement.Domain.Model;
using HotelRoomManagement.Domain.QuerryModels;

namespace HotelRoomManagement.DataAccess.Interfaces
{
    public interface IHotelRoomRepository
    {
        Task CreateNewHotelRoom(HotelRoom hotelRoom);
        Task<IEnumerable<HotelRoomDto>> GetHotelRooms(HotelRoomFilterModel hotelRoomFilterModel);
        Task<HotelRoom> GetHotelRoomByGuid(Guid hotelRoomGuid);
        Task UpdateHotelRoomDetails();
    }
}
