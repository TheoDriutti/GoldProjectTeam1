using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : InventoryItemBase
{
    public float speedMultiplicator;
    public float boostDuration;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            BallController bc = col.GetComponent<BallController>();
            bc.maxFallSpeed *= speedMultiplicator;
            col.GetComponent<Rigidbody2D>().velocity *= speedMultiplicator;
            bc.isBoosting = true;
            bc.boostCD = boostDuration;
            bc.boostCoeff = speedMultiplicator;
        }
    }


}
