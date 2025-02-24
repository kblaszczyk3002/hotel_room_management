using HotelRoomManagement.DataAccess.Interfaces;
using HotelRoomManagement.Domain.QuerryModels;
using HotelRoomManagement.Service;
using HotelRoomManagement.Service.Interfaces;
using Moq;
using HotelRoomManagement.Test.TestStubs;

namespace HotelRoomManagement.Test
{
    [TestClass]
    public class HotelRoomServiceUnitTests
    {
        private IHotelRoomService _hotelRoomService;
        private Mock<IHotelRoomService> _mockHotelRoomService = new Mock<IHotelRoomService>();
        private Mock<IHotelRoomRepository> _mockHotelRoomRepository = new Mock<IHotelRoomRepository>();

        public HotelRoomServiceUnitTests()
        {
            _hotelRoomService = new HotelRoomService(_mockHotelRoomRepository.Object);
        }

        #region GetHotelRoomById

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task HotelRoomServiceGetHotelRoomByIdZeroIdReturnsArgumentException()
        {
            var zeroIdParameter = 0;

            var result = await _hotelRoomService.GetHotelRoomById(zeroIdParameter);
        }

        [TestMethod]
        public async Task HotelRoomServiceGetHotelRoomByIdReturnsProperRecord()
        {
            var testIdParameter = 1;
            _mockHotelRoomRepository.Setup(x => x.GetHotelRoomById(It.IsAny<int>()).Result).Returns(HotelRoomServiceTestStubs.GetTestHotelRoom());

            var result = await _hotelRoomService.GetHotelRoomById(testIdParameter);

            Assert.AreEqual(testIdParameter, result.HotelRoomId);
        }
        #endregion

        #region GetHotelRooms

        [TestMethod]
        public async Task HotelRoomServiceGetHotelRoomsReturnsAllRooms()
        {
            _mockHotelRoomRepository.Setup(x => x.GetHotelRooms(It.IsAny<HotelRoomFilterModel>()).Result)
                .Returns(HotelRoomServiceTestStubs.GetTestHotelRoomCollectionByParameter());

            var result = await _hotelRoomService.GetHotelRooms();

            Assert.AreEqual(6, result.Count());
        }

