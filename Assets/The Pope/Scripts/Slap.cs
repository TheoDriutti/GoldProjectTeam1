using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slap : MonoBehaviour
{
    public Hitbox HB;

    public float RotateSpeed;

    public float SlapX;
    public float SlapY;


    private void Update()
    {
        if (HB.TargetAcquired)
        {
            transform.Rotate(new Vector3(0, 0, 1), -10);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(SlapX, SlapY));
        }
            
    }


}
