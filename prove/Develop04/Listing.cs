// Nathan Atchley
// 6/9/2026
// Used information learned in class and listed in the assignment page.
// Used Gemini to look over the program and to suggest additions.
// https://gemini.google.com/share/ecce5241a45c
public class Listing : Activity
{
    private List<string> _prompts_na;
    private List<int> _promptsIndexesUsed_na;
    private List<string> _responses_na;
    private List<int> _responsesIndexesUsed_na;
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
        bool RandomFlag_na = true;
        int PromptIndex_na = 0;
        while (RandomFlag_na)
        {
            PromptIndex_na = _random_na.Next(_prompts_na.Count());
            if (!_promptsIndexesUsed_na.Contains(PromptIndex_na))
            {
                _promptsIndexesUsed_na.Add(PromptIndex_na);
                RandomFlag_na = false;
            }
            if (_promptsIndexesUsed_na.Count == _prompts_na.Count())
            {
                _promptsIndexesUsed_na.Clear();
            }
        }
        Console.WriteLine($" --- {_prompts_na[PromptIndex_na]} --- ");
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