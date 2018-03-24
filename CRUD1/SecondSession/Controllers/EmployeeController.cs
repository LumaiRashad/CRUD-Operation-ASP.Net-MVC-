using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondSession.Models;

namespace SecondSession.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<Employee> empList = new List<Employee>()
        {
                new Employee(0, "Sam", "Frank", 2000, "SFrank@gmail.com", new DateTime(2017,11,5), "HR"),
                new Employee(1, "Tom", "Eddy", 3500, "TEdd@gmail.com", new DateTime(2014,9,25), "FR"),
                new Employee(2, "Derek", "Smith", 2000, "dSmith@gmail.com", new DateTime(2015,7,10), "IT")
        };

        /*public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }*/

        public ActionResult RetrieveEmployee(int? id)
        {
            bool found = false;            
            Employee Obj = new Employee();
            for (int i = 0; i < empList.Count(); i++)
            {
                if (empList[i].Id == id)
                {
                    Obj = empList[i];
                    found = true;
                    break;
                }
            }
            if (found)
                return View(Obj);
            else
                return HttpNotFound();
            //return Content("Employee Not Found!!");
        }

        public ActionResult DisplayEmployees()
        {
            return View(empList);
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }

        public ActionResult SaveEmployee(Employee EmpObj)
        {
            if (!ModelState.IsValid)
                return View("CreateEmployee", EmpObj);
            int max = -1;
            for (int i = 0; i < empList.Count(); i++)
            {
                if (max <= empList[i].Id)
                    max = empList[i].Id;
            }
            EmpObj.Id = max + 1;
            empList.Add(EmpObj);

            return RedirectToAction("DisplayEmployees");
        }

        public ActionResult SaveEditedEmployee(Employee EmpObj, int? id)
        {
            if(!ModelState.IsValid)
                return View("EditEmployee", EmpObj);
            for(int i = 0; i < empList.Count(); i++)
            {
                if (empList[i].Id == id)
                {
                    empList.Remove(empList[i]);
                    break;
                }
            }
            EmpObj.Id = (int)id;
            empList.Add(EmpObj);

            return RedirectToAction("DisplayEmployees");
        }

        public ActionResult DeleteEmployee(int? id)
        {
            for (int i = 0; i < empList.Count(); i++)
            {
                if (id == empList[i].Id)
                {
                    empList.Remove(empList[i]);
                    break;
                }
            }

            return RedirectToAction("DisplayEmployees");
        }

        public ActionResult EditEmployee(int? id)
        {
            Employee EmpObj = new Employee();
            for (int i = 0; i < empList.Count(); i++)
            {
                if (id == empList[i].Id)
                {
                    EmpObj = empList[i];
                    break;
                }
            }

            return View(EmpObj);
        }
    }
}
