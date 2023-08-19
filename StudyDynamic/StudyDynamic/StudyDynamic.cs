using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDynamic
{

    public class Duck
    {
        public void Walk()
        {
            Console.WriteLine("Duck, Walk");
        }

        public void Swim()
        {
            Console.WriteLine("Duck, Swim");
        }
    }

    public class Mallard : Duck
    {
        
    }

    public class Robot
    {
        public void Walk()
        {
            Console.WriteLine("Robot, Walk");
        }

        public void Swim()
        {
            Console.WriteLine("Robot, Swim");
        }
    }

    public class StudyDynamic
    {
        public void Execute()
        {
            dynamic[] arr = new dynamic[] { new Duck(), new Mallard(), new Robot() };

            foreach(dynamic duck in arr)
            {
                Console.WriteLine(duck.GetType());
                duck.Walk();
                duck.Swim();
                Console.WriteLine();
            }
        }

    }
}