        [TestMethod]
        public async Task HotelRoomServiceGetHotelRoomsReturnsAllRoomsByNameFilter()
        {
            var testNameParameter = "double";
            _mockHotelRoomRepository.Setup(x => x.GetHotelRooms(It.IsAny<HotelRoomFilterModel>()).Result)
                .Returns(HotelRoomServiceTestStubs.GetTestHotelRoomCollectionByParameter(testNameParameter));

            var result = await _hotelRoomService.GetHotelRooms(testNameParameter);

            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task HotelRoomServiceGetHotelRoomsReturnsAllRoomsBySizeFilter()
        {
            var testSizeParameter = 70;
            _mockHotelRoomRepository.Setup(x => x.GetHotelRooms(It.IsAny<HotelRoomFilterModel>()).Result)
                .Returns(HotelRoomServiceTestStubs.GetTestHotelRoomCollectionByParameter(null, testSizeParameter));

            var result = await _hotelRoomService.GetHotelRooms(null, testSizeParameter);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task HotelRoomServiceGetHotelRoomsReturnsAllRoomsByIaAvailableFilter()
        {
            var testIsAvailableParameter = true;
            _mockHotelRoomRepository.Setup(x => x.GetHotelRooms(It.IsAny<HotelRoomFilterModel>()).Result)
                .Returns(HotelRoomServiceTestStubs.GetTestHotelRoomCollectionByParameter(null, null, testIsAvailableParameter));

            var result = await _hotelRoomService.GetHotelRooms(null, null, testIsAvailableParameter);

            Assert.AreEqual(4, result.Count());
        }
        #endregion

        #region CreateNewHotelRoom

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task HotelRoomServiceCreateNewHotelRoomNoReasonOfOccupationReturnsArgumentException()
        {
            var mockCreateNewHotelRoomModel = HotelRoomServiceTestStubs.GetCreateNewHotelRoomModelWithoutOccupationReason();

            var result = await _hotelRoomService.CreateNewHotelRoom(mockCreateNewHotelRoomModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task HotelRoomServiceCreateNewHotelRoomNoReasonOfMaintenanceReturnsArgumentException()
        {
            var mockCreateNewHotelRoomModel = HotelRoomServiceTestStubs.GetCreateNewHotelRoomModelWithoutMaintenanceReason();

            var result = await _hotelRoomService.CreateNewHotelRoom(mockCreateNewHotelRoomModel);
        }

        [TestMethod]
        public async Task HotelRoomServiceCreateNewHotelRoom()
        {
            var mockCreateNewHotelRoomModel = HotelRoomServiceTestStubs.GetCreateNewHotelRoomModel();

            var result = await _hotelRoomService.CreateNewHotelRoom(mockCreateNewHotelRoomModel);

            Assert.AreEqual(mockCreateNewHotelRoomModel.Name, result.Name);
            Assert.AreEqual(mockCreateNewHotelRoomModel.Size, result.Size);
            Assert.AreEqual(mockCreateNewHotelRoomModel.RoomType, result.RoomType);
            Assert.AreEqual(mockCreateNewHotelRoomModel.IsAvailable, result.IsAvailable);
            Assert.AreEqual(mockCreateNewHotelRoomModel.ReasonOfOccupation, result.ReasonOfOccupation);
        }

        [TestMethod]
        public async Task HotelRoomServiceCreateNewHotelRoomReasonMaintenance()
        {
            var mockCreateNewHotelRoomModel = HotelRoomServiceTestStubs.GetCreateNewHotelRoomModelWithMaintenance();

            var result = await _hotelRoomService.CreateNewHotelRoom(mockCreateNewHotelRoomModel);

            Assert.AreEqual(mockCreateNewHotelRoomModel.Name, result.Name);
            Assert.AreEqual(mockCreateNewHotelRoomModel.Size, result.Size);
            Assert.AreEqual(mockCreateNewHotelRoomModel.RoomType, result.RoomType);
            Assert.AreEqual(mockCreateNewHotelRoomModel.IsAvailable, result.IsAvailable);
            Assert.AreEqual(mockCreateNewHotelRoomModel.ReasonOfOccupation, result.ReasonOfOccupation);
            Assert.AreEqual(mockCreateNewHotelRoomModel.ReasonOfMaintenance, result.ReasonOfMaintenance);
            Assert.IsNotNull(result.AdditionalDetails);
        }

        [TestMethod]
        public async Task HotelRoomServiceCreateNewHotelRoomReasonManuallyLocked()
        {
            var mockCreateNewHotelRoomModel = HotelRoomServiceTestStubs.GetCreateNewHotelRoomModelManualLock();

            var result = await _hotelRoomService.CreateNewHotelRoom(mockCreateNewHotelRoomModel);

            Assert.AreEqual(mockCreateNewHotelRoomModel.Name, result.Name);
            Assert.AreEqual(mockCreateNewHotelRoomModel.Size, result.Size);
            Assert.AreEqual(mockCreateNewHotelRoomModel.RoomType, result.RoomType);
            Assert.AreEqual(mockCreateNewHotelRoomModel.IsAvailable, result.IsAvailable);
            Assert.AreEqual(mockCreateNewHotelRoomModel.ReasonOfOccupation, result.ReasonOfOccupation);
            Assert.IsNotNull(result.AdditionalDetails);
        }
        #endregion

        #region UpdateHotelRoomDetails

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task HotelRoomServiceUpdateHotelRoomDetailsGetHotelRoomByIdZeroIdReturnsArgumentException()
        {
            var updateHotelRoomDetailsModel = HotelRoomServiceTestStubs.GetHotelRoomUpdateModelTestStub();

            var result = await _hotelRoomService.UpdateHotelRoomDetails(updateHotelRoomDetailsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task HotelRoomServiceUpdateHotelRoomDetailsNoReasonOfOccupationReturnsArgumentException()
        {
            var mockUpdateHotelRoomDetails = HotelRoomServiceTestStubs.GetUpdateHotelRoomDetailsModelWithoutOccupationReason();
            _mockHotelRoomRepository.Setup(x => x.GetHotelRoomById(It.IsAny<int>()).Result).Returns(HotelRoomServiceTestStubs.GetTestHotelRoom());

            var result = await _hotelRoomService.UpdateHotelRoomDetails(mockUpdateHotelRoomDetails);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task HotelRoomServiceUpdateHotelRoomDetailsNoReasonOfMaintenanceReturnsArgumentException()
        {
            var mockUpdateHotelRoomDetails = HotelRoomServiceTestStubs.GetUpdateHotelRoomDetailsModelWithoutMaintenanceReason();
            _mockHotelRoomRepository.Setup(x => x.GetHotelRoomById(It.IsAny<int>()).Result).Returns(HotelRoomServiceTestStubs.GetTestHotelRoom());

            var result = await _hotelRoomService.UpdateHotelRoomDetails(mockUpdateHotelRoomDetails);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task HotelRoomServiceUpdateHotelRoomDetailsModelDoesNotExistInDatabaseReturnsArgumentException()
        {
            var mockUpdateHotelRoomDetails = HotelRoomServiceTestStubs.GetUpdateHotelRoomDetailsModelWithoutMaintenanceReason();

            var result = await _hotelRoomService.UpdateHotelRoomDetails(mockUpdateHotelRoomDetails);
        }

        [TestMethod]
        public async Task HotelRoomServiceUpdateHotelRoomDetails()
        {
            var mockUpdateHotelRoomDetailsModel = HotelRoomServiceTestStubs.GetUpdateHotelRoomDetailsModel();
            _mockHotelRoomRepository.Setup(x => x.GetHotelRoomById(It.IsAny<int>()).Result).Returns(HotelRoomServiceTestStubs.GetTestHotelRoom());

            var result = await _hotelRoomService.UpdateHotelRoomDetails(mockUpdateHotelRoomDetailsModel);

            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.Name, result.Name);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.Size, result.Size);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.RoomType, result.RoomType);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.IsAvailable, result.IsAvailable);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.ReasonOfOccupation, result.ReasonOfOccupation);
        }

        [TestMethod]
        public async Task HotelRoomServiceUpdateHotelRoomDetailsWithMaintenance()
        {
            var mockUpdateHotelRoomDetailsModel = HotelRoomServiceTestStubs.GetUpdateHotelRoomDetailsModelWithMaintenance();
            _mockHotelRoomRepository.Setup(x => x.GetHotelRoomById(It.IsAny<int>()).Result).Returns(HotelRoomServiceTestStubs.GetTestHotelRoom());

            var result = await _hotelRoomService.UpdateHotelRoomDetails(mockUpdateHotelRoomDetailsModel);

            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.Name, result.Name);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.Size, result.Size);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.RoomType, result.RoomType);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.IsAvailable, result.IsAvailable);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.ReasonOfOccupation, result.ReasonOfOccupation);
        }

        [TestMethod]
        public async Task HotelRoomServiceUpdateHotelRoomDetailsManuallyLocked()
        {
            var mockUpdateHotelRoomDetailsModel = HotelRoomServiceTestStubs.GetUpdateHotelRoomDetailsModelManualLock();
            _mockHotelRoomRepository.Setup(x => x.GetHotelRoomById(It.IsAny<int>()).Result).Returns(HotelRoomServiceTestStubs.GetTestHotelRoom());

            var result = await _hotelRoomService.UpdateHotelRoomDetails(mockUpdateHotelRoomDetailsModel);

            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.Name, result.Name);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.Size, result.Size);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.RoomType, result.RoomType);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.IsAvailable, result.IsAvailable);
            Assert.AreEqual(mockUpdateHotelRoomDetailsModel.ReasonOfOccupation, result.ReasonOfOccupation);
        }
        #endregion
    }
}