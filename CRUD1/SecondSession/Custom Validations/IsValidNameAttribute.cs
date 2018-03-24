using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SecondSession.Controllers;
using SecondSession.Models;

namespace SecondSession.Custom_Validations
{
    public class IsValidNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string Name = Convert.ToString(value);
            bool NotFound = true;
            for (int i = 0; i < DepartmentController.DepList.Count; i++)
            {
                Department department = DepartmentController.DepList.ElementAt(i);
                if (department.Department_Name == Name)
                {
                    NotFound = false;
                    break;
                }
            }
            return NotFound;
        }
    }
}