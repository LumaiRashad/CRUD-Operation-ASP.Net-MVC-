using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondSession.Models;
using SecondSession.Controllers;

namespace SecondSession.Controllers
{
    public class DepartmentController : Controller
    {

        //
        // GET: /Department/

        public static List<Department> DepList = new List<Department>() 
        {
            new Department("HR", 0),
            new Department("FR", 1),
            new Department("Logistics", 2),
            new Department("IT", 3)
        };

        public static List<string> Departments = new List<string>()
        {
            "HR", "FR", "Logistics", "IT"
        };

       /* public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }*/

        public ActionResult DisplayDepartments()
        {
            return View(DepList);
        }

        public ActionResult RetrieveEmpList(string DepName)
        {
            List<Employee> EmpList = new List<Employee>();
            for (int i = 0; i < EmployeeController.empList.Count(); i++)
            {
                if(DepName == EmployeeController.empList[i].Employee_Dep_Name)
                {
                    EmpList.Add(EmployeeController.empList[i]);
                }
            }
            if (EmpList.Count() > 0)
                return View(EmpList);
            else
                return Content("No Employees Found in the Requested Department!!");
        }

        public ActionResult CreateDepartment()
        {
            return View();
        }

        public ActionResult SaveDepartment(Department DepObj)
        {
            if (!ModelState.IsValid)
                return View("CreateDepartment", DepObj);
            int max=-1;
            for (int i = 0; i < DepList.Count(); i++)
            {
                if (max <= DepList[i].Department_Id)
                    max = DepList[i].Department_Id;
            }
            DepObj.Department_Id = max + 1;
            DepList.Add(DepObj);
            Departments.Add(DepObj.Department_Name);

            return RedirectToAction("DisplayDepartments");
        }

        public ActionResult DeleteDepartment(int? id)
        {
            for (int i = 0; i < DepList.Count(); i++)
            {
                if (id == DepList[i].Department_Id)
                {
                    Departments.Remove(DepList[i].Department_Name);
                    DepList.Remove(DepList[i]);
                    break;
                }
            }
                return RedirectToAction("DisplayDepartments");
        }

        public ActionResult EditDepartment(int? id)
        {
            Department DepObj = new Department();
            for (int i = 0; i < DepList.Count(); i++)
            {
                if (id == DepList[i].Department_Id)
                {
                    DepObj = DepList[i];
                    break;
                }
            }

            return View(DepObj);
        }

        public ActionResult SaveEditedDepartment(Department DepObj, int? id)
        {
            if (!ModelState.IsValid)
                return View("EditDepartment", DepObj);
            for (int i = 0; i < DepList.Count(); i++)
            {
                if (DepList[i].Department_Id == id)
                {
                    DepList[i] = DepObj;
                    Departments[i] = DepObj.Department_Name;
                    break;
                }
            }

            return RedirectToAction("DisplayDepartments");
        }
    }
}

  

/* 
List<Employee> EmpList = new List<Employee>();
            for (int i = 0; i < EmployeeController.empList.Count(); i++)
            {
                var id = Enum.Parse(typeof(SecondSession.Models.Department_Name), EmployeeController.empList.ElementAt(i).Employee_Dep_Name.ToString());
                if(DepID == (int)id)
                {
                    EmpList.Add(EmployeeController.empList.ElementAt(i));
                }
            }
            if (EmpList.Count() > 0)
                return View(EmpList);
            else
                return Content("Not Employees Found in the Requested Department!!");
*/