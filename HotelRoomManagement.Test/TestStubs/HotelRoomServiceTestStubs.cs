using HotelRoomManagement.DataAccess.Interfaces;
using HotelRoomManagement.Domain.CommandModels;
using HotelRoomManagement.Domain.Enums;
using HotelRoomManagement.Domain.Model;
using HotelRoomManagement.Domain.QuerryModels;

namespace HotelRoomManagement.Test.TestStubs
{
    public class HotelRoomServiceTestStubs
    {
        public static UpdateHotelRoomDetailsModel GetHotelRoomUpdateModelTestStub()
        {
            return new UpdateHotelRoomDetailsModel
            {
                HotelRoomId = 0,
                Name = "single room",
                Size = 30,
                RoomType = RoomType.SingleRoom,
                IsAvailable = true
            };
        }

        public static HotelRoom GetTestHotelRoom()
        {
            return new HotelRoom
            {
                HotelRoomId = 1,
                Name = "double room",
                Size = 50,
                RoomType = RoomType.StandardDoubleRoom,
                IsAvailable = true
            };
        }

        public static IEnumerable<HotelRoom> GetTestHotelRoomCollectionByParameter(string? name = null, int? size = null, bool? isAvailable = null)
        {
            var hotelRoomCollection = new List<HotelRoom>();

            var hotelRoomItem1 = new HotelRoom
            {
                HotelRoomId = 1,
                Name = "single room",
                Size = 35,
                RoomType = RoomType.SingleRoom,
                IsAvailable = true
            };

            hotelRoomCollection.Add(hotelRoomItem1);

            var hotelRoomItem2 = new HotelRoom
            {
                HotelRoomId = 2,
                Name = "double room",
                Size = 60,
                RoomType = RoomType.StandardDoubleRoom,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.Booked
            };

            hotelRoomCollection.Add(hotelRoomItem2);

            var hotelRoomItem3 = new HotelRoom
            {
                HotelRoomId = 3,
                Name = "deluxe double room",
                Size = 70,
                RoomType = RoomType.DeluxeDoubleRoom,
                IsAvailable = true
            };

            hotelRoomCollection.Add(hotelRoomItem3);

            var hotelRoomItem4 = new HotelRoom
            {
                HotelRoomId = 4,
                Name = "junior suite",
                Size = 90,
                RoomType = RoomType.JuniorSuite,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.Maintenance,
                ReasonOfMaintenance = ReasonOfMaintenance.WaterLeek,
                AdditionalDetails = "Room is unavailable due to maintenance works taking place. There reason why maintenance is needed is - waterleek"
            };

            hotelRoomCollection.Add(hotelRoomItem4);

            var hotelRoomItem5 = new HotelRoom
            {
                HotelRoomId = 5,
                Name = "twin room",
                Size = 60,
                RoomType = RoomType.StandardTwinRoom,
                IsAvailable = true
            };

            hotelRoomCollection.Add(hotelRoomItem5);

            var hotelRoomItem6 = new HotelRoom
            {
                HotelRoomId = 6,
                Name = "presidential suite",
                Size = 120,
                RoomType = RoomType.PresidentialSuite,
                IsAvailable = true
            };

            hotelRoomCollection.Add(hotelRoomItem6);


            return hotelRoomCollection.Where(x => (string.IsNullOrWhiteSpace(name) || x.Name.Contains(name)) &&
                                            (!size.HasValue || x.Size == size) &&
                                            (!isAvailable.HasValue || x.IsAvailable == isAvailable));
        }

        public static CreateNewHotelRoomModel GetCreateNewHotelRoomModelWithoutOccupationReason()
        {
            return new CreateNewHotelRoomModel
            {
                Name = "executive suite",
                Size = 100,
                RoomType = RoomType.ExecutiveSuite,
                IsAvailable = false
            };
        }

        public static CreateNewHotelRoomModel GetCreateNewHotelRoomModelWithoutMaintenanceReason()
        {
            return new CreateNewHotelRoomModel
            {
                Name = "executive suite",
                Size = 100,
                RoomType = RoomType.ExecutiveSuite,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.Maintenance
            };
        }

        public static CreateNewHotelRoomModel GetCreateNewHotelRoomModel()
        {
            return new CreateNewHotelRoomModel
            {
                Name = "executive suite",
                Size = 100,
                RoomType = RoomType.ExecutiveSuite,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.Booked
            };
        }

        public static CreateNewHotelRoomModel GetCreateNewHotelRoomModelWithMaintenance()
        {
            return new CreateNewHotelRoomModel
            {
                Name = "executive suite",
                Size = 100,
                RoomType = RoomType.ExecutiveSuite,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.Maintenance,
                ReasonOfMaintenance = ReasonOfMaintenance.CentralHeating
            };
        }

        public static CreateNewHotelRoomModel GetCreateNewHotelRoomModelManualLock()
        {
            return new CreateNewHotelRoomModel
            {
                Name = "executive suite",
                Size = 100,
                RoomType = RoomType.ExecutiveSuite,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.ManuallyLocked
            };
        }

        public static UpdateHotelRoomDetailsModel GetUpdateHotelRoomDetailsModelWithoutOccupationReason()
        {
            return new UpdateHotelRoomDetailsModel
            {
                HotelRoomId = 4,
                Name = "junior suite",
                Size = 100,
                RoomType = RoomType.JuniorSuite,
                IsAvailable = false
            };
        }

        public static UpdateHotelRoomDetailsModel GetUpdateHotelRoomDetailsModelWithoutMaintenanceReason()
        {
            return new UpdateHotelRoomDetailsModel
            {
                Name = "junior suite",
                Size = 100,
                RoomType = RoomType.JuniorSuite,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.Maintenance
            };
        }

        public static UpdateHotelRoomDetailsModel GetUpdateHotelRoomDetailsModel()
        {
            return new UpdateHotelRoomDetailsModel
            {
                HotelRoomId = 4,
                Name = "junior suite",
                Size = 100,
                RoomType = RoomType.JuniorSuite,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.Booked
            };
        }

        public static UpdateHotelRoomDetailsModel GetUpdateHotelRoomDetailsModelWithMaintenance()
        {
            return new UpdateHotelRoomDetailsModel
            {
                HotelRoomId = 4,
                Name = "junior suite",
                Size = 100,
                RoomType = RoomType.JuniorSuite,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.Maintenance,
                ReasonOfMaintenance = ReasonOfMaintenance.Lighting
            };
        }

        public static UpdateHotelRoomDetailsModel GetUpdateHotelRoomDetailsModelManualLock()
        {
            return new UpdateHotelRoomDetailsModel
            {
                HotelRoomId = 4,
                Name = "junior suite",
                Size = 100,
                RoomType = RoomType.JuniorSuite,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.ManuallyLocked
            };
        }
    }
}
