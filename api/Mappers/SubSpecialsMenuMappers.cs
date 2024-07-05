using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.SpecialsMenu;
using api.Models;

namespace api.Mappers
{
    public static class SubSpecialsMenuMappers
    {
        public static SubSpecialsMenuDto ToSubSpecialsMenuDto(this SpecialsMenu specialsMenuModel)
        {
            if (specialsMenuModel != null)
            {
                return new SubSpecialsMenuDto
                {
                    Id = specialsMenuModel.Id,
                    MenuId = specialsMenuModel.MenuId,
                    CreatedAt = specialsMenuModel.CreatedAt,
                    UpdatedAt = specialsMenuModel.UpdatedAt,
                };
            }
            else
            {
                return null;
            }
        }
    }
}