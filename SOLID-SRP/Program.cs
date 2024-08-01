using System.Reflection;
using SOLID_SRP;

var journal = new Journal();
// Get user input in the console.
Console.WriteLine("What is your name?");
var name = Console.ReadLine();

Console.WriteLine($"Hello {name}!");
Console.WriteLine("What is your age?");

var age = Console.ReadLine();
Console.WriteLine($"You are {age} years old.");
Console.WriteLine("What is your favorite color?");

var color = Console.ReadLine();
Console.WriteLine($"Your favorite color is {color}.");
Console.WriteLine("What is your favorite animal?");

var animal = Console.ReadLine();
Console.WriteLine($"Your favorite animal is {animal}.");
Console.WriteLine("What is your favorite band?");

var band = Console.ReadLine();
Console.WriteLine($"Your favorite band is {band}.");
Console.WriteLine("What is your favorite food?");

var food = Console.ReadLine();

// Entry all user input into a journal.
journal.AddEntry($"Name: {name}");
journal.AddEntry($"Age: {age}");
journal.AddEntry($"Favorite Color: {color}");
journal.AddEntry($"Favorite Animal: {animal}");
journal.AddEntry($"Favorite Band: {band}");
journal.AddEntry($"Favorite Food: {food}");

Console.WriteLine(journal);

// cross-platform file path of desktop.
var pathDirectory = Path.GetDirectoryName(
    Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException();

var filename = Path.Combine(pathDirectory, "journal.txt");

// log filename.
Console.WriteLine(filename);

JournalExtendedPersistence.SaveToFile(journal, filename, true);