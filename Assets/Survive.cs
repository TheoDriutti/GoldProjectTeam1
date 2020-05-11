using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survive : MonoBehaviour
{
    public GameObject Player;

    public bool Shelled = false;

    private Vector2 Speed;

    // Update is called once per frame
    void Update()
    {
        Speed = Player.GetComponent<Rigidbody2D>().velocity;
        if (!Player.activeSelf && Shelled)
        {
            Player.SetActive(true);
            Player.GetComponent<Rigidbody2D>().velocity = Speed;
            Shelled = false;
            Player.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }
}
