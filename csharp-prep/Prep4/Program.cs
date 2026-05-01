using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        List<int> na_numbers = na_getList();
        //The following orderBy was assisted by gemini Ai
        List<int> sortedNumbers = na_numbers.OrderBy(n => n).ToList();
        int na_listSum = na_numbers.Sum();
        double na_listAvg = na_numbers.Average();
        int na_listMax = na_numbers.Max();
        int na_listMinPositive = na_getSmallestPositive(na_numbers);
        Console.WriteLine($"The sum is: {na_listSum}");
        Console.WriteLine($"The average is: {na_listAvg}");
        Console.WriteLine($"The largest number is: {na_listMax}");
        Console.WriteLine($"The smallest positive number is: {na_listMinPositive}");
        na_printList(sortedNumbers);
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

    static List<int> na_getList()
    {
        List<int> numbers = new List<int>();
        int na_number;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            na_number = na_getUserInputNumber("Please enter a number: ");
            if (na_number != 0)
            {
                numbers.Add(na_number);
            }
        } while (na_number != 0);

        return numbers;
    }

    static int na_getSmallestPositive(List<int> na_numbers)
    {
        List<int> na_modifiedNumbers = new List<int>();
        foreach (var item in na_numbers)
        {
            if (item > 0)
            {
                na_modifiedNumbers.Add(item);
            }
        }
        int na_min = na_modifiedNumbers.Min();
        return na_min;
    }

    static void na_printList(List<int> na_numbers)
    {
        Console.WriteLine("The sorted list is: ");
        for (int i = 0; i < na_numbers.Count; i++)
        {
            Console.WriteLine(na_numbers[i]);
        }
    }
}