using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragile : MonoBehaviour
{
    public float HitPoints;
    public float TimeForHit;
    public bool Contact = false;
    private bool CountdownStart = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            StartCoroutine(HitPoint());
        }
        
    }

    IEnumerator HitPoint()
    {
        yield return new WaitForSeconds(TimeForHit);
        HitPoints -= 1;
        if(HitPoints == 0)
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
