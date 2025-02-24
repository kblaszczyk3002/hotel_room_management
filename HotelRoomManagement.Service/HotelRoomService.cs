using HotelRoomManagement.DataAccess.Interfaces;
using HotelRoomManagement.Domain.CommandModels;
using HotelRoomManagement.Domain.Model;
using HotelRoomManagement.Domain.QuerryModels;
using HotelRoomManagement.Service.Helpers;
using HotelRoomManagement.Service.Interfaces;

namespace HotelRoomManagement.Service
{
    public class HotelRoomService : IHotelRoomService
    {
        private readonly IHotelRoomRepository _hotelRoomRepository;
        public HotelRoomService(IHotelRoomRepository hotelRoomRepository)
        {
            _hotelRoomRepository = hotelRoomRepository;
        }

        public async Task<HotelRoom> CreateNewHotelRoom(CreateNewHotelRoomModel createNewHotelRoomModel)
        {
            var hotelRoom = new HotelRoom
            {
                Name = createNewHotelRoomModel.Name,
                Size = createNewHotelRoomModel.Size,
                RoomType = createNewHotelRoomModel.RoomType,
                IsAvailable = createNewHotelRoomModel.IsAvailable
            };

            AvailabilityOperationHelper.ValidateAvailabilityAndAddProperAdditionalDetails(hotelRoom, createNewHotelRoomModel);

            await _hotelRoomRepository.CreateNewHotelRoom(hotelRoom);

            return hotelRoom;
        }

        public async Task<HotelRoom> GetHotelRoomById(int hotelRoomId)
        {
            if (hotelRoomId <= 0)
                throw new ArgumentException("Please specify the hotel room Id value greater then 0");

            return await _hotelRoomRepository.GetHotelRoomById(hotelRoomId);
        }

        public async Task<IEnumerable<HotelRoom>> GetHotelRooms(string? name = null, decimal? size = null, bool? isAvailable = null)
        {
            var hotelRoomFilterModel = new HotelRoomFilterModel
            {
                Name = name,
                Size = size,
                IsAvailable = isAvailable
            };
            return await _hotelRoomRepository.GetHotelRooms(hotelRoomFilterModel);
        }

        public async Task<HotelRoom> UpdateHotelRoomDetails(UpdateHotelRoomDetailsModel updateHotelRoomDetailsModel)
        {
            var dbHotelRoom = await GetHotelRoomById(updateHotelRoomDetailsModel.HotelRoomId);

            if (dbHotelRoom != null)
            {
                AvailabilityOperationHelper.ValidateAvailabilityAndAddProperAdditionalDetails(dbHotelRoom, updateHotelRoomDetailsModel);

                dbHotelRoom.Name = updateHotelRoomDetailsModel.Name;
                dbHotelRoom.Size = updateHotelRoomDetailsModel.Size;
                dbHotelRoom.RoomType = updateHotelRoomDetailsModel.RoomType;

                await _hotelRoomRepository.UpdateHotelRoomDetails();
            }
            else
            {
                throw new ArgumentException($"hotel room of id: {updateHotelRoomDetailsModel.HotelRoomId} dose not exist in the database");
            }

            return dbHotelRoom;
        }
    }
}
