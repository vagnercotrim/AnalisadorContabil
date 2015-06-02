using System.Collections.Generic;
using System.ComponentModel;

namespace AnalisadorContabil
{
    public class AnonymousObject
    {
        public static IDictionary<string, object> ToDictionary(object propertyBag)
        {
            var result = new Dictionary<string, object>();
            if (propertyBag != null)
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(propertyBag))
                {
                    result.Add(property.Name, property.GetValue(propertyBag));
                }
            }
            return result;
        }
    }
}
