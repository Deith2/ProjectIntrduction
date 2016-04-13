using Hobby.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Services.Interfaces
{
    public interface IAuthenticateService
    {
        UserDTO CheckUser(string login, string password);

        List<string> PermissionActiveNameList(decimal idUser);

        bool Register(UserDTO user);
    }
}
