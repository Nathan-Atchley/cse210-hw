// Nathan Atchley
// 6/9/2026
// Used information learned in class and listed in the assignment page.
// Used Gemini to look over the program and to suggest additions.
// https://gemini.google.com/share/ecce5241a45c
public class Reflection : Activity
{
    private List<string> _questions_na;
    private List<int> _questionsIndexesUsed_na;
    private List<string> _prompts_na;
    private List<int> _promptsIndexesUsed_na;
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
            if (_promptsIndexesUsed_na.Count() == _prompts_na.Count())
            {
                _promptsIndexesUsed_na.Clear();
            }
        }
        Console.WriteLine($" --- {_prompts_na[PromptIndex_na]} --- \n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }
    public void PrintRandQuestion()
    {
        bool RandomFlag_na = true;
        int QuestionIndex_na = 0;
        while (RandomFlag_na)
        {
            QuestionIndex_na = _random_na.Next(_questions_na.Count());
            if (!_questionsIndexesUsed_na.Contains(QuestionIndex_na))
            {
                _questionsIndexesUsed_na.Add(QuestionIndex_na);
                RandomFlag_na = false;
            }
            if (_questionsIndexesUsed_na.Count() == _questions_na.Count())
            {
                _questionsIndexesUsed_na.Clear();
            }
        }
        Console.WriteLine($"> {_questions_na[QuestionIndex_na]}");
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