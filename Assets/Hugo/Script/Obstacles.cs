﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private bool LockOn = false;

    public string nameId;
    public GameObject bullet;
    public float cooldownGun;
    public float baseCooldown;
    public int bulletStrength;
    public float FireX;
    public float FireY;
    public float Firetime;
    public float EnlargeTime;
    public float EnlargeForce;

    public float AccelForce;
    public float AccelTime;
    public float speedRotate;

    // Start is called before the first frame update
    void Start()
    {
        if (nameId == "Fire")
        {
            StartCoroutine(FireMove());
        }


        if (nameId == "Bullet")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletStrength, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nameId == "Slap")
        {
            transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
        }

        if (nameId == "Gun")
        {
            cooldownGun -= Time.deltaTime;
            if (cooldownGun < 0)
            {
                Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                cooldownGun = baseCooldown;
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (nameId == "Bullet")
        {

            if (collision.gameObject.tag == "Cover")
            {
                Debug.Log("cover");
                GetComponent<Rigidbody2D>().gravityScale = 1;
                Destroy(gameObject, 1.5f);
            }
            if (collision.gameObject.tag == "Ball")
            {
                Destroy(gameObject, 0.01f);
                collision.gameObject.GetComponent<BallController>().Lose();
            }
        }

    }

    IEnumerator FireMove()
    {
        yield return new WaitForSeconds(Firetime);
        Instantiate(this, new Vector2(transform.position.x + FireX, transform.position.y + FireY), Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (nameId == "Enlarge")
        {
            PlayerTestHugo.instance.Enlarging(EnlargeTime, EnlargeForce);
        }
        if (nameId == "Accelerator")
        {
            PlayerTestHugo.instance.Boost(AccelForce);
            PlayerTestHugo.instance.Boosting(AccelTime);

        }
    }
}
