using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public Crusher_Zone CZ;

    public float speed;

    public bool Right;

    private void Update()
    {
        if (CZ.TargetAcquired)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (Right)
            {
                CZ.Right = true;
            }
            else
            {
                CZ.Left = true;
            }
        }
    }



}
