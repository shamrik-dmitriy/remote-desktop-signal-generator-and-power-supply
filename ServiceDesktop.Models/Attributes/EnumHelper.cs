﻿using System;
using System.Collections;

namespace ServiceDesktop.Models.Attributes
{
    public static class EnumHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueOfEnum"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum valueOfEnum)
        {
            if (valueOfEnum == null)
            {
                throw new ArgumentNullException("valueOfEnum");
            }

            var description = valueOfEnum.ToString();
            var fieldInfo = valueOfEnum.GetType().GetField(description);

            var attributes =
                (EnumDescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                description = attributes[0].Description;
            }

            return description;
        }

        public static IList ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var list = new ArrayList();

            foreach (Enum value in Enum.GetValues(type))
            {
                list.Add(GetDescription(value));
            }

            return list;
        }
    }
}