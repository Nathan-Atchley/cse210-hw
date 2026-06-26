using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using CsvHelper;

public abstract class Goal
{
    private string _Name_na;
    private string _Description_na;
    private int _Reward_na;

    protected Goal(string name_na, string descr_na, int reward_na)
    {
        _Name_na = name_na;
        _Description_na = descr_na;
        _Reward_na = reward_na;
    }
    public string GetName()
    {
        return _Name_na;
    }
    public string GetDescription()
    {
        return _Description_na;
    }
    public int AddPoints()
    {
        return _Reward_na;
    }
    public static int AddPoints(int points)
    {
        return points;
    }

    public virtual string ToCSVRecord()
    {
        return "";
    }
    public virtual string Display(bool Long)
    {
        return "";
    }

    public virtual int RecordEvent()
    {
        return 0;
    }
}