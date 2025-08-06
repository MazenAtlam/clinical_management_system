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

        public bool Delete(int id)
        {
            try
            {
                var room = db.rooms.Where(a => a.id == id).FirstOrDefault();
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

        public Room GetById(int id)
        {
            var room = db.rooms.Where(a => a.id == id).FirstOrDefault();
            return room;
        }

        public bool Update(Room room, string modifyingUser)
        {
            try
            {
                var rom = db.rooms.Where(a => a.id == room.id).FirstOrDefault();
                if (rom == null)
                    return false;
                
                rom.Edit(room.capacity,room.floorNum,room.buildingNum,room.rtype,room.rstatus, modifyingUser);
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
