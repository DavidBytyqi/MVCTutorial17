using MVCTutorial17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTutorial17.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            MVCDatabaseEntities db = new MVCDatabaseEntities();
            List<Department> list = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

            List<EmployeeViewModel> listEmp = db.Employees.Where(x => x.isDeleted == false).Select(x => new EmployeeViewModel
            {
                Name = x.Name,
                DepartmentName = x.Department.DepartmentName,
                Address = x.Address,
                EmployeeId = x.EmployeeId

            }).ToList();
            ViewBag.EmployeeList = listEmp;
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmployeeViewModel model)
        {
            try
            {
                MVCDatabaseEntities db = new MVCDatabaseEntities();
                List<Department> list = db.Departments.ToList();
                ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

                Employee emp = new Employee();
                emp.Address = model.Address;
                emp.EmployeeId = model.EmployeeId;
                emp.Name = model.Name;
                emp.DepartmentId = model.DepartmentId;
                db.Employees.Add(emp);
                db.SaveChanges();

                int latestEmpId = emp.EmployeeId;

                //Site site = new Site();
                //site.SiteName = model.SiteName;
                //site.EmployeeId = latestEmpId;

                //db.Sites.Add(site);
                //db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(model);
        }

        public JsonResult DeleteEmployee(int EmployeeId)
        {
            MVCDatabaseEntities db = new MVCDatabaseEntities();
            bool result = false;
            Employee emp = db.Employees.SingleOrDefault(x => x.isDeleted == false && x.EmployeeId == EmployeeId);
            if (emp != null)
            {
                emp.isDeleted = true;
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ShowPartial()
        {
            return PartialView("Partial1");
        }
    }
}