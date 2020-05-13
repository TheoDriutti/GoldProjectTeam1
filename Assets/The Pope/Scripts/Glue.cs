using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour
{
    public float TimeDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(DeathByGlue(collision.gameObject));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 1;
        StopCoroutine(DeathByGlue(collision.gameObject));
    }

    IEnumerator DeathByGlue(GameObject Collision)
    {
        yield return new WaitForSeconds(TimeDeath);
        Collision.SetActive(false);
    }
}
