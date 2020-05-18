using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public InventoryController inventoryController;
    public PlayerCharacter PlayerCharacter;
    public BoxCollider2D ItemSpawnArea;
    public int Level = 1;
    public int LevelUpTarget = 3;
    public int CurrentSlimes = 0;
    public int InventorySize = 1;
    public List<GameObject> ItemsInBody;

    private Vector3 MinSpawn;
    private Vector3 MaxSpawn;

    bool CheckCondition = false;
    int ItemCount = 0;
    private Animator Animator;

    public void CountItems(string key)
    {
        ItemCount = ItemsInBody.Count(x => x.name == key);
    }

    public void CountCheck(int count)
    {
        if (ItemCount >= count)
            CheckCondition = true;
    }

    public void CheckInventory(string itemKey)
    {
        if (ItemsInBody.Any(x => x.name.Equals(itemKey)))
        {
            CheckCondition = true;
        }
    }

    public void CheckSlimes(int count)
    {
        if (CurrentSlimes >= count)
        {
            CheckCondition = true;
        }
    }


    public void SetAnimation(Animator animator)
    {
        if (CheckCondition)
            Animator = animator;
    }

    public void PlayAnimation(string animator)
    {
        if (Animator != null && CheckCondition)
        {
            Animator.Play(animator);
        }
        Animator = null;
        CheckCondition = false;
        ItemCount = 0;
    }

    public void PickUpItem(InventoryItem inventoryItem)
    {
        if (inventoryItem.inventoryKey == "Slime")
        {
            CurrentSlimes++;
            transform.localScale *= 1.1f;
            CheckLevelUp();
            return;
        }

        if (ItemsInBody.Count < InventorySize)
        {
            var newItem = SpawnItemInBody(inventoryItem.SpriteIconPrefab);
            newItem.name = inventoryItem.inventoryKey;
            newItem.GetComponent<SpriteRenderer>().color = inventoryItem.gameObject.GetComponent<SpriteRenderer>().color;
            ItemsInBody.Add(newItem);
        }
    }

    public void CheckLevelUp()
    {
        if (CurrentSlimes == LevelUpTarget)
        {
            LevelUpTarget += Mathf.RoundToInt(LevelUpTarget * 2.5f);
            Level++;
            // update HP
            // HP = Level + 1;
            InventorySize = Level;
        }
    }

    public GameObject SpawnItemInBody(GameObject item)
    {
        Vector2 size = ItemSpawnArea.size;
        Vector3 worldPos = ItemSpawnArea.transform.position;

        float top = worldPos.y + (size.y / 4f);
        float btm = worldPos.y - (size.y / 4f);
        float left = worldPos.x - (size.x / 4f);
        float right = worldPos.x + (size.x / 4f);

        MinSpawn = new Vector3(left, top, worldPos.z);
        MaxSpawn = new Vector3(right, btm, worldPos.z);

        var xAxis = Random.Range(MinSpawn.x, MaxSpawn.x);
        var yAxis = Random.Range(MinSpawn.y, MaxSpawn.y);
        var randomPosition = new Vector3(xAxis, yAxis, 0f);

        return Instantiate(item, randomPosition, Quaternion.identity, ItemSpawnArea.transform);
    }

    public void UseItem(string itemKey)
    {

    }

    public bool InventoryFull()
    {
        if (InventorySize <= ItemsInBody.Count)
            return true;

        return false;
    }
}
