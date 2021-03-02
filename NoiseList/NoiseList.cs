using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NoiseLists
{
    //Trying to figure out delegate nonsense.

    public static class NoiseList<T>
    {
        private static Dictionary<Type, Func<object>> _typeResolvers = new Dictionary<Type, Func<object>>();
        private static Random _random;

        static NoiseList()
        {
            _random = new Random();

            _typeResolvers.Add(typeof(string), RandomString);
            _typeResolvers.Add(typeof(int), RandomInt);
            _typeResolvers.Add(typeof(float), RandomFloat);
            _typeResolvers.Add(typeof(bool), RandomBool);
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
            var result = Convert.ChangeType(_typeResolvers[type].Invoke(), type);

            property.SetValue(returnObject, result);

            return returnObject;
        }

        internal static object RandomInt()
        {
            return _random.Next(int.MinValue, int.MaxValue);
        }

        private static object RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            
            var length = 10;
            var randomString =  new string(Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
            
            return randomString;
        }

        private static object RandomFloat()
        {
            var max = 10000f;
            var min = -10000f;
            double val = (_random.NextDouble() * (max - min) + min);
            return (float)val;
        }

        private static object RandomBool()
        {
            return _random.Next(2) == 1 ? true : false;
        }

    }
}
