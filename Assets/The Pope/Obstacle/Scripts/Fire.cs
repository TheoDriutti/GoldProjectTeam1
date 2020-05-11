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
        collision.gameObject.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(time);
        Instantiate(this, new Vector2(transform.position.x + X, transform.position.y + Y), Quaternion.identity);
    }

}
