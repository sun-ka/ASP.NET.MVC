using EFDemo.DAL;
using EFDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDemo.Controllers
{
    public class GenericBODemoController : Controller
    {

        GenericBO<Employee> obj = new GenericBO<Employee>();
        GenericBO<Department> objDept = new GenericBO<Department>();


        // GET: GenericBODemo
        public ActionResult Index()
        {
            var employees = obj.GetAll();
            return View(employees.ToList());
        }

        // GET: GenericBODemo/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = obj.GetDetails(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: GenericBODemo/Create
        public ActionResult Create()
        {
            ViewBag.DeptID = new SelectList(objDept.GetAll(), "DeptID", "DeptName");
            return View();
        }

        // POST: GenericBODemo/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.Insert(employee);
                    return RedirectToAction("Index");
                }

                ViewBag.DeptID = new SelectList(objDept.GetAll(), "DeptID", "DeptName");
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        // GET: GenericBODemo/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = obj.GetDetails(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.DeptID = new SelectList(objDept.GetAll(), "DeptID", "DeptName", employee.DeptID);
            return View(employee);
        }

        // POST: GenericBODemo/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.Update(employee);
                    return RedirectToAction("Index");
                }

                ViewBag.DeptID = new SelectList(objDept.GetAll(), "DeptID", "DeptName", employee.DeptID);
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        // GET: GenericBODemo/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = obj.GetDetails(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: GenericBODemo/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            try
            {
                obj.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}