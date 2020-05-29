using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public IInventoryItem Item { get; set; }

    ItemDropHandler dropHandler;

    void Start()
    {
        dropHandler = GameObject.Find("Inventaire").GetComponent<ItemDropHandler>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        FindObjectOfType<AudioManager>().PickItemInv();
        dropHandler.Item = Item;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }
}
