using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCMS.DAL.Repository.Abstraction;
using CCMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using CCMS.DAL.Database;


namespace CCMS.DAL.Repository.Implementation
{
 
    public class PersonRepo : IPersonRepo
    {
        private readonly CcmsDbContext _context;

        public PersonRepo(CcmsDbContext context)
        {
            _context = context;
        }

        public async Task<Person> CreatePerson(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return false;

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
