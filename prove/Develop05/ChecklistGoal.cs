public class ChecklistGoal : Goal
{
    private int _BonusReward_na;
    private int _TargetCompletions_na;
    private int _NumberOfCompletions_na;
    public ChecklistGoal(string name_na, string descr_na, int reward_na, int target_na, int bonusReward_na) : base(name_na, descr_na, reward_na)
    {
        _BonusReward_na = bonusReward_na;
        _TargetCompletions_na = target_na;
        _NumberOfCompletions_na = 0;
    }
    public override string Display(bool Long_na)
    {
        if (Long_na)
        {
            if (_TargetCompletions_na <= _NumberOfCompletions_na)
            {
                return $" [X] {GetName()} ({GetDescription()}) -- Currently completed: {_NumberOfCompletions_na}/{_TargetCompletions_na}";
            }
            else
            {
                return $" [ ] {GetName()} ({GetDescription()}) -- Currently completed: {_NumberOfCompletions_na}/{_TargetCompletions_na}";
            }
        }
        else
        {
            return $" {GetName()}";
        }
    }
    public override int RecordEvent()
    {
        _NumberOfCompletions_na += 1;
        if (_NumberOfCompletions_na == _TargetCompletions_na)
        {
            return AddPoints() + _BonusReward_na;
        }
        else
        {
            return AddPoints();
        }
    }
    public override string ToCSVRecord()
    {
        return $"ChecklistGoal,{GetName()},{GetDescription()},{AddPoints()},{_BonusReward_na},{_TargetCompletions_na},{_NumberOfCompletions_na}";
    }
}