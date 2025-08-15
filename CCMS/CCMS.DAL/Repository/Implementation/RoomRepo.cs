using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class RoomRepo : IRoomRepo
    {
        private readonly CcmsDbContext db;

        public RoomRepo(CcmsDbContext db) => this.db = db;

        public async Task Add(Room room) => db.rooms.Add(room);

        // In RoomService
        //public bool Delete(string rNumber)
        //{
        //    try
        //    {
        //        var room = db.rooms.Where(a => a.RNumber == rNumber).FirstOrDefault();
        //        if (room == null)
        //            return false;
        //        //add modifiing user
        //        room.Delete("admin");
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<List<Room>> GetAll() => db.rooms.Where(a => !a.IsDeleted).ToList();

        public async Task<Room> GetById(string rNumber)
        {
            Room? room = db.rooms.Where(a => a.RNumber == rNumber && !a.IsDeleted).FirstOrDefault();

            return room == null
                ? throw new ArgumentException($"There is no room with the number {rNumber}", nameof(rNumber))
                : room;
        }

        public async Task Save() => db.SaveChanges();

        // In RoomService
        //public bool Update(Room room, string modifiedBy)
        //{
        //    try
        //    {
        //        var rom = db.rooms.Where(a => a.RNumber == room.RNumber).FirstOrDefault();
        //        if (rom == null)
        //            return false;

        //        rom.Edit(room.RNumber, room.capacity,room.rtype,room.rstatus, room.DeptId, modifiedBy);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
