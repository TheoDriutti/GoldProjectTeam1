using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxFallSpeed;

    [HideInInspector] public bool isBoosting = false;
    [HideInInspector] public float boostCD = -1f;
    [HideInInspector] public float boostCoeff;
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
        UpdateBoost();

        Debug.Log(rb.velocity.y);

        if (Mathf.Abs(rb.velocity.y) > maxFallSpeed)
        {
            Debug.Log("coucou");
            rb.velocity = rb.velocity.normalized * maxFallSpeed;
        }
    }

    void UpdateBoost()
    {
        if (boostCD < 0f)
        {
            isBoosting = false;
            boostCD = 0;
            maxFallSpeed /= boostCoeff;
        }
    }
}
