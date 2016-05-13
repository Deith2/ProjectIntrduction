using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.DTO;
using Hobby.Entities;

namespace Hobby.Services.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUserDTO(decimal id);

        void AddUser(User user);
    }
}
