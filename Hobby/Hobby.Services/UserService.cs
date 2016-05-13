using System;
using System.Collections.Generic;
using System.Linq;
using Hobby.Common.Authentication;
using Hobby.Common.Enums;
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

        public UserDTO GetUserDTO(decimal id)
        {
            return _uow.Users.SingleAsNoTracking(p => p.Id == id).Map();
        }

        public void AddUser(User user)
        {
            _uow.Users.Add(user);
            _uow.Save();
        }
    }
}
