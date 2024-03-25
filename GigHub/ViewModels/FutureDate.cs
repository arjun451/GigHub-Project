using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string[] formats = {
                 "MM/dd/yyyy"
                };
            string dateString = (string)value;

            DateTime dateTime;
            var isValid = DateTime.TryParseExact(dateString, formats,
                                       new CultureInfo("en-US"),
                                       DateTimeStyles.None, out dateTime);

            return (isValid && dateTime > DateTime.Now);


        }
    }
}