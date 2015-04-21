using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var problems = new List<Problem>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(Problem).IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        problems.Add(Activator.CreateInstance(type) as Problem);
                    }
                }
            }

            var sw = new Stopwatch();

            foreach (var problem in problems.OrderBy(p => p.GetType().Name))
            {
                sw.Reset();
                sw.Start();

                Exception error = null;

                try
                {
                    problem.Execute();
                }
                catch (Exception ex)
                {
                    error = ex;                    
                }

                sw.Stop();

                Console.WriteLine(problem.GetType().Name + " " + sw.ElapsedMilliseconds);

                if (error != null)
                {
                    var original = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("    ERROR: " + error.Message);
                    Console.ForegroundColor = original;
                }
            }

            Console.WriteLine("Done...");
            Console.ReadLine();
        }
    }
}
