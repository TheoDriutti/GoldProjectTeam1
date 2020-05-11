using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(STARTIME());
    }
    IEnumerator STARTIME()
    {
        float X = Random.Range(0, 250);
        float Y = Random.Range(0, 250);
        float Z = Random.Range(0, 250);
        GetComponent<SpriteRenderer>().color = new Color32 ((byte)X, (byte)Y, (byte)Z,255);
        yield return new WaitForSeconds(0.12f);
        StartCoroutine(STARTIME());
    }
}
