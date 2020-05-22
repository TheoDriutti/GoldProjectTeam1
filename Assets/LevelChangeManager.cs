using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChangeManager : MonoBehaviour
{
    public List<GameObject> levelButton = new List<GameObject>();
    public GameObject levellist;

    public Sprite StLocked;
    public Sprite StFinish;

    public Sprite LvLocked;
    public Sprite LvUnLocked;
    public Sprite LvFinish;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levellist.transform.childCount; i++)
        {
            levelButton.Add(levellist.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < levelButton.Count; i++)
        {
            switch (levelButton[i].GetComponent<LevelClass>().LevelState)
            {
                case State.Locked:
                    levelButton[i].transform.GetChild(0).GetComponent<Image>().sprite = StLocked;
                    levelButton[i].GetComponent<Image>().sprite = LvLocked;
                    break;


                case State.Unlocked:
                    levelButton[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                    levelButton[i].GetComponent<Image>().sprite = LvUnLocked;
                    break;

                case State.Finished:
                    levelButton[i].transform.GetChild(0).GetComponent<Image>().sprite = StFinish;
                    levelButton[i].GetComponent<Image>().sprite = LvFinish;
                    break;


            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
