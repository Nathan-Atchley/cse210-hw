using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        string na_playAgain;
        do
        {
            Random randomGenerator = new Random();
            int na_magicNumber = randomGenerator.Next(1,101);
            int na_userGuess;
            int na_guessCount = 0;
            do
            {
                na_userGuess = na_getUserInputNumber("Guess an integer between 1-100: ");
                na_guessCount++;
                string na_guessOutput = na_numberComparison(na_magicNumber, na_userGuess);
                Console.WriteLine(na_guessOutput);
            } while (na_magicNumber != na_userGuess);

            na_playAgain = na_gameWin(na_guessCount);
        } while (na_playAgain == "yes" || na_playAgain == "Yes");
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

    static string na_numberComparison(int na_magicNumber, int na_userGuess)
    {
        string na_returnVal = "";

        if (na_userGuess > na_magicNumber)
        {
            na_returnVal = "Sorry your guess was too high.";
        } else if (na_userGuess < na_magicNumber)
        {
            na_returnVal = "Sorry your guess was too low.";
        } else
        {
            na_returnVal = "Congrats you guessed the magic Number!!";
        }

        return na_returnVal;
    }

    static string na_gameWin(int na_guessCount)
    {
        Console.WriteLine($"It took you {na_guessCount} guesses to win.");
        Console.Write("Would you like to play again? ");
        string na_playAgain = Console.ReadLine();
        return na_playAgain;
    }
}