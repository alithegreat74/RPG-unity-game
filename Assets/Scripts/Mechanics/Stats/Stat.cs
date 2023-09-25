using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField] private int value;
    [SerializeField] List<int> modifiers= new List<int>();
    public int getValue()
    {
        foreach (int modifier in modifiers)
        {
            value+=modifier;
        }
        return value;
    }
    public void addModifier(int _modifier)
    {
        modifiers.Add(_modifier);
    }
    public void removeModifier(int _modifier)
    {
        modifiers.RemoveAt(_modifier);
    }
}
