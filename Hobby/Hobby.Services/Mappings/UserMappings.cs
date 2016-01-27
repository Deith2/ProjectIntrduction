using Hobby.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.DTO;

namespace Hobby.Services.Mappings
{
    public static class UserMappings
    {
        public static User Map(this UserDTO source)
        {
            User target = new User();

            target.Id = source.Id;
            target.Login = source.Login;
            target.Password = source.Password;
            target.Email = source.Email;

            return target;
        }

        public static UserDTO Map(this User source)
        {
            UserDTO target = new UserDTO();
            target.Id = source.Id;
            target.Login = source.Login;
            target.Password = source.Password;
            target.Email = source.Email;

            return target;
        }

        public static List<UserDTO> MapList(this List<User> source)
        {
            var list = new List<UserDTO>();
            foreach (var item in source)
            {
                list.Add(item.Map());
            }

            return list;
        }
    }
}
