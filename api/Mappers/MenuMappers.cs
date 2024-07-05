using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Menu;
using api.Models;

namespace api.Mappers
{
    public static class MenuMappers
    {
        public static MenuDto ToMenuDto(this Menu menuModel)
        {
            if (menuModel != null)
            {
                return new MenuDto
                {
                    Id = menuModel.Id,
                    Name = menuModel.Name,
                    Description = menuModel.Description,
                    Price = menuModel.Price,
                    Image = menuModel.Image,
                    Available = menuModel.Available,
                    Discounted = menuModel.Discounted,
                    Discount = menuModel.Discount,
                    CreatedAt = menuModel.CreatedAt,
                    UpdatedAt = menuModel.UpdatedAt,
                    Special = menuModel.Special.ToSubSpecialsMenuDto()
                };
            }
            else
            {
                return null;
            }
        }

        public static Menu ToCreateMenuDto(this CreateMenuRequestDto menuDto)
        {
            return new Menu
            {
                Name = menuDto.Name,
                Description = menuDto.Description,
                Price = menuDto.Price,
                Image = menuDto.Image,
                Available = menuDto.Available,
                Discounted = menuDto.Discounted,
                Discount = menuDto.Discount,
                CreatedAt = menuDto.CreatedAt,
                UpdatedAt = menuDto.UpdatedAt
            };
        }
    }
}
