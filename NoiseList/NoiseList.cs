using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NoiseList
{
    public static class NoiseList<T> 
    {
        public static List<T> Build(int count = 0)
        {
            var listType = typeof(T);

            var returnList = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var returnObject = (T)Activator.CreateInstance(listType);
                foreach (var property in listType.GetProperties())
                {
                    returnObject = SetRandomValue(property, returnObject);
                }
                returnList.Add(returnObject);
            }

            return returnList;
        }

        private static T SetRandomValue(System.Reflection.PropertyInfo property, T returnObject)
        {
            

            switch (property.PropertyType.Name.ToString().ToLower())
            {
                case "int32":
                    property.SetValue(returnObject, 5);
                    break;

                case "boolean":
                    property.SetValue(returnObject, true);
                    break;

                case "string":
                    property.SetValue(returnObject, "lolfail");
                    break;

                case "single":
                    property.SetValue(returnObject, 0.2f);
                    break;

                default:
                    break;
            }

            return returnObject;
        }
    }
}
