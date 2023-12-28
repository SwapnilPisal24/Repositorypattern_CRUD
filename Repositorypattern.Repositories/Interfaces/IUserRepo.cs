using Repositorypattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task RegisterUser(UserInfo userInfo);
        Task<UserInfo> GetUserInfo(string Username, string Password);
    }
}
