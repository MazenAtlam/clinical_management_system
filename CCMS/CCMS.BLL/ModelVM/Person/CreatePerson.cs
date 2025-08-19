using CCMS.DAL.Enums;
using Microsoft.AspNetCore.Http;

namespace CCMS.BLL.ModelVM.Person
{
    public class CreatePerson
    {
        public string FName { get; set; }
        public string? MidName { get; set; }
        public string LName { get; set; }
        public string Ssn { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public IFormFile? File { get; set; }
        // add in DTO path, and in the service string path = Upload.UploadFile("Files", empDTO.File);, and in the view form of the create enctype="multipart/form-data"

    }
}
