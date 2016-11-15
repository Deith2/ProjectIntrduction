using Hobby.DTO;
using Hobby.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Services.Mappings
{
    public static class CategorieMappings
    {
        public static CategorieDTO Map(this Categorie source)
        {
            var target = new CategorieDTO();

            target.Id = source.Id;
            target.Name = source.Name;

            return target;
        }

        public static Categorie Map(this CategorieDTO source)
        {
            var target = new Categorie();

            target.Id = source.Id;
            target.Name = source.Name;

            return target;
        }
    }
}
