using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class ValidateTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string[] formats = {
                 "HH:mm"
                };
            string dateString = (string)value;

            DateTime time;
            var isValid = DateTime.TryParseExact(dateString, formats,
                                       new CultureInfo("en-US"),
                                       DateTimeStyles.None, out time);

            return isValid;


        }
    }
}