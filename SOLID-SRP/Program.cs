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

Console.WriteLine(journal);

// cross platform file path of desktop.
var pathDirectory = Path.GetDirectoryName(
    System.Reflection.Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException();

var filename = Path.Combine(pathDirectory, "journal.txt");

// log filename.
Console.WriteLine(filename);

JournalExtendedPersistence.SaveToFile(journal, filename, true);