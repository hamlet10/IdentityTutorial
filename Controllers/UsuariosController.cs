using IdentityTutorial.Context;
using IdentityTutorial.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController: ControllerBase
    {
        private readonly AplicationDbContext _context;
        private readonly UserManager<AplicationUser> _userManager;

        public UsuariosController(AplicationDbContext context, UserManager<AplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpPost("AsignUserRole")]
        public async Task<ActionResult> AsignUserRole(EditarRoleDto editarRoleDto)
        {
            var user = await _userManager.FindByIdAsync(editarRoleDto.UserId);
            if(user == null) { return NotFound(); }
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editarRoleDto.RoleName));
            await _userManager.AddToRoleAsync(user, editarRoleDto.RoleName);
            return Ok();
        }

        [HttpPost("RemoveUserRole")]
        public async Task<ActionResult>RemoveUserRole(EditarRoleDto editarRoleDto)
        {
            var user = await _userManager.FindByIdAsync(editarRoleDto.UserId);
            if (user == null) { return NotFound(); }
            await _userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editarRoleDto.RoleName));
            await _userManager.RemoveFromRoleAsync(user, editarRoleDto.RoleName);
            return Ok();
        }
    }
}
