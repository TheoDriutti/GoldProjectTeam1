using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float X;
    public float Y;
    public float time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<BallController>().Lose();
        }
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(time);
        var newObject = Instantiate(this, new Vector2(transform.position.x + X, transform.position.y + Y), Quaternion.identity);
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Cover"))
        {
            if (newObject.GetComponent<BoxCollider2D>().bounds.Intersects(obj.GetComponent<BoxCollider2D>().bounds))
            {
                Destroy(newObject);
                StopCoroutine(Move());
                break;
            }
        }
    }

}
