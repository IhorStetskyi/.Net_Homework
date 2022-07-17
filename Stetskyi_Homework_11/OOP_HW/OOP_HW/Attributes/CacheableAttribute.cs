using System;

namespace OOP_HW.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class CacheableAttribute : Attribute
    {
        public bool ShouldBeCached { get; set; }
        public CacheableAttribute(bool chacheable)
        {
            ShouldBeCached = chacheable;
        }
    }
}
