﻿using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Room", Schema = "ccms")]
    public class Room : Base
    {
        public int id { get; private set; }
        public int capacity { get; private set; }
        [Required]
        public int floorNum { get; private set; }
        [Required]
        [MaxLength(50)]
        public string buildingNum { get; private set; }
        public Rtype rtype { get; private set; }
        public Rstatus rstatus { get; private set; }
        // FOREIGN KEY DEP ID
        [ForeignKey("Department")]
        public int depId { get; private set; }
        public Department department { get; private set; }
        public List<MedicalDevice>? medicalDevices { get; private set; }

        //ternary relationship book
        public List<Book> Books { get; set; }

        public Room(int capacity, int floorNum, string buildingNum, Rtype rtype)
        {
            this.capacity = capacity;
            this.floorNum = floorNum;
            this.buildingNum = buildingNum;
            this.rtype = rtype;
            rstatus = Rstatus.Available;
        }
    }
}