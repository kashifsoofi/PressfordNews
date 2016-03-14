using PressfordNews.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PressfordNews.Model;
using System.Configuration;
using Dapper;

namespace PressfordNews.Dal
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly DatabaseService _database;

        public AppUserRepository()
        {
            _database = new DatabaseService();
        }

        public void Create(AppUser userToCreate)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "insert into AppUser (Fullname, Username, Role) values (@fullname, @username, @role)";
                conn.Execute(sql,
                    new
                    {
                        fullname = userToCreate.FullName,
                        username = userToCreate.Username,
                        role = (int)userToCreate.Role
                    });
            }
        }

        public void Delete(int userId)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "update AppUser set IsDeleted = 1 where UserId = @id";
                conn.Execute(sql, new { id = userId });
            }
        }

        public AppUser Get(int id)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from AppUser where IsDeleted = 0 and UserId = @id";
                return conn.Query<AppUser>(sql, new { id = id }).FirstOrDefault();
            }
        }

        public AppUser GetByUsername(string username)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from AppUser where IsDeleted = 0 and Username = @username";
                return conn.Query<AppUser>(sql, new { username = username }).FirstOrDefault();
            }
        }

        public IEnumerable<AppUser> GetAllUsers()
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from AppUser where IsDeleted = 0";
                return conn.Query<AppUser>(sql);
            }
        }

        public void Update(AppUser userToUpdate)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "update AppUser set Fullname = @fullname, Username = @username, Role = @role where UserId = @id";
                conn.Execute(sql,
                    new
                    {
                        fullname = userToUpdate.FullName,
                        username = userToUpdate.Username,
                        role = (int)userToUpdate.Role,
                        id = userToUpdate.UserId
                    });
            }
        }
    }
}
