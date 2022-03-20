using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.CustomAttributes
{
    public class IsBeforeAttribute : ValidationAttribute
    {
        //private readonly DateTime dateToCompare;
        //public IsBeforeAttribute(string _propertyToCompare, string errorMessage ="")
        //{
        //    dateToCompare = _dateToCompare;
        //    this.ErrorMessage = errorMessage;
        //}


        //public override bool IsValid(object? value)
        //{
        //    if (value == null) return false; 

        //    return (DateTime)value < dateToCompare;
        //}
    }
}
