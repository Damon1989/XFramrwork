using System;
using System.Collections.Generic;
using System.Text;

namespace XFramework.Infrastructure
{
    public static class Utility
    {
        public static string GetFullNameWithAssembly(this Type type)
        {
            return $"{type.FullName},{type.Assembly.GetName().Name}";
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> act)
        {
            if (source == null)
            {
                return;
            }

            foreach (var element in source)
            {
                act(element);
            }
        }
    }
}