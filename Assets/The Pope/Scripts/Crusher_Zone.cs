using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher_Zone : MonoBehaviour
{
    public bool TargetAcquired;

    public bool Left;

    public bool Right;

    private GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.name == "Player")
        {
            Player = collision.gameObject;
            TargetAcquired = true;
        }
    }

    private void Update()
    {
        if (Left && Right)
        {
            Player.SetActive(false);
        }
    }
}
