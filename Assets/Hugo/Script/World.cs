using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject limit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator destroyWorld() 
    {
        yield return new WaitForSeconds(1);
        DestroyImmediate(gameObject);
      
    
    }
    


    public void Destroyer() 
    {
        StartCoroutine(destroyWorld());
    
    
    }
}
