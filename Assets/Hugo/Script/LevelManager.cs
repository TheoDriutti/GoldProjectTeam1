using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject Spawner;
    public float SpawnerX;
    public float spawnDistance;
    public List<GameObject> LevelList = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnerX = Spawner.transform.position.x;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLevel() 
    {
        //int rmdLevel = Random.Range(0, LevelList.Count);
        
        Instantiate(LevelList[0],new Vector2( SpawnerX, Spawner.transform.position.y), Quaternion.identity);
        
    
    }

   
}
