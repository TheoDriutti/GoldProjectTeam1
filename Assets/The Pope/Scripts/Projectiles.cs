using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float BetweenTime;
    public GameObject FiredObject;
    public float X_Speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            collision.gameObject.SetActive(false);
        }
        
    }

    IEnumerator Fire()
    {
        GameObject Z;
        yield return new WaitForSeconds(BetweenTime);
        Z = Instantiate(FiredObject, transform);
        Z.GetComponent<Rigidbody2D>().AddForce(new Vector2(X_Speed, 0));
        StartCoroutine(Fire());
    }
}
