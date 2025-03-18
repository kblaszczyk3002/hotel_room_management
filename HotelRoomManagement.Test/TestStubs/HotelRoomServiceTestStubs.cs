using HotelRoomManagement.DataAccess.Interfaces;
using HotelRoomManagement.Domain.CommandModels;
using HotelRoomManagement.Domain.DTOs;
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
                HotelRoomGuid = new Guid("fb69d80d-8b0d-48a9-a045-6cc74eee7b90"),
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
                HotelRoomGuid = new Guid("d669f9da-d067-44e1-91c2-ba4c3842454f"),
                Name = "double room",
                Size = 50,
                RoomType = RoomType.StandardDoubleRoom,
                IsAvailable = true
            };
        }

        public static IEnumerable<HotelRoomDto> GetTestHotelRoomCollectionByParameter(string? name = null, int? size = null, bool? isAvailable = null)
        {
            var hotelRoomCollection = new List<HotelRoomDto>();

            var hotelRoomItem1 = new HotelRoomDto
            {
                HotelRoomId = 1,
                HotelRoomGuid = new Guid("8671d28e-db87-41b7-9446-365fbb60c288"),
                Name = "single room",
                Size = 35,
                RoomType = RoomType.SingleRoom,
                IsAvailable = true
            };

            hotelRoomCollection.Add(hotelRoomItem1);

            var hotelRoomItem2 = new HotelRoomDto
            {
                HotelRoomId = 2,
                HotelRoomGuid = new Guid("ecfe6aa4-36f5-4957-a8cf-83efb0999b11"),
                Name = "double room",
                Size = 60,
                RoomType = RoomType.StandardDoubleRoom,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.Booked
            };

            hotelRoomCollection.Add(hotelRoomItem2);

            var hotelRoomItem3 = new HotelRoomDto
            {
                HotelRoomId = 3,
                HotelRoomGuid = new Guid("03b98946-c5d5-41c8-bed9-a1b2f7889a72"),
                Name = "deluxe double room",
                Size = 70,
                RoomType = RoomType.DeluxeDoubleRoom,
                IsAvailable = true
            };

            hotelRoomCollection.Add(hotelRoomItem3);

            var hotelRoomItem4 = new HotelRoomDto
            {
                HotelRoomId = 4,
                HotelRoomGuid = new Guid("38872398-bdf5-4764-bf7d-e61be66694c1"),
                Name = "junior suite",
                Size = 90,
                RoomType = RoomType.JuniorSuite,
                IsAvailable = false,
                ReasonOfOccupation = ReasonOfOccupation.Maintenance,
                ReasonOfMaintenance = ReasonOfMaintenance.WaterLeek,
                AdditionalDetails = "Room is unavailable due to maintenance works taking place. There reason why maintenance is needed is - waterleek"
            };

            hotelRoomCollection.Add(hotelRoomItem4);

            var hotelRoomItem5 = new HotelRoomDto
            {
                HotelRoomId = 5,
                HotelRoomGuid = new Guid("304a0487-ed52-4376-8e9a-23d2214602d2"),
                Name = "twin room",
                Size = 60,
                RoomType = RoomType.StandardTwinRoom,
                IsAvailable = true
            };

            hotelRoomCollection.Add(hotelRoomItem5);

            var hotelRoomItem6 = new HotelRoomDto
            {
                HotelRoomId = 6,
                HotelRoomGuid = new Guid("e8fac57d-f85f-47ba-aedc-de04034caea0"),
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
                HotelRoomGuid = new Guid("38872398-bdf5-4764-bf7d-e61be66694c1"),
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
                HotelRoomGuid = new Guid("38872398-bdf5-4764-bf7d-e61be66694c1"),
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
                HotelRoomGuid = new Guid("38872398-bdf5-4764-bf7d-e61be66694c1"),
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
