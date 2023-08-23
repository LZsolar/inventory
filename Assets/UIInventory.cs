using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [Header("Category")]
    [SerializeField] Image CategoryIconImage;
    [SerializeField] Text CategoryText;

    [Header("Current Items")]
    [SerializeField] Image CurrentItemIconImage;
    [SerializeField] Text DescriptionText;

    [Header("Item List")]
    [SerializeField] UIItem itemUIPrefeb;
    [SerializeField] List<UIItem> itemUIList = new List<UIItem>();

    void Start()
    {
        itemUIPrefeb.gameObject.SetActive(false);   
    }
    public void SetCategory(CategoryInfo info)
    {
        CategoryIconImage.sprite = info.icon;
        CategoryText.text = info.name;
    }
    public void SetCurrentItemInfo(ItemData info)
    {
        DescriptionText.text = info.description;
        CurrentItemIconImage.sprite = info.icon;
    }

    public void SetItemList(UIItem_Data[] items)
    {
        foreach (UIItem uiItem in itemUIList)
            Destroy(uiItem.gameObject);

        itemUIList.Clear();
        foreach(var item in items)
        {
            itemUIPrefeb.gameObject.SetActive(true);
            var newItemUI = Instantiate(itemUIPrefeb,itemUIPrefeb.transform.parent,false);
            itemUIList.Add(newItemUI);
            newItemUI.SetData(item);
        }
    }
}

[SerializeField]
public class CategoryInfo
{
    public string name;
    public Sprite icon;
}
