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

    #region User Interface
    [Header("UI Manager")]
    [SerializeField]private GameObject inventoryGrid;
    //[SerializeField] private GameObject equipmentGrid;
    public bool activeUI=false;
    private ItemSlotUI[] itemSlots;
    #endregion
    [Header("Lists")]
    public List<InventoryItem> inventoryItems;
    public List<EquipmentItem> equipmentItems;

    private Dictionary<ItemData, InventoryItem> inventoryDictionary;
    private Dictionary<ItemData,EquipmentItem> equipmentDictionary;


    private void Awake()
    {
        inventoryItems=new List<InventoryItem>();
        inventoryDictionary=new Dictionary<ItemData, InventoryItem>();
        equipmentItems=new List<EquipmentItem>();
        equipmentDictionary=new Dictionary<ItemData,EquipmentItem>();
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
        foreach(ItemSlotUI itemSlot in itemSlots)
        {
            itemSlot.clearUI();
        }
        for(int i=0;i<inventoryItems.Count;i++)
        {
            itemSlots[i].setUI(inventoryItems[i]);
        }
    }

    public void equipItem(ItemData _newItemData)
    {
        EquipmentItem newItem = new EquipmentItem(_newItemData);
        EquipmentItem oldItem = null;

        foreach(KeyValuePair<ItemData,EquipmentItem> item in equipmentDictionary)
        {
            if (_newItemData.type==item.Key.type)
                oldItem= item.Value;
        }

        if(oldItem!=null)
        {
            equipmentItems.Remove(oldItem);
            equipmentDictionary.Remove(oldItem.data);
            addItem(oldItem.data);
        }

        removeItem(_newItemData);
        equipmentDictionary.Add(_newItemData, newItem);
        equipmentItems.Add(newItem);
        updateUI();
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
