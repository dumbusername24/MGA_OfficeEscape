using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EscButton : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] public InventoryLogic inventoryLogic;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        inventoryLogic.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        //clicking on Objects to add them to inventory
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform != null)
            {
                var tag = hit.collider.gameObject.tag;
                PrintName(hit.transform.gameObject);
                //add item to inventory
                if(tag == "Key")
                {
                    Item item = new Item();
                    item.itemType = "Key";
                    item.GetSprite();
                    inventory.AddItem(item);
                    inventoryLogic.SetInventory(inventory);

                    GameObject keyText = hit.collider.gameObject.transform.GetChild(0).gameObject;
                    keyText.SetActive(true);
                    
                    //hit.collider.gameObject.SetActive(false);


                }
                else if(tag == "Drawer")
                {
                    //delete key from inventory (maybe)
                    foreach(Item item in inventory.GetItemList())
                    {
                        if(item.itemType == "Key")
                        {
                            //open drawer animation
                        }
                        else
                        {
                            //popup you shall not pass?
                        }
                    }

                }
                else if(tag == "Monalisa")
                {
                    Item item = new Item();
                    item.itemType = "Paper";
                    item.GetSprite();
                    inventory.AddItem(item);
                    inventoryLogic.SetInventory(inventory);

                    GameObject paintingText = GameObject.FindWithTag("Painting_text");
                    paintingText.SetActive(true);
                }
                else if(tag == "Clipboard")
                {
                    //popup UI element
                    GameObject clipboardText = GameObject.FindWithTag("Clipboard_text");
                    clipboardText.SetActive(true);
                }
                else if(tag == "numberfield")
                {
                    //open input menu for code at the end
                }
            }
        }
    }
    private void PrintName(GameObject go)
    {
        Debug.Log(go.name);
    }
}
