using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerTheo : MonoBehaviour
{
    public int tailleLevel;
    public GameObject uniteDecor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DisplayLevel");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DisplayLevel()
    {
        for (int i = 1; i < tailleLevel; i++)
        {
            Instantiate(uniteDecor, new Vector3(0, -i * uniteDecor.GetComponent<Renderer>().bounds.size.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(.5f);
        }
    }
}
