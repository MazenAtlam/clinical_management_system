using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepo _roomRepo;

        public RoomService(IRoomRepo roomRepo)
        {
            _roomRepo = roomRepo;
        }

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

        public Task</*(List<RoomDTO>?, */string?/*)*/> GetAvailableRooms()
        {
            throw new NotImplementedException();
        }

        public Task</*(List<RoomDTO>?, */string?/*)*/> GetByType(string roomType)
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

        //public bool Create(Room room)
        //{
        //    try
        //    {
        //        _roomRepo.Create(room);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool Update(Room room)
        //{
        //    try
        //    {
        //        _roomRepo.Update(room, room.CreatedBy ?? "system");
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool Delete(string roomNumber)
        //{
        //    try
        //    {
        //        var room = _roomRepo.GetById(roomNumber);
        //        if (room == null) return false;

        //        _roomRepo.Delete(roomNumber);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public Room GetById(string roomNumber)
        //{
        //    return _roomRepo.GetById(roomNumber);
        //}

        //public List<Room> GetAll()
        //{
        //    return _roomRepo.GetAll();
        //}

        //public List<Room> GetAvailableRooms()
        //{
        //    return new List<Room>();
        //}

        //public List<Room> GetByType(string roomType)
        //{
        //    return new List<Room>();
        //}
    }
}
