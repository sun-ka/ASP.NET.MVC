using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDemo.DAL;
using EFDemo.Models;

namespace EFDemo.Controllers
{
    public class EmployeeDALController : Controller
    {
        EmployeeDAL objEmpBO = new EmployeeDAL();
        DepartmentDAL objDeptBO = new DepartmentDAL();
        // GET: EmployeeDAL
        public ActionResult Index()
        {
            var employees = objEmpBO.GetAllEmployees();
            return View(employees.ToList());
        }

        // GET: EmployeeDAL/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = objEmpBO.GetDetails(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: EmployeeDAL/Create
        public ActionResult Create()
        {

            ViewBag.DeptID = new SelectList(objDeptBO.GetAllDepartments(), "DeptID", "DeptName");
            return View();
        }

        // POST: EmployeeDAL/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objEmpBO.Insert(employee);
                    return RedirectToAction("Index");
                }
           
                ViewBag.DeptID = new SelectList(objDeptBO.GetAllDepartments(), "DeptID", "DeptName");
                return View(employee);

                
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeDAL/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = objEmpBO.GetDetails(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
          
            ViewBag.DeptID = new SelectList(objDeptBO.GetAllDepartments(), "DeptID", "DeptName", employee.DeptID);
            return View(employee);
        }

        // POST: EmployeeDAL/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objEmpBO.Update(employee);
                    return RedirectToAction("Index");
                }
              
                ViewBag.DeptID = new SelectList(objDeptBO.GetAllDepartments(), "DeptID", "DeptName", employee.DeptID);
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeDAL/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = objEmpBO.GetDetails(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: EmployeeDAL/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                objEmpBO.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
