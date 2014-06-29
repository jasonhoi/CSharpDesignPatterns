using System;
using FacadeLibrary;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Facade Pattern\n");

            Facade.Operation1();
            Facade.Operation2();

            Console.ReadLine();

            /*
             * Output:
             * 
             * Facade Pattern
             * 
             * operation 1
             * Subsystem A, Method A1
             * Subsystem A, Method A2
             * Subsystem B, Method B1
             * 
             * opeartion 2
             * Subsystem B, Method B1
             * Subsystem C, Method C1
             */
        }
    }
}
