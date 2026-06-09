public class Listing : Activity
{
    private List<string> _prompts_na;
    private List<string> _responses_na;
    private Random _random_na;

    public Listing() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts_na = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _responses_na = new List<string> {};
        _random_na = new Random();
    }

    public void PrintRandPrompt()
    {
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($" --- {_prompts_na[_random_na.Next(_prompts_na.Count())]} --- ");
        Console.Write("You may begin in: ");
        Countdown(8);
        Console.WriteLine("");
    }
    public void ListingActivity()
    {
        Console.Clear();
        StartMessage();
        Console.Clear();
        GetReady(3);
        PrintRandPrompt();
        DateTime StartTime_na = DateTime.Now; 
        SetEndTime(StartTime_na);
        while (StartTime_na < GetEndTime())
        {
            string UserResponse_na = GrabInput.String("> ");
            _responses_na.Add(UserResponse_na);
            StartTime_na = DateTime.Now;
        }
        Console.WriteLine($"You listed {_responses_na.Count()}!\n");
        EndMessage();
    }
}