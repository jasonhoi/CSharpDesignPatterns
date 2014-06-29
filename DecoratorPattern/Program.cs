using System;

// Decorator Pattern
// Show two decorator and the output of various combinations of decorators on the basic component

class DecoratorPattern
{
    interface IComponent
    {
        string Operation();
    }

    class Component : IComponent
    {
        public string Operation()
        {
            return "I am walking ";
        }
    }

    class DecoratorA : IComponent
    {
        IComponent component;
        public DecoratorA(IComponent com)
        {
            component = com;
        }

        public string Operation()
        {
            string s = component.Operation();
            return s + "and listening to radio ";
        }
    }

    class DecoratorB : IComponent
    {
        IComponent component;
        public string addedState = "outside";

        public DecoratorB(IComponent com)
        {
            component = com;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "to school ";
            return s;
        }

        public string AddedBehavior()
        {
            return "also going to coffee shop ";
        }
    }

    static void Display(string s, IComponent com)
    {
        Console.WriteLine(s + com.Operation());
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Decorator Pattern\n");

        IComponent component = new Component();
        Display("1. Basic component: ", component);
        Display("2. Decorated component A: ", new DecoratorA(component));
        Display("3. Decorated component B: ", new DecoratorB(component));
        Display("4. B-A-decorated component: ", new DecoratorB(new DecoratorA(component)));

        // Explicit B then decorated with A decorator
        DecoratorB b = new DecoratorB(component);
        Display("5. A-B-decorated component: ", new DecoratorA(b));
        Console.WriteLine("\tadded state: " + b.addedState + ", added behavior: " + b.AddedBehavior());

        Console.ReadLine();
    }
}