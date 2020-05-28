﻿using System.Collections;
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
    public GameObject pauseMenu;
    public GameObject btnPause;

    public Slider sliderMusic;
    public Slider sliderSFX;

    int levelNumber;
    List<GameObject> listeObjets;
    AudioSource music;
    AudioSource sfx;

    public enum GameState { PREP, GAME };
    [HideInInspector] public GameState gState;

    // Start is called before the first frame update
    void Start()
    {
        //music = GameObject.Find("Music").GetComponent<AudioSource>();
        //sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume");

        //sfx = GameObject.Find("SFX").GetComponent<AudioSource>();
        //sliderSFX.value = PlayerPrefs.GetFloat("SFXVolume");

        levelNumber = SceneManager.GetActiveScene().buildIndex;
        LaunchBulletTime();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LaunchBulletTime()
    {
        Time.timeScale = 0;
        gState = GameState.PREP;
        listeObjets = new List<GameObject>();
        GetObjets();
        DonneItems();
    }

    void DonneItems()
    {
        foreach (GameObject gobj in listeObjets)
        {
            inventory.AddItem(gobj.GetComponent<IInventoryItem>(), gobj.transform.rotation.eulerAngles.z, levelNumber < 13);
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
        gState = GameState.GAME;
        inventory.gameObject.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        btnPause.SetActive(false);
    }

    public void Resume()
    {
        if (gState == GameState.GAME)
        {
            Time.timeScale = 1;
        }
        pauseMenu.SetActive(false);
        btnPause.SetActive(true);
    }

    public void UpdateMusicVolume(float value)
    {
        //music.volume = value;
        //PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void UpdateSFXVolume(float value)
    {
        //sfx.volume = value;
        //PlayerPrefs.SetFloat("SFXVolume", value);
    }
}
