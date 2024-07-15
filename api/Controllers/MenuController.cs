using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using api.Dtos.Menu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepo;

        public MenuController(IMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        [HttpGet("menu")]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var menus = await _menuRepo.GetAllAsync(query);
            return Ok(menus);
        }

        [HttpGet("menu/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var menu = await _menuRepo.GetByIdAsync(id);
            return (menu == null) ? NotFound() : Ok(menu.ToMenuDto());
        }

        [HttpPost("menu/create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateMenuRequestDto menuDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); };
            var menuModel = menuDto.ToCreateMenuDto();
            await _menuRepo.CreateAsync(menuModel);
            return CreatedAtAction(nameof(GetById), new { id = menuModel.Id }, menuModel.ToMenuDto());
        }

        [HttpPut("menu/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMenuRequestDto updateDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); };
            var menuModel = await _menuRepo.UpdateAsync(id, updateDto);
            return (menuModel == null) ? NotFound() : Ok(menuModel.ToMenuDto());
        }

        [HttpDelete("menu/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); };
            var menuModel = await _menuRepo.DeleteAsync(id);
            return (menuModel == null) ? NotFound() : Ok(menuModel.ToMenuDto());
        }
    }
}