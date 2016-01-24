using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Data.Interface;
using Hobby.DTO;
using Hobby.Entities;
using Hobby.Services.Interfaces;
using Hobby.Services.Mappings;

namespace Hobby.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<UserDTO> UserTake(decimal id)
        {
            var test = _uow.Users.All().ToList().MapList();
            var z = _uow.Users.FirstOrDefault(p => p.Login == "darek");
            var c = _uow.Users.Single(p => p.Id == 3);
            var x = _uow.Users.GetById(3);
            return test;
        }

        public UserDTO test()
        {
            User test = _uow.Users.Single(P => P.Id == 1);

            return test.Map();
        }
    }
}
