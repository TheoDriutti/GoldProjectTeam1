using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private float OriginalBounce;
    public float SpeedMultiplier;

    public float DecayTimer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OriginalBounce = collision.GetComponent<Rigidbody2D>().sharedMaterial.bounciness;
        collision.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = 1;
        collision.GetComponent<Rigidbody2D>().velocity = collision.GetComponent<Rigidbody2D>().velocity * SpeedMultiplier;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = OriginalBounce;
        StartCoroutine(DecaySpeed(collision.gameObject));
    }

    IEnumerator DecaySpeed(GameObject Ball)
    {
        yield return new WaitForSeconds(DecayTimer);
        Ball.GetComponent<Rigidbody2D>().velocity /= SpeedMultiplier;
    }
}
