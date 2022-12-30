using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}