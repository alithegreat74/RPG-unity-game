using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem 
{
    public ItemData data;
    public int stackSize;

    public InventoryItem(ItemData _data)
    {
        data = _data;
        addStack();
    }

    public void addStack()=>stackSize++;
    public void removeStack()=>stackSize--;
}
