using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Ensure correct usage
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: dotnet run <pattern> <file1> [<file2> ...]");
            return;
        }

        // Get the pattern from command-line arguments
        string pattern = args[0];

        // Loop through each file and search for the pattern
        for (int i = 1; i < args.Length; i++)
        {
            string filePath = args[i];
            SearchFile(filePath, pattern);
        }
    }

    static void SearchFile(string filePath, string pattern)
    {
        try
        {
            // Read each line of the file
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Check if the line matches the pattern
                    if (Regex.IsMatch(line, pattern))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}
