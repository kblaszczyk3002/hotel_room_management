using HotelRoomManagement.Domain.CommandModels;
using HotelRoomManagement.Domain.Model;

namespace HotelRoomManagement.Service.Interfaces
{
    public interface IHotelRoomService
    {
        Task<HotelRoom> CreateNewHotelRoom(CreateNewHotelRoomModel createNewHotelRoomModel);
        Task<IEnumerable<HotelRoom>> GetHotelRooms(string? name = null, decimal? size = null, bool? isAvailable = null);
        Task<HotelRoom> GetHotelRoomById(int hotelRoomId);
        Task<HotelRoom> UpdateHotelRoomDetails(UpdateHotelRoomDetailsModel updateHotelRoomDetailsModel);
    }
}
