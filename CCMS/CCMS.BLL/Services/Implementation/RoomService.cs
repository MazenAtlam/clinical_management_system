using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Enums;

namespace CCMS.BLL.Services.Implementation
{
    public class RoomService : IRoomService
    {
        public string? Create(/*CreateRoom room, */string creatingUser)
        {
            throw new NotImplementedException();
        }

        public /*(List<RoomDTO>?, */string?/*)*/ GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public (List<MedicalDeviceDTO>?, string?) GetAllMedicalDevicesIn(string roomNum)
        {
            throw new NotImplementedException();
        }

        public /*(List<RoomDTO>?, */string?/*)*/ GetAllRoomsByBuildingAndFloorNumber(string buildingNum, int floorNum)
        {
            throw new NotImplementedException();
        }

        public /*(RoomDTO?, */string?/*)*/ GetRoomByNumber(string roomNum)
        {
            throw new NotImplementedException();
        }

        public string? UpdateStatus(string roomNum, Rstatus newStatus, string modifyingUser)
        {
            throw new NotImplementedException();
        }

        public string? Update(/*RoomDTO room, */string modifyingUser)
        {
            throw new NotImplementedException();
        }

        public string? Delete(string roomNum, string modifyingUser)
        {
            throw new NotImplementedException();
        }
    }
}
