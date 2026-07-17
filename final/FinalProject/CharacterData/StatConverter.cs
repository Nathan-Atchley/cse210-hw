namespace FinalProject.CharacterData;

public static class StatConverter
{
    public static int GetStatBonus(int baseStat_na)
    {
        if (baseStat_na <= 20) return 0;
        if (baseStat_na <= 40) return 1;
        if (baseStat_na <= 60) return 2;
        if (baseStat_na <= 80) return 3;
        if (baseStat_na <= 100) return 4;
        if (baseStat_na <= 120) return 5;
        if (baseStat_na <= 140) return 6;
        if (baseStat_na <= 160) return 7;
        if (baseStat_na <= 180) return 8;
        if (baseStat_na <= 200) return 9;
        return 10;
    }
    public static int GetSpeed(int baseSpeed_na)
    {
        return (int)Math.Ceiling(baseSpeed_na / 10.0);
    }

    public static int GetStabBasic(int level_na)
    {
        return 1 + 2 * ((int)Math.Floor(level_na / 5.0));
    }
}