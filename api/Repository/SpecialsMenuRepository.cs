using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.SpecialsMenu;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class SpecialsMenuRepository : ISpecialsMenuRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialsMenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SpecialsMenu?> CreateAsync(SpecialsMenu specialsMenuModel)
        {
            var existingSpecialsMenuModel = await _context.SpecialsMenus.FirstOrDefaultAsync(x => x.MenuId == specialsMenuModel.MenuId);
            if (existingSpecialsMenuModel != null) { return null; }

            var menuModel = await _context.Menus.FirstOrDefaultAsync(x => x.Id == specialsMenuModel.MenuId);
            if (menuModel == null) { return null; }

            await _context.SpecialsMenus.AddAsync(specialsMenuModel);
            await _context.SaveChangesAsync();
            return specialsMenuModel;
        }

        public async Task<SpecialsMenu?> DeleteAsync(int id)
        {
            var specialsMenuModel = await _context.SpecialsMenus.FirstOrDefaultAsync(x => x.Id == id);
            if (specialsMenuModel == null)
            {
                return null;
            }
            else
            {
                _context.SpecialsMenus.Remove(specialsMenuModel);
                await _context.SaveChangesAsync();
                return specialsMenuModel;
            }
        }

        public async Task<List<SpecialsMenu>> GetAllAsync(QueryObject query)
        {
            var specialMenus = _context.SpecialsMenus.Include(e => e.Menu).AsQueryable();

            if (query.Available != null)
            {
                specialMenus = specialMenus.Where(e => e.Menu.Available.Equals(query.Available));
            }

            if (query.Discounted != null)
            {
                specialMenus = specialMenus.Where(e => e.Menu.Discounted.Equals(query.Discounted));
            }
            return await specialMenus.ToListAsync();
        }

        public async Task<SpecialsMenu?> GetByIdAsync(int id)
        {
            var specialsMenu = await _context.SpecialsMenus.Include(e => e.Menu).FirstOrDefaultAsync(i => i.Id == id);
            return (specialsMenu == null) ? null : specialsMenu;
        }

        public async Task<SpecialsMenu?> GetByMenuIdAsync(int menuId)
        {
            var specialsMenu = await _context.SpecialsMenus.Include(e => e.Menu).FirstOrDefaultAsync(i => i.MenuId == menuId);
            return (specialsMenu == null) ? null : specialsMenu;
        }

        public async Task<Menu?> GetMenuExistAsync(int menuId)
        {
            var menu = await _context.Menus.Include(e => e.Special).FirstOrDefaultAsync(i => i.Id == menuId);
            return (menu == null) ? null : menu;
        }

        public async Task<SpecialsMenu?> UpdateAsync(int id, UpdateSpecialsMenuRequestDto updateDto)
        {
            var specialsMenuModel = await _context.SpecialsMenus.FirstOrDefaultAsync(x => x.Id == id);
            if (specialsMenuModel == null) { return null; }
            specialsMenuModel.MenuId = updateDto.MenuId;
            specialsMenuModel.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return specialsMenuModel;

        }
    }
}