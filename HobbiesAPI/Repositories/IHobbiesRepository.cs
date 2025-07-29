using HobbiesAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HobbiesAPI.Repositories
{
    public interface IHobbiesRepository
    {
        Task<IEnumerable<Hobbies>> GetAllAsync();
        Task<Hobbies> GetByIdAsync(int id);
        Task<Hobbies> CreateAsync(Hobbies hobby);
        Task<Hobbies> UpdateAsync(Hobbies hobby);
        Task<bool> DeleteAsync(int id);
       
    }
}