using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using AdminRoles.Models;

namespace AdminRoles.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext _context;

        public RoleController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Role 
        [Authorize]
        public ActionResult Index()
        {
            var Roles = _context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            _context.Roles.Add(Role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}