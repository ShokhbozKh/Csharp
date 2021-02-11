using FinalProject.Models;
using System.Threading.Tasks;

namespace FinalProject.DAL
{
    public interface IDbLayer
    {
        Task<Enumerable<User>> GetUsers();
        Task<Enumerable<Customer>> GetCustomers();
    }
}
