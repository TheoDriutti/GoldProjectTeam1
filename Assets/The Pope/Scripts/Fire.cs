using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float X;
    public float Y;
    public float time;

    float currentTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<BallController>().Lose();
        }
        else
        {
            if (collision.GetComponent<Push>() != null)
            {
                StopCoroutine(Move());
            }
            if (collision.GetComponent<SlowCtrl>() != null)
            {
                currentTime = 2 * time;
            }
        }
    }

    private void Start()
    {
        currentTime = time;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(currentTime);
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
