using UnityEngine;


public class GenericPlayableObject<T> : ScriptableObject, IPlayableObject where T : Stats
{
    public CharacterClass characterClass;
    public Rank rank;
    public Sprite image;

    protected T stats;


    /// <summary>
    /// should be overwritten by any class that inherits from this one
    /// used for saving and loading the correct stats
    /// </summary>
    /// <returns></returns>
    protected virtual string GetKey()
    {
        return "";
    }

    /// <summary>
    /// can be overwritten if some class needs
    /// specific default values
    /// </summary>
    public virtual void LoadCurrentStats()
    {
        stats = JsonUtility.FromJson<T>(PlayerPrefs.GetString(GetKey(),
            new CharacterStats().ToString()));
        // TODO 5 times called on selection in scrollrect...
        //Debug.Log(name + " " + GetKey() + stats.ToString());
    }

    /// <summary>
    /// initialized with default values from class T
    /// </summary>
    protected void SaveCurrentStats()
    {
        PlayerPrefs.SetString(GetKey(), stats.ToString());
    }

    public void Unlock()
    {
        LoadCurrentStats();
        stats.isUnlocked = true;
        SaveCurrentStats();
    }

    #region Getters

    public T GetCurrentStats()
    {
        LoadCurrentStats();
        Debug.Log(stats);
        return stats;
    }

    public bool IsUnlocked()
    {
        LoadCurrentStats();
        return stats.isUnlocked;
    }

    public bool IsActivated()
    {
        LoadCurrentStats();
        return stats.isActivated;
    }

    public int GetRank()
    {
        switch (rank)
        {
            case Rank.R2: return 2;
            case Rank.R3: return 3;
            case Rank.R4: return 4;
            default: return 1;
        }
    }

    public Color GetStrengthColor()
    {
        switch (rank)
        {
            case Rank.R2: return new Color(93f / 255f, 183f / 255f, 82f / 255f);
            case Rank.R3: return new Color(1, 122 / 255f, 0);
            case Rank.R4: return new Color(1, 0, 0);
            default: return new Color(1, 1, 1);
        }
    }

    #endregion Getters


    public enum Rank
    {
        R1,
        R2,
        R3,
        R4
    }
}