using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratorTheo : MonoBehaviour
{
    public float speedMultiplicator;
    public float boostDuration;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            BallController bc = col.GetComponent<BallController>();

            bc.boostCD = boostDuration;
            bc.isBoosting = true;
            bc.maxFallSpeed *= speedMultiplicator;
            col.GetComponent<Rigidbody2D>().velocity *= speedMultiplicator;
            bc.boostCoeff = speedMultiplicator;
        }
    }


}
