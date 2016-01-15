using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Data.Interface;
using Hobby.DTO;
using Hobby.DTO.Mappings;
using Hobby.Services.Interfaces;

namespace Hobby.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<UserDTO> User(decimal id)
        {
            var test = _uow.Users.All().ToList().MapList();
            return test;
        }
    }
}
