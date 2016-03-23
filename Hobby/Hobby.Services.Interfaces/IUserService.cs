using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.DTO;

namespace Hobby.Services.Interfaces
{
    public interface IUserService
    {
        UserDTO CheckUser(string login, string password);

        List<string> PermissionActiveNameList(decimal idUser);

        void Register(UserDTO user);
    }
}
