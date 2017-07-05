using System;
using System.Text;

namespace NDC.Build.Core
{
    public static class StringExtensions
    {
        public static string ToBase64(this string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }
    }
}
