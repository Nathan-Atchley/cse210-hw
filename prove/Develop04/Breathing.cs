// Nathan Atchley
// 6/9/2026
// Used information learned in class and listed in the assignment page.
// Used Gemini to look over the program and to suggest additions.
// https://gemini.google.com/share/ecce5241a45c
public class Breathing : Activity
{
    public Breathing() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public static void Breath(int breathDuration_na)
    {
        Console.Write("Breath in...");
        Countdown(breathDuration_na);
        Console.Write("\nNow breathe out...");
        Countdown(breathDuration_na + 2);
        Console.WriteLine("\n");
    }
    public void BreathActivity()
    {
        Console.Clear();
        StartMessage();
        Console.Clear();
        GetReady(3);
        DateTime StartTime_na =  DateTime.Now;
        SetEndTime(StartTime_na);

        Breath(2);
        StartTime_na = DateTime.Now;
        while (StartTime_na < GetEndTime())
        {
            Breath(4);
            StartTime_na = DateTime.Now;
        }
        
        EndMessage();
    }
}