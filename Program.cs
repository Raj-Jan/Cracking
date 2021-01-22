using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cracking
{
    public class Program
    {
        public static List<IExercise> exercies;
        public static IExercise current;

        private static void Main()
        {
            var assembly = Assembly.GetEntryAssembly();
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.GetCustomAttribute<EntryAttribute>() == null) continue;
                if (type.IsGenericType) continue;
                if (type.IsAbstract) continue;

                current = Activator.CreateInstance(type, true) as IExercise;

                break;
            }

            current.Main();
        }
    }

    public interface IExercise
    {
        void Main();
    }

    public class EntryAttribute : Attribute { }
}
