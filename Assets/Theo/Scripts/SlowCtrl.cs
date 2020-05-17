using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCtrl : InventoryItemBase
{
    public float slowDuration;
    public float slowMultiplicator;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            BallController bc = col.GetComponent<BallController>();

            bc.slowCD = slowDuration;
            bc.isSlowing = true;
            bc.maxFallSpeed *= slowMultiplicator;
            col.GetComponent<Rigidbody2D>().velocity *= slowMultiplicator;
            bc.slowCoeff = slowMultiplicator;
        }
    }
}
