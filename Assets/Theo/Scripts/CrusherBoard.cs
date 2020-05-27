using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherBoard : MonoBehaviour
{
    public string LeftOrRight;
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
        if (LeftOrRight == "Right")
        {
            if (collision.gameObject.tag == "Left")
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            }
        }
        if (LeftOrRight == "Left")
        {
            if (collision.gameObject.tag == "Right")
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
}
