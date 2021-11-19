using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenericList<T> : MonoBehaviour where T : ScriptableObject,IPlayableObject
{
    public List<T> list;
    
    public T GetByName(string name)
    {
        return list.Find(val => val.name == name);
    }

    public T GetActive()
    {
        return list.Find(val => val.IsActivated());
    }
    
    public T GetByIndex(int index)
    {
        if (index < 0 || index > list.Count)
        {
            return list[index];
        }

        return list[index];
    }

    public int GetIndexOf(T obj)
    {
        return list.IndexOf(obj);
    }
    
}