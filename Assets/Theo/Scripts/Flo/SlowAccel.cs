using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAccel : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fire"))
        {
            col.GetComponent<Animator>().speed = 1; //LA SPEED;
        }

        if (col.gameObject.CompareTag("Crusher"))
        {
            col.GetComponent<Animator>().speed = 1; //LA SPEED;
        }

        if (col.gameObject.CompareTag("Proj"))
        {
            col.GetComponent<Projectile>().projSpeed = 1; //LA SPEED;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fire"))
        {
            col.GetComponent<Animator>().speed = 1; //RESET LA SPEED;
        }

        if (col.gameObject.CompareTag("Crusher"))
        {
            col.GetComponent<Animator>().speed = 1; //RESET LA SPEED;
        }

        if (col.gameObject.CompareTag("Proj"))
        {
            col.GetComponent<Projectile>().projSpeed = 1; //RESET LA SPEED;
        }
    }
}
