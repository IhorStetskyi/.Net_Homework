using System;

namespace ConcatenationLib
{
    public static class ConcatClass
    {
        public static string Concat(string name)
        {
            return $"{DateTime.Now} \nHello {name}";
        }
    }
}
