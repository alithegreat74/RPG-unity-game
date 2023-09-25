using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI stackSize;
    [SerializeField]private Image icon;
    private InventoryItem item;

    public void setUI(InventoryItem _newItem)
    {
        item = _newItem;

        if (item.stackSize>1)
        {
            stackSize.text= item.stackSize.ToString();
        }
        else
        {
            stackSize.text="";
        }
        icon.color = Color.white;
        icon.sprite=item.data.itemIcon;
    }
}
