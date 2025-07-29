using HobbiesAPI.Entity;

using HobbiesAPI.Repositories;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace HobbiesAPI.Services
{
    public class HobbiesService : IHobbiesService
    {
                private readonly IHobbiesRepository _repository;

        public HobbiesService(IHobbiesRepository repository)
        {
            _repository = repository;
        }
        public async Task<Hobbies> CreateAsync(Hobbies hobby)
        {
            var hobbyTemp = new Hobbies
            {
                
                title = hobby.title,
                date = hobby.date,
                updated_at = hobby.updated_at
            };
            return await _repository.CreateAsync(hobbyTemp);
        }

        public async Task<IEnumerable<Hobbies>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<Hobbies> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        
        public async Task<Hobbies> UpdateAsync(Hobbies hobby)
        {
          return await _repository.UpdateAsync(hobby);
        }

       public async Task<bool>   DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

     
    }
}