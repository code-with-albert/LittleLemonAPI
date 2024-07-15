using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using api.Dtos.SpecialsMenu;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    public class SpecialsMenuController : ControllerBase
    {
        private readonly ISpecialsMenuRepository _specialsMenuRepo;

        public SpecialsMenuController(ISpecialsMenuRepository specialsMenuRepo)
        {
            _specialsMenuRepo = specialsMenuRepo;
        }

        [HttpGet("specials-menu")]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var specialsMenus = await _specialsMenuRepo.GetAllAsync(query);
            var menuDto = specialsMenus.Select(s => s.ToSpecialsMenuDto());
            return Ok(specialsMenus);
        }

        [HttpGet("specials-menu/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var specialsMenu = await _specialsMenuRepo.GetByIdAsync(id);
            return (specialsMenu == null) ? NotFound() : Ok(specialsMenu.ToSpecialsMenuDto());
        }

        [HttpPost("specials-menu/create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateSpecialsMenuRequestDto specialsMenuDto)
        {
            if (await _specialsMenuRepo.GetByMenuIdAsync(specialsMenuDto.MenuId) != null)
            {
                ModelState.AddModelError("MenuId", "Menu Id already taken.");
            };
            if (await _specialsMenuRepo.GetMenuExistAsync(specialsMenuDto.MenuId) == null)
            {
                ModelState.AddModelError("Menu", "Menu does not Exist.");
            };
            if (!ModelState.IsValid) { return BadRequest(ModelState); };
            var specialsMenuModel = specialsMenuDto.ToCreateSpecialsMenuDto();
            await _specialsMenuRepo.CreateAsync(specialsMenuModel);
            return CreatedAtAction(nameof(GetById), new { id = specialsMenuModel.Id }, specialsMenuModel.ToSpecialsMenuDto());
        }

        [HttpPut("specials-menu/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSpecialsMenuRequestDto updateDto)
        {
            if (await _specialsMenuRepo.GetByMenuIdAsync(updateDto.MenuId) != null)
            {
                ModelState.AddModelError("MenuId", "Menu Id already taken.");
            };
            if (await _specialsMenuRepo.GetMenuExistAsync(updateDto.MenuId) == null)
            {
                ModelState.AddModelError("Menu", "Menu does not Exist.");
            };
            if (!ModelState.IsValid) { return BadRequest(ModelState); };
            var specialsMenuModel = await _specialsMenuRepo.UpdateAsync(id, updateDto);
            return (specialsMenuModel == null) ? NotFound() : Ok(specialsMenuModel.ToSpecialsMenuDto());
        }

        [HttpDelete("specials-menu/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); };
            var specialsMenuModel = await _specialsMenuRepo.DeleteAsync(id);
            return (specialsMenuModel == null) ? NotFound() : Ok(specialsMenuModel.ToSpecialsMenuDto());
        }
    }
}