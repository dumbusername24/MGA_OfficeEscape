using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    //public static ItemAssets Instance { 
    //    get 
    //    { 
    //        if(instance == null)
    //        {
    //            instance = new ItemAssets();
    //        }
    //        return instance;
    //    }
    //}
    //private static ItemAssets instance = null;
    
    //private ItemAssets()
    //{

    //}

    public static ItemAssets Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }


    public Sprite KeySprite;
    public Sprite ClipboardSprite;
    public Sprite PaperSprite;
}
