using System;

class BunnyPreference
{
    static void Main()
    {
        Console.WriteLine("Does the bunny like carrots or humans?");
        Console.Write("Enter 'carrots' or 'humans': ");
        string input = Console.ReadLine()?.Trim().ToLower();

        if (input == "carrots")
        {
            Console.WriteLine("The bunny likes carrots!");
        }
        else if (input == "humans")
        {
            Console.WriteLine("The bunny is friendly and likes humans!");
        }
        else
        {
            Console.WriteLine("Unknown preference.");
        }
    }
}
