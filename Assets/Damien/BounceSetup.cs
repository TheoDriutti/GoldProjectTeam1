using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSetup : MonoBehaviour
{
    private float OriginalBounce;
    public float Bounce;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OriginalBounce = this.GetComponent<BoxCollider2D>().sharedMaterial.bounciness;
        this.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = Bounce;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = OriginalBounce;
    }
}
