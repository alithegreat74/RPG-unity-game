using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance
    {
        get
        {
            if (Instance == null)
                Instance = FindObjectOfType(typeof(Inventory)) as Inventory;

            return Instance;
        }
        set
        {
            instance = value;
        }
    }
    private static Inventory Instance;
    #endregion
    #region UI
    [Header("UI Manager")]
    [SerializeField]private GameObject inventoryGrid;
    [SerializeField]private ItemSlotUI[] itemSlots;
    public bool activeUI=false;
    #endregion

    public List<InventoryItem> inventoryItems;
    public Dictionary<ItemData, InventoryItem> inventoryDictionary;


    private void Awake()
    {
        inventoryItems=new List<InventoryItem>();
        inventoryDictionary=new Dictionary<ItemData, InventoryItem>();
        itemSlots=inventoryGrid.GetComponentsInChildren<ItemSlotUI>();
        inventoryGrid.SetActive(false);
    }

    public void enableUI()
    {
        activeUI= true;
        inventoryGrid.SetActive(true);
    }
    public void disableUI()
    {
        activeUI= false;
        inventoryGrid.SetActive(false);
    }

    public void updateUI()
    {
        for(int i=0;i<inventoryItems.Count;i++)
        {
            itemSlots[i].setUI(inventoryItems[i]);
        }
    }

    public void addItem(ItemData _newData)
    {
        if(inventoryDictionary.TryGetValue(_newData,out InventoryItem value))
        {
            value.addStack();
        }
        else
        {
            InventoryItem newInventoryItem = new InventoryItem(_newData);
            inventoryItems.Add(newInventoryItem);
            inventoryDictionary.Add(_newData, newInventoryItem);
        }
        updateUI();
    }
    public void removeItem(ItemData _newData)
    {
        if(inventoryDictionary.TryGetValue(_newData,out InventoryItem value))
        {
            if (value.stackSize<=1)
            {
                inventoryItems.Remove(value);
                inventoryDictionary.Remove(_newData);
            }
            else
            {
                value.removeStack();
            }
        }

    }
}
