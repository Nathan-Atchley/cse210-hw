public class EternalGoal : Goal
{
    public EternalGoal(string name_na, string descr_na, int reward_na) : base(name_na, descr_na, reward_na){}

    public override string Display(bool Long_na)
    {
        if (Long_na)
        {
            return $" [ ] {GetName()} ({GetDescription()})";
        }
        else
        {
            return $" {GetName()}";
        }
    }
    public override int RecordEvent()
    {
        return AddPoints();
    }

    public override string ToCSVRecord()
    {
        return $"EternalGoal,{GetName()},{GetDescription()},{AddPoints()}";
    }
}