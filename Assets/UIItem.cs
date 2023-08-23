using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] Text itemNameText;
    [SerializeField] Text countText;
    [SerializeField] Image pointerImage;

    public void SetData(UIItem_Data data)
    {
        itemNameText.text = data.itemData.displayName;
        countText.text = "X" + data.itemData.count;
        pointerImage.gameObject.SetActive(data.isSelected);
    }
   
}
public class UIItem_Data
{
    public ItemData itemData;
    public bool isSelected;

    public UIItem_Data(ItemData itemdata,bool isSelected)
    {
        this.itemData = itemdata;
        this.isSelected = isSelected;
    }
}