using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public bool TargetAcquired = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.name == "Player")
        {
            TargetAcquired = true;
        }
        
    }
}
