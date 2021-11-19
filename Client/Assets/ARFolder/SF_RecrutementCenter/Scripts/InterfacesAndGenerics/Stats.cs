using UnityEngine;

public class Stats
{
    public bool isActivated;
    public bool isUnlocked;
    
    
    public override string ToString()
    {
        return JsonUtility.ToJson(this);
    }
}