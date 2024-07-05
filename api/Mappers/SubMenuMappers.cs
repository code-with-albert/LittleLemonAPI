using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Menu;
using api.Models;

namespace api.Mappers
{
    public static class SubMenuMappers
    {
        public static SubMenuDto ToSubMenuDto(this Menu menuModel)
        {
            if (menuModel != null)
            {
                return new SubMenuDto
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
                };
            }
            else
            {
                return null;
            }
        }
    }
}
