using System;

class Program
{
    static void Main(string[] args)
    {
        na_displayWelcome();
        string na_userName = na_promptUserName();
        int na_userNumber = na_promptUserNumber();
        int na_userBirthYear;
        na_promptUserBirthYear(out na_userBirthYear);
        int na_squaredNumber = na_squareNumber(na_userNumber);
        na_displayResult(na_userName, na_userBirthYear, na_squaredNumber);
    }

    static void na_displayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string na_promptUserName()
    {
        string na_userName = na_getUserInput("Please enter your name: ");
        return na_userName;
    }

    static int na_promptUserNumber()
    {
        int na_userNumber = na_getUserInputNumber("PLease enter your favorite number: ");
        return na_userNumber;
    }

    static void na_promptUserBirthYear(out int na_userBirthYear)
    {
        na_userBirthYear = na_getUserInputNumber("Please enter the year you were born: ");
    }

    static int na_squareNumber(int num)
    {
        int na_square = num * num;
        return na_square;
    }

    static void na_displayResult(string na_userName, int na_userBirthYear, int na_squaredNumber)
    {
        //This was given to me by gemini
        int currentYear = DateTime.Today.Year;
        int age = currentYear - na_userBirthYear;
        Console.WriteLine($"{na_userName}, the square of your number is {na_squaredNumber}");
        Console.WriteLine($"{na_userName}, you will turn {age} this year.");
    }


    static int na_getUserInputNumber(string na_prompt)
    {
        int na_returnValue = 0;
        bool na_flag = true;
        while (na_flag)
        {
            try
            {
                Console.Write(na_prompt);
                na_returnValue = int.Parse(Console.ReadLine());
                na_flag = false;
            } 
            catch
            {
                Console.WriteLine("Invalid input please enter a number.");
            }
        }
        
        return na_returnValue;
    }

    static string na_getUserInput(string prompt)
    {
        Console.Write(prompt);
        string na_returnString = Console.ReadLine();
        return na_returnString;
    }

}