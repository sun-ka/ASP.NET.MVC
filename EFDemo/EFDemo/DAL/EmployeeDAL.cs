using EFDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFDemo.DAL
{
    public class EmployeeDAL
    {
        private EFDemoWithMVCDBEntities db = new EFDemoWithMVCDBEntities();
        public Employee GetDetails(int id)
        {
            Employee employee = db.Employees.Find(id);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return db.Employees.Include("Department");
        }

        public Employee Insert(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return emp;
        }

        public void Update(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            db.Dispose();
            //base.Dispose(disposing);
        }
    }
}