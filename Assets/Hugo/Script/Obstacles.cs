using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public string nameId;
    public GameObject bullet;
    public float cooldown;
    public float baseCooldown;
    public int bulletStrength;
    // Start is called before the first frame update
    void Start()
    {
        if (nameId == "Bullet")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletStrength,0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (nameId == "Fire")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
        }
        if (nameId == "Gun")
        {
            if (cooldown < 0)
            {
                Instantiate(bullet,new Vector2(transform.position.x + 1,transform.position.y), Quaternion.identity);
                cooldown = baseCooldown;
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
}
