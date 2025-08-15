using CCMS.BLL.ModelVM.Book;
using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IRoomService
    {
        public Task<string?> Create(/*RoomDTO room, */string createdBy);

        public Task</*(List<RoomDTO>?, */string?/*)*/> GetAllRooms();

        public Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevicesIn(string roomNum);

        public Task</*(List<RoomDTO>?, */string?/*)*/> GetAllRoomsByBuildingAndFloorNumber(string buildingNum, int floorNum);

        public Task</*(RoomDTO?, */string?/*)*/> GetRoomByNumber(string roomNum);
        public Task</*(List<RoomDTO>?, */string?/*)*/> GetAvailableRooms();
        public Task</*(List<RoomDTO>?, */string?/*)*/> GetByType(string roomType);

        public Task<string?> UpdateStatus (string roomNum, Rstatus newStatus, string modifiedBy);

        public Task<string?> Update(/*RoomDTO room, */string modifiedBy);

        public Task<string?> Delete(string roomNum, string modifiedBy);
    }
}
