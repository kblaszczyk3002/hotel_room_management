using HotelRoomManagement.DataAccess.Interfaces;
using HotelRoomManagement.Domain.CommandModels;
using HotelRoomManagement.Domain.DTOs;
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

        public async Task<HotelRoomDto> CreateNewHotelRoom(CreateNewHotelRoomModel createNewHotelRoomModel)
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

            return new HotelRoomDto
            {
                HotelRoomId = hotelRoom.HotelRoomId,
                HotelRoomGuid = hotelRoom.HotelRoomGuid,
                Name = hotelRoom.Name,
                Size = hotelRoom.Size,
                RoomType = hotelRoom.RoomType,
                IsAvailable = hotelRoom.IsAvailable,
                ReasonOfOccupation = hotelRoom.ReasonOfOccupation,
                ReasonOfMaintenance = hotelRoom.ReasonOfMaintenance,
                AdditionalDetails = hotelRoom.AdditionalDetails
            };
        }

        public async Task<HotelRoom> GetHotelRoomByGuid(Guid hotelRoomGuid)
        {
            if (hotelRoomGuid == Guid.Empty)
                throw new ArgumentException("Please provide a valid hotel room identifier");

            return await _hotelRoomRepository.GetHotelRoomByGuid(hotelRoomGuid);
        }

        public async Task<IEnumerable<HotelRoomDto>> GetHotelRooms(string? name = null, decimal? size = null, bool? isAvailable = null)
        {
            var hotelRoomFilterModel = new HotelRoomFilterModel
            {
                Name = name,
                Size = size,
                IsAvailable = isAvailable
            };
            return await _hotelRoomRepository.GetHotelRooms(hotelRoomFilterModel);
        }

        public async Task<HotelRoomDto> UpdateHotelRoomDetails(UpdateHotelRoomDetailsModel updateHotelRoomDetailsModel)
        {
            var dbHotelRoom = await GetHotelRoomByGuid(updateHotelRoomDetailsModel.HotelRoomGuid);

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

            return new HotelRoomDto
            {
                HotelRoomId = dbHotelRoom.HotelRoomId,
                HotelRoomGuid = dbHotelRoom.HotelRoomGuid,
                Name = dbHotelRoom.Name,
                Size = dbHotelRoom.Size,
                RoomType = dbHotelRoom.RoomType,
                IsAvailable = dbHotelRoom.IsAvailable,
                ReasonOfOccupation = dbHotelRoom.ReasonOfOccupation,
                ReasonOfMaintenance = dbHotelRoom.ReasonOfMaintenance,
                AdditionalDetails = dbHotelRoom.AdditionalDetails
            };
        }
    }
}
