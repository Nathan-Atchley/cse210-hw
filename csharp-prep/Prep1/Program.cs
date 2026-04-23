using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        //Primarily used content from prepare materials and class. Asked Gemini to help find an error.
        string na_firstName = na_getFirstName();
        string na_lastName = na_getLastName();
        na_printName(na_firstName, na_lastName);
    }

    static string na_getUserInput(string prompt)
    {
        Console.Write(prompt);
        string na_returnString = Console.ReadLine();
        return na_returnString;
    }

    static string na_getFirstName()
    {
        string na_prompt = "What is your first name? ";
        string na_FirstName = na_getUserInput(na_prompt);
        return na_FirstName;
    }

    static string na_getLastName()
    {
        string na_prompt = "What is your last name? ";
        string na_LastName = na_getUserInput(na_prompt);
        return na_LastName;
    }

    static void na_printName(string na_firstName, string na_lastName)
    {
        Console.WriteLine("");
        Console.WriteLine($"Your name is {na_lastName}, {na_firstName} {na_lastName}");
    }
}