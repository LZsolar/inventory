using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class InventoryPresenter : MonoBehaviour
{
    int currentItemIndex;
    int currentCategoryIndex;
    
    int maxItemIndex;
    int maxCategoryCount = 4;
    
    int pageSize = 6;

    [SerializeField] UIInventory UI;
    [SerializeField] Invertory inventory;
    [SerializeField] List<CategoryInfo> CategoryInfoList = new List<CategoryInfo>();

    void Start()
    {
        RefreshUI();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PrevCategory();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            NextCategory();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            PrevItem();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            NextItem();
        }
    }
    void PrevCategory()
    {
        if (currentCategoryIndex <= 0) { return; }
        currentCategoryIndex--;
        currentItemIndex = 0;
        RefreshUI();
    }
    void NextCategory()
    {
        if (currentCategoryIndex >= maxCategoryCount-1) { return; }
        currentCategoryIndex++;
        currentItemIndex = 0;
        RefreshUI();
    }
    void PrevItem()
    {
        if (currentItemIndex <= 0) { return; }
        currentItemIndex--;
        RefreshUI();
    }
    void NextItem()
    {
        if (currentItemIndex >= maxItemIndex) { return; }
        currentItemIndex++;
        RefreshUI();
    }
    void RefreshUI()
    {
        var currentCategoryInfo = CategoryInfoList[currentCategoryIndex];
        UI.SetCategory(currentCategoryInfo);

        var currentItem = inventory.Items[currentItemIndex];
        UI.SetCurrentItemInfo(currentItem);

        var currentCategory = (ItemType)currentCategoryIndex;
        var itemToDisplay = inventory.GetItemByType(currentCategory);

        var uiDataList = new List<UIItem_Data>();

        var currentPageIndex = currentItemIndex / pageSize;
        var StartIndexToDisplay = currentPageIndex*pageSize;
        var EndIndexToDisplay = StartIndexToDisplay+ pageSize;

        var i = 0;
        foreach(var item in itemToDisplay)
        {
            if(i>=StartIndexToDisplay && i< EndIndexToDisplay)
                uiDataList.Add(new UIItem_Data(item,currentItem==item));
            
            i++;
        }

        maxItemIndex = itemToDisplay.Length;
        UI.SetItemList(uiDataList.ToArray());
    }
}
