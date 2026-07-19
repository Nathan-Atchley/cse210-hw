namespace FinalProject.CharacterData;
public class Destiny : CharacterFeature
{
    public string FlavorText_na { get; set; }
    public List<string> BonusSkills_na { get; set; }
    public string BonusProficiency_na { get; set; }
    public string Lv5FeatureName_na { get; set; }
    public string Lv5FeatureDesc_na { get; set; }
    public string Lv15FeatureName_na { get; set; }
    public string Lv15FeatureDesc_na { get; set; }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public List<MythicalPatronOption>? PatronOptions_na { get; private set; }
    public string? PatronChoice_na { get; private set;}
    public List<string> ChosenSkills_na { get ; private set ;}

    public Destiny( string name_na, string description_na, string flavorText_na, List<string> bonusSkills_na, string bonusProficiency_na, string lv5FeatureName_na, string lv5FeatureDesc_na, string lv15FeatureName_na, string lv15FeatureDesc_na, List<string> chosenSkills_na, List<MythicalPatronOption>? patronOptions_na = null, string? patronChoice_na = null, int prerequisites_na = 5) : base(name_na, description_na, prerequisites_na)
    {
        FlavorText_na = flavorText_na;
        BonusSkills_na = bonusSkills_na ?? new List<string>();
        BonusProficiency_na = bonusProficiency_na;
        Lv5FeatureName_na = lv5FeatureName_na;
        Lv5FeatureDesc_na = lv5FeatureDesc_na;
        Lv15FeatureName_na = lv15FeatureName_na;
        Lv15FeatureDesc_na = lv15FeatureDesc_na;
        PatronOptions_na = patronOptions_na;
        PatronChoice_na = patronChoice_na;
        ChosenSkills_na = chosenSkills_na;
    }

    public override void ApplyToCharacter(Character player_na)
    {
        player_na.AddProficiency(BonusProficiency_na);
        if (ChosenSkills_na.Count() == 1)
        {
            player_na.Skills_na.SetValue(ChosenSkills_na[0], player_na.Skills_na.GetValue(ChosenSkills_na[0]) + 10);
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                player_na.Skills_na.SetValue(ChosenSkills_na[i], player_na.Skills_na.GetValue(ChosenSkills_na[i]) + 5);
            }
        }
    }

    public void SetDestinyPatron(string patronChoice_na)
    {
        PatronChoice_na = patronChoice_na;

        if (PatronOptions_na != null)
        {
            var matchedOption_na = PatronOptions_na.Find(option_na =>
                option_na.Pokemon_na != null &&
                option_na.Pokemon_na.Contains(patronChoice_na, StringComparer.OrdinalIgnoreCase)
            );
            if (matchedOption_na != null)
            {
                Lv5FeatureDesc_na = $"{Lv5FeatureDesc_na}\n{patronChoice_na}: {matchedOption_na.Effect_na}";
            }
        }
    }
}