using System;
using System.Collections.Generic;
using System.Linq;  // Needed for sorting and LINQ operations

namespace DictionarySwitchExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a dictionary that maps a string key to a list of string values
            Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();

            bool running = true;

            // Main loop that keeps running until the user chooses to exit
            while (running)
            {
                Console.WriteLine("\n===== Dictionary Menu =====");
                Console.WriteLine("a. Populate the Dictionary");
                Console.WriteLine("b. Display Dictionary Contents");
                Console.WriteLine("c. Remove a Key");
                Console.WriteLine("d. Add a New Key and Value");
                Console.WriteLine("e. Add a Value to an Existing Key");
                Console.WriteLine("f. Sort the Keys");
                Console.WriteLine("x. Exit");
                Console.Write("Enter your choice: ");
                string choice = (Console.ReadLine() ?? string.Empty).ToLower();

                // Switch statement to handle menu choices
                switch (choice)
                {
                    case "a":
                        // Populate the dictionary with sample data
                        PopulateDictionary(myDictionary);
                        break;

                    case "b":
                        // Display the contents of the dictionary
                        DisplayDictionary(myDictionary);
                        break;

                    case "c":
                        // Remove a key from the dictionary
                        RemoveKey(myDictionary);
                        break;

                    case "d":
                        // Add a new key and value
                        AddNewKey(myDictionary);
                        break;

                    case "e":
                        // Add a new value to an existing key
                        AddValueToExistingKey(myDictionary);
                        break;

                    case "f":
                        // Sort the dictionary keys
                        SortKeys(myDictionary);
                        break;

                    case "x":
                        // Exit the loop
                        running = false;
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // a. Populate Dictionary
        static void PopulateDictionary(Dictionary<string, List<string>> dict)
        {
            dict.Clear(); // Clear any existing data first
            dict.Add("Fruits", new List<string> { "Apple", "Banana", "Orange" });
            dict.Add("Vegetables", new List<string> { "Carrot", "Broccoli" });
            dict.Add("Dairy", new List<string> { "Milk", "Cheese" });

            Console.WriteLine("Dictionary populated with sample data.");
        }

        // b. Display Dictionary Contents
        static void DisplayDictionary(Dictionary<string, List<string>> dict)
        {
            if (dict.Count == 0)
            {
                Console.WriteLine("The dictionary is empty.");
                return;
            }

            Console.WriteLine("\n--- Dictionary Contents ---");

            // Using foreach to enumerate key-value pairs
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
            }
        }

        // c. Remove a Key
        static void RemoveKey(Dictionary<string, List<string>> dict)
        {
            Console.Write("Enter the key to remove: ");
            string key = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(key))
            {
                Console.WriteLine("No key entered. Operation canceled.");
                return;
            }

            if (dict.Remove(key))
            {
                Console.WriteLine($"Key '{key}' removed successfully.");
            }
            else
            {
                Console.WriteLine($"Key '{key}' not found.");
            }
        }

        // d. Add a New Key and Value
                static void AddNewKey(Dictionary<string, List<string>> dict)
                {
                    Console.Write("Enter new key: ");
                    string key = Console.ReadLine() ?? string.Empty;
        
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        Console.WriteLine("No key entered. Operation canceled.");
                        return;
                    }
        
                    if (dict.ContainsKey(key))
                    {
                        Console.WriteLine("That key already exists. Try using option (e) to add a value.");
                        return;
                    }
        
                    Console.Write("Enter value for the key: ");
                    string value = Console.ReadLine() ?? string.Empty;
        
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        Console.WriteLine("No value entered. Operation canceled.");
                        return;
                    }
        
                    dict[key] = new List<string> { value };
                    Console.WriteLine($"Added key '{key}' with initial value '{value}'.");
                }
        
                // e. Add a Value to an Existing Key
                static void AddValueToExistingKey(Dictionary<string, List<string>> dict)
                {
                    Console.Write("Enter existing key: ");
                    string key = Console.ReadLine() ?? string.Empty;
        
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        Console.WriteLine("No key entered. Operation canceled.");
                        return;
                    }
        
                    if (dict.TryGetValue(key, out var values))
                    {
                        Console.Write("Enter new value to add: ");
                        string value = Console.ReadLine() ?? string.Empty;
        
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            Console.WriteLine("No value entered. Operation canceled.");
                            return;
                        }
        
                        values.Add(value);
                        Console.WriteLine($"Added '{value}' to key '{key}'.");
                    }
                    else
                    {
                        Console.WriteLine("Key not found. Try adding it first using option (d).");
                    }
                }
        
                // f. Sort the Keys
        static void SortKeys(Dictionary<string, List<string>> dict)
        {
            if (dict.Count == 0)
            {
                Console.WriteLine("The dictionary is empty. Nothing to sort.");
                return;
            }

            // Sort by key using LINQ
            var sortedDict = dict.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("\n--- Sorted Dictionary (by Key) ---");
            foreach (var kvp in sortedDict)
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
