﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.Core.Controllers;
using PortfolioBackend.Core.DAL;
using PortfolioBackend.Models.ViewModels;
using PortfolioBackend.Core.BLL.Services;
using Microsoft.EntityFrameworkCore;

namespace PortfolioBackend.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Route("api/dashboard/[controller]")]///[action]
    public class PermissionController : BaseEntityController<Permission, PermissionViewModel, PermissionService>
    {
        //public async override Task<IActionResult> Get()
        //{
        //    var ents = Service.AllAsQueryable
        //                      .Include(a => a.Localizations)
        //                      .Include(a => a.RoleInPermissions);

        //    var list = await ents.ToListAsync();
        //    var result = list.Select(s => s.ConvertToModel<Permission, PermissionViewModel>());

        //    return Ok(result);
        //}

        public async override Task<IActionResult> GetById(int id)
        {
            Permission ent = await Service.AllAsQueryable
                                          .Include(a => a.Localizations)
                                          .Include(a => a.RoleInPermissions)
                                          .FirstOrDefaultAsync(a => a.Id == id);

            if (ent == null)
                return NotFound();

            PermissionViewModel model = Activator.CreateInstance<PermissionViewModel>();
            model.LoadEntity(ent);

            return Ok(model);
        }
    }
}
