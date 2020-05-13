using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestHugo : MonoBehaviour
{
    public float SlowDownForce;
    public bool Boosted = false;
    public bool Slowing = false;
    public float speed;
    public Rigidbody2D rb;
    public float maxVelocity;
    public float sqrMaxVelocity;
    public static PlayerTestHugo instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
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
            if (Boosted)
            {

            }
            else 
            {
                Slowing = true;


            }
            
        }
        else
        {
            Slowing = false;
        }
        
    }
        // Update is called once per frame
    void Update()
    {
        if (Slowing)
        {
            rb.velocity *= SlowDownForce / 100;
        }
        
    }

    public void Boosting(float Time) 
    {
        StartCoroutine(Booster(Time));
    }
    public void Boost(float AccelForce) 
    {
        rb.AddForce(new Vector2(0, -AccelForce));

    }
    IEnumerator Booster(float Time) 
    {
        Boosted = true;
        yield return new WaitForSeconds(Time);
        Boosted = false;
    
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Dammage")
        {
            //gameover
        }
    }

   

    

    
     
    public void Shrinking(float shrinkT, float shrinkF) 
    {
        StartCoroutine(ShrinkingPhase(shrinkT, shrinkF));
     
    }
    
   public IEnumerator ShrinkingPhase(float shrinkTime, float shrinkForce ) 
   {
        
      gameObject.transform.localScale = new Vector3( shrinkForce,shrinkForce,0);
      yield return new WaitForSeconds(shrinkTime);
        gameObject.transform.localScale = new Vector3(1 ,1, 0);
   }
    public void Enlarging(float EnlargeT, float EnlargeF) 
    {
        StartCoroutine(EnlargingPhase(EnlargeT, EnlargeF));
     
    }
    
   public IEnumerator EnlargingPhase(float EnlargeTime, float EnlargeForce) 
   {
        
      gameObject.transform.localScale = new Vector3(EnlargeForce, EnlargeForce, 0);
      yield return new WaitForSeconds(EnlargeTime);
        gameObject.transform.localScale = new Vector3(1 ,1, 0);
   }
}
