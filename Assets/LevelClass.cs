using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Locked,
    Unlocked,
    Finished
}
public class LevelClass : MonoBehaviour
{
    public State LevelState;
    public int namescene;


    public void Ontouch()
    {
        if (LevelState != State.Locked)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(namescene);
        }
    }

    public static LevelClass instance;
    private void Awake()
    {
        instance = this;

        if (namescene <= PlayerPrefs.GetInt("LevelPassed"))
        {
            LevelState = State.Finished;
        }
        else if (namescene == PlayerPrefs.GetInt("LevelPassed") + 1)
        {
            LevelState = State.Unlocked;
        }
        else
        {
            LevelState = State.Locked;
        }
    }


}


