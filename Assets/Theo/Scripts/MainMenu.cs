using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject mainCanvas;
    public GameObject levelsCanvas;

    public GameObject Levels1;
    public GameObject Levels2;

    public Sprite StLocked;
    public Sprite StFinish;
    public Sprite LvLocked;
    public Sprite LvUnLocked;
    public Sprite LvFinish;

    List<GameObject> levelButton = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        FillBtnList();

        UpdateBtnDisplay();
        //Debug.Log(PlayerPrefs.GetInt("LevelPassed"));

       var pp=PlayerPrefs.GetInt("LevelPassed");
        pp = 0;
        PlayerPrefs.SetInt("LevelPassed",pp);
    }

    void UpdateBtnDisplay()
    {
        for (int i = 0; i < levelButton.Count; i++)
        {
            switch (levelButton[i].GetComponent<LevelClass>().LevelState)
            {
                case State.Locked:
                    levelButton[i].transform.GetChild(0).GetComponent<Image>().sprite = StLocked;
                    levelButton[i].GetComponent<Image>().sprite = LvLocked;
                    break;

                case State.Unlocked:
                    levelButton[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                    levelButton[i].GetComponent<Image>().sprite = LvUnLocked;
                    break;

                case State.Finished:
                    levelButton[i].transform.GetChild(0).GetComponent<Image>().sprite = StFinish;
                    levelButton[i].GetComponent<Image>().sprite = LvFinish;
                    break;
            }
        }
    }

    void FillBtnList()
    {
        foreach (Transform child in Levels1.transform)
        {
            levelButton.Add(child.gameObject);
        }
        //foreach (Transform child in Levels2.transform)
        //{
        //    levelButton.Add(child.gameObject);
        //}
    }

    public void GoToLevels()
    {
        mainCanvas.SetActive(false);
        levelsCanvas.SetActive(true);
    }

    public void GoToMainMenu()
    {
        mainCanvas.SetActive(true);
        levelsCanvas.SetActive(false);
    }
}
