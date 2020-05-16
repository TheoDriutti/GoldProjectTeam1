using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Slow : MonoBehaviour
{
    public float NewGravity;

    public float TimeDebuff;

    public GameObject Coll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coll = collision.gameObject;
        collision.GetComponent<Rigidbody2D>().gravityScale = NewGravity;
        StartCoroutine(SlowTimer(collision.gameObject));        
    }

    IEnumerator SlowTimer(GameObject Target)
    {
        yield return new WaitForSeconds(TimeDebuff);
        Target.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
