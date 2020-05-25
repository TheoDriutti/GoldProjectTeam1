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

    GameManager gameManager;
    bool hittingCrusherLeft = false;
    bool hittingCrusherRight = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplySpeedEffect();
        UpdateBoost();
        UpdateSlow();

        if (Mathf.Abs(rb.velocity.y) > maxFallSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxFallSpeed;
        }

        if (transform.position.y < -6)
        {
            gameManager.WinLevel();
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

    void ApplySpeedEffect()
    {
        if (isBoosting)
        {
            boostCD -= Time.deltaTime;
        }
        if (isSlowing)
        {
            slowCD -= Time.deltaTime;
        }
    }

    public void Lose(string str = "")
    {
        gameManager.Lose();
        if (str == "Crusher")
        {
            Destroy(gameObject, .35f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Left")
        {
            hittingCrusherLeft = true;
        }
        if (col.gameObject.tag == "Right")
        {
            hittingCrusherRight = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Left")
        {
            hittingCrusherLeft = false;
        }
        if (col.gameObject.tag == "Right")
        {
            hittingCrusherRight = false;
        }
    }

}
