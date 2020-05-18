using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInventory : MonoBehaviour
{
    public int InventorySize = 1;
    public int CurrentItems = 0;
    public List<GameObject> ItemsInBody;


    // Start is called before the first frame update
    void Start()
    {
        ItemsInBody = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpItem(InventoryItem inventoryItem)
    {

    }

    public void SpawnItemInBody()
    {

    }

    public void UseItem()
    {

    }
}
