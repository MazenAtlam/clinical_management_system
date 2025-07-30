using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.DAL.Enums;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IRoomService
    {
        public string? Create(/*CreateRoom room, */string creatingUser);

        public /*(List<RoomDTO>?, */string?/*)*/ GetAllRooms();

        public (List<MedicalDeviceDTO>?, string?) GetAllMedicalDevicesIn(string roomNum);

        public /*(List<RoomDTO>?, */string?/*)*/ GetAllRoomsByBuildingAndFloorNumber(string buildingNum, int floorNum);

        public /*(RoomDTO?, */string?/*)*/ GetRoomByNumber(string roomNum);

        public string? UpdateStatus (string roomNum, Rstatus newStatus, string modifyingUser);

        public string? Update(/*RoomDTO room, */string modifyingUser);

        public string? Delete(string roomNum, string modifyingUser);
    }
}
