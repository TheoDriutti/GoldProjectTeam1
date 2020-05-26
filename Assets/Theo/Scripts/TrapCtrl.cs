using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCtrl : MonoBehaviour
{
    Material mat;
    private void Start()
    {
        mat = gameObject.GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<BallController>().Lose();
        }
    }
}

    
