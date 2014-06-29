using System;

// Adapter Pattern - Pluggable
// Adapter can accept any number of pluggable adaptees and targets and route
// the requests via a delegate, in some cases using the anonymous delegate construct

// Existing way requests are implemented
class Adaptee
{
    public double Precise(double a, double b)
    {
        return a / b;
    }
}

// New standard for requests
class Target
{
    public string Estimate(int a, int b)
    {
        return "(Standard) Estimate is " + (int)Math.Round((double) a / b);
    }
}

// Implement new requests via old
class Adapter : Adaptee
{
    public Func<int, int, string> Request;

    // Different constructs for the expected target/adaptees
    // Construct 1: Adapter-Adaptee
    public Adapter(Adaptee adaptee)
    {
        // Set the delegate to the new standard
        Request = delegate(int a, int b)
        {
            return "(Precised) Estimate is " + (int)Math.Round(Precise((double)a, (double)b));
        };
    }

    // Construct 2: Adapter-Target
    public Adapter(Target target)
    {
        // Set the delegate to the existing standard
        Request = target.Estimate;
    }
}

class Client
{
    static void Main(string[] args)
    {
        Console.WriteLine("Pluggable Adaptor");

        Adapter calculatorOriginal = new Adapter(new Adaptee());
        Console.WriteLine(calculatorOriginal.Request(5, 3));

        Adapter calculatorStandard = new Adapter(new Target());
        Console.WriteLine(calculatorStandard.Request(5, 3));

        Console.ReadLine();
    }
}
