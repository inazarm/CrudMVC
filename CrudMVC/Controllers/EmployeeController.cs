using CrudMVC.Models;
using CrudMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDB empDB = new EmployeeDB();
        // GET: Employee
        public ActionResult Index()
        {
            return View(empDB.ListAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            int r=empDB.Add(emp);
            if (r>0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        public ActionResult Edit(int id)
        {
            var Employee = empDB.ListAll().Find(x => x.EmployeeID.Equals(id));
            return View(Employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            int r = empDB.Update(emp);
            if (r > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }
        public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Employee emp)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB.ListAll().Find(x => x.EmployeeID.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Employee emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}