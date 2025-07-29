using HobbiesAPI.Data;
using HobbiesAPI.Entity;
using HobbiesAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HobbiesAPI.Repositories
{
    public class HobbiesRepository : IHobbiesRepository
    {
        private readonly DataContext _context;

        public HobbiesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Hobbies>> GetAllAsync()
        {
           var tempData = await _context.HobbiesDB.ToListAsync();
            if (tempData == null || !tempData.Any())
            {
                throw new ArgumentException(nameof(tempData), "No comments found");
            }
            return tempData;
        }

        public async Task<Hobbies> GetByIdAsync(int ID)
        {
            var tempData = await _context.HobbiesDB.FindAsync(ID);
            if (tempData == null)
            {
                throw new ArgumentException(nameof(tempData), "Hobby not found");
            }
            return tempData;
        }
        public async Task<Hobbies> CreateAsync(Hobbies hobby)
        {
            if (hobby == null)
            {
                throw new ArgumentNullException(nameof(hobby), "Hobby cannot be null!");
            }
            _context.HobbiesDB.Add(hobby);
            await _context.SaveChangesAsync();
            return hobby;
        }


        public async Task<Hobbies> UpdateAsync(Hobbies hobby)
        {
            var tempData = await _context.HobbiesDB.FindAsync(hobby.type_id);
            if (tempData == null)
            {
                throw new ArgumentNullException(nameof(hobby), "Comment not found! / 404");
            }
            _context.HobbiesDB.Update(tempData);
            await _context.SaveChangesAsync();
            return tempData;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hobby = await _context.HobbiesDB.FindAsync(id);
            if (hobby == null)
            {
                return false;
            }
            _context.HobbiesDB.Remove(hobby);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}