using HotelRoomManagement.Domain.CommandModels;
using HotelRoomManagement.Domain.Model;
using HotelRoomManagement.Domain.QuerryModels;

namespace HotelRoomManagement.DataAccess.Interfaces
{
    public interface IHotelRoomRepository
    {
        Task CreateNewHotelRoom(HotelRoom hotelRoom);
        Task<IEnumerable<HotelRoom>> GetHotelRooms(HotelRoomFilterModel hotelRoomFilterModel);
        Task<HotelRoom> GetHotelRoomById(int hotelRoomId);
        Task UpdateHotelRoomDetails();
    }
}
