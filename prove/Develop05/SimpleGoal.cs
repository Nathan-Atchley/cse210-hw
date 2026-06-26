public class SimpleGoal : Goal
{
    private bool _IsComplete;

    public SimpleGoal(string name_na, string descr_na, int reward_na) : base(name_na, descr_na, reward_na)
    {
        _IsComplete = false;
    }

    public override string Display(bool Long_na)
    {
        if (Long_na)
        {
            if (_IsComplete)
            {
                return $" [X] {GetName()} ({GetDescription()})";
            }
            else
            {
                return $" [ ] {GetName()} ({GetDescription()})";
            }
        }
        else
        {
            return $" {GetName()}";
        }
    }
    public override int RecordEvent()
    {
        _IsComplete = true;
        return AddPoints(AddPoints());
    }
    public override string ToCSVRecord()
    {
        return $"SimpleGoal,{GetName()},{GetDescription()},{AddPoints()},{_IsComplete}";
    }
}