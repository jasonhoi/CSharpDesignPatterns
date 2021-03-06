﻿using System;
using System.Collections.Generic;

// Simple adoptor for int to double division function
class Adaptee
{
    public double SpecificRequest(double a, double b)
    {
        return a / b;
    }
}

interface ITarget
{
    string Request(int a, int b);
}

class Adoptor : Adaptee, ITarget
{
    public string Request(int a, int b)
    {
        return "Rough estimate is " + (int)Math.Round(SpecificRequest(a, b));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Adaptor Pattern \n");

        Adaptee precise = new Adaptee();
        Console.WriteLine("Before the standard precise reading: ");
        Console.WriteLine(precise.SpecificRequest(5, 3));

        ITarget adoptedObj = new Adoptor();
        Console.WriteLine("Standard precise reading: ");
        Console.WriteLine(adoptedObj.Request(5, 3));
        Console.ReadLine();

        /*
         * Output:
         * 
         * Adaptor Pattern
         * 
         * Before the standard precise reading:
         * 1.66666666666667
         * Standard precise reading:
         * Rough estimate is 2
         * 
         */
    }
}
