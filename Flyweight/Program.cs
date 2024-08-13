namespace Flyweight;

class Program
{
    static void Main(string[] args)
    {
        var factory = new CharacterFactory();

        var character1 = factory.GetCharacter('A');
        character1.Display("Arial", 12, "Red");

        var character2 = factory.GetCharacter('B');
        character2.Display("Times New Roman", 14, "Blue");

        var character3 = factory.GetCharacter('A');
        character3.Display("Arial", 12, "Red");
        
        var character4 = factory.GetCharacter('B');
        character4.Display("Times New Roman", 14, "Blue");
        
        var character5 = factory.GetCharacter('C');
        character5.Display("Arial", 12, "Red");
        
        Console.WriteLine(factory.GetCharacter('A') == factory.GetCharacter('B')); // False
        
        Console.WriteLine(factory.GetCharacter('A') == factory.GetCharacter('A')); // True
    }
}

public interface ICharacter
{
    void Display(string font, int size, string color);
}

public class Character : ICharacter
{
    private char _character;

    public Character(char character)
    {
        _character = character;
    }

    public void Display(string font, int size, string color)
    {
        Console.WriteLine($"Character: {_character}, Font: {font}, Size: {size}, Color: {color}");
    }
}

public class CharacterFactory
{
    private Dictionary<char, ICharacter> _characters = new Dictionary<char, ICharacter>();

    public ICharacter GetCharacter(char character)
    {
        if (!_characters.ContainsKey(character))
        {
            _characters[character] = new Character(character);
        }

        return _characters[character];
    }
}