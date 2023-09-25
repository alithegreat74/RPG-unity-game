using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField]private ItemData data;

    private void OnValidate()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite=data.itemIcon;
        gameObject.name="Item Object - "+data.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>()!=null)
        {
            Inventory.instance.addItem(data);
            Destroy(gameObject);
        }
    }
}
