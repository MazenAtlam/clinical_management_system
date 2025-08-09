using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Enums;

namespace CCMS.BLL.Services.Implementation
{
    public class RoomService : IRoomService
    {
        public async Task<string?> Create(/*RoomDTO room, */string createdBy)
        {
            throw new NotImplementedException();
        }

        public async Task</*(List<RoomDTO>?, */string?/*)*/> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public async Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevicesIn(string roomNum)
        {
            throw new NotImplementedException();
        }

        public async Task</*(List<RoomDTO>?, */string?/*)*/> GetAllRoomsByBuildingAndFloorNumber(string buildingNum, int floorNum)
        {
            throw new NotImplementedException();
        }

        public async Task</*(RoomDTO?, */string?/*)*/> GetRoomByNumber(string roomNum)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> UpdateStatus(string roomNum, Rstatus newStatus, string modifiedBy)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Update(/*RoomDTO room, */string modifiedBy)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Delete(string roomNum, string modifiedBy)
        {
            throw new NotImplementedException();
        }
    }
}
