using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxFallSpeed = 5f;

    [HideInInspector] public bool isBoosting = false;
    [HideInInspector] public float boostCD = 0f;
    [HideInInspector] public float boostCoeff;

    [HideInInspector] public bool isSlowing = false;
    [HideInInspector] public float slowCD = 0f;
    [HideInInspector] public float slowCoeff;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBoosting)
        {
            boostCD -= Time.deltaTime;
        }
        if (isSlowing)
        {
            slowCD -= Time.deltaTime;
        }
        UpdateBoost();
        UpdateSlow();

        if (Mathf.Abs(rb.velocity.y) > maxFallSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxFallSpeed;
        }
    }

    void UpdateBoost()
    {
        if (boostCD < 0f)
        {
            isBoosting = false;
            boostCD = 0f;
            maxFallSpeed /= boostCoeff;
        }
    }

    void UpdateSlow()
    {
        if (slowCD < 0f)
        {
            isSlowing = false;
            slowCD = 0f;
            maxFallSpeed /= slowCoeff;
        }
    }

}
