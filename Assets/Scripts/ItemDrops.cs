using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrops : MonoBehaviour
{
    public GameObject ItemPrefab;
    public string ItemId;

    public void DropItem()
    {
        var item = Instantiate(ItemPrefab, transform.position + Vector3.up, Quaternion.identity);
        item.GetComponent<InventoryItem>().inventoryKey = ItemId;
    }
}
