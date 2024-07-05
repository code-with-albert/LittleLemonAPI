using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.SpecialsMenu;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ISpecialsMenuRepository
    {
        Task<List<SpecialsMenu>> GetAllAsync(QueryObject query);
        Task<SpecialsMenu?> GetByIdAsync(int id);
        Task<SpecialsMenu?> GetByMenuIdAsync(int id);
        Task<Menu?> GetMenuExistAsync(int menuId);
        Task<SpecialsMenu?> CreateAsync(SpecialsMenu specialsMenuModel);
        Task<SpecialsMenu?> UpdateAsync(int id, UpdateSpecialsMenuRequestDto updateDto);
        Task<SpecialsMenu?> DeleteAsync(int id);
    }
}