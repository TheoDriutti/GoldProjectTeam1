using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float X;
    public float Y;
    public float time;

    float speed = .7f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<BallController>().Lose();
        }
    }

    private void Start()
    {
        //currentTime = time;
    }

    private void Update()
    {
        if (FindObjectsOfType<GameManager>()[0].gState == GameManager.GameState.GAME)
        {
            transform.position += new Vector3(speed * Time.deltaTime * Mathf.Abs(X) / X, 0, 0);
            transform.Rotate(new Vector3(0, 0, 1));

            if (Mathf.Abs(transform.position.x) > 3.5)
            {
                X = -X;
            }
        }
    }
    //IEnumerator Move()
    //{
    //yield return new WaitForSeconds(currentTime);
    //var newObject = Instantiate(this, new Vector2(transform.position.x + X, transform.position.y + Y), Quaternion.identity);

    //foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Cover"))
    //{
    //    if (newObject.GetComponent<Collider2D>().bounds.Intersects(obj.GetComponent<BoxCollider2D>().bounds))
    //    {
    //        Destroy(newObject);
    //        StopCoroutine(Move());
    //        break;
    //    }
    //}
    //foreach (Push obj in FindObjectsOfType<Push>())
    //{
    //    if (newObject.GetComponent<Collider2D>().bounds.Intersects(obj.GetComponent<BoxCollider2D>().bounds))
    //    {
    //        Destroy(newObject);
    //        StopCoroutine(Move());
    //        break;
    //    }
    //}
    //foreach (SlowCtrl obj in FindObjectsOfType<SlowCtrl>())
    //{
    //    currentTime = 2 * time;
    //}

    //}

}
