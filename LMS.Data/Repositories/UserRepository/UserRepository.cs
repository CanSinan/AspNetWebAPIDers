using LMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly LMSDBContext _context;

        public UserRepository(IGenericRepository<User> userRepository, LMSDBContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> InsertAsync(User entity)
        {
            return await _userRepository.InsertAsync(entity);
        }

        public async Task<User> UpdateAsync(User entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }

        public async Task<User> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}
