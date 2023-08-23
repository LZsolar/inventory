using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertory : MonoBehaviour
{
    public ItemData[] Items => itemList.ToArray();
    [SerializeField] List<ItemData> itemList = new List<ItemData>();
    
    public ItemData[] GetItemByType(ItemType targetType)
    {
        var resultList = new List<ItemData>();
        foreach (var itemData in itemList)
        {
            if(itemData.type == targetType)
                resultList.Add(itemData);
        }
        return resultList.ToArray();
    }

    public void Add(ItemData itemToAdd)
    {

    }
    public void Remove(ItemData itemToRemove)
    {

    }
}

[Serializable]
public class ItemData
{
    public string displayName;
    public string description;
    public Sprite icon;
    public int count;
    public ItemType type;
}
public enum ItemType
{
    PokeBalls,Items,KeyItems,Others
}
