using CCMS.BLL.ModelVM.Book;
using CCMS.DAL.Entities;
using System;
using System.Collections.Generic;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IBookService
    {
        Task Create(CreateBookDTO book);
        bool Update(BookDTO book);
        bool Delete(int id);
        Book? GetById(int id);
        List<Book> GetAll();
        List<Book> GetByPatient(int patientId);
        List<Book> GetByDoctor(int doctorId);
        List<Book> GetByDate(DateTime date);
        bool CancelAppointment(int bookId);
        
        // New methods
        bool CreateBookWithFixedPrice(int patientId, int doctorId, string roomNumber, DateTime bookDate, string prescription);
        bool AddPrescriptionToPatientBook(int bookId, string prescription);
    }
}
