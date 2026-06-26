using System.Reflection.Metadata;

public class Holder
{
    private List<Goal> _UserGoals_na;
    private List<Reward> _UserRewards_na;
    private int _Score_na;

    public Holder() {
        _UserGoals_na = new List<Goal>();
        _UserRewards_na = new List<Reward>();
        _Score_na = 0;
    }
    public int GetScore()
    {
        return _Score_na;
    }
    public string DisplayGoals(bool Long_na)
    {
        int count_na = 0;
        string return_val_na = "";
        foreach (Goal goal in _UserGoals_na)
        {
            count_na += 1;
            return_val_na += $"{count_na}." + goal.Display(Long_na) + $"\n";
        }
        return return_val_na;
    }
    public string DisplayReward(int index_na)
    {
        return _UserRewards_na[index_na].Display(false);
    }

    public string DisplayRewards(bool Long_na)
    {
        int count_na = 0;
        string return_val_na = "";
        foreach (Reward reward in _UserRewards_na)
        {
            count_na += 1;
            return_val_na += $"{count_na}." + reward.Display(Long_na) + $"\n";
        }
        return return_val_na;
    }

    public void CreateSimpleGoal(string name_na, string descr_na, int reward_na)
    {
        Goal goal = new SimpleGoal(name_na, descr_na, reward_na);
        _UserGoals_na.Add(goal);
    }
    public void CreateEternalGoal(string name_na, string descr_na, int reward_na)
    {
        Goal goal = new EternalGoal(name_na, descr_na, reward_na);
        _UserGoals_na.Add(goal);
    }
    public void CreateChecklistGoal(string name_na, string descr_na, int reward_na, int target_na, int bonusReward_na)
    {
        Goal goal = new ChecklistGoal(name_na, descr_na, reward_na, target_na, bonusReward_na);
        _UserGoals_na.Add(goal);
    }
    public void CreateReward(string name_na, string descr_na, int cost_na)
    {
        Reward reward = new Reward(name_na, descr_na, cost_na);
        _UserRewards_na.Add(reward);
    }

    public string RecordEvent(int index_na)
    {
        _Score_na += _UserGoals_na[index_na].RecordEvent();
        return $"Congratulations! You have earned {_UserGoals_na[index_na].AddPoints()} points!\nYou now have {_Score_na} points.\n";
    }
    public string BuyReward(int index_na)
    {
        _Score_na -= _UserRewards_na[index_na].BuyReward();
        return $"Nice Work! You just spent {_UserRewards_na[index_na].BuyReward()} points on a {_UserRewards_na[index_na].Display(false)}.";
    }
    public bool CanPurchaseReward(int index)
    {
        if (_UserRewards_na[index].BuyReward() < _Score_na)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Save(string filename_na)
    {
        // Was assisted by Gemini AI to get this working properly
        using (StreamWriter writer = new StreamWriter(filename_na))
        {
            writer.WriteLine(_Score_na);

            foreach (Goal goal in _UserGoals_na)
            {
                writer.WriteLine(goal.ToCSVRecord());
            }

            foreach (Reward reward in _UserRewards_na)
            {
                writer.WriteLine(reward.ToCSVRecord());
            }
        }
        Console.WriteLine("Progress saved successfully!");
    }
    public void Load(string filename_na)
    {
        List<string[]> data_na = GrabInput.CSV(filename_na, false);
        _UserGoals_na.Clear();

        string[] scoreRow_na = data_na[0];
        _Score_na = int.Parse(scoreRow_na[0]);

        for (int i = 1; i < data_na.Count; i++)
        {
            string[] row_na = data_na[i];
            string type_na = row_na[0];
            string name_na = row_na[1];
            string descr_na = row_na[2];
            int points_na = int.Parse(row_na[3]);

            if (type_na == "SimpleGoal")
            {
                SimpleGoal simple_na = new SimpleGoal(name_na, descr_na, points_na);
                if (bool.Parse(row_na[4]))
                {
                    simple_na.RecordEvent();
                }
                _UserGoals_na.Add(simple_na);
            }
            else if (type_na == "EternalGoal")
            {
                EternalGoal eternal_na = new EternalGoal(name_na, descr_na, points_na);
                _UserGoals_na.Add(eternal_na);
            }
            else if (type_na == "ChecklistGoal")
            {
                int bonusReward_na = int.Parse(row_na[4]);
                int targetCompletions_na = int.Parse(row_na[5]);
                int numberOfCompletions_na = int.Parse(row_na[6]);

                ChecklistGoal checklist_na = new ChecklistGoal(name_na, descr_na, points_na, targetCompletions_na, bonusReward_na);
                
                for (int x = 0; x < numberOfCompletions_na; x++)
                {
                    checklist_na.RecordEvent();
                }
                _UserGoals_na.Add(checklist_na);
            }
            else if (type_na == "Reward")
            {
                Reward reward = new Reward(name_na, descr_na, points_na);
                _UserRewards_na.Add(reward);
            }
        }
        Console.WriteLine("Goals loaded successfully!\n");
    }

}