namespace FinalProject;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
using FinalProject.data;
using System;


// Used Gemini AI to help understand how API calls work and
// how auto getters and setters work
// https://share.gemini.google/IoKgX1VARZPr
class Program
{
    static async Task Main(string[] args)
    {
        DataStorage allData_na = new DataStorage();
        allData_na.loadAllData();
        Character player_na = await ViewPrint.MakeCharacter(allData_na);
        ViewPrint.PrintCharacter(player_na);
    }

    
}