using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EscButton : MonoBehaviour
{
    public GameObject drawer;
    public GameObject keyPad;
    public GameObject radio;
    public bool pullDrawer;
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

        StartCoroutine(MouseClick());
    }

    IEnumerator MouseClick(){
        //clicking on Objects to add them to inventory
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform != null)
            {
                var tag = hit.collider.gameObject.tag;
                Debug.Log(hit.collider.gameObject.name);
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
                    
                    yield return new WaitForSeconds(3);

                    hit.collider.gameObject.SetActive(false);


                }
                else if(tag == "Drawer")
                {
                    if(inventory.GetItemList().Count == 0)
                    {
                        //popup you shall not pass?
                        GameObject gandalfText = hit.collider.transform.GetChild(0).gameObject;
                        gandalfText.SetActive(true);

                        yield return new WaitForSeconds(3);

                        gandalfText.SetActive(false);
                    }
                    else{
                        //delete key from inventory (maybe)
                        foreach(Item item in inventory.GetItemList())
                        {
                            if(item.itemType == "Key")
                            {
                                pullDrawer = true;
                            }
                            else
                            {
                                //popup you shall not pass?
                            }
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

                    GameObject paintingText = hit.collider.gameObject.transform.GetChild(0).gameObject;
                    paintingText.SetActive(true);

                    yield return new WaitForSeconds(3);

                    paintingText.SetActive(false);
                }
                else if(tag == "Clipboard")
                {
                    //popup UI element
                    GameObject clipboardText = hit.collider.gameObject.transform.GetChild(0).gameObject;
                    clipboardText.SetActive(true);
                    Debug.Log("Clipboard!");

                    yield return new WaitForSeconds(3);

                    clipboardText.SetActive(false);
                }
                else if(tag == "Numberfield")
                {
                    //open input menu for code at the end
                    keyPad.SetActive(true);
                    Debug.Log("Numberfield!");
                }
                else if(tag == "Radio")
                {
                    if(hit.collider.gameObject.GetComponent<AudioSource>().isPlaying == false)
                    {
                        hit.collider.gameObject.GetComponent<AudioSource>().Play();
                    }
                    else if(hit.collider.gameObject.GetComponent<AudioSource>().isPlaying == true)
                    {
                        hit.collider.gameObject.GetComponent<AudioSource>().Pause();
                    }
                    
                }
            }
        }
        if (pullDrawer == true && drawer.transform.localPosition.z < 2.5)
        {
            drawer.transform.position = drawer.transform.position + new Vector3(0, 0, Time.deltaTime*20);
        }
    }
}
