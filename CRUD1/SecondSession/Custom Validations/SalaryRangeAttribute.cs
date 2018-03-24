using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SecondSession.Custom_Validations
{
    public class SalaryRangeAttribute: RangeAttribute
    {
        //Second type of Custom Validation
        //Originally to create Custom Validation, MUST inherit from Validation Attribute class
        //Here Range Attribute class is internally inheriting from Validation Attribute class
        public SalaryRangeAttribute(int minValue) : base(typeof(int), "500", "20000") { }
    }
}