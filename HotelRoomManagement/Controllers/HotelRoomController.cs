using HotelRoomManagement.Domain.CommandModels;
using HotelRoomManagement.Domain.DTOs;
using HotelRoomManagement.Domain.Model;
using HotelRoomManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly ILogger<HotelRoomController> _logger;
        private readonly IHotelRoomService _hotelRoomService;

        public HotelRoomController(ILogger<HotelRoomController> logger, IHotelRoomService hotelRoomService)
        {
            _logger = logger;
            _hotelRoomService = hotelRoomService;
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult<IEnumerable<HotelRoomDto>>> GetHotelRooms(string? name = null, decimal? size = null, bool? isAvailable = null)
        {
            try
            {
                var result = await _hotelRoomService.GetHotelRooms(name, size, isAvailable);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[Action]/{hotelRoomGuid}")]
        public async Task<ActionResult<HotelRoomDto>> GetHotelRoomByGuid(Guid hotelRoomGuid)
        {
            try
            {
                var result = await _hotelRoomService.GetHotelRoomByGuid(hotelRoomGuid);
                return Ok(new HotelRoomDto
                {
                    HotelRoomId = result.HotelRoomId,
                    HotelRoomGuid = result.HotelRoomGuid,
                    Name = result.Name,
                    Size = result.Size,
                    RoomType = result.RoomType,
                    IsAvailable = result.IsAvailable,
                    ReasonOfOccupation = result.ReasonOfOccupation,
                    ReasonOfMaintenance = result.ReasonOfMaintenance,
                    AdditionalDetails = result.AdditionalDetails
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[Action]")]
        public async Task<ActionResult> CreateNewHotelRoom([FromBody] CreateNewHotelRoomModel createNewHotelRoomModel)
        {
            try
            {
                var result = await _hotelRoomService.CreateNewHotelRoom(createNewHotelRoomModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[Action]")]
        public async Task<ActionResult> UpdateHotelRoomDetails([FromBody] UpdateHotelRoomDetailsModel updateHotelRoomDetailsModel)
        {
            try
            {
                var result = await _hotelRoomService.UpdateHotelRoomDetails(updateHotelRoomDetailsModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
