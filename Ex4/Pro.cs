using System;
using System.Collections.Generic;
using _04_generic_example.Model;
using _04_generic_example.Repository;

namespace _04_generic_example
{
    class Program
    {
        private static List<Student> s_students = new List<Student>();
        private static List<Class> s_classes = new List<Class>();
        static void Main(string[] args)
        {

            IRepository<Student> rep = new BaseRepository<Student>(s_students);
            IRepository<Class> rep1 = new BaseRepository<Class>(s_classes);



            rep1.Add(new Class("19DTHQA1"));
            rep1.Add(new Class("19DTHQA2"));

            rep.Add(new Student("AAA", 11));
            rep.Add(new Student("BBB", 22));
            rep.Add(new Student("CCC", 33));
            rep.Add(new Student("DDD", 44));

            Console.WriteLine("List all classes:");

          
            foreach(var cl in rep1.GetAll())
            {
                Console.WriteLine(cl.Name);
            }
            Console.WriteLine("List all Students:");
            foreach(var st in rep.GetAll())
            {
               Console.WriteLine(st.Name);
            }
        }
    }
}
