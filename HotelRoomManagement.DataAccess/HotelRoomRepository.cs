using HotelRoomManagement.DataAccess.Interfaces;
using HotelRoomManagement.Domain.DTOs;
using HotelRoomManagement.Domain.Model;
using HotelRoomManagement.Domain.QuerryModels;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManagement.DataAccess
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly IHotelRoomContext _hotelRoomContext;
        public HotelRoomRepository(IHotelRoomContext hotelRoomContext)
        {
            _hotelRoomContext = hotelRoomContext;
        }
        public async Task CreateNewHotelRoom(HotelRoom hotelRoom)
        {
            _hotelRoomContext.HotelRooms.Add(hotelRoom);

            await _hotelRoomContext.SaveChangesAsync();
        }

        public async Task<HotelRoom> GetHotelRoomByGuid(Guid hotelRoomGuid)
        {
            return await _hotelRoomContext.HotelRooms.SingleOrDefaultAsync(x => x.HotelRoomGuid == hotelRoomGuid);
        }

        public async Task<IEnumerable<HotelRoomDto>> GetHotelRooms(HotelRoomFilterModel hotelRoomFilterModel)
        {
            var hotelRooms = _hotelRoomContext.HotelRooms.AsNoTracking()
                .Where(x => (string.IsNullOrWhiteSpace(hotelRoomFilterModel.Name) || x.Name.Contains(hotelRoomFilterModel.Name)) &&
                            (!hotelRoomFilterModel.Size.HasValue || x.Size == hotelRoomFilterModel.Size) &&
                            (!hotelRoomFilterModel.IsAvailable.HasValue || x.IsAvailable == hotelRoomFilterModel.IsAvailable));

            return await hotelRooms.Select(x => new HotelRoomDto
            {
                HotelRoomId = x.HotelRoomId,
                HotelRoomGuid = x.HotelRoomGuid,
                Name = x.Name,
                Size = x.Size,
                RoomType = x.RoomType,
                IsAvailable = x.IsAvailable,
                ReasonOfOccupation = x.ReasonOfOccupation,
                ReasonOfMaintenance = x.ReasonOfMaintenance,
                AdditionalDetails = x.AdditionalDetails
            }).ToListAsync();
        }

        public async Task UpdateHotelRoomDetails()
        {
            await _hotelRoomContext.SaveChangesAsync();
        }
    }
}
