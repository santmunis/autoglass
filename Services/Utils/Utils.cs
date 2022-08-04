using System;
using System.Linq.Expressions;
using FluentValidation.Internal;

namespace Services.Utils
{
    public static class Utils
    {
        public static bool DateValidator(DateTimeOffset date)
        {
            return date <= DateTimeOffset.Now;
        }


    }
}
