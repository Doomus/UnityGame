using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public GameObject inventoryPanel;

    public GameObject itemSlot;

    public GameObject itemSlotParent;

    public bool inventoryOpen = false;

    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        inventoryPanel.SetActive(false);

        if(instance != null)
        {
            Debug.LogWarning("More than one inventory found");
        }
        instance = this;
    }
    #endregion

    private void openInventory()
    {
        inventoryPanel.SetActive(true);
        inventoryOpen = true;
        //foreach (Item item in items)
        //{
        //    Instantiate(itemSlot, itemSlotParent.transform);
        //    Text textC = itemSlot.GetComponentInChildren<Text>();
        //    textC.text = item.name;
        //}
    }

    private void closeInventory()
    {
        inventoryPanel.SetActive(false);
        inventoryOpen = false;
    }


    public delegate void OnGunChanged();
    public OnGunChanged onGunChangedCallback;


    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
        Instantiate(itemSlot, itemSlotParent.transform);
        Text textC = itemSlot.GetComponentInChildren<Text>();
        textC.text = item.name;
        Debug.Log (item.name);
        Image itemSprite = itemSlot.GetComponent<Image>();
        itemSprite.sprite = item.icon;

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }


    private void Update()
    {
        if (Input.GetButtonDown("InventoryToggle"))
        {
            if (inventoryOpen == false)
            {
                Debug.Log("opened");
                openInventory();
            }
            else if (inventoryOpen == true)
            {
                Debug.Log("closed");
                closeInventory();
            }
            //foreach (Item item in items)
            //{
            //    Debug.Log(item.name);
            //}
        }
    }
    //public List<Spell> spells = new List<Spell>();

    //public List<Gun> guns = new List<Gun>();
    //
    //public void AddGun(Gun gun)
    //{
    //    guns.Add(gun);
    //}
    //
    //public void RemoveGun(Gun gun)
    //{
    //    guns.Remove(gun);
    //}


}
