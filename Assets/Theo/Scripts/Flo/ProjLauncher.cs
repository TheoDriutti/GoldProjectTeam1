using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjLauncher : MonoBehaviour
{
    public GameObject proj;
    public float projRepTime;
    void Start()
    {
        StartCoroutine(RepeatProj());
    }

    IEnumerator RepeatProj()
    {
        yield return new WaitForSeconds(projRepTime);
        Instantiate(proj, transform.position, Quaternion.identity);
    }
}
