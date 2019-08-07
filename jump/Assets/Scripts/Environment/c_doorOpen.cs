using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_doorOpen : Interactable
{

    public GameObject Door;
    private Animator doorAnimator;
    public bool needsKey;
    public Item requiredKey = null;

    private void Start()
    {
        doorAnimator = Door.GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();

        Open();
    }

    void Open()
    {
        if (needsKey && Inventory.instance.activeItem == requiredKey)
        {
            Debug.Log("you used " + requiredKey.name);
            doorAnimator.SetBool("doorOpen", true);
            Inventory.instance.activeItemIcon.sprite = Inventory.instance.inventoryDefaultSprite;
        }
        if (needsKey && Inventory.instance.activeItem != requiredKey)
        {
            Debug.Log("needs " + requiredKey.name);
        }
        if (!needsKey)
        {
            doorAnimator.SetBool("doorOpen", true);
        }
    }
    void AutoClose()
    {
        doorAnimator.SetBool("doorOpen", false);
    }
}
