using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SecondSession.Custom_Validations
{
    public class IsvalidDateAttribute: ValidationAttribute
    {
        //First type of Custom Validation
        //Inherit from Validation Attribute class
        //This class contains ONLY one Virtual Function Called: IsValid
        //We Override it in order to create a Custom Validation
        public IsvalidDateAttribute() { }
        public IsvalidDateAttribute(string Err_Msg) { }
        public override bool IsValid(object value)
        {      
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now; // Will return Either True of False              
        }
    }
}