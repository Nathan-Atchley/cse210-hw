using System;

class Program
{
    static void Main(string[] args)
    {
        //Program mostly written from what we learned/ talked about in class
        //Everything else is marked in line of where I got it from
        Console.Clear();
        Console.WriteLine("Welcome to your personal scripture memorizer assistant.");
        // I was trying to get a scripture selection thing going, but ran out of time.
        // List<string[]> verses = GrabInput.CSV("book_of_mormon_references.csv");
        int userChoice_na = GrabInput.Int("How many words would you like to hide at a time? ");
        Scripture scripture = new Scripture("Joshua 1:9", "Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the LORD thy God is with thee whithersoever thou goest.");
        Console.WriteLine("Here is your scripture to memorize. Hit enter to hide more words or type quit to exit.");
        bool whileFlag = true;
        bool warning_na = false;
        while (scripture.getIsNotAllHidden() && whileFlag)
        {
            if (warning_na)
            {
                Console.WriteLine("Please hit enter to hide more words or type quit to exit");
                Console.WriteLine("");
                warning_na = false;
            }
            Console.WriteLine(scripture.toString());
            string userInput_na = Console.ReadLine();
            if (userInput_na == "")
            {
                scripture.hideWords(userChoice_na);
            }
            else if (userInput_na == "quit")
            {
                whileFlag = false;
            }
            else
            {
                warning_na = true;
            }
            Console.Clear();
        }
        if (whileFlag)
        {
            Console.WriteLine(scripture.toString());
            string userInput_na = Console.ReadLine();
        }
    }
}