using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{ public float ShrinkForce;
  public float ShrinkTime;
  public string nameId;
  
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (nameId == "Shrink")
        {
            PlayerTestHugo.instance.Shrinking(ShrinkTime, ShrinkForce);
        }
        if (nameId =="Zap")
        {
            if (collision.tag == "World" || collision.tag == "LimitWorld" || collision.tag == "Player")
            {
                
            }
            else
            {
                StartCoroutine(Zapping(collision.gameObject));
            }
            
        }
    }

    private IEnumerator Zapping(GameObject zapped) 
    {
        yield return new WaitForSeconds(0.0001f);
        zapped.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
