using HobbiesAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HobbiesAPI.Services
{
    public interface IHobbiesService
    {
        Task<IEnumerable<Hobbies>> GetAllAsync();
        Task<Hobbies> GetByIdAsync(int id);
        Task<Hobbies> CreateAsync(Hobbies hobby);
        Task<Hobbies> UpdateAsync(Hobbies hobby);
        Task<bool> DeleteAsync(int id);
        
    }
}