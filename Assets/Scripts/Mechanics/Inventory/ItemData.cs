using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType
{
    Weapon,
    Armor,
    Ring,
    Flask,
}
[CreateAssetMenu(fileName ="New Item Data",menuName ="Items/Item Data")]
public class ItemData : ScriptableObject
{
    public itemType type;
    public string itemName;
    public Sprite itemIcon;
}
