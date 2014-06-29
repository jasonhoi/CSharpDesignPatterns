using System;

// Proxy Pattern
// Shows virtual and protection proxies

public interface ISubject
{
    string Request();
}

class SubjectAccessor
{
    private class Subject
    {
        public string Request()
        {
            return "Subject request response \n";
        }
    }

    public class ProxyA : ISubject
    {
        Subject subject;

        public string Request()
        {
            // A virtual proxy creates the object only on its first method call
            if (subject == null)
            {
                Console.WriteLine("Subject inactive");
                subject = new Subject();
            }
            Console.WriteLine("Subject activated");
            return "Proxy A: Call - " + subject.Request();
        }
    }

    public class ProtectedProxy : ISubject
    {
        Subject subject;
        string password = "abc123";

        public string Authenticate(string input)
        {
            if (input != password)
            {
                return "Protected Proxy: No access";
            }
            else
            {
                subject = new Subject();
                return "Protected Proxy: Authenticated";
            }
        }

        public string Request()
        {
            if (subject == null)
            {
                return "Protected Proxy: Must authenticated first";
            }
            else
            {
                return "Protected Proxy: Call - " + subject.Request();
            }
        }
    }
}


class Client : SubjectAccessor
{
    static void Main(string[] args)
    {
        Console.WriteLine("Proxy Pattern\n");

        ISubject proxyA = new ProxyA();
        Console.WriteLine(proxyA.Request());

        ProtectedProxy subject = new ProtectedProxy();
        Console.WriteLine(subject.Request());
        Console.WriteLine(subject.Authenticate("abc"));
        Console.WriteLine(subject.Authenticate("abc123"));
        Console.WriteLine(subject.Request());

        Console.ReadLine();

        /*
         * Output:
         * 
         * Proxy Pattern
         * 
         * Subject inactive
         * Subject activated
         * Proxy A: Call - Subject request response
         * 
         * Protected Proxy: Must authenticated first
         * Protected Proxy: No access
         * Protected Proxy: Authenticated
         * Protected Proxy: Call - Subject request response
         * 
         */ 
    }
}