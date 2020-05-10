using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestHugo : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float maxVelocity;
    public float sqrMaxVelocity;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        SetMaxVelocity(maxVelocity);
    }
    void SetMaxVelocity(float maxVelocity  )
    {
        this.maxVelocity = maxVelocity;
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }
    void Start()
    {
        
    }




    private void FixedUpdate()
    {
        if (rb.velocity.sqrMagnitude > sqrMaxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
        
    }
        // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LimitWorld")
        {
            
            LevelManager.instance.SpawnLevel();
            StartCoroutine(destroyLimit(collision.gameObject));
        }
    }

    private IEnumerator destroyLimit(GameObject limit) 
    {

        yield return new WaitForSeconds(0.1f);
        limit.SetActive(false);
      
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "World")
        {
            collision.gameObject.GetComponent<World>().Destroyer();
        }
    }
}
