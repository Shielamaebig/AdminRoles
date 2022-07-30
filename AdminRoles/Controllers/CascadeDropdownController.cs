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
    public class CascadeDropdownController : Controller
    {
        ApplicationDbContext _context;
        public CascadeDropdownController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Department
        public ActionResult Index()
        {
            var DepartmentsTypes = _context.DepartmentTypes.ToList();
            return View(DepartmentsTypes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentType DepartmentType)
        {
            _context.DepartmentTypes.Add(DepartmentType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DivisionIndex()
        {
            var DivisionTypes = _context.DepartmentTypes.ToList();
            return View(DivisionTypes);
        }

        public ActionResult CreateDivision()
        {
            ViewBag.DepartmentTypes = new SelectList(_context.DepartmentTypes, "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult CreateDivision(DivisionType DivisionType)
        {
            _context.DivisionTypes.Add(DivisionType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CascadeList()
        {
            ViewBag.DepartmentTypes = new SelectList(_context.DepartmentTypes, "Id", "Name");
            return View();
        }

        public JsonResult LoadDivision(int id)
        {
            var DivisionTypes = _context.DivisionTypes.Where(z => z.DepartmentTypeId == id).ToList();
            return Json(new SelectList(DivisionTypes,"Id", "Name"));
        }
    }
}