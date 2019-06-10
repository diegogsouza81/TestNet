using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAppApi.Extensions
{
    public static class StringExtensions
    {
        public static int WordCount(this String str)
        {
         
            return str.Length;
        }
    }
}