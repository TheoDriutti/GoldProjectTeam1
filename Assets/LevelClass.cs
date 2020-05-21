using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum State 
{
    Locked,
    Unlocked,
    Finished
}
public class LevelClass : MonoBehaviour
{
    public State LevelState;
    public string namescene;


    public void Ontouch() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(namescene);

    }

    public static LevelClass instance;
    private void Start()
    {
        instance = this;
    }

   
}


