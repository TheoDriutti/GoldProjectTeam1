using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public float BetweenTime;
    public GameObject FireObject;
    public float DuringTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(BetweenTime);
        FireObject.SetActive(true);
        yield return new WaitForSeconds(DuringTime);
        FireObject.SetActive(false);
        StartCoroutine(Fire());
    }

}
