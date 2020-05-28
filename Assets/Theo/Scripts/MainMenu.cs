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

    public Button switchTo2;
    public Button switchTo1;

    public Sprite StLocked;
    public Sprite StFinish;
    public Sprite LvLocked;
    public Sprite LvUnLocked;
    public Sprite LvFinish;

    public AudioSource menuMusic;
    public AudioSource sourceSFX;

    List<GameObject> levelButton = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        FillBtnList();
        UpdateBtnDisplay();
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
                    levelButton[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                    levelButton[i].transform.GetChild(0).GetComponent<Image>().sprite = StFinish;
                    levelButton[i].GetComponent<Image>().sprite = LvFinish;
                    break;
            }
        }
    }

    public void UpdateMusicVolume(float value)
    {
        menuMusic.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void UpdateSFXVolume(float value)
    {
        sourceSFX.volume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    void FillBtnList()
    {
        foreach (Transform child in Levels1.transform)
        {
            levelButton.Add(child.gameObject);
        }
        foreach (Transform child in Levels2.transform)
        {
            levelButton.Add(child.gameObject);
        }
    }

    public void GoToLevels()
    {
        mainCanvas.SetActive(false);
        levelsCanvas.SetActive(true);
        Levels1.SetActive(true);
        Levels2.SetActive(false);
        switchTo1.gameObject.SetActive(false);
        switchTo2.gameObject.SetActive(true);
        UpdateBtnDisplay();
    }

    public void GoToLevels2()
    {
        Levels1.SetActive(false);
        Levels2.SetActive(true);
        switchTo1.gameObject.SetActive(true);
        switchTo2.gameObject.SetActive(false);
        UpdateBtnDisplay();
    }

    public void GoToMainMenu()
    {
        mainCanvas.SetActive(true);
        levelsCanvas.SetActive(false);
    }
}
