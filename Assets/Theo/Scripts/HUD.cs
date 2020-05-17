﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += InventoryScript_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = Inventory.gameObject.transform;

        foreach (Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            if (!image.enabled)
            {

                image.enabled = true;
                image.sprite = e.Item.Image;

                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    private void InventoryScript_ItemRemoved(object sender, InventoryEventArgs e)
    {
        //Transform inventoryPanel = Inventory.gameObject.transform;
        //foreach (Transform slot in inventoryPanel)
        //{
        //    Transform imageTransform = slot.GetChild(0);
        //    Image image = imageTransform.GetComponent<Image>();
        //    ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

        //    if (itemDragHandler.Item != null)
        //    {
        //        if (itemDragHandler.Item.Equals(e.Item))
        //        {
        //            itemDragHandler.Item = null;
        //        }
        //    }
        //}
    }
}