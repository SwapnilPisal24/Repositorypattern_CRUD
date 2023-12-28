using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Repositorypattern.Entities;
using Repositorypattern.repositories;
using Repositorypattern.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.Repositories.Implimentations
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDBContext _context;

        public UserRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> GetUserInfo(string Username, string Password)
        {
            var user = await _context.UserInfos.FirstOrDefaultAsync(
                x => x.UserName.ToLower() == Username.ToLower() && x.Password.ToLower() == Password.ToLower());
            return user;
        }

        public async Task RegisterUser(UserInfo userInfo)
        {
            if (!Exists(userInfo.UserName))
            {
                await _context.UserInfos.AddAsync(userInfo);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(string Username)
        {
            return _context.UserInfos.Any(x => x.UserName.ToLower() == Username.ToLower());

        }
    }
}
