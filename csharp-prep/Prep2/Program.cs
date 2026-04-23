using System;

class Program
{
    static void Main(string[] args)
    {
        int na_gradePercent = na_getGradePercent();
        string na_gradeLetter = na_getGradeLetter(na_gradePercent);
        na_printGradeLetter(na_gradeLetter);
        bool na_passOrFail = na_checkPassOrFail(na_gradePercent);
        na_printAffirmation(na_passOrFail);
    }

    static int na_getGradePercent()
    {
        int na_gradePercent = na_getUserInputNumber("What grade did you get? ");
        return na_gradePercent;
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

    static string na_getGradeLetter(int na_gradePercent)
    {
        string na_gradeLetter = "E";
        if (na_gradePercent > 90) {
            na_gradeLetter = "A";
        } else if (na_gradePercent > 80) {
            na_gradeLetter = "B";
        } else if (na_gradePercent > 70) {
            na_gradeLetter = "C";
        } else if (na_gradePercent > 60) {
            na_gradeLetter = "D";
        } else {
            na_gradeLetter = "F";
        }

        return na_gradeLetter;
    }

    static bool na_checkPassOrFail(int na_gradePercent)
    {
        bool na_returnVal = false;
        if (na_gradePercent > 70)
        {
            na_returnVal = true;
        }
        return na_returnVal;
    }

    static void na_printGradeLetter(string na_gradeLetter)
    {
        Console.WriteLine($"You got a {na_gradeLetter}!");
    }

    static void na_printAffirmation(bool na_passOrFail)
    {
        if (na_passOrFail)
        {
            Console.WriteLine("Congratulations!!! You passed!!");
        }
        else
        {
            Console.WriteLine("Sorry, better luck next time.");
        }
    }


}