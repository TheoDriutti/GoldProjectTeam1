using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : MonoBehaviour
{
    public Hitbox HB;
    public float Speed;

    void Update()
    {
      if (HB.TargetAcquired)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
        }
    }

    private void OnColliderEnter2D (Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
