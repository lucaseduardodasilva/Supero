using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Exceptions.General
{
    public static class MessageExtension
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            Array values = Enum.GetValues(type);

            foreach (var val in values)
            {
                if (val.ToString() == value.ToString())
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
            }

            return string.Empty;
        }
    }
}
