// Nathan Atchley
// 6/9/2026
// Used information learned in class and listed in the assignment page.
// Used Gemini to look over the program and to suggest additions.
// https://gemini.google.com/share/ecce5241a45c
public class Activity
{
    private int _duration_na;
    private string _name_na;
    private DateTime _endTime_na;
    private string _description_na;

    protected Activity(string name, string description)
    {
        _name_na = name;
        _description_na = description;
    }

    public static void Spinner(int spinDuration_na)
    {
        List<Char> spinnerChars = new List<char> {'|','/','-','\\'};
        DateTime currTime_na = DateTime.Now;
        DateTime endTime_na = currTime_na.AddSeconds(spinDuration_na);
        int spinnerCharsIndex = 0;
        while (currTime_na < endTime_na)
        {
            Console.Write(spinnerChars[spinnerCharsIndex % spinnerChars.Count]);
            Thread.Sleep(180);
            Console.Write("\b \b");
            spinnerCharsIndex += 1;
            currTime_na = DateTime.Now;
        }
    }

    public static void Countdown(int countDuration_na)
    {  
        for (int x = countDuration_na; x > 0; x--)
        {
            Console.Write(x);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public static void GetReady(int spinDuration_na)
    {
        Console.WriteLine("Get ready...");
        Spinner(spinDuration_na);
        Console.WriteLine("");
    }


    public DateTime GetEndTime()
    {
        return _endTime_na;
    }

    public void SetEndTime(DateTime start_na)
    {
        _endTime_na = start_na.AddSeconds(_duration_na);
    }

    public void StartMessage()
    {
        Console.WriteLine($"Welcome to the {_name_na} Activity.");
        Console.WriteLine("");
        Console.WriteLine($"{_description_na}\n");
        HowLong();
    }

    public void HowLong()
    {
        int duration_na = GrabInput.Int("How long, in seconds, would you like for your session? ");
        _duration_na = duration_na;
    }

    public void EndMessage()
    {
        Console.WriteLine("Well done!!");
        Spinner(4);
        Console.WriteLine("");
        Console.WriteLine($"You have completed another {_duration_na} seconds of the {_name_na} Activity.");
        Spinner(4);
    }
}