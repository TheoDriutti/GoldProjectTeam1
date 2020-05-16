using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour, IInventoryItem
{
    public virtual string Name
    {
        get { return "_base item_"; }
    }

    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public virtual void OnPickUp()
    {
    }

    public virtual void OnDrop()
    {
        Vector3 DropPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var newObj = Instantiate(gameObject, new Vector3(DropPos.x, DropPos.y, 0), Quaternion.identity);
        newObj.transform.parent = transform.parent;
    }

}
