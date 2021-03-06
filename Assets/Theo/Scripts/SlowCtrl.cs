﻿using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;


public class SlowCtrl : InventoryItemBase
{
    public float slowDuration;
    public float slowMultiplicator;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Debug.Log("okbal");
            BallController bc = col.GetComponent<BallController>();
            if (!bc.isSlowing)
            {
                bc.slowCD = slowDuration;
                bc.isSlowing = true;
                bc.maxFallSpeed *= slowMultiplicator;
                col.GetComponent<Rigidbody2D>().velocity *= slowMultiplicator;
                bc.slowCoeff = slowMultiplicator;

            }
        }
        if (col.gameObject.tag == "Crusher")
        {
            Debug.Log("ok");
            col.GetComponent<CrusherH>().CrusherForce /= 2;
        }
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
       
        if (col.gameObject.tag == "Crusher")
        {
            Debug.Log("ok");
            col.GetComponent<CrusherH>().CrusherForce /= 2;
        }

    }
}
