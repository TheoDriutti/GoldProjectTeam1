using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public GameObject objets;
    public Inventory inventory;
    public GameObject endgameUI;
    public GameObject loseUI;

    int levelNumber;
    List<GameObject> listeObjets;

    // Start is called before the first frame update
    void Start()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        LaunchBulletTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
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

    public void Lose()
    {
        loseUI.SetActive(true);
    }

    public void WinLevel()
    {
        Time.timeScale = 0;
        if (levelNumber > PlayerPrefs.GetInt("LevelPassed"))
        {
            PlayerPrefs.SetInt("LevelPassed", levelNumber);
        }
        endgameUI.gameObject.SetActive(true);
    }

    public void GoNextLevel()
    {
        if (levelNumber < 23)
        {
            Debug.Log(levelNumber);
            SceneManager.LoadScene(levelNumber + 1);
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(levelNumber);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndPrep()
    {
        Time.timeScale = 1;
        inventory.gameObject.SetActive(false);
    }
}
