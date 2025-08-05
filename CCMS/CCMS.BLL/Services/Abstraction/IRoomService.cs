using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.DAL.Enums;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IRoomService
    {
        public Task<string?> Create(/*RoomDTO room, */string creatingUser);

        public Task</*(List<RoomDTO>?, */string?/*)*/> GetAllRooms();

        public Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevicesIn(string roomNum);

        public Task</*(List<RoomDTO>?, */string?/*)*/> GetAllRoomsByBuildingAndFloorNumber(string buildingNum, int floorNum);

        public Task</*(RoomDTO?, */string?/*)*/> GetRoomByNumber(string roomNum);

        public Task<string?> UpdateStatus (string roomNum, Rstatus newStatus, string modifyingUser);

        public Task<string?> Update(/*RoomDTO room, */string modifyingUser);

        public Task<string?> Delete(string roomNum, string modifyingUser);
    }
}
