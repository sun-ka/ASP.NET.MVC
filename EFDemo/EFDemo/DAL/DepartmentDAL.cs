using EFDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFDemo.DAL
{
    public class DepartmentDAL
    {

        private EFDemoWithMVCDBEntities db = new EFDemoWithMVCDBEntities();

        public IEnumerable<Department> GetAllDepartments()
        {
            return db.Departments;
        }

    }
}