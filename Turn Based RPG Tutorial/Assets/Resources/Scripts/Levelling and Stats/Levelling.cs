using System;

public static class Levelling
{
    public static readonly int MAX_LEVEL = 30;


    // Stats should be in order 0 - 7:
    // 0 - Max HP,
    // 1 - Max Resource,
    // 2 - Attack,
    // 3 - Magic Power,
    // 4 - Armor,
    // 5 - Magic Resist,
    // 6 - Speed,
    // 7 - Crit Rate.
    
    //Base Stats by Job
    private static readonly int[] berserkerBaseStats = new int[] { 200, 50, 10, 0, 10, 10, 5, 0 }; //Player Jobs
    private static readonly int[] assassinBaseStats = new int[] { 100, 50, 15, 0, 0, 0, 10, 5 };
    private static readonly int[] mageBaseStats = new int[] { 100, 100, 5, 15, 0, 5, 5, 0 };
    private static readonly int[] herbalistBaseStats = new int[] { 200, 50, 30, 0, 10, 15, 10, 0 };
    private static readonly int[] sageBaseStats = new int[] { 200, 50, 30, 0, 10, 15, 10, 0 };
    private static readonly int[] marksmanBaseStats = new int[] { 200, 50, 30, 0, 10, 15, 10, 0 };

    private static readonly int[] banditBaseStats = new int[] {80, 50, 10, 0, 5, 5, 5, 0}; //Enemy Jobs
    private static readonly int[] crookBaseStats = new int[] { 80, 50, 10, 0, 5, 5, 5, 0 }; //TODO: attack should be 10
    private static readonly int[] pirateBaseStats = new int[] { 80, 50, 10, 0, 5, 5, 5, 0 };

    //Stat Growth Rates by Job
    private static readonly int[] berserkerGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }; //Player Jobs
    private static readonly int[] assassinGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
    private static readonly int[] mageGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
    private static readonly int[] herbalistGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
    private static readonly int[] sageGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
    private static readonly int[] marksmanGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };

    private static readonly int[] banditGrowthRates = new int[] {1, 1, 1, 1, 1, 1, 1, 1}; //Enemy Jobs
    private static readonly int[] crookGrowthRates = new int[] {1, 1, 1, 1, 1, 1, 1, 1};
    private static readonly int[] pirateGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };


    // Jobs should be in order: 
    // 0 = Berserker, 
    // 1 = Assassin, 
    // 2 = Mage, 
    // 3 = Herbalist,
    // 4 = Sage,
    // 5 = Marksman.

    //BaseStats of All Jobs
    private static readonly int[][] baseStats = new int[][] {berserkerBaseStats,
            assassinBaseStats, mageBaseStats, herbalistBaseStats,
            sageBaseStats, marksmanBaseStats, banditBaseStats, crookBaseStats, 
            pirateBaseStats};

    //Stat Growth Rates of All Jobs
    private static readonly int[][] growthRates = new int[][] {berserkerGrowthRates,
            assassinGrowthRates, mageGrowthRates, herbalistGrowthRates,
            sageGrowthRates, marksmanGrowthRates, banditGrowthRates, crookGrowthRates, 
            pirateGrowthRates};

    /// <summary>
    /// Gets the Base Stats for a given Job and
    /// UnitType.
    /// </summary>
    /// <param name="job">The Job.</param>
    /// <returns>The Job's Base Stats in an array with the
    /// order: Max HP, Max Resource, Attack, Magic Power, Armor, Magic Resist,
    /// Speed, and Crit Rate.
    /// </returns>
    public static int[] GetBaseStats(Job job)
    {
        int i = (int)job;
        int[] playerBaseStats = baseStats[i];

        return playerBaseStats;
    }

    /// <summary>
    /// Gets the Growth Rates for the stats of a given
    /// Job and UnitType.
    /// </summary>
    /// <param name="job">The Job.</param>
    /// <returns>The Job's growth rates for stats in the order:
    /// Max HP, Max Resource, Attack, Magic Power, Armor, Magic Resist, Speed,
    /// and Crit Rate.</returns>
    public static int[] GetGrowthRates(Job job)
    {
        int i = (int)job;
        int[] playerGrowthRates = growthRates[i];

        return playerGrowthRates;
    }

    /// <summary>
    /// Gets the XP required to reach
    /// the given next Level.
    /// </summary>
    /// <param name="nextLevel">The next Level to reach.</param>
    /// <returns>The amount of xp required to reach
    /// that Level.</returns>
    public static int GetXPToNextLevel(int nextLevel)
    {
        throw new NotImplementedException();
    }
}
