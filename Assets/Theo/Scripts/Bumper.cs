using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : InventoryItemBase
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            
            gameObject.GetComponent<Animation>().Play();
            FindObjectOfType<AudioManager>().Bounce();

        }


    }

    public override string Name
    {
        get { return "Bumper"; }
    }
}