public class Reflection : Activity
{
    private List<string> _questions_na;
    private List<string> _prompts_na;
    private Random _random_na;
    
    public Reflection() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _questions_na = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        _prompts_na = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _random_na = new Random();
    }

    public void PrintRandPrompt()
    {
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {_prompts_na[_random_na.Next(_prompts_na.Count())]} --- \n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }
    public void PrintRandQuestion()
    {
        Console.WriteLine($"> {_questions_na[_random_na.Next(_questions_na.Count())]}");
    }
    public void ReflectActivity()
    {
        Console.Clear();
        StartMessage();
        Console.Clear();
        GetReady(3);
        PrintRandPrompt();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        Countdown(5);
        Console.Clear();
        DateTime StartTime_na = DateTime.Now; 
        SetEndTime(StartTime_na);
        while (StartTime_na < GetEndTime())
        {
            PrintRandQuestion();
            Spinner(8);
            StartTime_na = DateTime.Now;
        }
        EndMessage();
    }
}