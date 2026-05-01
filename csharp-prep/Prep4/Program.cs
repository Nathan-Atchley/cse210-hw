using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = na_getList();
        int na_listSum = numbers.Sum();
        double na_listAvg = numbers.Average();
        int na_listMax = numbers.Max();
        int na_listMinPositive = na_getSmallestPositive(numbers);
        Console.WriteLine($"The sum is: {na_listSum}");
        Console.WriteLine($"The average is: {na_listAvg}");
        Console.WriteLine($"The largest number is: {na_listMax}");
        Console.WriteLine($"The smallest positive number is: {na_listMinPositive}");
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
}