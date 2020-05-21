using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject objets;
    public Inventory inventory;

    public float dureeBulletTime;
    public float coeffBulletTime;

    List<GameObject> listeObjets;

    enum GameState { BULLETTIME, GAME };
    GameState gameState;

    float defaultTimeScale;
    float timeLancementBT;

    // Start is called before the first frame update
    void Start()
    {
        defaultTimeScale = Time.timeScale;
        LaunchBulletTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletTimeFinished())
        {
            gameState = GameState.GAME;
            Time.timeScale = defaultTimeScale;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    void LaunchBulletTime()
    {
        //timeLancementBT = Time.time;
        //gameState = GameState.BULLETTIME;
        //Time.timeScale = defaultTimeScale * coeffBulletTime;

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

    bool BulletTimeFinished()
    {
        return (Time.time / coeffBulletTime) > timeLancementBT + dureeBulletTime && gameState == GameState.BULLETTIME;
    }
}
