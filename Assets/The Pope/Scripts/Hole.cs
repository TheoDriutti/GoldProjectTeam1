using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = transform.position;
        collision.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0) ;
        collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(Suck(collision.gameObject));
    }

    IEnumerator Suck(GameObject target)
    {
        while(target.transform.localScale.x >= 0.1f)
        {
            target.transform.localScale *= 0.9f;
            yield return new WaitForSeconds(0.07f);
        }
        target.SetActive(false);
    }
}
