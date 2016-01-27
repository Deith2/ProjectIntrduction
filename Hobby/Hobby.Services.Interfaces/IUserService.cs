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
        List<UserDTO> UserTake(decimal id);

        UserDTO CheckUser(string login, string password);

        List<string> PermissionActiveNameList(decimal idUser);

        decimal IdPermissionByName(string role);
    }
}
