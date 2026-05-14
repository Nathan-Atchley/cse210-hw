using System;
using System.IO;

class Program
{
    //Nathan Atchley
    //Got most from myself
    //The load and save to a file from the reading
    //Prompts and some suggestions from Gemini AI marked in code
    static void Main(string[] args)
    {
        Console.Write("Hello! What is your name? ");
        string na_userName = Console.ReadLine();
        na_Journal journal = new na_Journal(na_userName);
        bool na_menuFlag = true;
        while (na_menuFlag)
        {
            Console.WriteLine("");
            Console.Write($"Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Journal Statistics\n6. Quit\nWhat would you like to do? ");
            //Tryparse suggested and explained by gemini
            if (int.TryParse(Console.ReadLine(), out int na_menuChoice))
            {
                if (na_menuChoice == 1)
                {
                    journal.na_AddEntry();
                }
                else if (na_menuChoice == 2)
                {
                    journal.na_DisplayAll();
                }
                else if (na_menuChoice == 3)
                {
                    journal.na_LoadFromCSV();
                }
                else if (na_menuChoice == 4)
                {
                    journal.na_SaveToCSV();
                }
                else if (na_menuChoice == 5)
                {
                    journal.na_journalStatistics();
                }
                else if (na_menuChoice == 6)
                {
                    na_menuFlag = false;
                }
            }
            else
            {
                Console.WriteLine("That is not one of the menu options.\nPlease enter an integer");
            }
            
            
        }
    }
}