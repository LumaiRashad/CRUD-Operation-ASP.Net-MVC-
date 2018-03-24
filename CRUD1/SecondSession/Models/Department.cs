using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecondSession.Custom_Validations;

namespace SecondSession.Models
{
    public class Department
    {
        int department_Id = 0;
        public int Department_Id
        {
            get { return department_Id; }
            set { department_Id = value; }
        }

        string department_Name;
        [IsValidName]
        public string Department_Name
        {
            get { return department_Name; }
            set { department_Name = value; }
        }

        public Department(string department_Name, int department_Id)
        {
            this.department_Id = department_Id;
            this.department_Name = department_Name;
        }
        public Department() : this("", 0) { }
    }
}