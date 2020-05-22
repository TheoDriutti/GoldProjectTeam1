﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCtrl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<BallController>().Lose();
        }
    }
}
