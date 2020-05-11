using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public Survive Surv;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Surv.Shelled = true;
        collision.GetComponent<SpriteRenderer>().color = new Color32(210, 180, 60, 255);
        this.gameObject.SetActive(false);
    }
}
