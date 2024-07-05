using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Menu;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllAsync(QueryObject query);
        Task<Menu?> GetByIdAsync(int id);
        Task<Menu?> CreateAsync(Menu menuModel);
        Task<Menu?> UpdateAsync(int id, UpdateMenuRequestDto updateDto);
        Task<Menu?> DeleteAsync(int id);
    }
}