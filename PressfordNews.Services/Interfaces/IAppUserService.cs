using PressfordNews.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Services.Interfaces
{
    public interface IAppUserService
    {
        AppUser Get(int userId);
        AppUser GetByUsername(string username);
        IEnumerable<AppUser> GetAllUsers();
        void Create(AppUser userToCreate);
        void Update(AppUser userToUpdate);
        void Delete(int userId);
    }
}
