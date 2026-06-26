using System;

class Program
{
    static void Main(string[] args)
    {
        Holder holder_na = new Holder();
        bool menuFlag_na = true;
        while (menuFlag_na)
        {
            Console.WriteLine(
                $"You have {holder_na.GetScore()} points.\n\n" +
                "Menu Options:\n" +
                "  1. Create New Goal\n" +
                "  2. List Goals\n" +
                "  3. Save\n" +
                "  4. Load\n" +
                "  5. Record Event\n" +
                "  6. Create Reward\n" +
                "  7. List Rewards\n" +
                "  8. Buy Reward\n" +
                "  9. Quit\n"
            );
            int userChoice_na = GrabInput.Int("Select a choice from the menu: ");
            if (userChoice_na == 1)
            {
                Console.WriteLine(
                    "The types of Goals are:\n" +
                    "  1. Simple Goal\n" +
                    "  2. Eternal Goal\n" +
                    "  3. Checklist Goal\n"
                );
                int userGoalChoice_na = GrabInput.Int("Which type of goal would you like to create? ");
                string userGoalName_na = GrabInput.String("What is the name of your goal? ");
                string userGoalDescr_na = GrabInput.String("What is a short description of it? ");
                int userGoalPoints_na = GrabInput.Int("What is the amount of points associated with this goal? ");
                
                if (userGoalChoice_na == 1)
                {
                    holder_na.CreateSimpleGoal(userGoalName_na, userGoalDescr_na, userGoalPoints_na);
                }
                else if (userGoalChoice_na == 2)
                {
                    holder_na.CreateEternalGoal(userGoalName_na, userGoalDescr_na, userGoalPoints_na);
                }
                else if (userGoalChoice_na == 3)
                {
                    int userChecklistGoalCount_na = GrabInput.Int("How many times does this goal need to be accomplished for a bonus? ");
                    int userChecklistGoalBonus_na = GrabInput.Int("How many bonus points to award for accomplishing it that many times? ");
                    holder_na.CreateChecklistGoal(userGoalName_na, userGoalDescr_na, userGoalPoints_na, userChecklistGoalCount_na, userChecklistGoalBonus_na);
                }
            }
            else if (userChoice_na == 2)
            {
                Console.WriteLine(holder_na.DisplayGoals(true));
            }
            else if (userChoice_na == 3)
            {
                string filename_na = GrabInput.String("What would you like to call the file? ");
                holder_na.Save(filename_na);
            }
            else if (userChoice_na == 4)
            {
                string filename_na = GrabInput.String("What is the filename? ");
                holder_na.Load(filename_na);
            }
            else if (userChoice_na == 5)
            {
                Console.WriteLine(holder_na.DisplayGoals(false));
                int index = GrabInput.Int("Which goal did you accomplish? ") - 1;
                holder_na.RecordEvent(index);
            }
            else if (userChoice_na == 6)
            {
                string userRewardName_na = GrabInput.String("What is the name of your reward? ");
                string userRewardDescr_na = GrabInput.String("What is a short description of it? ");
                int userRewardCost_na = GrabInput.Int("What is the amount of points that this reward should cost? ");
                holder_na.CreateReward(userRewardName_na, userRewardDescr_na, userRewardCost_na);
            }
            else if (userChoice_na == 7)
            {
                Console.WriteLine(holder_na.DisplayRewards(true));
            }
            else if (userChoice_na == 8)
            {
                Console.WriteLine(holder_na.DisplayRewards(false));
                int index = GrabInput.Int("Which reward would you like to purchase? ") - 1;
                if (holder_na.CanPurchaseReward(index))
                {
                    Console.WriteLine(holder_na.BuyReward(index));
                }
                else
                {
                    Console.WriteLine("Sorry you don't have enough points to purchase ");
                }
            }
            else if (userChoice_na == 9)
            {
                menuFlag_na = false;
            }
        }
    }
}