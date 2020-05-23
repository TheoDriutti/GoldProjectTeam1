using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherH : MonoBehaviour
{
    private bool LockOn = false;
    public GameObject Left;
    public GameObject Right;
    public float CrusherForce;
    private float timeBfrDie=.35f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( LockOn == true)
        {
            Right.GetComponent<Rigidbody2D>().AddForce(new Vector2(-CrusherForce, 0));
            Left.GetComponent<Rigidbody2D>().AddForce(new Vector2(CrusherForce, 0));
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
     
            if (collision.gameObject.tag == "Crusher")
            {
                Debug.Log("ok");
                CrusherForce /= 2;
                timeBfrDie = 10;
            }

        if (collision.gameObject.tag == "Ball")
        {
            LockOn = true;
            Destroy(collision.gameObject, timeBfrDie);

        }
    }

}
