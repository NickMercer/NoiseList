using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NoiseLists
{
    //Trying to figure out delegate nonsense.

    public static class NoiseList<T> 
    {
        private delegate object RandomDelegate<U>(TypeRange<U> range);

        private static Dictionary<Type, RandomDelegate> _defaultFunctionMap = new Dictionary<Type, RandomDelegate>();
        private static Dictionary<Type, TypeRange<Type>> _defaultRangeMap = new Dictionary<Type, TypeRange<Type>>();

        static NoiseList()
        {
            _defaultFunctionMap.Add(typeof(int), new RandomDelegate<int>(RandomInt);
        }

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

        internal static T SetRandomValue(System.Reflection.PropertyInfo property, T returnObject)
        {
            var type = property.PropertyType;
            var range = _defaultRangeMap[property.PropertyType];
            var result = _defaultFunctionMap[property.PropertyType](range);

            property.SetValue(returnObject, result);

            return returnObject;
        }

        internal static object RandomInt(TypeRange<int> range)
        {
            return int.MinValue;
        }
    }
}
