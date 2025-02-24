using HotelRoomManagement.DataAccess.Interfaces;
using HotelRoomManagement.Domain.CommandModels;
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

        public async Task<HotelRoom> GetHotelRoomById(int hotelRoomId)
        {
            return await _hotelRoomContext.HotelRooms.Where(x => x.HotelRoomId == hotelRoomId).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<HotelRoom>> GetHotelRooms(HotelRoomFilterModel hotelRoomFilterModel)
        {
            var hotelRooms = _hotelRoomContext.HotelRooms.AsNoTracking()
                .Where(x => (string.IsNullOrWhiteSpace(hotelRoomFilterModel.Name) || x.Name.Contains(hotelRoomFilterModel.Name)) &&
                            (!hotelRoomFilterModel.Size.HasValue || x.Size == hotelRoomFilterModel.Size) &&
                            (!hotelRoomFilterModel.IsAvailable.HasValue || x.IsAvailable == hotelRoomFilterModel.IsAvailable));

            return await hotelRooms.ToListAsync();
        }

        public async Task UpdateHotelRoomDetails()
        {
            await _hotelRoomContext.SaveChangesAsync();
        }
    }
}
