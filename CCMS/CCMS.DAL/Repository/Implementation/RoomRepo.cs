using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Implementation
{
    public class RoomRepo:IRoomRepo
    {
        private readonly CcmsDbContext db;

        public RoomRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(Room room)
        {
            try
            {
                db.rooms.Add(room);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string rNumber)
        {
            try
            {
                var room = db.rooms.Where(a => a.RNumber == rNumber).FirstOrDefault();
                if (room == null)
                    return false;
                //add modifiing user
                room.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Room> GetAll()
        {
            var result = db.rooms.Where(a => a.IsDeleted == false).ToList();
            return result;
        }

        public Room GetById(string rNumber)
        {
            var room = db.rooms.Where(a => a.RNumber == rNumber).FirstOrDefault();
            return room;
        }

        public bool Update(Room room, string modifiedBy)
        {
            try
            {
                var rom = db.rooms.Where(a => a.RNumber == room.RNumber).FirstOrDefault();
                if (rom == null)
                    return false;
                
                rom.Edit(room.RNumber, room.capacity,room.rtype,room.rstatus, room.DeptId, modifiedBy);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
