using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SecondSession.Custom_Validations;
using SecondSession.Controllers;

namespace SecondSession.Models
{
    public class Employee
    {
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string first_name;
        [Required(ErrorMessage = "Enter First Name!")]
        [Display(Name = "First Name")]
        public string First_name
        {
            get { return first_name; }
            set { first_name = value; }
        }

        string last_name;
        [Required]
        [Display(Name = "Last Name")]
        public string Last_name
        {
            get { return last_name; }
            set { last_name = value; }
        }

        int salary;       
        [Required]
        [Display(Name = "Salary")]
        [SalaryRange(500)] //Custom Validation
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }     

        string email;
        [EmailAddress(ErrorMessage = "XXXX@XXX.com")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        DateTime hireDate;
        [Required]
        [Display(Name = "Hire Date")]
        [IsvalidDate] //Custom Validation
        public DateTime HireDate
        {
            get { return hireDate; }
            set { hireDate = value; }
        }

        string employee_Dep_Name;
        [Required]
        [Display(Name = "Department Name")]
        public string Employee_Dep_Name
        {
            get { return employee_Dep_Name; }
            set { employee_Dep_Name = value; }
        }

        int department_ID;
        public int Department_ID
        {
            get { return department_ID; }
            set { department_ID = value; }
        }

        public Employee(int id, string first_name, string last_name, int salary, string email, DateTime Date, string employee_Dep_Name)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.salary = salary;
            this.email = email;
            this.hireDate = Date;
            this.employee_Dep_Name = employee_Dep_Name;
            
        }

        public Employee() : this(0, "", "", 0, "", DateTime.Now, "") { }

        //public Employee() : this(0, "", "", 0, "", DateTime.Now, Department_Name.NoJob){}
    }

    /*public enum Department_Name
    {
        HR = 1,
        FR= 2,
        IT= 4,
        Logistics = 3,
        NoJob = -1
    }*/
}