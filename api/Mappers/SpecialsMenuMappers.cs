using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.SpecialsMenu;
using api.Models;

namespace api.Mappers
{
    public static class SpecialsMenuMappers
    {
        public static SpecialsMenuDto ToSpecialsMenuDto(this SpecialsMenu specialsMenuModel)
        {
            if (specialsMenuModel != null)
            {
                return new SpecialsMenuDto
                {
                    Id = specialsMenuModel.Id,
                    MenuId = specialsMenuModel.MenuId,
                    CreatedAt = specialsMenuModel.CreatedAt,
                    UpdatedAt = specialsMenuModel.UpdatedAt,
                    Menu = specialsMenuModel.Menu.ToSubMenuDto(),
                };
            }
            else
            {
                return null;
            }
        }

        public static SpecialsMenu ToCreateSpecialsMenuDto(this CreateSpecialsMenuRequestDto specialsMenuDto)
        {
            return new SpecialsMenu
            {
                MenuId = specialsMenuDto.MenuId,
                CreatedAt = specialsMenuDto.CreatedAt,
                UpdatedAt = specialsMenuDto.UpdatedAt
            };
        }

    }
}