using System.Collections.Generic;
using System.Threading.Tasks;
using ecoupon.models;

namespace ecoupon.repository.contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<bool> AddUser();
    }
}
