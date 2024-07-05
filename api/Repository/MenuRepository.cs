using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Menu;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu?> CreateAsync(Menu menuModel)
        {
            await _context.Menus.AddAsync(menuModel);
            await _context.SaveChangesAsync();
            return menuModel;
        }

        public async Task<Menu?> DeleteAsync(int id)
        {
            var menuModel = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);
            if (menuModel == null)
            {
                return null;
            }
            else
            {
                _context.Menus.Remove(menuModel);
                await _context.SaveChangesAsync();
                return menuModel;
            }
        }

        public async Task<List<Menu>> GetAllAsync(QueryObject query)
        {
            var menus = _context.Menus.Include(e => e.Special).AsQueryable();

            if (query.Available != null)
            {
                menus = menus.Where(e => e.Available.Equals(query.Available));
            }

            if (query.Discounted != null)
            {
                menus = menus.Where(e => e.Discounted.Equals(query.Discounted));
            }

            return await menus.ToListAsync();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            return await _context.Menus.Include(e => e.Special).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Menu?> UpdateAsync(int id, UpdateMenuRequestDto updateDto)
        {
            var menuModel = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);
            if (menuModel == null)
            {
                return null;
            }
            else
            {
                menuModel.Name = updateDto.Name;
                menuModel.Description = updateDto.Description;
                menuModel.Price = updateDto.Price;
                menuModel.Image = updateDto.Image;
                menuModel.Available = updateDto.Available;
                menuModel.Discounted = updateDto.Discounted;
                menuModel.Discount = updateDto.Discount;
                menuModel.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
                return menuModel;
            }
        }
    }
}