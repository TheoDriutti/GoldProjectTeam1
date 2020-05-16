using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Zap : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
