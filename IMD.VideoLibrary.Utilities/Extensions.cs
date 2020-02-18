using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace IMD.VideoLibrary.Utilities
{
    /// <summary>
    /// Class sto include all common extensions
    /// </summary>
    public static class Extensions
    {
        private static readonly DateTime MinimumDateValue = new DateTime(1753, 1, 1);

        /// <summary>
        /// Converts a string to a int
        /// </summary>
        /// <param name="value">string to be converted to int</param>
        /// <returns>converted value. Zero in case of a failure.</returns>
        public static int ToInt(this string value)
        {
            int result;
            int.TryParse(value, out result);
            return result;
        }

        /// <summary>
        /// Get Description From EnumValue
        /// </summary>
        /// <param name="value">Enum name</param>
        /// <returns>Enum description</returns>
        public static string GetDescriptionFromEnumValue(Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Get Enum Value From Description
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="description"> enum description</param>
        /// <returns>Enum name</returns>
        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException();
            }

            FieldInfo[] fields = type.GetFields();
            var field =
                fields.SelectMany(
                    f => f.GetCustomAttributes(typeof(DescriptionAttribute), false),
                    (f, a) => new { Field = f, Att = a }).SingleOrDefault(a => ((DescriptionAttribute)a.Att)
                                .Description == description);
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }

        /// <summary>
        /// Convert an object to an integer
        /// </summary>
        /// <param name="val">object to be converted</param>
        /// <returns>integer value</returns>
        public static int ToInt(this object val)
        {
            int result;
            return int.TryParse(Convert.ToString(val), out result) ? result : 0;
        }

        /// <summary>
        /// Convert an object to an long integer
        /// </summary>
        /// <param name="val">object to be converted</param>
        /// <returns>long value</returns>
        public static long ToLongInt(this object val)
        {
            long result;
            return long.TryParse(Convert.ToString(val), out result) ? result : 0;
        }

        /// <summary>
        /// Convert an string to an DateTime with culture support
        /// </summary>
        /// <param name="val">object to be converted</param>
        /// <returns>Date time</returns>
        public static DateTime ToDate(this string val)
        {
            if (val == null)
            {
                return MinimumDateValue;
            }

            DateTime result;
            return DateTime.TryParse(val, out result) ? result : MinimumDateValue;
        }

        /// <summary>
        /// Convert an object to an DateTime with culture support
        /// </summary>
        /// <param name="val">object to be converted</param>
        /// <returns>Date time</returns>
        public static DateTime ToDate(this object val)
        {
            if (val == null)
            {
                return MinimumDateValue;
            }

            DateTime result;
            return DateTime.TryParse(Convert.ToString(val), out result) ? result : MinimumDateValue;
        }
    }
}
