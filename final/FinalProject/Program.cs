namespace FinalProject;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
using FinalProject.data;


// Used Gemini AI to help understand how API calls work and
// how auto getters and setters work
class Program
{
    static async Task Main(string[] args)
    {
        DataStorage allData_na = new DataStorage();
        Character player_na = null;
        bool menuFlag_na = true;

        while (menuFlag_na)
        {
            Console.Clear();
            Console.WriteLine("=== POKEMON TTRPG CHARACTER MANAGER ===");

            if (player_na != null)
            {
                Console.WriteLine($"Active Character: {player_na.CharName_na}");
            }
            else
            {
                Console.WriteLine($"Active Character: None");
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" 1. Create New Character");
            Console.WriteLine(" 2. Display Character Sheet");
            Console.WriteLine(" 3. Add Experience Points");
            Console.WriteLine(" 4. Spend Level Points");
            Console.WriteLine(" 5. Change Moves");
            Console.WriteLine(" 6. Save Current Character");
            Console.WriteLine(" 7. Load Character File");
            Console.WriteLine(" 8. Exit");
            Console.WriteLine("---------------------------------------");

            int choice_na = GrabInput.Int("Select an option (1-7): ");
            Console.WriteLine();

            switch (choice_na)
            {
                case 1:
                    Console.WriteLine("--- Character Creation ---");
                    player_na = await ViewPrint.MakeCharacter(allData_na);
                    Console.WriteLine("\nCharacter successfully created! Press any key to return to menu...");
                    Console.ReadKey();
                    break;

                case 2:
                    if (player_na == null)
                    {
                        Console.WriteLine("No active character loaded. Please create or load a character first.");
                    }
                    else
                    {
                        Console.Clear();
                        ViewPrint.PrintCharacter(player_na);
                    }
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                    break;

                case 3:
                    if (player_na == null)
                    {
                        Console.WriteLine("No active character loaded.");
                    }
                    else
                    {
                        Console.WriteLine($"Current Exp: {player_na.Experience_na} / {player_na.Level_na * 100}");
                        int expAmount_na = GrabInput.Int("Enter amount of EXP to add: ");
                        if (expAmount_na > 0)
                        {
                            int oldLevel_na = player_na.Level_na;
                            UserAssignmentHandler.AddExperience(expAmount_na, player_na, allData_na);
                            
                            Console.WriteLine($"Added {expAmount_na} EXP!");
                            if (player_na.Level_na > oldLevel_na)
                            {
                                Console.WriteLine($"LEVEL UP! You grew from Lv{oldLevel_na} to Lv{player_na.Level_na}!");
                            }
                        }
                    }
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                    break;
                
                case 4:
                    if (player_na == null)
                    {
                        Console.WriteLine("No active character to save.");
                    }
                    else
                    {
                        LevelUpHandler.LevelPointsMenu(player_na, allData_na);
                    }
                    break;

                case 5:
                    player_na.SwapMoves();
                    break;
                    
                case 6:
                    if (player_na == null)
                    {
                        Console.WriteLine("No active character to save.");
                    }
                    else
                    {
                        CharacterSaveManager.SaveCharacter(player_na);
                    }
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                    break;

                case 7:
                    var saveFiles = CharacterSaveManager.GetSaveFiles();
                    if (saveFiles.Count == 0)
                    {
                       Console.WriteLine("No save files found in the 'saves' directory."); 
                    }
                    else
                    {
                        Console.WriteLine("\nSelect a save file to load:");
                        for (int i = 0; i < saveFiles.Count; i++)
                        {
                            Console.WriteLine($" {i + 1}. {Path.GetFileNameWithoutExtension(saveFiles[i])}");
                        }

                        int choice = GrabInput.IntInRange("Enter file number: ", 1, saveFiles.Count);
                        string selectedFile = saveFiles[choice - 1];

                        using IPokeApi pokeApi = new PokeApi();
                        player_na = await CharacterSaveManager.LoadCharacterAsync(selectedFile, allData_na, pokeApi);

                        if (player_na != null)
                        {
                            Console.WriteLine($"\nCharacter '{player_na.CharName_na}' successfully loaded!");
                        }
                    }
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                    break;

                case 8:
                    menuFlag_na = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid selection. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    
}