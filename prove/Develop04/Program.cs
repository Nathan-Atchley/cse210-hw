using System;
// Nathan Atchley
// 6/9/2026
// Used information learned in class and listed in the assignment page.
// Used Gemini to look over the program and to suggest additions.
// https://gemini.google.com/share/ecce5241a45c

class Program
{
    static void Main(string[] args)
    {
        Breathing breathing = new Breathing();
        Reflection reflection = new Reflection();
        Listing listing = new Listing();

        bool MenuFlag_na = true;
        string error_na = "";
        while (MenuFlag_na)
        {
            Console.Clear();
            Console.Write(error_na);
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            int UserResponse_na = GrabInput.Int("Select a choice from the menu: ");
            if (UserResponse_na == 1)
            {
                breathing.BreathActivity();
            }
            else if (UserResponse_na == 2)
            {
                reflection.ReflectActivity();
            }
            else if (UserResponse_na == 3)
            {
                listing.ListingActivity();
            }
            else if (UserResponse_na == 4)
            {
                MenuFlag_na = false;
            }
            else
            {
                error_na = "Invalid entry, please choose one of the options.\n\n";
            }
        }
    }
}