public class Reward
{
    private string _Name_na;
    private string _Description_na;
    private int _Cost_na;

    public Reward(string name_na, string descr_na, int cost_na)
    {
        _Name_na = name_na;
        _Description_na = descr_na;
        _Cost_na = cost_na;
    }
    public string Display(bool Long_na)
    {
        if (Long_na)
        {
            return $" {_Name_na} - {_Cost_na}pts ({_Description_na})";
        }
        else
        {
            return _Name_na;
        }
    }
    public int BuyReward()
    {
        return _Cost_na;
    }
    public string ToCSVRecord()
    {
        return $"Reward,{_Name_na},{_Description_na},{_Cost_na}";
    }
}