using PressfordNews.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Dal.Interfaces
{
    public interface IAppUserRepository
    {
        IEnumerable<AppUser> GetAllUsers();
        AppUser Get(int id);
        AppUser GetByUsername(string username);
        void Create(AppUser userToCreate);
        void Update(AppUser userToUpdate);
        void Delete(int userId);
    }
}
