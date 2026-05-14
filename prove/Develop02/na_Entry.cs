public class na_Entry
{
    public string na_Prompt { get; set; }
    public string na_Paper { get; set; }
    public string na_Date { get; set; }


    public na_Entry(string na_prompt, string na_paper)
    {
        na_Prompt = na_prompt;
        na_Paper = na_paper;
        DateTime theCurrentTime = DateTime.Now;
        na_Date = theCurrentTime.ToShortDateString();
    }
    public na_Entry(string na_prompt, string na_paper, string na_date)
    {
        na_Prompt = na_prompt;
        na_Paper = na_paper;
        na_Date = na_date;
    }

    public string na_display()
    {
        string na_rValue = $"Date: {na_Date} - Prompt: {na_Prompt}\n{na_Paper}";
        return na_rValue;
    }
}