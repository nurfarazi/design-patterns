using System;
using System.Collections.Generic;
using System.IO;

// Single Responsibility Principle (SRP)
// A class should have only one reason to change.
// A class should have only one job.
// A class should have only one responsibility.

namespace SOLID
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var journal = new Journal();
            // Get user input in console.
            System.Console.WriteLine("What is your name?");
            var name = System.Console.ReadLine();
            System.Console.WriteLine($"Hello {name}!");
            System.Console.WriteLine("What is your age?");
            var age = System.Console.ReadLine();
            System.Console.WriteLine($"You are {age} years old.");
            System.Console.WriteLine("What is your favorite color?");
            var color = System.Console.ReadLine();
            System.Console.WriteLine($"Your favorite color is {color}.");
            System.Console.WriteLine("What is your favorite animal?");
            var animal = System.Console.ReadLine();
            System.Console.WriteLine($"Your favorite animal is {animal}.");
            System.Console.WriteLine("What is your favorite band?");
            var band = System.Console.ReadLine();
            System.Console.WriteLine($"Your favorite band is {band}.");
            System.Console.WriteLine("What is your favorite food?");
            var food = System.Console.ReadLine();

            // Entry all user input into journal.
            journal.AddEntry($"Name: {name}");
            journal.AddEntry($"Age: {age}");
            journal.AddEntry($"Favorite Color: {color}");
            journal.AddEntry($"Favorite Animal: {animal}");
            journal.AddEntry($"Favorite Band: {band}");
            journal.AddEntry($"Favorite Food: {food}");

            System.Console.WriteLine(journal);

            var persistence = new JournalExtendedPersistence();
            // cross platform file path of desktop.
            var pathDirectory = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException();

            var filename = Path.Combine(pathDirectory, "journal.txt");
            // log filename.
            System.Console.WriteLine(filename);

            JournalExtendedPersistence.SaveToFile(journal, filename, true);
        }
    }
    // Journal class is only responsible for journal entries.

    public class Journal
    {
        private readonly List<string> _entries = new List<string>();
        private static int _count = 0;

        public int AddEntry(string text)
        {
            _entries.Add($"{++_count}: {text}");
            return _count;
        }

        public void RemoveEntry(int index)
        {
            _entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join("\n", _entries);
        }
    }

    // JournalExtendedPersistence class is only responsible for saving journal entries to file.
    public class JournalExtendedPersistence
    {
        public static void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
}