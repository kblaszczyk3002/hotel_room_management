using HotelRoomManagement.Domain.CommandModels;
using HotelRoomManagement.Domain.CommandModels.Interfaces;
using HotelRoomManagement.Domain.Enums;
using HotelRoomManagement.Domain.Model;

namespace HotelRoomManagement.Service.Helpers
{
    public class AvailabilityOperationHelper
    {
        public static void ValidateAvailabilityAndAddProperAdditionalDetails(HotelRoom hotelRoom, IHotelRoomCommandModel commandModel)
        {
            if (!commandModel.IsAvailable)
            {
                hotelRoom.IsAvailable = commandModel.IsAvailable;
                if (!commandModel.ReasonOfOccupation.HasValue)
                {
                    throw new ArgumentException("You need to provide reason of occupation if room is set as not available");
                }
                hotelRoom.ReasonOfOccupation = commandModel.ReasonOfOccupation;

                if (commandModel.ReasonOfOccupation == ReasonOfOccupation.Maintenance)
                {
                    if (!commandModel.ReasonOfMaintenance.HasValue)
                    {
                        throw new ArgumentException("You need to provide reason of maintenance if room is set as not available due to maintenance works");
                    }

                    hotelRoom.ReasonOfMaintenance = commandModel.ReasonOfMaintenance;
                    hotelRoom.AdditionalDetails = $"Room is unavailable due to maintenance works taking place. There reason why maintenance is needed is - {commandModel.ReasonOfMaintenance.Value}";
                }
                else if (commandModel.ReasonOfOccupation == ReasonOfOccupation.ManuallyLocked)
                {
                    hotelRoom.AdditionalDetails = "Room is manually locked by the hotel staff, to secure it for special guest";
                }
                else
                {
                    hotelRoom.AdditionalDetails = commandModel.AdditionalDetails;
                }
            }
        }
    }
}
