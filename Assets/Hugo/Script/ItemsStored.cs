﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsStored : MonoBehaviour
{
    
    public bool Isactivated = false;
    public bool Isactivating = false;
    public GameObject itemstored;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


        if (Isactivated == true && Input.GetMouseButtonDown(0) ) //Input.touchCount >= 1
        {
            //Touch touch = Input.GetTouch(0);
            //Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 instancePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(itemstored, instancePos ,Quaternion.identity );
            //Instantiate(itemstored, touchPos ,Quaternion.identity );
            itemstored = null;
            Isactivated = false;
            
        }
        
        if (Isactivating == true && Input.GetMouseButtonDown(0) ) //Input.touchCount >= 1
        {
                        
            
            //Touch touch = Input.GetTouch(0);
            //Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            // touchPos.z = 0;
            Vector3 instancePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            instancePos.z = 0;
           
            

            //Instantiate(itemstored, touchPos ,Quaternion.identity );
           
                Instantiate(itemstored, instancePos, Quaternion.identity);
                itemstored = null;
                Isactivated = false;
            
           
            
        }
    }

    public void onButtonTouch() 
    {
        StartCoroutine(activating());
    
    }

    IEnumerator activating() 
    {

        yield return new WaitForSeconds(0.2f);
        Isactivated = true;
    }
}
