using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    private float BackBouncy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        BackBouncy = collision.GetComponent<Rigidbody2D>().sharedMaterial.bounciness;
        collision.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = BackBouncy;
    }
}
