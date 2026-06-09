using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
//Make sure to run this command in each new project when you copy it over:
//dotnet add package CsvHelper --version 33.1.0

public static class GrabInput
{
    public static List<String[]> CSV(string filename)
    {
        List<string[]> data = new List<string[]>();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not Found");
            return data;
        }

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };

        using (var reader = new StreamReader(filename))
        using (var csv = new CsvReader(reader, config))
        {
            while (csv.Read())
            {
                string[] row = csv.Context.Parser.Record;
                data.Add(row);
            }
        }
        
        return data;
    }
    public static float Float(string prompt)
    {
        float na_returnValue = 0;
        bool na_flag = true;
        while (na_flag)
        {
            if (float.TryParse(String(prompt), out float result))
            {
                na_returnValue = result;
                na_flag = false;
            }
            else
            {
                Console.WriteLine("Invalid input please enter a number.");
            }
        }
        
        return na_returnValue;
    }
    public static int Int(string prompt)
    {
        int na_returnValue = 0;
        bool na_flag = true;
        while (na_flag)
        {
            if (int.TryParse(String(prompt), out int result))
            {
                na_returnValue = result;
                na_flag = false;
            }
            else
            {
                Console.WriteLine("Invalid input please enter a number.");
            }
        }
        return na_returnValue;
    }

    public static string String(string prompt)
    {
        Console.Write(prompt);
        string na_returnString = Console.ReadLine();
        return na_returnString;
    }
}