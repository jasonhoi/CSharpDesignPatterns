using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeLibrary
{
    internal class SubsystemA
    {
        internal string A1()
        {
            return "Subsystem A, Method A1\n";
        }
        internal string A2()
        {
            return "Subsystem A, Method A2\n";
        }
    }

    internal class SubsystemB
    {
        internal string B1()
        {
            return "Subsystem B, Method B1\n";
        }
    }

    internal class SubsystemC
    {
        internal string C1()
        {
            return "Subsystem C, Method C1\n";
        }
    }

    public static class Facade
    {
        static SubsystemA a = new SubsystemA();
        static SubsystemB b = new SubsystemB();
        static SubsystemC c = new SubsystemC();

        public static void Operation1()
        {
            Console.WriteLine("operation 1\n" +
                a.A1() +
                a.A2() +
                b.B1());
        }

        public static void Operation2()
        {
            Console.WriteLine("operation 2\n" +
                b.B1() +
                c.C1());
        }

        public static void Main()
        {
        }
    }
}
