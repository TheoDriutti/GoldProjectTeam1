using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject mainCanvas;
    public GameObject levelsCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
