using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCMS.DAL.Repository.Implementation
{
    public class ScanRepo : IScanRepo
    {
        private readonly CcmsDbContext db;

        public ScanRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(Scan scan)
        {
            try
            {
                db.scans.Add(scan);
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
                var scan = db.scans.Where(a => a.Id == id).FirstOrDefault();
                if (scan == null)
                    return false;
                //add modifiing user
                scan.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Scan> GetAll()
        {
            return db.scans.Where(a => a.IsDeleted == false).ToList();
        }

        public Scan GetById(int id)
        {
            return db.scans.Where(a => a.Id == id).FirstOrDefault();
        }

        public bool Update(Scan scan)
        {
            try
            {
                var sc = db.scans.Where(a => a.Id == scan.Id).FirstOrDefault();
                if (sc == null)
                    return false;
                sc.Edit(scan.ScanType, scan.ScanTech, scan.SDate, scan.PatientId,scan.Results);
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