using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PressfordNews.Services.Interfaces;
using PressfordNews.Dal.Interfaces;
using AutoMapper;
using PressfordNews.Model;

namespace PressfordNews.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _userRepository;

        public AppUserService(IAppUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(AppUser userToCreate)
        {
            _userRepository.Create(userToCreate);
        }

        public void Delete(int userId)
        {
            _userRepository.Delete(userId);
        }

        public AppUser Get(int userId)
        {
            return _userRepository.Get(userId);
        }

        public IEnumerable<AppUser> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public AppUser GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }

        public void Update(AppUser userToUpdate)
        {
            _userRepository.Update(userToUpdate);
        }
    }
}
