using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject objets;
    public Inventory inventory;

    List<GameObject> listeObjets;

    //enum GameState { BULLETTIME, GAME };
    //GameState gameState;


    // Start is called before the first frame update
    void Start()
    {
        LaunchBulletTime();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LaunchBulletTime()
    {
        Time.timeScale = 0;

        listeObjets = new List<GameObject>();
        GetObjets();
        DonneItems();
    }

    void DonneItems()
    {
        foreach (GameObject gobj in listeObjets)
        {
            inventory.AddItem(gobj.GetComponent<IInventoryItem>());
        }
    }

    void GetObjets()
    {
        for (int i = 0; i < objets.transform.childCount; i++)
        {
            Transform child = objets.transform.GetChild(i);
            listeObjets.Add(child.gameObject);
        }
    }

    //bool BulletTimeFinished()
    //{
    //    return Time.time > timeLancementBT + dureeBulletTime && gameState == GameState.BULLETTIME;
    //    //return (Time.time / coeffBulletTime) > timeLancementBT + dureeBulletTime && gameState == GameState.BULLETTIME;
    //}

    public void EndPrep()
    {
        Time.timeScale = 1;
        inventory.gameObject.SetActive(false);
    }
}
