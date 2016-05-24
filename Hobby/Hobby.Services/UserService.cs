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

        public void Update(User user)
        {
            _uow.Users.Update(user);
            _uow.Save();
        }

        public UserDTO UpdateUser(UserDTO userDTO)
        {
            var entity = _uow.Users.FirstOrDefault(p => p.Id == userDTO.Id);
            if (entity != null)
            {
                entity.LastName = userDTO.LastName;
                entity.FirstName = userDTO.FirstName;
                if (_uow.Users.SingleOrDefault(p => p.Email == userDTO.Email) != null)
                {
                    entity.Email = userDTO.Email;
                    _uow.Users.Add(entity);
                    _uow.Save();

                    return entity;
                }

                return null;
            }

            return null;
        }
    }
}
