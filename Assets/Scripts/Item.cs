using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //public enum ItemType
    //{
    //    Key,
    //    Clipboard,
    //    Paper,
    //}

    public string itemType;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case "Key": return ItemAssets.Instance.KeySprite;
            case "Clipboard": return ItemAssets.Instance.ClipboardSprite;
            case "Paper": return ItemAssets.Instance.PaperSprite;
            
        }
    }
}
