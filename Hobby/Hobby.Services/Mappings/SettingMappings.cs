using Hobby.DTO;
using Hobby.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Services.Mappings
{
    public static class SettingMappings
    {
        public static Setting Map(this SettingDTO source)
        {
            Setting target = new Setting();

            target.Id = source.Id;
            target.IdUser = source.IdUser;
            target.Name = source.Name;
            target.Value = source.Value;

            return target;
        }

        public static SettingDTO Map(this Setting source)
        {
            SettingDTO target = new SettingDTO();

            target.Id = source.Id;
            target.IdUser = source.IdUser;
            target.Name = source.Name;
            target.Value = source.Value;

            return target;
        } 
    }
}
