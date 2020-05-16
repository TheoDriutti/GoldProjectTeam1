using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fire"))
        {
            col.GetComponent<Animator>().speed = 0; //STOP ANIM
        }

        if (col.gameObject.CompareTag("Proj"))
        {
            col.GetComponent<Projectile>().projSpeed = 0; //STOP ANIM
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fire"))
        {
            col.GetComponent<Animator>().speed = 1; //RELANCE ANIM
        }

        if (col.gameObject.CompareTag("Proj"))
        {
            col.GetComponent<Projectile>().projSpeed = 1; //RELANCE ANIM
        }
    }
}
