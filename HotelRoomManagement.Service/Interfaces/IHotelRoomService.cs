using HotelRoomManagement.Domain.CommandModels;
using HotelRoomManagement.Domain.DTOs;
using HotelRoomManagement.Domain.Model;

namespace HotelRoomManagement.Service.Interfaces
{
    public interface IHotelRoomService
    {
        Task<HotelRoomDto> CreateNewHotelRoom(CreateNewHotelRoomModel createNewHotelRoomModel);
        Task<IEnumerable<HotelRoomDto>> GetHotelRooms(string? name = null, decimal? size = null, bool? isAvailable = null);
        Task<HotelRoom> GetHotelRoomByGuid(Guid hotelRoomGuid);
        Task<HotelRoomDto> UpdateHotelRoomDetails(UpdateHotelRoomDetailsModel updateHotelRoomDetailsModel);
    }
}
