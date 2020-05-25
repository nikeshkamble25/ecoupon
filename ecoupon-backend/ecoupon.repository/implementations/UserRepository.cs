using System.Collections.Generic;
using System.Threading.Tasks;
using ecoupon.data;
using ecoupon.models;
using ecoupon.repository.contracts;
using Microsoft.EntityFrameworkCore;

namespace ecoupon.repository.implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly EcouponContext _context;
        public UserRepository(EcouponContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<bool> AddUser()
        {
            bool userAdded = false;
            var users = await _context.Users.ToListAsync();
            userAdded = true;
            return userAdded;
        }
    }
}