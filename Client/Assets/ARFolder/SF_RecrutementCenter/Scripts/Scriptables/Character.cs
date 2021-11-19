using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "newCharacter", menuName = "Characters/Character")]
public class Character : GenericPlayableObject<CharacterStatsUI>
{
    //AR changed all skills label to UI
    public SkillUI skillUI;
    public string description;
    
    [Header("currently only 1 passive skillUI supported")]
    public PassiveSkillUI[] passiveSkillsUI;
    
    /// <summary>
    /// Sets the correct SPrefs key to load and save characters
    /// </summary>
    /// <returns></returns>
    protected override string GetKey()
    {
        return "character_"+name;
    }
    
    public void AddXp(int exp)
    {
        stats.currentXp += exp;
        if (stats.currentLevel >= GetMaxLevel())
        {
            return;
        }

        if (stats.currentXp >= stats.neededXp)
        {
            stats.currentXp -= stats.neededXp;
            stats.currentLevel++;
            stats.neededXp = stats.currentLevel * 1000;

            //TODO invoke character level up event....
            // and upgrade Character Stats
        }

        SaveCurrentStats();
    }

    public void AddFragments(int amount)
    {
        stats.fragments += amount;
        SaveCurrentStats();
    }

    /// <summary>
    /// Selects or deselects the character
    /// </summary>
    /// <param name="choice"> true if character should be selected, false to deselect the character</param>
    public void SetActivationStatus(bool choice)
    {
        stats.isActivated = choice;
        SaveCurrentStats();
    }

    public bool PayFragments(int amount)
    {
        if (stats.fragments < amount)
        {
            return false;
        }

        stats.fragments -= amount;
        SaveCurrentStats();
        return true;
    }

    #region Getters
    
    public int GetCurrentLevel()
    {
        return stats.currentLevel;
    }

    public int GetMaxLevel()
    {
        switch (rank)
        {
            case Rank.R1: return 10;
            case Rank.R2: return 20;
            case Rank.R3: return 30;
            case Rank.R4: return 40;
            default: return 10; // Novice
        }
    }

    public int GetCurrentXp()
    {
        return stats.currentXp;
    }

    public int GetNeededXp()
    {
        return stats.neededXp;
    }
    
    public int GetNeededFragmentsToUnlock()
    {
        return 10;
    }

    public int getAvailableFragments()
    {
        return stats.fragments;
    }
    

    /// <summary>
    /// NOTE: current stats will be loaded first, via SPrefs
    /// </summary>
    public string GetPassiveSkillUI()
    {
        LoadCurrentStats();
        if (passiveSkillsUI.Length > 0)
        {
            var passiveSkillUI = passiveSkillsUI[0];
            var bonus = passiveSkillUI.startValue +
                        (passiveSkillUI.increasementPerLevel * (float) (stats.currentLevel - 1));
            return passiveSkillUI.stat + " : " + bonus + " %";
        }

        return "not defined";

    }
    #endregion Getters
    
    /// <summary>
    /// CAUTION: this method will overwrite all the character progress with the default lvl1 stats
    /// </summary>
    public void DebugResetStats()
    {
        PlayerPrefs.SetString(GetKey(), new CharacterStatsUI().ToString());
    }
}

public class CharacterStatsUI: Stats
{
    public int currentLevel = 1;
    public int currentXp = 0;
    public int neededXp = 500;
    public int fragments = 0;
}

[Serializable]
public class PassiveSkillUI
{
    public AvailableStats stat;

    [Header("Increasement in % --> 5 = 5%")]
    public float startValue;

    public float increasementPerLevel;
}


public enum AvailableStats
{
    Nothing,
    Damage,
    Health,
    Speed,
    FireRate,
    Coins,
    DarkMatter,
    criticalProbability, // probability that a critical hit is done
    criticalDamage, // multiplier for critical damage
}