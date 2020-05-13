using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        if (nameId =="Fire")
        {
            StartCoroutine(FireMove());
        }
        

        if (nameId == "Bullet")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletStrength,0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldownGun -= Time.deltaTime;
        
        if (nameId == "Gun")
        {
            if (cooldownGun < 0)
            {
                Instantiate(bullet,new Vector2(transform.position.x + 1,transform.position.y), Quaternion.identity);
                cooldownGun = baseCooldown;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (nameId == "Bullet")
        {
            Destroy(gameObject, 0.01f);
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
