using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector.Editor.TypeSearch;
using UnityEngine;

public static class Levelling
{
    public static readonly int MAX_LEVEL = 30;
    private static readonly float enemyStatsRatio = 0.75f; //ratio multiplied
                                                          //by stats to get
                                                          //enemy base stats and
                                                          //stat growth rates


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
    private static readonly int[] berserkerBaseStats = new int[] { 200, 50, 30, 0, 10, 15, 10, 0 };
    private static readonly int[] assassinBaseStats = new int[] { 200, 50, 30, 0, 10, 15, 10, 0 };
    private static readonly int[] mageBaseStats = new int[] { 200, 50, 30, 0, 10, 15, 10, 0 };
    private static readonly int[] herbalistBaseStats = new int[] { 200, 50, 30, 0, 10, 15, 10, 0 };
    private static readonly int[] sageBaseStats = new int[] { 200, 50, 30, 0, 10, 15, 10, 0 };
    private static readonly int[] marksmanBaseStats = new int[] { 200, 50, 30, 0, 10, 15, 10, 0 };

    //Stat Growth Rates by Job
    private static readonly int[] berserkerGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
    private static readonly int[] assassinGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
    private static readonly int[] mageGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
    private static readonly int[] herbalistGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
    private static readonly int[] sageGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
    private static readonly int[] marksmanGrowthRates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };

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
            sageBaseStats, marksmanBaseStats};

    //Stat Growth Rates of All Jobs
    private static readonly int[][] growthRates = new int[][] {berserkerGrowthRates,
            assassinGrowthRates, mageGrowthRates, herbalistGrowthRates,
            sageGrowthRates, marksmanGrowthRates};

    /// <summary>
    /// Gets the Base Stats for a given Job and
    /// UnitType.
    /// </summary>
    /// <param name="job">The Job.</param>
    /// <param name="type">The UnitType.</param>
    /// <returns></returns>
    public static int[] GetBaseStats(Job job, UnitType type)
    {
        int i = (int)job;
        int[] playerBaseStats = baseStats[i];

        //Case 1: Enemy Unit
        if (type.Equals(UnitType.Enemy))
        {
            int[] enemyBaseStats = new int[8];

            for (int index = 0; index < enemyBaseStats.Length; index++)
            {
                enemyBaseStats[index] = (int) (playerBaseStats[index] * 
                                               enemyStatsRatio);
            }

            return enemyBaseStats;
        }

        //Case 2: Player Unit
        return playerBaseStats;
    }

    /// <summary>
    /// Gets the Growth Rates for the stats of a given
    /// Job and UnitType.
    /// </summary>
    /// <param name="job">The Job.</param>
    /// <param name="type">The UnitType.</param>
    /// <returns></returns>
    public static int[] GetGrowthRates(Job job, UnitType type)
    {
        int i = (int)job;
        int[] playerGrowthRates = growthRates[i];

        //Case 1: Enemy Unit
        if (type.Equals(UnitType.Enemy))
        {
            int[] enemyGrowthRates = new int[8];

            for (int index = 0; index < enemyGrowthRates.Length; index++)
            {
                enemyGrowthRates[index] = (int) (playerGrowthRates[index] * 
                                                 enemyStatsRatio);
            }

            return enemyGrowthRates;
        }

        //Case 2: Player Unit
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
