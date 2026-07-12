namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public class SkillSheet : AttributeGroup
{
    public SkillSheet(int Athletics_na = 15, int Craft_na = 15, int Endurance_na = 15, int Finesse_na = 15, int Medicine_na = 15, int Perception_na = 15, int Performance_na = 15, int Persuasion_na = 15, int SpKnowledge_na = 15, int Stealth_na = 15, int Survival_na = 15) : base()
    {
        SetValue("Athletics", Athletics_na);
        SetValue("Craft", Craft_na);
        SetValue("Endurance", Endurance_na);
        SetValue("Finesse", Finesse_na);
        SetValue("Medicine", Medicine_na);
        SetValue("Perception", Perception_na);
        SetValue("Performance", Performance_na);
        SetValue("Persuasion", Persuasion_na);
        SetValue("Special Knowledge", SpKnowledge_na);
        SetValue("Stealth", Stealth_na);
        SetValue("Survival", Survival_na);
    }
}